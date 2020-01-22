//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class MobileDataByteCrud {
		///<summary>Gets one MobileDataByte object from the database using the primary key.  Returns null if not found.</summary>
		public static MobileDataByte SelectOne(long mobileDataByteNum) {
			string command="SELECT * FROM mobiledatabyte "
				+"WHERE MobileDataByteNum = "+POut.Long(mobileDataByteNum);
			List<MobileDataByte> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one MobileDataByte object from the database using a query.</summary>
		public static MobileDataByte SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<MobileDataByte> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of MobileDataByte objects from the database using a query.</summary>
		public static List<MobileDataByte> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<MobileDataByte> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<MobileDataByte> TableToList(DataTable table) {
			List<MobileDataByte> retVal=new List<MobileDataByte>();
			MobileDataByte mobileDataByte;
			foreach(DataRow row in table.Rows) {
				mobileDataByte=new MobileDataByte();
				mobileDataByte.MobileDataByteNum= PIn.Long  (row["MobileDataByteNum"].ToString());
				mobileDataByte.RawBase64Data    = PIn.String(row["RawBase64Data"].ToString());
				mobileDataByte.RawBase64Code    = PIn.String(row["RawBase64Code"].ToString());
				mobileDataByte.RawBase64Tag     = PIn.String(row["RawBase64Tag"].ToString());
				mobileDataByte.PatNum           = PIn.Long  (row["PatNum"].ToString());
				mobileDataByte.ActionType       = (OpenDentBusiness.eActionType)PIn.Int(row["ActionType"].ToString());
				mobileDataByte.DateTimeEntry    = PIn.DateT (row["DateTimeEntry"].ToString());
				mobileDataByte.DateTimeExpires  = PIn.DateT (row["DateTimeExpires"].ToString());
				retVal.Add(mobileDataByte);
			}
			return retVal;
		}

		///<summary>Converts a list of MobileDataByte into a DataTable.</summary>
		public static DataTable ListToTable(List<MobileDataByte> listMobileDataBytes,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="MobileDataByte";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("MobileDataByteNum");
			table.Columns.Add("RawBase64Data");
			table.Columns.Add("RawBase64Code");
			table.Columns.Add("RawBase64Tag");
			table.Columns.Add("PatNum");
			table.Columns.Add("ActionType");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("DateTimeExpires");
			foreach(MobileDataByte mobileDataByte in listMobileDataBytes) {
				table.Rows.Add(new object[] {
					POut.Long  (mobileDataByte.MobileDataByteNum),
					            mobileDataByte.RawBase64Data,
					            mobileDataByte.RawBase64Code,
					            mobileDataByte.RawBase64Tag,
					POut.Long  (mobileDataByte.PatNum),
					POut.Int   ((int)mobileDataByte.ActionType),
					POut.DateT (mobileDataByte.DateTimeEntry,false),
					POut.DateT (mobileDataByte.DateTimeExpires,false),
				});
			}
			return table;
		}

		///<summary>Inserts one MobileDataByte into the database.  Returns the new priKey.</summary>
		public static long Insert(MobileDataByte mobileDataByte) {
			return Insert(mobileDataByte,false);
		}

		///<summary>Inserts one MobileDataByte into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(MobileDataByte mobileDataByte,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				mobileDataByte.MobileDataByteNum=ReplicationServers.GetKey("mobiledatabyte","MobileDataByteNum");
			}
			string command="INSERT INTO mobiledatabyte (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="MobileDataByteNum,";
			}
			command+="RawBase64Data,RawBase64Code,RawBase64Tag,PatNum,ActionType,DateTimeEntry,DateTimeExpires) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(mobileDataByte.MobileDataByteNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramRawBase64Data,"
				+    DbHelper.ParamChar+"paramRawBase64Code,"
				+    DbHelper.ParamChar+"paramRawBase64Tag,"
				+    POut.Long  (mobileDataByte.PatNum)+","
				+    POut.Int   ((int)mobileDataByte.ActionType)+","
				+    DbHelper.Now()+","
				+    POut.DateT (mobileDataByte.DateTimeExpires)+")";
			if(mobileDataByte.RawBase64Data==null) {
				mobileDataByte.RawBase64Data="";
			}
			OdSqlParameter paramRawBase64Data=new OdSqlParameter("paramRawBase64Data",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Data));
			if(mobileDataByte.RawBase64Code==null) {
				mobileDataByte.RawBase64Code="";
			}
			OdSqlParameter paramRawBase64Code=new OdSqlParameter("paramRawBase64Code",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Code));
			if(mobileDataByte.RawBase64Tag==null) {
				mobileDataByte.RawBase64Tag="";
			}
			OdSqlParameter paramRawBase64Tag=new OdSqlParameter("paramRawBase64Tag",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Tag));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramRawBase64Data,paramRawBase64Code,paramRawBase64Tag);
			}
			else {
				mobileDataByte.MobileDataByteNum=Db.NonQ(command,true,"MobileDataByteNum","mobileDataByte",paramRawBase64Data,paramRawBase64Code,paramRawBase64Tag);
			}
			return mobileDataByte.MobileDataByteNum;
		}

		///<summary>Inserts one MobileDataByte into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MobileDataByte mobileDataByte) {
			return InsertNoCache(mobileDataByte,false);
		}

		///<summary>Inserts one MobileDataByte into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MobileDataByte mobileDataByte,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO mobiledatabyte (";
			if(!useExistingPK && isRandomKeys) {
				mobileDataByte.MobileDataByteNum=ReplicationServers.GetKeyNoCache("mobiledatabyte","MobileDataByteNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="MobileDataByteNum,";
			}
			command+="RawBase64Data,RawBase64Code,RawBase64Tag,PatNum,ActionType,DateTimeEntry,DateTimeExpires) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(mobileDataByte.MobileDataByteNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramRawBase64Data,"
				+    DbHelper.ParamChar+"paramRawBase64Code,"
				+    DbHelper.ParamChar+"paramRawBase64Tag,"
				+    POut.Long  (mobileDataByte.PatNum)+","
				+    POut.Int   ((int)mobileDataByte.ActionType)+","
				+    DbHelper.Now()+","
				+    POut.DateT (mobileDataByte.DateTimeExpires)+")";
			if(mobileDataByte.RawBase64Data==null) {
				mobileDataByte.RawBase64Data="";
			}
			OdSqlParameter paramRawBase64Data=new OdSqlParameter("paramRawBase64Data",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Data));
			if(mobileDataByte.RawBase64Code==null) {
				mobileDataByte.RawBase64Code="";
			}
			OdSqlParameter paramRawBase64Code=new OdSqlParameter("paramRawBase64Code",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Code));
			if(mobileDataByte.RawBase64Tag==null) {
				mobileDataByte.RawBase64Tag="";
			}
			OdSqlParameter paramRawBase64Tag=new OdSqlParameter("paramRawBase64Tag",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Tag));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramRawBase64Data,paramRawBase64Code,paramRawBase64Tag);
			}
			else {
				mobileDataByte.MobileDataByteNum=Db.NonQ(command,true,"MobileDataByteNum","mobileDataByte",paramRawBase64Data,paramRawBase64Code,paramRawBase64Tag);
			}
			return mobileDataByte.MobileDataByteNum;
		}

		///<summary>Updates one MobileDataByte in the database.</summary>
		public static void Update(MobileDataByte mobileDataByte) {
			string command="UPDATE mobiledatabyte SET "
				+"RawBase64Data    =  "+DbHelper.ParamChar+"paramRawBase64Data, "
				+"RawBase64Code    =  "+DbHelper.ParamChar+"paramRawBase64Code, "
				+"RawBase64Tag     =  "+DbHelper.ParamChar+"paramRawBase64Tag, "
				+"PatNum           =  "+POut.Long  (mobileDataByte.PatNum)+", "
				+"ActionType       =  "+POut.Int   ((int)mobileDataByte.ActionType)+", "
				//DateTimeEntry not allowed to change
				+"DateTimeExpires  =  "+POut.DateT (mobileDataByte.DateTimeExpires)+" "
				+"WHERE MobileDataByteNum = "+POut.Long(mobileDataByte.MobileDataByteNum);
			if(mobileDataByte.RawBase64Data==null) {
				mobileDataByte.RawBase64Data="";
			}
			OdSqlParameter paramRawBase64Data=new OdSqlParameter("paramRawBase64Data",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Data));
			if(mobileDataByte.RawBase64Code==null) {
				mobileDataByte.RawBase64Code="";
			}
			OdSqlParameter paramRawBase64Code=new OdSqlParameter("paramRawBase64Code",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Code));
			if(mobileDataByte.RawBase64Tag==null) {
				mobileDataByte.RawBase64Tag="";
			}
			OdSqlParameter paramRawBase64Tag=new OdSqlParameter("paramRawBase64Tag",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Tag));
			Db.NonQ(command,paramRawBase64Data,paramRawBase64Code,paramRawBase64Tag);
		}

		///<summary>Updates one MobileDataByte in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(MobileDataByte mobileDataByte,MobileDataByte oldMobileDataByte) {
			string command="";
			if(mobileDataByte.RawBase64Data != oldMobileDataByte.RawBase64Data) {
				if(command!="") { command+=",";}
				command+="RawBase64Data = "+DbHelper.ParamChar+"paramRawBase64Data";
			}
			if(mobileDataByte.RawBase64Code != oldMobileDataByte.RawBase64Code) {
				if(command!="") { command+=",";}
				command+="RawBase64Code = "+DbHelper.ParamChar+"paramRawBase64Code";
			}
			if(mobileDataByte.RawBase64Tag != oldMobileDataByte.RawBase64Tag) {
				if(command!="") { command+=",";}
				command+="RawBase64Tag = "+DbHelper.ParamChar+"paramRawBase64Tag";
			}
			if(mobileDataByte.PatNum != oldMobileDataByte.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(mobileDataByte.PatNum)+"";
			}
			if(mobileDataByte.ActionType != oldMobileDataByte.ActionType) {
				if(command!="") { command+=",";}
				command+="ActionType = "+POut.Int   ((int)mobileDataByte.ActionType)+"";
			}
			//DateTimeEntry not allowed to change
			if(mobileDataByte.DateTimeExpires != oldMobileDataByte.DateTimeExpires) {
				if(command!="") { command+=",";}
				command+="DateTimeExpires = "+POut.DateT(mobileDataByte.DateTimeExpires)+"";
			}
			if(command=="") {
				return false;
			}
			if(mobileDataByte.RawBase64Data==null) {
				mobileDataByte.RawBase64Data="";
			}
			OdSqlParameter paramRawBase64Data=new OdSqlParameter("paramRawBase64Data",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Data));
			if(mobileDataByte.RawBase64Code==null) {
				mobileDataByte.RawBase64Code="";
			}
			OdSqlParameter paramRawBase64Code=new OdSqlParameter("paramRawBase64Code",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Code));
			if(mobileDataByte.RawBase64Tag==null) {
				mobileDataByte.RawBase64Tag="";
			}
			OdSqlParameter paramRawBase64Tag=new OdSqlParameter("paramRawBase64Tag",OdDbType.Text,POut.StringParam(mobileDataByte.RawBase64Tag));
			command="UPDATE mobiledatabyte SET "+command
				+" WHERE MobileDataByteNum = "+POut.Long(mobileDataByte.MobileDataByteNum);
			Db.NonQ(command,paramRawBase64Data,paramRawBase64Code,paramRawBase64Tag);
			return true;
		}

		///<summary>Returns true if Update(MobileDataByte,MobileDataByte) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(MobileDataByte mobileDataByte,MobileDataByte oldMobileDataByte) {
			if(mobileDataByte.RawBase64Data != oldMobileDataByte.RawBase64Data) {
				return true;
			}
			if(mobileDataByte.RawBase64Code != oldMobileDataByte.RawBase64Code) {
				return true;
			}
			if(mobileDataByte.RawBase64Tag != oldMobileDataByte.RawBase64Tag) {
				return true;
			}
			if(mobileDataByte.PatNum != oldMobileDataByte.PatNum) {
				return true;
			}
			if(mobileDataByte.ActionType != oldMobileDataByte.ActionType) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(mobileDataByte.DateTimeExpires != oldMobileDataByte.DateTimeExpires) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one MobileDataByte from the database.</summary>
		public static void Delete(long mobileDataByteNum) {
			string command="DELETE FROM mobiledatabyte "
				+"WHERE MobileDataByteNum = "+POut.Long(mobileDataByteNum);
			Db.NonQ(command);
		}

	}
}