using CodeBase;
using Microsoft.Win32;
using OpenDental.UI;
using OpenDentBusiness;
using OpenDentBusiness.Mobile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using System.Data;
using System.Linq;
using System.IO;
using WebServiceSerializer;
using OpenDentBusiness.WebServiceMainHQ;
using OpenDentBusiness.WebTypes.WebSched.TimeSlot;

namespace OpenDental {
	///<summary>Form manages all eServices setup.  Also includes monitoring for the Listener Service that is required for HQ hosted eServices.</summary>
	public partial class FormEServicesSetup:ODForm {
		///<summary>Output from HQ initialized in FillForm().</summary>
		WebServiceMainHQProxy.EServiceSetup.SignupOut _signupOut;
		private const int CP_NOCLOSE_BUTTON = 0x200;
		private bool _doSetInvalidClinicPrefs=false;
		
		///<summary>Launches the eServices Setup window defaulted to the tab of the eService passed in.</summary>
		public FormEServicesSetup(EService setTab=EService.SignupPortal) {
			InitializeComponent();
			Lan.F(this);
			switch(setTab) {
				case EService.ListenerService:
					tabControl.SelectTab(tabEConnector);
					break;
				case EService.MobileOld:
					tabControl.SelectTab(tabMobileSynch);
					break;
				case EService.MobileNew:
					tabControl.SelectTab(tabMobileWeb);
					break;
				case EService.WebSched:
					tabControl.SelectTab(tabWebSched);
					break;
				case EService.SmsService:
					tabControl.SelectTab(tabTexting);
					break;
				case EService.eConfirmRemind:
					tabControl.SelectTab(tabECR);
					break;
				case EService.eMisc:
					tabControl.SelectTab(tabMisc);
					break;
				case EService.PatientPortal:
					tabControl.SelectTab(tabPatientPortal);
					break;
				case EService.WebSchedNewPat:
					tabControl.SelectTab(tabWebSched);
					tabControlWebSched.SelectTab(tabWebSchedNewPatAppts);
					break;
				case EService.EClipboard:
					tabControl.SelectTab(tabEClipboard);
					break;
				case EService.SignupPortal:
				default:
					tabControl.SelectTab(tabSignup);
					break;
			}
		}

		/// <summary>When the user is trying to send a text message, if sending the text would exceed the users spending limit, this handles that error.
		/// If the user has permission to increase the spending limit, open a new FormEservicesSetup to allow them to increase their spending limit,
		/// otherwise warn them that they do not have permission. Returns true if the error passed in matches the spending limit error, false otherwise. </summary>
		public static bool ProcessSendSmsException(Exception ex) {
			if((ex is ODException) && ((ODException)ex).ErrorCode==1) {
				if(MsgBox.Show(typeof(FormEServicesSetup),MsgBoxButtons.YesNo,ex.Message+" Do you want to increase this spending limit?")) {
					if(Security.IsAuthorized(Permissions.EServicesSetup)) {
						FormEServicesSetup formEservice=new FormEServicesSetup();
						formEservice.Show();
					}
				}
				return true;
			}
			return false;
		}

		private void FormEServicesSetup_Load(object sender,EventArgs e) {
			FillForm();
		}

		///<summary>Makes a web call to WebServiceMainHQ to get the corresponding EServiceSetupFull information and then attempts to fill each tab.
		///If anything goes wrong within this method a message box will show to the user and then the window will auto close via Abort.</summary>
		private void FillForm() {
			Action actionCloseProgress=ODProgress.Show(ODEventType.EServices,typeof(EServicesEvent),"Validating eServices...");
			try {
				if(!ODBuild.IsWeb() && MiscUtils.TryUpdateIeEmulation()) {
					throw new Exception("Browser emulation version updated.\r\nYou must restart this application before accessing the Signup Portal.");
				}
				//Send light version of clinics to HQ to be used by signup portal below. Get back all args needed from HQ in order to perform the operations of this window.
				SignupPortalPermission perm=GetUserSignupPortalPermissions();
				SecurityLogs.MakeLogEntry(Permissions.Setup,0,$"User {Security.CurUser.UserName} entered EService Setup with SignupPortalPermission {perm}");
				if(_signupOut==null) { //the first time this loads _signupOut will be null, so we won't have a previous state to compare
					_signupOut=WebServiceMainHQProxy.GetEServiceSetupFull(perm);
				}
				else { //If we are switching from the signup tab to another this will get called again and we don't want to lose the "diff"
					_signupOut=WebServiceMainHQProxy.GetEServiceSetupFull(perm,oldSignupOut:_signupOut);
				}
				//Show user any prompts that were generated by GetEServiceSetupFull().
				if(_signupOut.Prompts.Count>0) {
					MessageBox.Show(string.Join("\r\n",_signupOut.Prompts.Select(x => Lans.g(this,x))));
				}
				if(ODBuild.IsWeb()) {
					bool isSignupSelected=tabControl.SelectedTab==tabSignup;
					tabControl.TabPages.Remove(tabSignup);
					if(isSignupSelected) {
						actionCloseProgress?.Invoke();
						this.ForceBringToFront();
						Process.Start(_signupOut.SignupPortalUrl);
						DialogResult=DialogResult.Abort;
						return;
					}
				}
				#region Fill
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Signup"));
				FillTabSignup();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - eConnector Service"));
				FillTabEConnector();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Mobile Synch (old-style)"));
				FillTabMobileSynch();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Mobile Web"));
				FillTabMobileWeb();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Patient Portal"));
				FillTabPatientPortal();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Web Sched Recall"));
				FillTabWebSchedRecall();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Web Sched New Pat Appt"));
				FillTabWebSchedNewPat();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Web Sched Verify"));
				FillTabWebSchedVerify();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Texting Services"));
				FillTabTexting();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - eReminders & eConfirmations"));
				FillTabECR();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - eClipboard"));
				FillTabEClipboard();
				EServicesEvent.Fire(ODEventType.EServices,Lan.g(this,"Loading tab - Miscellaneous"));
				FillTabMisc();
				#endregion
				#region Authorize editing
				//Disable certain buttons but let them continue to view.
				bool allowEdit=Security.IsAuthorized(Permissions.EServicesSetup,true);
				AuthorizeTabSignup(allowEdit);
				AuthorizeTabEConnector(allowEdit);
				AuthorizeTabMobileSynch(allowEdit);
				AuthorizeTabPatientPortal(allowEdit);
				AuthorizeTabWebSchedRecall(allowEdit);
				AuthorizeTabWebSchedNewPat(allowEdit);
				AuthorizeTabTexting(allowEdit);
				AuthorizeTabECR(allowEdit);
				AuthorizeTabEClipboard(allowEdit);
				AuthorizeTabMisc(allowEdit);
				((Control)tabMobileSynch).Enabled=allowEdit;
				#endregion
			}
			catch(WebException we) {
				actionCloseProgress?.Invoke();
				this.ForceBringToFront();
				FriendlyException.Show(Lan.g(this,"Could not reach HQ.  Please make sure you have an internet connection and try again or call support."),we);
				//Set the dialog result to Abort so that FormClosing knows to not try and save any changes.
				DialogResult=DialogResult.Abort;
				Close();
			}
			catch(Exception e) {
				actionCloseProgress?.Invoke();
				this.ForceBringToFront();
				FriendlyException.Show(Lan.g(this,"There was a problem loading the eServices Setup window.  Please try again or call support."),e);
				//Set the dialog result to Abort so that FormClosing knows to not try and save any changes.
				DialogResult=DialogResult.Abort;
				Close();
			}
			actionCloseProgress?.Invoke();
			this.ForceBringToFront();
		}

		///<summary>Validate form inputs and display any required messages to user. Returns true if all info valid.</summary>
		private bool IsFormValid() {
			if(
				!IsTabValidSignup() ||
				!IsTabValidEConnector()||
				!IsTabValidMobileSynch()||
				!IsTabValidMobileWeb()||
				!IsTabValidPatientPortal()||
				!IsTabValidWebSchedRecall()||
				!IsTabValidWebSchedNewPat()||
				!IsTabValidWebSchedVerify()||
				!IsTabValidTexting()||
				!IsTabValidECR()||
				!IsTabValidEClipboard() ||
				!IsTabValidMisc()) 
			{
				return false;
			}
			return true;
		}

		private bool SaveForm() {
			if(!IsFormValid()) {
				return false;
			}
			SaveTabSignup();
			SaveTabEConnector();
			SaveTabMobileSynch();
			SaveTabMobileWeb();
			SaveTabPatientPortal();
			SaveTabWebSchedRecall();
			SaveTabWebSchedNewPat();
			SaveTabWebSchedVerify();
			SaveTabTexting();
			SaveTabECR();
			SaveTabEClipboard();
			SaveTabMisc();
			DataValid.SetInvalid(InvalidType.Prefs);
			DataValid.SetInvalid(InvalidType.Providers);//Providers includes clinics.
			if(_doSetInvalidClinicPrefs) {
				DataValid.SetInvalid(InvalidType.ClinicPrefs);
			}
			return true;
		}

		private SignupPortalPermission GetUserSignupPortalPermissions() {
			SignupPortalPermission perm=SignupPortalPermission.ReadOnly;
			if(Security.IsAuthorized(Permissions.SecurityAdmin,true)) {
				perm=SignupPortalPermission.FullPermission;
			}
			else if(Security.IsAuthorized(Permissions.EServicesSetup,true)) {
				perm=SignupPortalPermission.ReadOnly;
			}
			else {
				perm=SignupPortalPermission.Denied;
			}
			return perm;
		}

		private void butClose_Click(object sender,EventArgs e) {
			Close();
		}

		private void FormEServicesSetup_FormClosing(object sender,FormClosingEventArgs e) {
			if(DialogResult==DialogResult.Abort || !Security.IsAuthorized(Permissions.EServicesSetup,true)) {
				return;
			}
			//Anything they could have modified should have been disabled on load anyways.
			if(!SaveForm()) { //Something failed. Ask the user if they are ok with exiting and not saving.
				if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Validation failed and no changes were saved. Would you like to close without saving?")) {
					//User wants to keep the form open.
					e.Cancel=true;
				}
			}
			//Call this a second time so we can log if any important changes were made to this form.
			//_signupOut gets filled on load and should not be null at this point
			Action actionCloseProgress=ODProgress.Show(ODEventType.EServices,typeof(EServicesEvent),"Saving eServices...");
			WebServiceMainHQProxy.GetEServiceSetupFull(GetUserSignupPortalPermissions(),oldSignupOut:_signupOut);
			actionCloseProgress?.Invoke();
		}

		private void tabControl_Deselecting(object sender,TabControlCancelEventArgs e) {
			bool isTabValid=false;
			bool doFillForm=false;
			if(e.TabPage==tabSignup) {
				isTabValid=IsTabValidSignup();
				if(isTabValid) { //Signup portal may have some changes so refill the entire form. This is chatty but it has to be this way.
					doFillForm=true;
				}
			}
			else if(e.TabPage==tabEConnector) {
				isTabValid=IsTabValidEConnector();
			}
			else if(e.TabPage==tabMobileSynch) {
				isTabValid=IsTabValidMobileSynch();
			}
			else if(e.TabPage==tabMobileWeb) {
				isTabValid=IsTabValidMobileWeb();
			}
			else if(e.TabPage==tabPatientPortal) {
				isTabValid=IsTabValidPatientPortal();
			}
			else if(e.TabPage==tabWebSched) {
				isTabValid=IsTabValidWebSchedRecall()&&IsTabValidWebSchedNewPat();
			}
			else if(e.TabPage==tabTexting) {
				isTabValid=IsTabValidTexting();
			}
			else if(e.TabPage==tabECR) {
				isTabValid=IsTabValidECR();
			}
			else if(e.TabPage==tabEClipboard) {
				isTabValid=IsTabValidEClipboard();
			}
			else if(e.TabPage==tabMisc) {
				isTabValid=IsTabValidMisc();
			}
			else if(e.TabPage==null) {
				//The selected tab was removed, we don't want to cancel this event.
				isTabValid=true;
			}
			else {
				throw new Exception("New eService TabPage validation has not been implemented for: "+e.TabPage.Text);
			}
			e.Cancel=!isTabValid;
			if(doFillForm) {
				FillForm();
			}
		}

		protected override CreateParams CreateParams {
			get {
			   CreateParams cp=base.CreateParams;
			   cp.ClassStyle=cp.ClassStyle | CP_NOCLOSE_BUTTON;
			   return cp;
			}
		}
		
		///<summary>Typically used in ctor determine which tab should be activated be default.</summary>
		public enum EService {
			PatientPortal,
			MobileOld,
			MobileNew,
			///<summary>Opens to the Recall tab.</summary>
			WebSched,
			ListenerService,
			SmsService,
			eConfirmRemind,
			eMisc,
			SignupPortal,
			WebSchedNewPat,
			EClipboard,
		}



	}
}