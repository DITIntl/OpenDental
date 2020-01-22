//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class WebSchedRecallCrud {
		///<summary>Gets one WebSchedRecall object from the database using the primary key.  Returns null if not found.</summary>
		public static WebSchedRecall SelectOne(long webSchedRecallNum) {
			string command="SELECT * FROM webschedrecall "
				+"WHERE WebSchedRecallNum = "+POut.Long(webSchedRecallNum);
			List<WebSchedRecall> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WebSchedRecall object from the database using a query.</summary>
		public static WebSchedRecall SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebSchedRecall> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WebSchedRecall objects from the database using a query.</summary>
		public static List<WebSchedRecall> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebSchedRecall> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WebSchedRecall> TableToList(DataTable table) {
			List<WebSchedRecall> retVal=new List<WebSchedRecall>();
			WebSchedRecall webSchedRecall;
			foreach(DataRow row in table.Rows) {
				webSchedRecall=new WebSchedRecall();
				webSchedRecall.WebSchedRecallNum      = PIn.Long  (row["WebSchedRecallNum"].ToString());
				webSchedRecall.ClinicNum              = PIn.Long  (row["ClinicNum"].ToString());
				webSchedRecall.PatNum                 = PIn.Long  (row["PatNum"].ToString());
				webSchedRecall.RecallNum              = PIn.Long  (row["RecallNum"].ToString());
				webSchedRecall.DateTimeEntry          = PIn.DateT (row["DateTimeEntry"].ToString());
				webSchedRecall.DateDue                = PIn.Date  (row["DateDue"].ToString());
				webSchedRecall.ReminderCount          = PIn.Int   (row["ReminderCount"].ToString());
				webSchedRecall.PreferRecallMethod     = (OpenDentBusiness.ContactMethod)PIn.Int(row["PreferRecallMethod"].ToString());
				webSchedRecall.DateTimeReminderSent   = PIn.DateT (row["DateTimeReminderSent"].ToString());
				webSchedRecall.DateTimeSendFailed     = PIn.DateT (row["DateTimeSendFailed"].ToString());
				webSchedRecall.EmailSendStatus        = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["EmailSendStatus"].ToString());
				webSchedRecall.SmsSendStatus          = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["SmsSendStatus"].ToString());
				webSchedRecall.PhonePat               = PIn.String(row["PhonePat"].ToString());
				webSchedRecall.EmailPat               = PIn.String(row["EmailPat"].ToString());
				webSchedRecall.MsgTextToMobileTemplate= PIn.String(row["MsgTextToMobileTemplate"].ToString());
				webSchedRecall.MsgTextToMobile        = PIn.String(row["MsgTextToMobile"].ToString());
				webSchedRecall.EmailSubjTemplate      = PIn.String(row["EmailSubjTemplate"].ToString());
				webSchedRecall.EmailSubj              = PIn.String(row["EmailSubj"].ToString());
				webSchedRecall.EmailTextTemplate      = PIn.String(row["EmailTextTemplate"].ToString());
				webSchedRecall.EmailText              = PIn.String(row["EmailText"].ToString());
				webSchedRecall.GuidMessageToMobile    = PIn.String(row["GuidMessageToMobile"].ToString());
				webSchedRecall.ShortGUIDSms           = PIn.String(row["ShortGUIDSms"].ToString());
				webSchedRecall.ShortGUIDEmail         = PIn.String(row["ShortGUIDEmail"].ToString());
				webSchedRecall.ResponseDescript       = PIn.String(row["ResponseDescript"].ToString());
				webSchedRecall.Source                 = (OpenDentBusiness.WebSchedRecallSource)PIn.Int(row["Source"].ToString());
				retVal.Add(webSchedRecall);
			}
			return retVal;
		}

		///<summary>Converts a list of WebSchedRecall into a DataTable.</summary>
		public static DataTable ListToTable(List<WebSchedRecall> listWebSchedRecalls,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="WebSchedRecall";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("WebSchedRecallNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("RecallNum");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("DateDue");
			table.Columns.Add("ReminderCount");
			table.Columns.Add("PreferRecallMethod");
			table.Columns.Add("DateTimeReminderSent");
			table.Columns.Add("DateTimeSendFailed");
			table.Columns.Add("EmailSendStatus");
			table.Columns.Add("SmsSendStatus");
			table.Columns.Add("PhonePat");
			table.Columns.Add("EmailPat");
			table.Columns.Add("MsgTextToMobileTemplate");
			table.Columns.Add("MsgTextToMobile");
			table.Columns.Add("EmailSubjTemplate");
			table.Columns.Add("EmailSubj");
			table.Columns.Add("EmailTextTemplate");
			table.Columns.Add("EmailText");
			table.Columns.Add("GuidMessageToMobile");
			table.Columns.Add("ShortGUIDSms");
			table.Columns.Add("ShortGUIDEmail");
			table.Columns.Add("ResponseDescript");
			table.Columns.Add("Source");
			foreach(WebSchedRecall webSchedRecall in listWebSchedRecalls) {
				table.Rows.Add(new object[] {
					POut.Long  (webSchedRecall.WebSchedRecallNum),
					POut.Long  (webSchedRecall.ClinicNum),
					POut.Long  (webSchedRecall.PatNum),
					POut.Long  (webSchedRecall.RecallNum),
					POut.DateT (webSchedRecall.DateTimeEntry,false),
					POut.DateT (webSchedRecall.DateDue,false),
					POut.Int   (webSchedRecall.ReminderCount),
					POut.Int   ((int)webSchedRecall.PreferRecallMethod),
					POut.DateT (webSchedRecall.DateTimeReminderSent,false),
					POut.DateT (webSchedRecall.DateTimeSendFailed,false),
					POut.Int   ((int)webSchedRecall.EmailSendStatus),
					POut.Int   ((int)webSchedRecall.SmsSendStatus),
					            webSchedRecall.PhonePat,
					            webSchedRecall.EmailPat,
					            webSchedRecall.MsgTextToMobileTemplate,
					            webSchedRecall.MsgTextToMobile,
					            webSchedRecall.EmailSubjTemplate,
					            webSchedRecall.EmailSubj,
					            webSchedRecall.EmailTextTemplate,
					            webSchedRecall.EmailText,
					            webSchedRecall.GuidMessageToMobile,
					            webSchedRecall.ShortGUIDSms,
					            webSchedRecall.ShortGUIDEmail,
					            webSchedRecall.ResponseDescript,
					POut.Int   ((int)webSchedRecall.Source),
				});
			}
			return table;
		}

		///<summary>Inserts one WebSchedRecall into the database.  Returns the new priKey.</summary>
		public static long Insert(WebSchedRecall webSchedRecall) {
			return Insert(webSchedRecall,false);
		}

		///<summary>Inserts one WebSchedRecall into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WebSchedRecall webSchedRecall,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				webSchedRecall.WebSchedRecallNum=ReplicationServers.GetKey("webschedrecall","WebSchedRecallNum");
			}
			string command="INSERT INTO webschedrecall (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="WebSchedRecallNum,";
			}
			command+="ClinicNum,PatNum,RecallNum,DateTimeEntry,DateDue,ReminderCount,PreferRecallMethod,DateTimeReminderSent,DateTimeSendFailed,EmailSendStatus,SmsSendStatus,PhonePat,EmailPat,MsgTextToMobileTemplate,MsgTextToMobile,EmailSubjTemplate,EmailSubj,EmailTextTemplate,EmailText,GuidMessageToMobile,ShortGUIDSms,ShortGUIDEmail,ResponseDescript,Source) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(webSchedRecall.WebSchedRecallNum)+",";
			}
			command+=
				     POut.Long  (webSchedRecall.ClinicNum)+","
				+    POut.Long  (webSchedRecall.PatNum)+","
				+    POut.Long  (webSchedRecall.RecallNum)+","
				+    DbHelper.Now()+","
				+    POut.Date  (webSchedRecall.DateDue)+","
				+    POut.Int   (webSchedRecall.ReminderCount)+","
				+    POut.Int   ((int)webSchedRecall.PreferRecallMethod)+","
				+    POut.DateT (webSchedRecall.DateTimeReminderSent)+","
				+    POut.DateT (webSchedRecall.DateTimeSendFailed)+","
				+    POut.Int   ((int)webSchedRecall.EmailSendStatus)+","
				+    POut.Int   ((int)webSchedRecall.SmsSendStatus)+","
				+"'"+POut.String(webSchedRecall.PhonePat)+"',"
				+"'"+POut.String(webSchedRecall.EmailPat)+"',"
				+    DbHelper.ParamChar+"paramMsgTextToMobileTemplate,"
				+    DbHelper.ParamChar+"paramMsgTextToMobile,"
				+    DbHelper.ParamChar+"paramEmailSubjTemplate,"
				+    DbHelper.ParamChar+"paramEmailSubj,"
				+    DbHelper.ParamChar+"paramEmailTextTemplate,"
				+    DbHelper.ParamChar+"paramEmailText,"
				+    DbHelper.ParamChar+"paramGuidMessageToMobile,"
				+"'"+POut.String(webSchedRecall.ShortGUIDSms)+"',"
				+"'"+POut.String(webSchedRecall.ShortGUIDEmail)+"',"
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    POut.Int   ((int)webSchedRecall.Source)+")";
			if(webSchedRecall.MsgTextToMobileTemplate==null) {
				webSchedRecall.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobileTemplate));
			if(webSchedRecall.MsgTextToMobile==null) {
				webSchedRecall.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobile));
			if(webSchedRecall.EmailSubjTemplate==null) {
				webSchedRecall.EmailSubjTemplate="";
			}
			OdSqlParameter paramEmailSubjTemplate=new OdSqlParameter("paramEmailSubjTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubjTemplate));
			if(webSchedRecall.EmailSubj==null) {
				webSchedRecall.EmailSubj="";
			}
			OdSqlParameter paramEmailSubj=new OdSqlParameter("paramEmailSubj",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubj));
			if(webSchedRecall.EmailTextTemplate==null) {
				webSchedRecall.EmailTextTemplate="";
			}
			OdSqlParameter paramEmailTextTemplate=new OdSqlParameter("paramEmailTextTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailTextTemplate));
			if(webSchedRecall.EmailText==null) {
				webSchedRecall.EmailText="";
			}
			OdSqlParameter paramEmailText=new OdSqlParameter("paramEmailText",OdDbType.Text,POut.StringParam(webSchedRecall.EmailText));
			if(webSchedRecall.GuidMessageToMobile==null) {
				webSchedRecall.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.GuidMessageToMobile));
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText,paramGuidMessageToMobile,paramResponseDescript);
			}
			else {
				webSchedRecall.WebSchedRecallNum=Db.NonQ(command,true,"WebSchedRecallNum","webSchedRecall",paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText,paramGuidMessageToMobile,paramResponseDescript);
			}
			return webSchedRecall.WebSchedRecallNum;
		}

		///<summary>Inserts one WebSchedRecall into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebSchedRecall webSchedRecall) {
			return InsertNoCache(webSchedRecall,false);
		}

		///<summary>Inserts one WebSchedRecall into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebSchedRecall webSchedRecall,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO webschedrecall (";
			if(!useExistingPK && isRandomKeys) {
				webSchedRecall.WebSchedRecallNum=ReplicationServers.GetKeyNoCache("webschedrecall","WebSchedRecallNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="WebSchedRecallNum,";
			}
			command+="ClinicNum,PatNum,RecallNum,DateTimeEntry,DateDue,ReminderCount,PreferRecallMethod,DateTimeReminderSent,DateTimeSendFailed,EmailSendStatus,SmsSendStatus,PhonePat,EmailPat,MsgTextToMobileTemplate,MsgTextToMobile,EmailSubjTemplate,EmailSubj,EmailTextTemplate,EmailText,GuidMessageToMobile,ShortGUIDSms,ShortGUIDEmail,ResponseDescript,Source) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(webSchedRecall.WebSchedRecallNum)+",";
			}
			command+=
				     POut.Long  (webSchedRecall.ClinicNum)+","
				+    POut.Long  (webSchedRecall.PatNum)+","
				+    POut.Long  (webSchedRecall.RecallNum)+","
				+    DbHelper.Now()+","
				+    POut.Date  (webSchedRecall.DateDue)+","
				+    POut.Int   (webSchedRecall.ReminderCount)+","
				+    POut.Int   ((int)webSchedRecall.PreferRecallMethod)+","
				+    POut.DateT (webSchedRecall.DateTimeReminderSent)+","
				+    POut.DateT (webSchedRecall.DateTimeSendFailed)+","
				+    POut.Int   ((int)webSchedRecall.EmailSendStatus)+","
				+    POut.Int   ((int)webSchedRecall.SmsSendStatus)+","
				+"'"+POut.String(webSchedRecall.PhonePat)+"',"
				+"'"+POut.String(webSchedRecall.EmailPat)+"',"
				+    DbHelper.ParamChar+"paramMsgTextToMobileTemplate,"
				+    DbHelper.ParamChar+"paramMsgTextToMobile,"
				+    DbHelper.ParamChar+"paramEmailSubjTemplate,"
				+    DbHelper.ParamChar+"paramEmailSubj,"
				+    DbHelper.ParamChar+"paramEmailTextTemplate,"
				+    DbHelper.ParamChar+"paramEmailText,"
				+    DbHelper.ParamChar+"paramGuidMessageToMobile,"
				+"'"+POut.String(webSchedRecall.ShortGUIDSms)+"',"
				+"'"+POut.String(webSchedRecall.ShortGUIDEmail)+"',"
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    POut.Int   ((int)webSchedRecall.Source)+")";
			if(webSchedRecall.MsgTextToMobileTemplate==null) {
				webSchedRecall.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobileTemplate));
			if(webSchedRecall.MsgTextToMobile==null) {
				webSchedRecall.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobile));
			if(webSchedRecall.EmailSubjTemplate==null) {
				webSchedRecall.EmailSubjTemplate="";
			}
			OdSqlParameter paramEmailSubjTemplate=new OdSqlParameter("paramEmailSubjTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubjTemplate));
			if(webSchedRecall.EmailSubj==null) {
				webSchedRecall.EmailSubj="";
			}
			OdSqlParameter paramEmailSubj=new OdSqlParameter("paramEmailSubj",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubj));
			if(webSchedRecall.EmailTextTemplate==null) {
				webSchedRecall.EmailTextTemplate="";
			}
			OdSqlParameter paramEmailTextTemplate=new OdSqlParameter("paramEmailTextTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailTextTemplate));
			if(webSchedRecall.EmailText==null) {
				webSchedRecall.EmailText="";
			}
			OdSqlParameter paramEmailText=new OdSqlParameter("paramEmailText",OdDbType.Text,POut.StringParam(webSchedRecall.EmailText));
			if(webSchedRecall.GuidMessageToMobile==null) {
				webSchedRecall.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.GuidMessageToMobile));
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText,paramGuidMessageToMobile,paramResponseDescript);
			}
			else {
				webSchedRecall.WebSchedRecallNum=Db.NonQ(command,true,"WebSchedRecallNum","webSchedRecall",paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText,paramGuidMessageToMobile,paramResponseDescript);
			}
			return webSchedRecall.WebSchedRecallNum;
		}

		///<summary>Updates one WebSchedRecall in the database.</summary>
		public static void Update(WebSchedRecall webSchedRecall) {
			string command="UPDATE webschedrecall SET "
				+"ClinicNum              =  "+POut.Long  (webSchedRecall.ClinicNum)+", "
				+"PatNum                 =  "+POut.Long  (webSchedRecall.PatNum)+", "
				+"RecallNum              =  "+POut.Long  (webSchedRecall.RecallNum)+", "
				//DateTimeEntry not allowed to change
				+"DateDue                =  "+POut.Date  (webSchedRecall.DateDue)+", "
				+"ReminderCount          =  "+POut.Int   (webSchedRecall.ReminderCount)+", "
				+"PreferRecallMethod     =  "+POut.Int   ((int)webSchedRecall.PreferRecallMethod)+", "
				+"DateTimeReminderSent   =  "+POut.DateT (webSchedRecall.DateTimeReminderSent)+", "
				+"DateTimeSendFailed     =  "+POut.DateT (webSchedRecall.DateTimeSendFailed)+", "
				+"EmailSendStatus        =  "+POut.Int   ((int)webSchedRecall.EmailSendStatus)+", "
				+"SmsSendStatus          =  "+POut.Int   ((int)webSchedRecall.SmsSendStatus)+", "
				+"PhonePat               = '"+POut.String(webSchedRecall.PhonePat)+"', "
				+"EmailPat               = '"+POut.String(webSchedRecall.EmailPat)+"', "
				+"MsgTextToMobileTemplate=  "+DbHelper.ParamChar+"paramMsgTextToMobileTemplate, "
				+"MsgTextToMobile        =  "+DbHelper.ParamChar+"paramMsgTextToMobile, "
				+"EmailSubjTemplate      =  "+DbHelper.ParamChar+"paramEmailSubjTemplate, "
				+"EmailSubj              =  "+DbHelper.ParamChar+"paramEmailSubj, "
				+"EmailTextTemplate      =  "+DbHelper.ParamChar+"paramEmailTextTemplate, "
				+"EmailText              =  "+DbHelper.ParamChar+"paramEmailText, "
				+"GuidMessageToMobile    =  "+DbHelper.ParamChar+"paramGuidMessageToMobile, "
				+"ShortGUIDSms           = '"+POut.String(webSchedRecall.ShortGUIDSms)+"', "
				+"ShortGUIDEmail         = '"+POut.String(webSchedRecall.ShortGUIDEmail)+"', "
				+"ResponseDescript       =  "+DbHelper.ParamChar+"paramResponseDescript, "
				+"Source                 =  "+POut.Int   ((int)webSchedRecall.Source)+" "
				+"WHERE WebSchedRecallNum = "+POut.Long(webSchedRecall.WebSchedRecallNum);
			if(webSchedRecall.MsgTextToMobileTemplate==null) {
				webSchedRecall.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobileTemplate));
			if(webSchedRecall.MsgTextToMobile==null) {
				webSchedRecall.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobile));
			if(webSchedRecall.EmailSubjTemplate==null) {
				webSchedRecall.EmailSubjTemplate="";
			}
			OdSqlParameter paramEmailSubjTemplate=new OdSqlParameter("paramEmailSubjTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubjTemplate));
			if(webSchedRecall.EmailSubj==null) {
				webSchedRecall.EmailSubj="";
			}
			OdSqlParameter paramEmailSubj=new OdSqlParameter("paramEmailSubj",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubj));
			if(webSchedRecall.EmailTextTemplate==null) {
				webSchedRecall.EmailTextTemplate="";
			}
			OdSqlParameter paramEmailTextTemplate=new OdSqlParameter("paramEmailTextTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailTextTemplate));
			if(webSchedRecall.EmailText==null) {
				webSchedRecall.EmailText="";
			}
			OdSqlParameter paramEmailText=new OdSqlParameter("paramEmailText",OdDbType.Text,POut.StringParam(webSchedRecall.EmailText));
			if(webSchedRecall.GuidMessageToMobile==null) {
				webSchedRecall.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.GuidMessageToMobile));
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText,paramGuidMessageToMobile,paramResponseDescript);
		}

		///<summary>Updates one WebSchedRecall in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WebSchedRecall webSchedRecall,WebSchedRecall oldWebSchedRecall) {
			string command="";
			if(webSchedRecall.ClinicNum != oldWebSchedRecall.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(webSchedRecall.ClinicNum)+"";
			}
			if(webSchedRecall.PatNum != oldWebSchedRecall.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(webSchedRecall.PatNum)+"";
			}
			if(webSchedRecall.RecallNum != oldWebSchedRecall.RecallNum) {
				if(command!="") { command+=",";}
				command+="RecallNum = "+POut.Long(webSchedRecall.RecallNum)+"";
			}
			//DateTimeEntry not allowed to change
			if(webSchedRecall.DateDue.Date != oldWebSchedRecall.DateDue.Date) {
				if(command!="") { command+=",";}
				command+="DateDue = "+POut.Date(webSchedRecall.DateDue)+"";
			}
			if(webSchedRecall.ReminderCount != oldWebSchedRecall.ReminderCount) {
				if(command!="") { command+=",";}
				command+="ReminderCount = "+POut.Int(webSchedRecall.ReminderCount)+"";
			}
			if(webSchedRecall.PreferRecallMethod != oldWebSchedRecall.PreferRecallMethod) {
				if(command!="") { command+=",";}
				command+="PreferRecallMethod = "+POut.Int   ((int)webSchedRecall.PreferRecallMethod)+"";
			}
			if(webSchedRecall.DateTimeReminderSent != oldWebSchedRecall.DateTimeReminderSent) {
				if(command!="") { command+=",";}
				command+="DateTimeReminderSent = "+POut.DateT(webSchedRecall.DateTimeReminderSent)+"";
			}
			if(webSchedRecall.DateTimeSendFailed != oldWebSchedRecall.DateTimeSendFailed) {
				if(command!="") { command+=",";}
				command+="DateTimeSendFailed = "+POut.DateT(webSchedRecall.DateTimeSendFailed)+"";
			}
			if(webSchedRecall.EmailSendStatus != oldWebSchedRecall.EmailSendStatus) {
				if(command!="") { command+=",";}
				command+="EmailSendStatus = "+POut.Int   ((int)webSchedRecall.EmailSendStatus)+"";
			}
			if(webSchedRecall.SmsSendStatus != oldWebSchedRecall.SmsSendStatus) {
				if(command!="") { command+=",";}
				command+="SmsSendStatus = "+POut.Int   ((int)webSchedRecall.SmsSendStatus)+"";
			}
			if(webSchedRecall.PhonePat != oldWebSchedRecall.PhonePat) {
				if(command!="") { command+=",";}
				command+="PhonePat = '"+POut.String(webSchedRecall.PhonePat)+"'";
			}
			if(webSchedRecall.EmailPat != oldWebSchedRecall.EmailPat) {
				if(command!="") { command+=",";}
				command+="EmailPat = '"+POut.String(webSchedRecall.EmailPat)+"'";
			}
			if(webSchedRecall.MsgTextToMobileTemplate != oldWebSchedRecall.MsgTextToMobileTemplate) {
				if(command!="") { command+=",";}
				command+="MsgTextToMobileTemplate = "+DbHelper.ParamChar+"paramMsgTextToMobileTemplate";
			}
			if(webSchedRecall.MsgTextToMobile != oldWebSchedRecall.MsgTextToMobile) {
				if(command!="") { command+=",";}
				command+="MsgTextToMobile = "+DbHelper.ParamChar+"paramMsgTextToMobile";
			}
			if(webSchedRecall.EmailSubjTemplate != oldWebSchedRecall.EmailSubjTemplate) {
				if(command!="") { command+=",";}
				command+="EmailSubjTemplate = "+DbHelper.ParamChar+"paramEmailSubjTemplate";
			}
			if(webSchedRecall.EmailSubj != oldWebSchedRecall.EmailSubj) {
				if(command!="") { command+=",";}
				command+="EmailSubj = "+DbHelper.ParamChar+"paramEmailSubj";
			}
			if(webSchedRecall.EmailTextTemplate != oldWebSchedRecall.EmailTextTemplate) {
				if(command!="") { command+=",";}
				command+="EmailTextTemplate = "+DbHelper.ParamChar+"paramEmailTextTemplate";
			}
			if(webSchedRecall.EmailText != oldWebSchedRecall.EmailText) {
				if(command!="") { command+=",";}
				command+="EmailText = "+DbHelper.ParamChar+"paramEmailText";
			}
			if(webSchedRecall.GuidMessageToMobile != oldWebSchedRecall.GuidMessageToMobile) {
				if(command!="") { command+=",";}
				command+="GuidMessageToMobile = "+DbHelper.ParamChar+"paramGuidMessageToMobile";
			}
			if(webSchedRecall.ShortGUIDSms != oldWebSchedRecall.ShortGUIDSms) {
				if(command!="") { command+=",";}
				command+="ShortGUIDSms = '"+POut.String(webSchedRecall.ShortGUIDSms)+"'";
			}
			if(webSchedRecall.ShortGUIDEmail != oldWebSchedRecall.ShortGUIDEmail) {
				if(command!="") { command+=",";}
				command+="ShortGUIDEmail = '"+POut.String(webSchedRecall.ShortGUIDEmail)+"'";
			}
			if(webSchedRecall.ResponseDescript != oldWebSchedRecall.ResponseDescript) {
				if(command!="") { command+=",";}
				command+="ResponseDescript = "+DbHelper.ParamChar+"paramResponseDescript";
			}
			if(webSchedRecall.Source != oldWebSchedRecall.Source) {
				if(command!="") { command+=",";}
				command+="Source = "+POut.Int   ((int)webSchedRecall.Source)+"";
			}
			if(command=="") {
				return false;
			}
			if(webSchedRecall.MsgTextToMobileTemplate==null) {
				webSchedRecall.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobileTemplate));
			if(webSchedRecall.MsgTextToMobile==null) {
				webSchedRecall.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.MsgTextToMobile));
			if(webSchedRecall.EmailSubjTemplate==null) {
				webSchedRecall.EmailSubjTemplate="";
			}
			OdSqlParameter paramEmailSubjTemplate=new OdSqlParameter("paramEmailSubjTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubjTemplate));
			if(webSchedRecall.EmailSubj==null) {
				webSchedRecall.EmailSubj="";
			}
			OdSqlParameter paramEmailSubj=new OdSqlParameter("paramEmailSubj",OdDbType.Text,POut.StringParam(webSchedRecall.EmailSubj));
			if(webSchedRecall.EmailTextTemplate==null) {
				webSchedRecall.EmailTextTemplate="";
			}
			OdSqlParameter paramEmailTextTemplate=new OdSqlParameter("paramEmailTextTemplate",OdDbType.Text,POut.StringParam(webSchedRecall.EmailTextTemplate));
			if(webSchedRecall.EmailText==null) {
				webSchedRecall.EmailText="";
			}
			OdSqlParameter paramEmailText=new OdSqlParameter("paramEmailText",OdDbType.Text,POut.StringParam(webSchedRecall.EmailText));
			if(webSchedRecall.GuidMessageToMobile==null) {
				webSchedRecall.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringParam(webSchedRecall.GuidMessageToMobile));
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			command="UPDATE webschedrecall SET "+command
				+" WHERE WebSchedRecallNum = "+POut.Long(webSchedRecall.WebSchedRecallNum);
			Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText,paramGuidMessageToMobile,paramResponseDescript);
			return true;
		}

		///<summary>Returns true if Update(WebSchedRecall,WebSchedRecall) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(WebSchedRecall webSchedRecall,WebSchedRecall oldWebSchedRecall) {
			if(webSchedRecall.ClinicNum != oldWebSchedRecall.ClinicNum) {
				return true;
			}
			if(webSchedRecall.PatNum != oldWebSchedRecall.PatNum) {
				return true;
			}
			if(webSchedRecall.RecallNum != oldWebSchedRecall.RecallNum) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(webSchedRecall.DateDue.Date != oldWebSchedRecall.DateDue.Date) {
				return true;
			}
			if(webSchedRecall.ReminderCount != oldWebSchedRecall.ReminderCount) {
				return true;
			}
			if(webSchedRecall.PreferRecallMethod != oldWebSchedRecall.PreferRecallMethod) {
				return true;
			}
			if(webSchedRecall.DateTimeReminderSent != oldWebSchedRecall.DateTimeReminderSent) {
				return true;
			}
			if(webSchedRecall.DateTimeSendFailed != oldWebSchedRecall.DateTimeSendFailed) {
				return true;
			}
			if(webSchedRecall.EmailSendStatus != oldWebSchedRecall.EmailSendStatus) {
				return true;
			}
			if(webSchedRecall.SmsSendStatus != oldWebSchedRecall.SmsSendStatus) {
				return true;
			}
			if(webSchedRecall.PhonePat != oldWebSchedRecall.PhonePat) {
				return true;
			}
			if(webSchedRecall.EmailPat != oldWebSchedRecall.EmailPat) {
				return true;
			}
			if(webSchedRecall.MsgTextToMobileTemplate != oldWebSchedRecall.MsgTextToMobileTemplate) {
				return true;
			}
			if(webSchedRecall.MsgTextToMobile != oldWebSchedRecall.MsgTextToMobile) {
				return true;
			}
			if(webSchedRecall.EmailSubjTemplate != oldWebSchedRecall.EmailSubjTemplate) {
				return true;
			}
			if(webSchedRecall.EmailSubj != oldWebSchedRecall.EmailSubj) {
				return true;
			}
			if(webSchedRecall.EmailTextTemplate != oldWebSchedRecall.EmailTextTemplate) {
				return true;
			}
			if(webSchedRecall.EmailText != oldWebSchedRecall.EmailText) {
				return true;
			}
			if(webSchedRecall.GuidMessageToMobile != oldWebSchedRecall.GuidMessageToMobile) {
				return true;
			}
			if(webSchedRecall.ShortGUIDSms != oldWebSchedRecall.ShortGUIDSms) {
				return true;
			}
			if(webSchedRecall.ShortGUIDEmail != oldWebSchedRecall.ShortGUIDEmail) {
				return true;
			}
			if(webSchedRecall.ResponseDescript != oldWebSchedRecall.ResponseDescript) {
				return true;
			}
			if(webSchedRecall.Source != oldWebSchedRecall.Source) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one WebSchedRecall from the database.</summary>
		public static void Delete(long webSchedRecallNum) {
			string command="DELETE FROM webschedrecall "
				+"WHERE WebSchedRecallNum = "+POut.Long(webSchedRecallNum);
			Db.NonQ(command);
		}

	}
}