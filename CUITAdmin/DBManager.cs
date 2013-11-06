/* TO-DO Take into account instrument increment 
 * 
 * 
 * 
 * 
 * 
 */



using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
namespace CUITAdmin
{
    class DBManager {

        static DBManager globalManager;

        private DBManager() {
            DBConnect();
        }



        public static DBManager Instance {
            get {
                if (globalManager == null) {
                    globalManager = new DBManager();
                    return globalManager;
                }
                return globalManager;
            }
        }

        ~DBManager(){

        }

        public SqlConnection DBConnect() {
            SqlConnection myConnection = new SqlConnection("Data Source=CUITS\\CUITS;" +
               "Initial Catalog=CUIT;" +
               "User ID=DataAdmin;" +
               "Password=JazBarne$411");
            try {
                myConnection.Open();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            return myConnection;
        }

        #region Add Functions

        // TESTED 11-4
        public void AddUser(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email,
            string username, string password, string department, string type, string notes, int contactID) {

            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "insertUser";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@firstName", firstName);
            myCommand.Parameters.AddWithValue("@lastName", lastName);
            myCommand.Parameters.AddWithValue("@street", street);
            myCommand.Parameters.AddWithValue("@city", city);
            myCommand.Parameters.AddWithValue("@state", state);
            myCommand.Parameters.AddWithValue("@zip", zip);
            myCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@userName", username);
            myCommand.Parameters.AddWithValue("@password", password);
            myCommand.Parameters.AddWithValue("@department", department);
            myCommand.Parameters.AddWithValue("@type", type);
            myCommand.Parameters.AddWithValue("@notes", notes);
            myCommand.Parameters.AddWithValue("@contactID", contactID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        // TESTED 11-4
        public void AddUserAccount(int personID, string accountNumber) {


            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT INTO User_Account (PersonID, Account_Number) " +
                                                  "VALUES (@personID, @accountNumber)", myConnection);

            myCommand.Parameters.AddWithValue("@personID", personID);
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }



        public void AddPointOfContact(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, string notes) {
            string throwaway;
            AddPointOfContact(firstName, lastName, street, city, state, zip, phoneNumber, email, notes, out throwaway);
        }
        public void AddPointOfContact(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, string notes, out string personID) {

            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "insertPointOfContact";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@firstName", firstName);
            myCommand.Parameters.AddWithValue("@lastName", lastName);
            myCommand.Parameters.AddWithValue("@street", street);
            myCommand.Parameters.AddWithValue("@city", city);
            myCommand.Parameters.AddWithValue("@state", state);
            myCommand.Parameters.AddWithValue("@zip", zip);
            myCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@notes", notes);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            personID = "";
            myConnection.Close();
        }

        // TESTED 11-4
        public void AddAccount(string accountNumber, string name, int maxChargeLimit, DateTime accountExpiration, string rateType, int managerID, 
            string notes, string costCenter, string wbsNumber, int balance, string street, string city, string state, int zip) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT into Account " +
            "(Account_Number, Name, Max_Charge_Limit, Account_Expiration, Rate_Type, PointOfContactID, Notes, Cost_Center, " +
            "WBS_Number, Balance, Street, City, State, Zip) " +

            "VALUES (@accountNumber, @name, @maxChargeLimit, @accountExpiration, @rateType, @pointOfContact, " +
            "@notes, @costCenter, @wbsNumber, @balance, @street, @city, @state, @zip)", myConnection);


            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@maxChargeLimit", maxChargeLimit);
            myCommand.Parameters.AddWithValue("@accountExpiration", accountExpiration);
            myCommand.Parameters.AddWithValue("@rateType", rateType);
            myCommand.Parameters.AddWithValue("@pointOfContact", managerID);
            myCommand.Parameters.AddWithValue("@notes", notes);
            myCommand.Parameters.AddWithValue("@costCenter", costCenter);
            myCommand.Parameters.AddWithValue("@wbsNumber", wbsNumber);
            myCommand.Parameters.AddWithValue("@balance", balance);
            myCommand.Parameters.AddWithValue("@street", street);
            myCommand.Parameters.AddWithValue("@city", city);
            myCommand.Parameters.AddWithValue("@state", state);
            myCommand.Parameters.AddWithValue("@zip", zip);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            myConnection.Close();

        }

        // TESTED 11-4
        public void AddPerson(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, string notes, bool isUser, bool isPointOfContact) {
            string throwaway;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, notes, isUser, isPointOfContact, out throwaway);
        }
        public void AddPerson(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, string notes, bool isUser, bool isPointOfContact, out string personID) {

            string personColumn = (isUser) ? ", IsUser" : ", IsPoint_of_Contact";
            string personParameter = (isUser) ? "@isUser" : "@isPointOfContact";

            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Person (First_Name, Last_Name, Street, City, State, Zip, Phone_Number, Email, Notes" + personColumn + ")" +
                "VALUES (@firstName, @lastName, @street, @city, @state, @zip, @phoneNumber, @email, @notes " + personParameter + ")" +
                "SELECT SCOPE_IDENTITY() As TheId",
                myConnection);



            myCommand.Parameters.AddWithValue("@firstName", firstName);
            myCommand.Parameters.AddWithValue("@lastName", lastName);
            myCommand.Parameters.AddWithValue("@street", street);
            myCommand.Parameters.AddWithValue("@city", city);
            myCommand.Parameters.AddWithValue("@state", state);
            myCommand.Parameters.AddWithValue("@zip", zip);
            myCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@notes", notes);

            myCommand.Parameters.AddWithValue(personParameter, 1);


            string newID = "";
            try {
                newID = myCommand.ExecuteScalar().ToString();
                Debug.WriteLine("Insert ID: " + newID);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            personID = newID;

            myConnection.Close();
        }

        public void AddSupply(string supplyName, int cost, string unit) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Supply(Supply_Name, Cost, Unit)" +
                "VALUES(@supplyName, @cost, @unit)", myConnection);

            myCommand.Parameters.AddWithValue("@supplyName", supplyName);
            myCommand.Parameters.AddWithValue("@cost", cost);
            myCommand.Parameters.AddWithValue("@unit", unit);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void AddSupplyUse(string accountNumber, string supplyName, DateTime date, int quantity) {
            Debug.WriteLine(date.ToString());
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "insertSupplyUse";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@Supply_Name", supplyName);
            myCommand.Parameters.AddWithValue("@Date", date);
            myCommand.Parameters.AddWithValue("@Quantity", quantity);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }


        public void AddTimeLog(string accountNumber, int userID, char approved, int instrumentID, DateTime startTime) {
            AddTimeLog(accountNumber, userID, approved, instrumentID, startTime, DateTime.Now, true);
        }

        public void AddTimeLog(string accountNumber, int userID, char approved, int instrumentID, DateTime startTime, DateTime endTime, bool partialLog = false) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "insertTimeLog";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@userID", userID);
            if(!(approved == ' ')) myCommand.Parameters.AddWithValue("@approved", approved);
            myCommand.Parameters.AddWithValue("@startTime", startTime);

            if (!partialLog) myCommand.Parameters.AddWithValue("@endTime", endTime);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void AddTimeLogEndTime(string accountNumber, int userID, int instrumentID, DateTime startTime, DateTime endTime) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "UPDATE Time_Log " +
                "SET End_Time = @endTime " +
                "WHERE Account_Number = @accountNumber and UserID = @userID and InstrumentID = @instrumentID and Start_Time = @startTime", myConnection);
            
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@userID", userID);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);
            myCommand.Parameters.AddWithValue("@startTime", startTime);
            myCommand.Parameters.AddWithValue("@endTime", endTime);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void AddInvoice(DateTime dateGenerated, DateTime postingStartDate, DateTime postingEndDate, string accountNumber, int totalBalance) {
            int throwaway;
            AddInvoice(dateGenerated, postingStartDate, postingEndDate, accountNumber, totalBalance, out throwaway);
        }

        public void AddInvoice(DateTime dateGenerated, DateTime postingStartDate, DateTime postingEndDate, string accountNumber, int totalBalance, out int invoiceID) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Invoice (Posting_Start_Date, Account_Number, Total_Balance, Posting_End_Date, Date_Generated) " +
                "VALUES(@postingStartDate, @accountNumber, @totalBalance, @postingEndDate, @dateGenerated)" +
                "SELECT SCOPE_IDENTITY() As TheId", myConnection);

            myCommand.Parameters.AddWithValue("@postingStartDate", postingStartDate);
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@totalBalance", totalBalance);
            myCommand.Parameters.AddWithValue("@postingEndDate", postingEndDate);
            myCommand.Parameters.AddWithValue("@dateGenerated", dateGenerated);


            int newID = 0;
            try {
                newID = int.Parse(myCommand.ExecuteScalar().ToString());
                Debug.WriteLine("Insert ID: " + newID);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            invoiceID = newID;

            myConnection.Close();
        }

        // TO-DO Test
        public void AddInvoiceSupplyLine(string supplyName, int lineAmount, int invoiceID) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Invoice_Supply_Line (Supply_Name, Line_Amount, InvoiceID)" +
                "VALUES (@supplyName, @lineAmount, @invoiceID)", myConnection);

            myCommand.Parameters.AddWithValue("@supplyName", supplyName);
            myCommand.Parameters.AddWithValue("@lineAmount", lineAmount);
            myCommand.Parameters.AddWithValue("@invoiceID", invoiceID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        // TO-DO test
        public void AddInvoiceTimeLine(string instrumentID, int hours, int lineAmount, int invoiceID) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Invoice_Time_Line(InstrumentID, Hours, Line_Amount, InvoiceID) " +
                "VALUES(@InstrumentID, @hours, @lineAmount, @invoiceID)", myConnection);

            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);
            myCommand.Parameters.AddWithValue("@hours", hours);
            myCommand.Parameters.AddWithValue("@lineAmount", lineAmount);
            myCommand.Parameters.AddWithValue("invoiceID", invoiceID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }


        public void AddRateType(string name) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Rate_Type(Name) " +
                "VALUES(@name)", myConnection);

            myCommand.Parameters.AddWithValue("@name", name);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void AddInstrument(string name, string billingUnit, int timeIncrement) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Instrument(Name, Billing_Unit, Time_Increment)" +
                "VALUES (@name, @billingUnit, @timeIncrement)",
                myConnection);

            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@billingUnit", billingUnit);
            myCommand.Parameters.AddWithValue("@timeIncrement", timeIncrement);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            myConnection.Close();
        }

        public void AddInstrumentRate(string rateName, int rate, int instrumentID) {

            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Instrument_Rate (Rate_Name, Rate, InstrumentID)" +
                "VALUES (@rateName, @rate, @instrumentID)",
                myConnection);

            myCommand.Parameters.AddWithValue("@rateName", rateName);
            myCommand.Parameters.AddWithValue("@rate", rate);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            myConnection.Close();
        }

        #endregion //End Add Region


        public bool CheckPassword(string username, string password) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "SELECT COUNT(Username) FROM Users " +
                "WHERE Username = @username AND Password = @password", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);
            myCommand.Parameters.AddWithValue("@password", password);
            
            int count = 0;

            try {
                count = (int) myCommand.ExecuteScalar();
            } catch (Exception e){
                Debug.Write(e.ToString());
            }

            myConnection.Close();
            return (count == 1);
        }


        #region Get Functions
        
        public int GetUserID(string username) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT PersonID FROM Users " +
                                                  "WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);

            int personID = 0;

            try {
                personID = int.Parse(myCommand.ExecuteScalar().ToString());
            } catch (Exception e) {
                Debug.Write(e.ToString());
            }

            myConnection.Close();
            return personID;
        }

        public bool GetServerDateTime(out DateTime serverTime) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT GETDATE()", myConnection);

            serverTime = DateTime.Now;
            try {
                serverTime = (DateTime)myCommand.ExecuteScalar();
            } catch (Exception e) {
                Debug.Write(e.ToString());
                myConnection.Close();
                return false;
            }

            myConnection.Close();
            return true;
        }

        public DataTable GetAccounts() {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT Account_Number, Name, Max_Charge_Limit, Balance, First_Name, Last_Name FROM Account acct left outer join Point_of_Contact poc on acct.PointOfContactID = poc.PersonID left outer join Person psn on poc.PersonID = psn.PersonID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public List<string> GetAccountNumberList() {

            SqlDataReader myReader = null;
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT Account_Number FROM Account", myConnection);

            try {
                myReader = myCommand.ExecuteReader();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            List<string> accounts = new List<string>();

            while (myReader.Read()) {
                accounts.Add(myReader["Account_Number"].ToString());
            }

            myConnection.Close();
            return accounts;

        }

        public DataTable GetInstruments() {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT Name, Billing_Unit, Time_Increment, InstrumentID FROM Instrument";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetSupplies() {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT * FROM Supply";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetTimeLogs(string accountNumber, DateTime startDate, DateTime endDate, bool acceptNull = false) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "Select tl.Account_Number, acct.Name, i.InstrumentID, i.Name, tl.Start_Time, tl.End_Time, tl.Current_Rate, tl.Time_Increment " +
                "From Time_Log tl INNER JOIN Account acct on tl.Account_Number = acct.Account_Number INNER JOIN Instrument i on tl.InstrumentID = i.InstrumentID " +
                "WHERE tl.Account_Number = @accountNumber and tl.Start_Time between @startDate and @endDate" + ((!acceptNull) ? " and tl.End_Time IS NOT NULL" : "")
                , myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@startDate", startDate);
            myCommand.Parameters.AddWithValue("@endDate", endDate);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetTimeLogsExceptions() {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "Select u.Username, acct.Name as Account_Name, i.Name as Instrument_Name, tl.Start_Time, tl.End_Time, tl.Approved, tl.Account_Number, i.InstrumentID, tl.Current_Rate " +
                "From Users u INNER JOIN Time_Log tl on u.PersonID = tl.UserID INNER JOIN Account acct on tl.Account_Number = acct.Account_Number INNER JOIN Instrument i on tl.InstrumentID = i.InstrumentID " +
                "WHERE tl.End_Time IS NULL OR tl.Approved IS NULL", myConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }
        
        public DataTable GetSupplyUse(string accountNumber, DateTime startDate, DateTime endDate) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "Select su.Account_Number, su.Supply_Name, su.Quantity, su.Current_Cost " +
                "FROM Supply_Use su Inner JOIN Account acct on su.Account_Number = acct.Account_Number " +
                "WHERE su.Date Between @startDate and @endDate and su.Account_Number = @accountNumber", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@startDate", startDate);
            myCommand.Parameters.AddWithValue("@endDate", endDate);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetUsers() {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT First_Name, Last_Name, Username, psn.PersonID, Department FROM Users usr left outer join Person psn on usr.PersonID = psn.PersonID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetInvoice(string accountNumber) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT * From Invoice Where Account_Number = @accountNumber", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetContacts() {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT First_Name, Last_Name, psn.PersonID, Email FROM Point_of_Contact poc left outer join Person psn on poc.PersonID = psn.PersonID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetUserAccounts(string username) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("SELECT ua.Account_Number, a.Name FROM User_Account ua INNER JOIN Users u on ua.PersonID = u.PersonID INNER JOIN Account a on ua.Account_Number = a.Account_Number WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);


            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public BindingList<Data> GetInstrumentsData() {
            SqlDataReader myReader = null;
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Instrument", myConnection);

            try {
                myReader = myCommand.ExecuteReader();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            BindingList<Data> instruments = new BindingList<Data>();

            while (myReader.Read()) {
                instruments.Add(new Data {
                    Value = myReader["InstrumentID"].ToString(),
                    Name = myReader["Name"].ToString()
                }
                );
            }

            myConnection.Close();
            return instruments;
        }
        
        #endregion End Get Region


        public void GenerateAllInvoices(string accountNumber, DateTime startDate, DateTime endDate) {

            DataTable timeLogs = GetTimeLogs(accountNumber, startDate, endDate, false);

            DataRowCollection rows = timeLogs.Rows;

            List<Invoice> invoices = new List<Invoice>();



            // Loop through all timelogs in the data table
            foreach (DataRow currentRow in rows) {

                Invoice invoiceToUpdate = null;
                InvoiceInstrumentLine instrumentToUpdate = null;
                bool foundFlag = false;


                // Check if an invoice with the current account number has already been generated for the account in the current row
                foreach (Invoice currentInvoice in invoices) {
                    if (currentRow["Account_Number"].ToString() == currentInvoice.accountNumber) {
                        invoiceToUpdate = currentInvoice;
                        foundFlag = true;
                        break;
                    }
                }

                // If there was no invoice, create one.
                if (!foundFlag) {

                    invoiceToUpdate = new Invoice {
                        accountNumber = currentRow["Account_Number"].ToString(),
                        accountName = currentRow["Name"].ToString(),
                        instrumets = new List<InvoiceInstrumentLine>(),
                        supplies = new List<InvoiceSupplyLine>(),
                        dateGenerated = DateTime.Now
                    };

                    DateTime startTime = (DateTime)currentRow["Start_Time"];
                    DateTime endTime = (DateTime)currentRow["End_Time"];
                    TimeSpan duration = endTime - startTime;


                    instrumentToUpdate = new InvoiceInstrumentLine {
                        name = currentRow["Name1"].ToString(),
                        id = (int)currentRow["InstrumentID"],
                        hours = duration.TotalHours,
                        rate = (double)currentRow["Current_Rate"],
                    };

                    invoices.Add(invoiceToUpdate);
                }

                foundFlag = false;



                foreach (InvoiceInstrumentLine currentInstrument in invoiceToUpdate.instrumets) {
                    if (currentInstrument.id == (int)currentRow["InstrumentID"] &&
                        currentInstrument.rate == (double)currentRow["InstrumentID"]) {
                        instrumentToUpdate = currentInstrument;
                        foundFlag = true;
                        break;
                    }
                }

                if (!foundFlag) {
                    instrumentToUpdate = new InvoiceInstrumentLine();
                }


            }
        }

        public bool GenerateInvoice(string accountNumber, DateTime startDate, DateTime endDate) {

            // Create an invoice for the account and set it's values, this will be used to build an SQL Query later
            Invoice invoice = new Invoice();
            invoice.accountNumber = accountNumber;
            invoice.dateGenerated = DateTime.Now;
            invoice.totalBalance = 0;

            // Initialize and populate the lines that will represent a line item billing for an instrument
            invoice.instrumets = new List<InvoiceInstrumentLine>();
            DataTable timeLogs = GetTimeLogs(accountNumber, startDate, endDate, false);
            GenerateInvoiceInstrumentLines(invoice, timeLogs);

            // Initialize and populate the lines that will represent a line item billing for a supply
            invoice.supplies = new List<InvoiceSupplyLine>();
            DataTable supplyUses = GetSupplyUse(accountNumber, startDate, endDate);
            GenerateInvoiceSupplyLines(invoice, supplyUses);

            // Set up a datatable that will be passed back to the server to be added
            DataTable invoiceTimeLine = new DataTable();
            invoiceTimeLine.Columns.Add("InstrumentID");
            invoiceTimeLine.Columns.Add("Hours");
            invoiceTimeLine.Columns.Add("Line_Amount");
            invoiceTimeLine.Columns.Add("InvoiceID");
            invoiceTimeLine.Columns.Add("Rate");

            // Set up a datatable that will be passed back to the server to be added
            DataTable invoiceSupplyLine = new DataTable();
            invoiceSupplyLine.Columns.Add("Supply_Name");
            invoiceSupplyLine.Columns.Add("Line_Amount");
            invoiceSupplyLine.Columns.Add("InvoiceID");
            invoiceSupplyLine.Columns.Add("Cost");
            invoiceSupplyLine.Columns.Add("Quantity");

            if (invoice.supplies.Count == 0 && invoice.instrumets.Count == 0) return false;

            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Invoice (Posting_Start_Date, Posting_End_Date, Account_Number, Total_Balance, Date_Generated) " +
                "VALUES (@postingStartDate, @postingEndDate, @accountNumber, @totalBalance, @dateGenerated) " + 
                "SELECT SCOPE_IDENTITY() As TheId",
                myConnection);



            myCommand.Parameters.AddWithValue("@postingStartDate", startDate);
            myCommand.Parameters.AddWithValue("@postingEndDate", endDate);
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@totalBalance", invoice.totalBalance);
            myCommand.Parameters.AddWithValue("@dateGenerated", DateTime.Now);

            string newID = "";
            try {
                newID = myCommand.ExecuteScalar().ToString();
                Debug.WriteLine("Insert ID: " + newID);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            int invoiceID;
            if(!int.TryParse(newID,out invoiceID)) return false;

            // Go through each instrument line object and add it to the table to send
            foreach (InvoiceInstrumentLine currentInstrumentLine in invoice.instrumets) {
                invoiceTimeLine.Rows.Add(
                    currentInstrumentLine.id,
                    currentInstrumentLine.hours,
                    currentInstrumentLine.charges,
                    invoiceID,
                    currentInstrumentLine.rate
                    );
            } 

            // Go through each supply line object and add it to the table to send
            foreach (InvoiceSupplyLine currentSupplyLine in invoice.supplies) {
                invoiceSupplyLine.Rows.Add(
                    currentSupplyLine.name,
                    currentSupplyLine.charges,
                    invoiceID,
                    currentSupplyLine.currentCost,
                    currentSupplyLine.quantity
                    );
            }

            SendDataTable(invoiceTimeLine, "Invoice_Time_Line");
            SendDataTable(invoiceSupplyLine, "Invoice_Supply_Line");

            return true;
        }

        

        private void GenerateInvoiceInstrumentLines(Invoice invoice, DataTable timeLogs) {

            DataRowCollection rows = timeLogs.Rows;
            foreach (DataRow currentRow in rows) {
                InvoiceInstrumentLine instrumentToUpdate = null;
                bool foundFlag = false;

                DateTime startTime = (DateTime)currentRow["Start_Time"];
                DateTime endTime = (DateTime)currentRow["End_Time"];
                TimeSpan duration = endTime - startTime;


                foreach (InvoiceInstrumentLine currentInstrument in invoice.instrumets) {
                    if (currentInstrument.id == Convert.ToInt32(currentRow["InstrumentID"]) &&
                        currentInstrument.rate == Convert.ToDouble(currentRow["Current_Rate"]) &&
                        currentInstrument.timeIncrement == Convert.ToInt32(currentRow["Time_Increment"])) {
                        instrumentToUpdate = currentInstrument;
                        foundFlag = true;
                        break;
                    }
                }


                if (!foundFlag) {
                    instrumentToUpdate = new InvoiceInstrumentLine();
                    instrumentToUpdate.name = currentRow["Name1"].ToString();
                    instrumentToUpdate.id = Convert.ToInt32(currentRow["InstrumentID"]);
                    instrumentToUpdate.hours = duration.TotalHours;
                    instrumentToUpdate.rate = Convert.ToDouble(currentRow["Current_Rate"]);
                    instrumentToUpdate.timeIncrement = Convert.ToInt32(currentRow["Time_Increment"]);
                    invoice.instrumets.Add(instrumentToUpdate);
                } else {
                    instrumentToUpdate.hours += duration.TotalHours;
                }


                
            }

            foreach (InvoiceInstrumentLine currentLine in invoice.instrumets) {
                currentLine.charges = (currentLine.hours * 60) / currentLine.timeIncrement * currentLine.rate;
                invoice.totalBalance += currentLine.charges;
            }

        }

        private void GenerateInvoiceSupplyLines(Invoice invoice, DataTable supplyUses) {

            DataRowCollection rows = supplyUses.Rows;
            InvoiceSupplyLine supplyToUpdate = null;

            foreach (DataRow currentRow in rows) {

                bool foundFlag = false;

                foreach (InvoiceSupplyLine currentSupply in invoice.supplies) {
                    if (currentSupply.name == currentRow["Supply_Name"].ToString() &&
                        currentSupply.currentCost == Convert.ToDouble(currentRow["Current_Cost"])) 
                    {
                        supplyToUpdate = currentSupply;
                        foundFlag = true;
                        break;
                    }
                }


                if (!foundFlag) {
                    supplyToUpdate = new InvoiceSupplyLine {
                        name = currentRow["Supply_Name"].ToString(),
                        quantity = Convert.ToDouble(currentRow["Quantity"]),
                        currentCost = Convert.ToDouble(currentRow["Current_Cost"])
                    };
                    invoice.supplies.Add(supplyToUpdate);
                } else {
                    supplyToUpdate.quantity += Convert.ToDouble(currentRow["Quantity"]);
                }
            }

            foreach (InvoiceSupplyLine currentLine in invoice.supplies) {
                currentLine.charges = currentLine.currentCost * currentLine.quantity;
                invoice.totalBalance += currentLine.charges;
            }
        }


        public void SendDataTable(DataTable tableToSend, string destinationTable) {

            SqlConnection myConnection = DBConnect();

            SqlBulkCopy bulkCopy = new SqlBulkCopy(myConnection);

            bulkCopy.DestinationTableName = destinationTable;

            try {
                bulkCopy.WriteToServer(tableToSend);
            } catch (Exception e) {
                Debug.Write(e.ToString());
            }
        }
        
        #region Invoice Classes
        
        private class Invoice {
            public string accountNumber { get; set; }
            public string accountName { get; set; }
            public List<InvoiceInstrumentLine> instrumets { get; set; }
            public List<InvoiceSupplyLine> supplies { get; set; }
            public DateTime dateGenerated { get; set; }
            public double totalBalance { get; set; }
        }

        private class InvoiceSupplyLine {
            public string name { get; set; }
            public double currentCost { get; set; }
            public double quantity { get; set; }
            public double charges { get; set; }
        }

        private class InvoiceInstrumentLine {
            public string name { get; set; }
            public int id { get; set; }
            public double hours { get; set; }
            public double charges { get; set; }
            public double rate { get; set; }
            public int timeIncrement { get; set; }
        }
        #endregion
    }
}
