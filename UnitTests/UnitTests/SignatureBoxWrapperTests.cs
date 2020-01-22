﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDentBusiness;
using UnitTestsCore;

namespace UnitTests.SignatureBoxWrapper_Tests {
	[TestClass]
	public class SignatureBoxWrapperTests:TestBase {

		///<summary>This method will execute only once, just before any tests in this class run.</summary>
		[ClassInitialize]
		public static void SetupClass(TestContext testContext) {
		}

		///<summary>This method will execute just before each test in this class.</summary>
		[TestInitialize]
		public void SetupTest() {
		}

		///<summary>This method will execute after each test in this class.</summary>
		[TestCleanup]
		public void TearDownTest() {
		}

		///<summary>This method will execute only once, just after all tests in this class have run.</summary>
		[ClassCleanup]
		public static void TearDownClass() {
		}

		[TestMethod]
		public void SignatureBoxWrapper_FillSignature_GetNumberOfTabletPoints() {
			string suffix = "52";
			Patient pat = PatientT.CreatePatient(suffix);
			List<int> listFailedTests = new List<int>();
			OpenDental.UI.SignatureBoxWrapper sbw = new OpenDental.UI.SignatureBoxWrapper();
			//1: Normal signature with \r\n
			sbw.FillSignature(false,"15.4 Normal\r\n15.4 Normal\r\n15.4 Normal3","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");
			if(sbw.GetNumberOfTabletPoints(false)==0) {
				listFailedTests.Add(1);
			}
			//2: Normal signature, middle tier with \r\n
			sbw.FillSignature(false,"15.4 Normal MiddleTier\r\n15.4 Normal MiddleTier\r\n15.4 Normal MiddleTier3","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");
			if(sbw.GetNumberOfTabletPoints(false)==0) {
				listFailedTests.Add(2);
			}
			//3: Topaz signature with \r\n
			sbw.FillSignature(true,"15.4 Topaz\r\n15.4 Topaz\r\n15.4 Topaz3","FFFFFFFFED1D7C6A37000000040000003E6A277C10525BF095781A4505E1A9814FB05B0B7930F49EDDE09B95B6743B4EF11B47C4E7DF151AA5C031BC4487067C897FA35C3E9A5FD9DAF32CEC3F9479C6CDB793CC5202BCE8714DDADDE228986E39440B31B76E940496E9F63EFFED1C3F896DE2B7EA5129CA08C9B22066C48CF27FEEBE00E107A3901498ABE9FA9F301FB028748CE0BBE01CC2A4628E94AF9854FFA4A15D60F3C488698D5F2F14379F99D764B27013B4FFB18336AA20B132DE18A85060544F5F92F4A259803FC2CA9384DF30B784703C80868C6F1D2EADCF55345F0380CC9A5F0C757594FF128F66E6F7BC6D655FF2592935EDB3CA52C642FC9C4A64B8623F43015F3810CC51A580081C50DC9FF1ADDFEF3FBD06E0C9E0DD47F1B87E1061C760099E6EA055A1533C6134700527723C62DDFD8B267D6CECC6399CCA149BA5B234B0A5EA44DF3223941DF7AFF6D4B5551366F71103B7B48EE7D2B6122B9495654DE257478FBED6680F4DE2A0C91EFFE5E95E785E7ADF0AED06BC384B69915DC4BA281980F9684AF119FB0B242EF4CCC82E3AE733C05F08933DD71E8D54F403C6C8A1A48D54F403C6C8A1A48D54F403C6C8A1A48D54F403C6C8A1A48D54F403C6C8A1A4");
			if(sbw.GetNumberOfTabletPoints(true)==0) {
				listFailedTests.Add(3);
			}
			//4: Topaz signature, middle tier with \r\n
			sbw.FillSignature(true,"15.4 Topaz MiddleTier\r\n15.4 Topaz MiddleTier\r\n15.4 Topaz MiddleTier3","FFFFFFFFAD1F4B693A00000000000000DEB4BBA8050C7F6E66DD8CC844BE7EEC6F3102C5E6B6F4977E482CE5F5E82ADCEEFFC822D77A6AB9529E824C363E0822ED65EBC841D98F55C7FF5CF269D8CBEF37B4E68BE56095D172699A8A58D8F71E366D6F65DA865F186454B4C9219D159147294001EBE30DF244B970B7B015C0FAEBC74BDDA61551412F6761D295D5C754A58B2B94781E067E7FEC2FEE0AAD6F0463D2C48F1EF21AD068CFE314CE2738949A01A19D29564D16A8C3D1CE462FEA754AD769CAFDEC057F9CF7AEB8BC68CDBDE965B83D75226294C44B14F4391BC07C32D908F409247E80C9C4C9DFE27C123459651FB5240C922841254DD77107DB1E6A5A525AFA10947BB1488D058C88E127DD6790A3F30A5013D9643AFDB03762875EA5D7D336EE6076B4AB7BD089872BD687300CF16AA32DC9606A91CD726E0244D91B760EA76C904B27180D271CCE952B80C4C65E39EBD2E41B84B7A7309AB3D953E673E788E063F624568F8C936B440254D832245B2DF3730066B0D32CBBD779AF1299037B3A14C72376D13B3B65E87D078FFB0FB98E2F53E6E02939A697AFAF585853EDB281D283765A15B1CE10060C4DC8A32D40884F8C4F5DEA3FA31345073F7C73434A9AE2913F7C73434A9AE2913F7C73434A9AE2913F7C73434A9AE291");
			if(sbw.GetNumberOfTabletPoints(true)==0) {
				listFailedTests.Add(4);
			}
			//5: Normal signature with \n
			sbw.FillSignature(false,"15.4 Normal\n15.4 Normal\n15.4 Normal3","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");
			if(sbw.GetNumberOfTabletPoints(false)==0) {
				listFailedTests.Add(5);
			}
			//6: Normal signature, middle tier with \n
			sbw.FillSignature(false,"15.4 Normal MiddleTier\n15.4 Normal MiddleTier\n15.4 Normal MiddleTier3","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");
			if(sbw.GetNumberOfTabletPoints(false)==0) {
				listFailedTests.Add(6);
			}
			//7: Topaz signature with \n
			sbw.FillSignature(true,"15.4 Topaz\n15.4 Topaz\n15.4 Topaz3","FFFFFFFFED1D7C6A37000000040000003E6A277C10525BF095781A4505E1A9814FB05B0B7930F49EDDE09B95B6743B4EF11B47C4E7DF151AA5C031BC4487067C897FA35C3E9A5FD9DAF32CEC3F9479C6CDB793CC5202BCE8714DDADDE228986E39440B31B76E940496E9F63EFFED1C3F896DE2B7EA5129CA08C9B22066C48CF27FEEBE00E107A3901498ABE9FA9F301FB028748CE0BBE01CC2A4628E94AF9854FFA4A15D60F3C488698D5F2F14379F99D764B27013B4FFB18336AA20B132DE18A85060544F5F92F4A259803FC2CA9384DF30B784703C80868C6F1D2EADCF55345F0380CC9A5F0C757594FF128F66E6F7BC6D655FF2592935EDB3CA52C642FC9C4A64B8623F43015F3810CC51A580081C50DC9FF1ADDFEF3FBD06E0C9E0DD47F1B87E1061C760099E6EA055A1533C6134700527723C62DDFD8B267D6CECC6399CCA149BA5B234B0A5EA44DF3223941DF7AFF6D4B5551366F71103B7B48EE7D2B6122B9495654DE257478FBED6680F4DE2A0C91EFFE5E95E785E7ADF0AED06BC384B69915DC4BA281980F9684AF119FB0B242EF4CCC82E3AE733C05F08933DD71E8D54F403C6C8A1A48D54F403C6C8A1A48D54F403C6C8A1A48D54F403C6C8A1A48D54F403C6C8A1A4");
			if(sbw.GetNumberOfTabletPoints(true)==0) {
				listFailedTests.Add(7);
			}
			//8: Topaz signature, middle tier with \n
			sbw.FillSignature(true,"15.4 Topaz MiddleTier\n15.4 Topaz MiddleTier\n15.4 Topaz MiddleTier3","FFFFFFFFAD1F4B693A00000000000000DEB4BBA8050C7F6E66DD8CC844BE7EEC6F3102C5E6B6F4977E482CE5F5E82ADCEEFFC822D77A6AB9529E824C363E0822ED65EBC841D98F55C7FF5CF269D8CBEF37B4E68BE56095D172699A8A58D8F71E366D6F65DA865F186454B4C9219D159147294001EBE30DF244B970B7B015C0FAEBC74BDDA61551412F6761D295D5C754A58B2B94781E067E7FEC2FEE0AAD6F0463D2C48F1EF21AD068CFE314CE2738949A01A19D29564D16A8C3D1CE462FEA754AD769CAFDEC057F9CF7AEB8BC68CDBDE965B83D75226294C44B14F4391BC07C32D908F409247E80C9C4C9DFE27C123459651FB5240C922841254DD77107DB1E6A5A525AFA10947BB1488D058C88E127DD6790A3F30A5013D9643AFDB03762875EA5D7D336EE6076B4AB7BD089872BD687300CF16AA32DC9606A91CD726E0244D91B760EA76C904B27180D271CCE952B80C4C65E39EBD2E41B84B7A7309AB3D953E673E788E063F624568F8C936B440254D832245B2DF3730066B0D32CBBD779AF1299037B3A14C72376D13B3B65E87D078FFB0FB98E2F53E6E02939A697AFAF585853EDB281D283765A15B1CE10060C4DC8A32D40884F8C4F5DEA3FA31345073F7C73434A9AE2913F7C73434A9AE2913F7C73434A9AE2913F7C73434A9AE291");
			if(sbw.GetNumberOfTabletPoints(true)==0) {
				listFailedTests.Add(8);
			}
			//9:  Invalid Signature (wrong key)
			sbw.FillSignature(false,"15.4 Normal\r\n15.4 Normal\r\n15.4 Normal4","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");
			if(sbw.GetNumberOfTabletPoints(false)!=0) {//This test is meant to be invalid intentionally.
				listFailedTests.Add(9);
			}
			Assert.AreEqual(0,listFailedTests.Count);
		}

	}
}