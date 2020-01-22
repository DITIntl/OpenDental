//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class AlertItemCrud {
		///<summary>Gets one AlertItem object from the database using the primary key.  Returns null if not found.</summary>
		public static AlertItem SelectOne(long alertItemNum) {
			string command="SELECT * FROM alertitem "
				+"WHERE AlertItemNum = "+POut.Long(alertItemNum);
			List<AlertItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one AlertItem object from the database using a query.</summary>
		public static AlertItem SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<AlertItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of AlertItem objects from the database using a query.</summary>
		public static List<AlertItem> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<AlertItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<AlertItem> TableToList(DataTable table) {
			List<AlertItem> retVal=new List<AlertItem>();
			AlertItem alertItem;
			foreach(DataRow row in table.Rows) {
				alertItem=new AlertItem();
				alertItem.AlertItemNum= PIn.Long  (row["AlertItemNum"].ToString());
				alertItem.ClinicNum   = PIn.Long  (row["ClinicNum"].ToString());
				alertItem.Description = PIn.String(row["Description"].ToString());
				alertItem.Type        = (OpenDentBusiness.AlertType)PIn.Int(row["Type"].ToString());
				alertItem.Severity    = (OpenDentBusiness.SeverityType)PIn.Int(row["Severity"].ToString());
				alertItem.Actions     = (OpenDentBusiness.ActionType)PIn.Int(row["Actions"].ToString());
				alertItem.FormToOpen  = (OpenDentBusiness.FormType)PIn.Int(row["FormToOpen"].ToString());
				alertItem.FKey        = PIn.Long  (row["FKey"].ToString());
				alertItem.ItemValue   = PIn.String(row["ItemValue"].ToString());
				alertItem.UserNum     = PIn.Long  (row["UserNum"].ToString());
				retVal.Add(alertItem);
			}
			return retVal;
		}

		///<summary>Converts a list of AlertItem into a DataTable.</summary>
		public static DataTable ListToTable(List<AlertItem> listAlertItems,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="AlertItem";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AlertItemNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("Description");
			table.Columns.Add("Type");
			table.Columns.Add("Severity");
			table.Columns.Add("Actions");
			table.Columns.Add("FormToOpen");
			table.Columns.Add("FKey");
			table.Columns.Add("ItemValue");
			table.Columns.Add("UserNum");
			foreach(AlertItem alertItem in listAlertItems) {
				table.Rows.Add(new object[] {
					POut.Long  (alertItem.AlertItemNum),
					POut.Long  (alertItem.ClinicNum),
					            alertItem.Description,
					POut.Int   ((int)alertItem.Type),
					POut.Int   ((int)alertItem.Severity),
					POut.Int   ((int)alertItem.Actions),
					POut.Int   ((int)alertItem.FormToOpen),
					POut.Long  (alertItem.FKey),
					            alertItem.ItemValue,
					POut.Long  (alertItem.UserNum),
				});
			}
			return table;
		}

		///<summary>Inserts one AlertItem into the database.  Returns the new priKey.</summary>
		public static long Insert(AlertItem alertItem) {
			return Insert(alertItem,false);
		}

		///<summary>Inserts one AlertItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(AlertItem alertItem,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				alertItem.AlertItemNum=ReplicationServers.GetKey("alertitem","AlertItemNum");
			}
			string command="INSERT INTO alertitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AlertItemNum,";
			}
			command+="ClinicNum,Description,Type,Severity,Actions,FormToOpen,FKey,ItemValue,UserNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(alertItem.AlertItemNum)+",";
			}
			command+=
				     POut.Long  (alertItem.ClinicNum)+","
				+"'"+POut.String(alertItem.Description)+"',"
				+    POut.Int   ((int)alertItem.Type)+","
				+    POut.Int   ((int)alertItem.Severity)+","
				+    POut.Int   ((int)alertItem.Actions)+","
				+    POut.Int   ((int)alertItem.FormToOpen)+","
				+    POut.Long  (alertItem.FKey)+","
				+"'"+POut.String(alertItem.ItemValue)+"',"
				+    POut.Long  (alertItem.UserNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				alertItem.AlertItemNum=Db.NonQ(command,true,"AlertItemNum","alertItem");
			}
			return alertItem.AlertItemNum;
		}

		///<summary>Inserts one AlertItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AlertItem alertItem) {
			return InsertNoCache(alertItem,false);
		}

		///<summary>Inserts one AlertItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AlertItem alertItem,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO alertitem (";
			if(!useExistingPK && isRandomKeys) {
				alertItem.AlertItemNum=ReplicationServers.GetKeyNoCache("alertitem","AlertItemNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="AlertItemNum,";
			}
			command+="ClinicNum,Description,Type,Severity,Actions,FormToOpen,FKey,ItemValue,UserNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(alertItem.AlertItemNum)+",";
			}
			command+=
				     POut.Long  (alertItem.ClinicNum)+","
				+"'"+POut.String(alertItem.Description)+"',"
				+    POut.Int   ((int)alertItem.Type)+","
				+    POut.Int   ((int)alertItem.Severity)+","
				+    POut.Int   ((int)alertItem.Actions)+","
				+    POut.Int   ((int)alertItem.FormToOpen)+","
				+    POut.Long  (alertItem.FKey)+","
				+"'"+POut.String(alertItem.ItemValue)+"',"
				+    POut.Long  (alertItem.UserNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				alertItem.AlertItemNum=Db.NonQ(command,true,"AlertItemNum","alertItem");
			}
			return alertItem.AlertItemNum;
		}

		///<summary>Updates one AlertItem in the database.</summary>
		public static void Update(AlertItem alertItem) {
			string command="UPDATE alertitem SET "
				+"ClinicNum   =  "+POut.Long  (alertItem.ClinicNum)+", "
				+"Description = '"+POut.String(alertItem.Description)+"', "
				+"Type        =  "+POut.Int   ((int)alertItem.Type)+", "
				+"Severity    =  "+POut.Int   ((int)alertItem.Severity)+", "
				+"Actions     =  "+POut.Int   ((int)alertItem.Actions)+", "
				+"FormToOpen  =  "+POut.Int   ((int)alertItem.FormToOpen)+", "
				+"FKey        =  "+POut.Long  (alertItem.FKey)+", "
				+"ItemValue   = '"+POut.String(alertItem.ItemValue)+"', "
				+"UserNum     =  "+POut.Long  (alertItem.UserNum)+" "
				+"WHERE AlertItemNum = "+POut.Long(alertItem.AlertItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one AlertItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(AlertItem alertItem,AlertItem oldAlertItem) {
			string command="";
			if(alertItem.ClinicNum != oldAlertItem.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(alertItem.ClinicNum)+"";
			}
			if(alertItem.Description != oldAlertItem.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(alertItem.Description)+"'";
			}
			if(alertItem.Type != oldAlertItem.Type) {
				if(command!="") { command+=",";}
				command+="Type = "+POut.Int   ((int)alertItem.Type)+"";
			}
			if(alertItem.Severity != oldAlertItem.Severity) {
				if(command!="") { command+=",";}
				command+="Severity = "+POut.Int   ((int)alertItem.Severity)+"";
			}
			if(alertItem.Actions != oldAlertItem.Actions) {
				if(command!="") { command+=",";}
				command+="Actions = "+POut.Int   ((int)alertItem.Actions)+"";
			}
			if(alertItem.FormToOpen != oldAlertItem.FormToOpen) {
				if(command!="") { command+=",";}
				command+="FormToOpen = "+POut.Int   ((int)alertItem.FormToOpen)+"";
			}
			if(alertItem.FKey != oldAlertItem.FKey) {
				if(command!="") { command+=",";}
				command+="FKey = "+POut.Long(alertItem.FKey)+"";
			}
			if(alertItem.ItemValue != oldAlertItem.ItemValue) {
				if(command!="") { command+=",";}
				command+="ItemValue = '"+POut.String(alertItem.ItemValue)+"'";
			}
			if(alertItem.UserNum != oldAlertItem.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(alertItem.UserNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE alertitem SET "+command
				+" WHERE AlertItemNum = "+POut.Long(alertItem.AlertItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(AlertItem,AlertItem) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(AlertItem alertItem,AlertItem oldAlertItem) {
			if(alertItem.ClinicNum != oldAlertItem.ClinicNum) {
				return true;
			}
			if(alertItem.Description != oldAlertItem.Description) {
				return true;
			}
			if(alertItem.Type != oldAlertItem.Type) {
				return true;
			}
			if(alertItem.Severity != oldAlertItem.Severity) {
				return true;
			}
			if(alertItem.Actions != oldAlertItem.Actions) {
				return true;
			}
			if(alertItem.FormToOpen != oldAlertItem.FormToOpen) {
				return true;
			}
			if(alertItem.FKey != oldAlertItem.FKey) {
				return true;
			}
			if(alertItem.ItemValue != oldAlertItem.ItemValue) {
				return true;
			}
			if(alertItem.UserNum != oldAlertItem.UserNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one AlertItem from the database.</summary>
		public static void Delete(long alertItemNum) {
			string command="DELETE FROM alertitem "
				+"WHERE AlertItemNum = "+POut.Long(alertItemNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<AlertItem> listNew,List<AlertItem> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<AlertItem> listIns    =new List<AlertItem>();
			List<AlertItem> listUpdNew =new List<AlertItem>();
			List<AlertItem> listUpdDB  =new List<AlertItem>();
			List<AlertItem> listDel    =new List<AlertItem>();
			listNew.Sort((AlertItem x,AlertItem y) => { return x.AlertItemNum.CompareTo(y.AlertItemNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((AlertItem x,AlertItem y) => { return x.AlertItemNum.CompareTo(y.AlertItemNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			AlertItem fieldNew;
			AlertItem fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.AlertItemNum<fieldDB.AlertItemNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.AlertItemNum>fieldDB.AlertItemNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])) {
					rowsUpdatedCount++;
				}
			}
			for(int i=0;i<listDel.Count;i++) {
				Delete(listDel[i].AlertItemNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}