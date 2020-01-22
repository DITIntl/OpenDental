//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class DbmLogCrud {
		///<summary>Gets one DbmLog object from the database using the primary key.  Returns null if not found.</summary>
		public static DbmLog SelectOne(long dbmLogNum) {
			string command="SELECT * FROM dbmlog "
				+"WHERE DbmLogNum = "+POut.Long(dbmLogNum);
			List<DbmLog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DbmLog object from the database using a query.</summary>
		public static DbmLog SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DbmLog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DbmLog objects from the database using a query.</summary>
		public static List<DbmLog> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DbmLog> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<DbmLog> TableToList(DataTable table) {
			List<DbmLog> retVal=new List<DbmLog>();
			DbmLog dbmLog;
			foreach(DataRow row in table.Rows) {
				dbmLog=new DbmLog();
				dbmLog.DbmLogNum    = PIn.Long  (row["DbmLogNum"].ToString());
				dbmLog.UserNum      = PIn.Long  (row["UserNum"].ToString());
				dbmLog.FKey         = PIn.Long  (row["FKey"].ToString());
				dbmLog.FKeyType     = (OpenDentBusiness.DbmLogFKeyType)PIn.Int(row["FKeyType"].ToString());
				dbmLog.ActionType   = (OpenDentBusiness.DbmLogActionType)PIn.Int(row["ActionType"].ToString());
				dbmLog.DateTimeEntry= PIn.DateT (row["DateTimeEntry"].ToString());
				dbmLog.MethodName   = PIn.String(row["MethodName"].ToString());
				dbmLog.LogText      = PIn.String(row["LogText"].ToString());
				retVal.Add(dbmLog);
			}
			return retVal;
		}

		///<summary>Converts a list of DbmLog into a DataTable.</summary>
		public static DataTable ListToTable(List<DbmLog> listDbmLogs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="DbmLog";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("DbmLogNum");
			table.Columns.Add("UserNum");
			table.Columns.Add("FKey");
			table.Columns.Add("FKeyType");
			table.Columns.Add("ActionType");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("MethodName");
			table.Columns.Add("LogText");
			foreach(DbmLog dbmLog in listDbmLogs) {
				table.Rows.Add(new object[] {
					POut.Long  (dbmLog.DbmLogNum),
					POut.Long  (dbmLog.UserNum),
					POut.Long  (dbmLog.FKey),
					POut.Int   ((int)dbmLog.FKeyType),
					POut.Int   ((int)dbmLog.ActionType),
					POut.DateT (dbmLog.DateTimeEntry,false),
					            dbmLog.MethodName,
					            dbmLog.LogText,
				});
			}
			return table;
		}

		///<summary>Inserts one DbmLog into the database.  Returns the new priKey.</summary>
		public static long Insert(DbmLog dbmLog) {
			return Insert(dbmLog,false);
		}

		///<summary>Inserts one DbmLog into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(DbmLog dbmLog,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				dbmLog.DbmLogNum=ReplicationServers.GetKey("dbmlog","DbmLogNum");
			}
			string command="INSERT INTO dbmlog (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DbmLogNum,";
			}
			command+="UserNum,FKey,FKeyType,ActionType,DateTimeEntry,MethodName,LogText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(dbmLog.DbmLogNum)+",";
			}
			command+=
				     POut.Long  (dbmLog.UserNum)+","
				+    POut.Long  (dbmLog.FKey)+","
				+    POut.Int   ((int)dbmLog.FKeyType)+","
				+    POut.Int   ((int)dbmLog.ActionType)+","
				+    DbHelper.Now()+","
				+"'"+POut.String(dbmLog.MethodName)+"',"
				+    DbHelper.ParamChar+"paramLogText)";
			if(dbmLog.LogText==null) {
				dbmLog.LogText="";
			}
			OdSqlParameter paramLogText=new OdSqlParameter("paramLogText",OdDbType.Text,POut.StringParam(dbmLog.LogText));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramLogText);
			}
			else {
				dbmLog.DbmLogNum=Db.NonQ(command,true,"DbmLogNum","dbmLog",paramLogText);
			}
			return dbmLog.DbmLogNum;
		}

		///<summary>Inserts many DbmLogs into the database.</summary>
		public static void InsertMany(List<DbmLog> listDbmLogs) {
			InsertMany(listDbmLogs,false);
		}

		///<summary>Inserts many DbmLogs into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<DbmLog> listDbmLogs,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(DbmLog dbmLog in listDbmLogs) {
					Insert(dbmLog);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listDbmLogs.Count) {
					DbmLog dbmLog=listDbmLogs[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO dbmlog (");
						if(useExistingPK) {
							sbCommands.Append("DbmLogNum,");
						}
						sbCommands.Append("UserNum,FKey,FKeyType,ActionType,DateTimeEntry,MethodName,LogText) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(dbmLog.DbmLogNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(dbmLog.UserNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(dbmLog.FKey)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)dbmLog.FKeyType)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)dbmLog.ActionType)); sbRow.Append(",");
					sbRow.Append(DbHelper.Now()); sbRow.Append(",");
					sbRow.Append("'"+POut.String(dbmLog.MethodName)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(dbmLog.LogText)+"'"); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listDbmLogs.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one DbmLog into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DbmLog dbmLog) {
			return InsertNoCache(dbmLog,false);
		}

		///<summary>Inserts one DbmLog into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DbmLog dbmLog,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO dbmlog (";
			if(!useExistingPK && isRandomKeys) {
				dbmLog.DbmLogNum=ReplicationServers.GetKeyNoCache("dbmlog","DbmLogNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="DbmLogNum,";
			}
			command+="UserNum,FKey,FKeyType,ActionType,DateTimeEntry,MethodName,LogText) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(dbmLog.DbmLogNum)+",";
			}
			command+=
				     POut.Long  (dbmLog.UserNum)+","
				+    POut.Long  (dbmLog.FKey)+","
				+    POut.Int   ((int)dbmLog.FKeyType)+","
				+    POut.Int   ((int)dbmLog.ActionType)+","
				+    DbHelper.Now()+","
				+"'"+POut.String(dbmLog.MethodName)+"',"
				+    DbHelper.ParamChar+"paramLogText)";
			if(dbmLog.LogText==null) {
				dbmLog.LogText="";
			}
			OdSqlParameter paramLogText=new OdSqlParameter("paramLogText",OdDbType.Text,POut.StringParam(dbmLog.LogText));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramLogText);
			}
			else {
				dbmLog.DbmLogNum=Db.NonQ(command,true,"DbmLogNum","dbmLog",paramLogText);
			}
			return dbmLog.DbmLogNum;
		}

		///<summary>Updates one DbmLog in the database.</summary>
		public static void Update(DbmLog dbmLog) {
			string command="UPDATE dbmlog SET "
				+"UserNum      =  "+POut.Long  (dbmLog.UserNum)+", "
				+"FKey         =  "+POut.Long  (dbmLog.FKey)+", "
				+"FKeyType     =  "+POut.Int   ((int)dbmLog.FKeyType)+", "
				+"ActionType   =  "+POut.Int   ((int)dbmLog.ActionType)+", "
				//DateTimeEntry not allowed to change
				+"MethodName   = '"+POut.String(dbmLog.MethodName)+"', "
				+"LogText      =  "+DbHelper.ParamChar+"paramLogText "
				+"WHERE DbmLogNum = "+POut.Long(dbmLog.DbmLogNum);
			if(dbmLog.LogText==null) {
				dbmLog.LogText="";
			}
			OdSqlParameter paramLogText=new OdSqlParameter("paramLogText",OdDbType.Text,POut.StringParam(dbmLog.LogText));
			Db.NonQ(command,paramLogText);
		}

		///<summary>Updates one DbmLog in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(DbmLog dbmLog,DbmLog oldDbmLog) {
			string command="";
			if(dbmLog.UserNum != oldDbmLog.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(dbmLog.UserNum)+"";
			}
			if(dbmLog.FKey != oldDbmLog.FKey) {
				if(command!="") { command+=",";}
				command+="FKey = "+POut.Long(dbmLog.FKey)+"";
			}
			if(dbmLog.FKeyType != oldDbmLog.FKeyType) {
				if(command!="") { command+=",";}
				command+="FKeyType = "+POut.Int   ((int)dbmLog.FKeyType)+"";
			}
			if(dbmLog.ActionType != oldDbmLog.ActionType) {
				if(command!="") { command+=",";}
				command+="ActionType = "+POut.Int   ((int)dbmLog.ActionType)+"";
			}
			//DateTimeEntry not allowed to change
			if(dbmLog.MethodName != oldDbmLog.MethodName) {
				if(command!="") { command+=",";}
				command+="MethodName = '"+POut.String(dbmLog.MethodName)+"'";
			}
			if(dbmLog.LogText != oldDbmLog.LogText) {
				if(command!="") { command+=",";}
				command+="LogText = "+DbHelper.ParamChar+"paramLogText";
			}
			if(command=="") {
				return false;
			}
			if(dbmLog.LogText==null) {
				dbmLog.LogText="";
			}
			OdSqlParameter paramLogText=new OdSqlParameter("paramLogText",OdDbType.Text,POut.StringParam(dbmLog.LogText));
			command="UPDATE dbmlog SET "+command
				+" WHERE DbmLogNum = "+POut.Long(dbmLog.DbmLogNum);
			Db.NonQ(command,paramLogText);
			return true;
		}

		///<summary>Returns true if Update(DbmLog,DbmLog) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(DbmLog dbmLog,DbmLog oldDbmLog) {
			if(dbmLog.UserNum != oldDbmLog.UserNum) {
				return true;
			}
			if(dbmLog.FKey != oldDbmLog.FKey) {
				return true;
			}
			if(dbmLog.FKeyType != oldDbmLog.FKeyType) {
				return true;
			}
			if(dbmLog.ActionType != oldDbmLog.ActionType) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(dbmLog.MethodName != oldDbmLog.MethodName) {
				return true;
			}
			if(dbmLog.LogText != oldDbmLog.LogText) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one DbmLog from the database.</summary>
		public static void Delete(long dbmLogNum) {
			string command="DELETE FROM dbmlog "
				+"WHERE DbmLogNum = "+POut.Long(dbmLogNum);
			Db.NonQ(command);
		}

	}
}