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
using System.Windows.Forms;
using CUITAdmin.Properties;

namespace CUITAdmin
{
    class DBManager {

        static DBManager globalManager;
        private frmCUITAdminMain mainForm;


        private DBManager() {
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
                if (mainForm != null && Settings.Default.FullScreen) {
                    mainForm.UnbindFormClosingEvent();
                }

                Debug.WriteLine(e.Message);
                DialogResult dialogResult = MessageBox.Show("There was an error connecting to the server, please try again or contact your system administrator.\r\n\r\n" + 
                                                            "Would you like to go into offline mode?", "Error", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    Properties.Settings.Default.StandaloneMode = true;
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    Application.Exit();
                } else if (dialogResult == DialogResult.No) {
                    Application.Exit();
                }
                return null;
            }
            return myConnection;
        }

        #region Add Functions


        public void AddUser(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email,
            string username, string password, string department, string type, string notes, int contactID)
        {
            int throwaway;
            AddUser(firstName, lastName, street, city, state, zip, phoneNumber, email,
             username, password, department, type, notes, contactID, out throwaway);
        }

        // TESTED 11-4
        public void AddUser(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email,
            string username, string password, string department, string type, string notes, int contactID, out int personID) {

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

            password = PasswordHash.getHashSha512(password);

            myCommand.Parameters.AddWithValue("@password", password);
            myCommand.Parameters.AddWithValue("@department", department);
            myCommand.Parameters.AddWithValue("@type", type);
            myCommand.Parameters.AddWithValue("@notes", notes);
            SqlParameter returnValue = myCommand.Parameters.Add("@personID", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.Output;
            
            if (contactID > 0) myCommand.Parameters.AddWithValue("@contactID", contactID);

            try {
                myCommand.ExecuteNonQuery();
                personID = int.Parse(myCommand.Parameters["@personID"].Value.ToString());
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                personID = 0;
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

        public void AddUserAccounts(DataTable userAccounts)
        {
            SendDataTable(userAccounts, "User_Account");
        }

        public void AddAccountInstrument(string accountNumber, string instrumentID)
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT INTO Account_Instrument (Account_Number, InstrumentID) " +
                                                  "VALUES (@accountNumber, @instrumentID)", myConnection);

           
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void AddAccountInstruments(DataTable accountInstruments)
        {
            SendDataTable(accountInstruments, "Account_Instrument");
        }

        public void AddUserInstrument(int personID, string instrumentID)
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT INTO User_Instrument (PersonID, InstrumentID) " +
                                                  "VALUES (@personID, @instrumentID)", myConnection);

            myCommand.Parameters.AddWithValue("@personID", personID);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void addUserInstruments(DataTable userInstruments)
        {
            SendDataTable(userInstruments, "User_Instrument");
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
        public void AddAccount(string accountNumber, string name, double maxChargeLimit, DateTime accountExpiration, string rateType, int managerID, 
            string notes, string costCenter, string wbsNumber, double balance, string street, string city, string state, int zip, string taxID) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT into Account " +
            "(Account_Number, Name, Max_Charge_Limit, Account_Expiration, Rate_Type, PointOfContactID, Notes, Cost_Center, " +
            "WBS_Number, Balance, Street, City, State, Zip, Tax_ID, Active) " +

            "VALUES (@accountNumber, @name, @maxChargeLimit, @accountExpiration, @rateType, @pointOfContact, " +
            "@notes, @costCenter, @wbsNumber, @balance, @street, @city, @state, @zip, @taxID, @active)", myConnection);


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
            myCommand.Parameters.AddWithValue("@taxID", taxID);
            myCommand.Parameters.AddWithValue("@active", 'Y');

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
            string personParameter = (isUser) ? ((isUser) ? "@isUser" : "@isPointofContact") : ((isUser) ? "@isUser" : "@isPointofContact");

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

        public void AddSupply(string supplyName, double cost, string unit) {
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

        public bool AddSupplyUse(string accountNumber, string supplyName, DateTime date, int quantity, bool approved = false) {
            Debug.WriteLine(date.ToString());
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "insertSupplyUse";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@Supply_Name", supplyName);
            myCommand.Parameters.AddWithValue("@Date", date);
            if (approved) myCommand.Parameters.AddWithValue("@Approved", 'Y');
            myCommand.Parameters.AddWithValue("@Quantity", quantity);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                return false;
            }

            myConnection.Close();

            return true;
        }

        public bool AddSupplyUseBulk(DataTable supplyUses) {
            bool returnBool = true;
            try {
                returnBool = SendDataTable(supplyUses, "Supply_Use");
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return returnBool;
        }

        public bool AddTimeLog(string accountNumber, int userID, char approved, int instrumentID, DateTime startTime) {
            return AddTimeLog(accountNumber, userID, approved, instrumentID, startTime, DateTime.Now, true);
        }

        public bool AddTimeLog(string accountNumber, int userID, char approved, int instrumentID, DateTime startTime, DateTime endTime, bool partialLog = false) {
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
                return false;
            }

            myConnection.Close();
            return true;
        }

        public void AddTimeLogEndTime(string accountNumber, int userID, int instrumentID, DateTime startTime, DateTime endTime) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "UPDATE Time_Log " +
                "SET End_Time = @endTime, Approved = 'Y'" +
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
       
        public bool AddTimeLogBulk(DataTable timeLogs) {      
            bool returnBool = true;
            try {
                returnBool = SendDataTable(timeLogs, "Time_Log");
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return returnBool;
        }

        public void AddInvoice(DateTime dateGenerated, DateTime postingStartDate, DateTime postingEndDate, string accountNumber, double totalBalance) {
            int throwaway;
            AddInvoice(dateGenerated, postingStartDate, postingEndDate, accountNumber, totalBalance, out throwaway);
        }

        public void AddInvoice(DateTime dateGenerated, DateTime postingStartDate, DateTime postingEndDate, string accountNumber, double totalBalance, out int invoiceID) {
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
        public void AddInvoiceSupplyLine(string supplyName, double lineAmount, int invoiceID) {
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
        public void AddInvoiceTimeLine(string instrumentID, double hours, double lineAmount, int invoiceID) {
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

        public void AddInstrument(string name, string billingUnit, int timeIncrement)
        {
            int throwaway;
            AddInstrument(name, billingUnit, timeIncrement, out throwaway);
        }

        public void AddInstrument(string name, string billingUnit, int timeIncrement, out int instrumentID) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Instrument(Name, Billing_Unit, Time_Increment)" +
                "VALUES (@name, @billingUnit, @timeIncrement)" +
                "SELECT SCOPE_IDENTITY() As TheId",
                myConnection);

            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@billingUnit", billingUnit);
            myCommand.Parameters.AddWithValue("@timeIncrement", timeIncrement);

            int newID = 0;
            try
            {
                newID = int.Parse(myCommand.ExecuteScalar().ToString());
                Debug.WriteLine("Insert ID: " + newID);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            instrumentID = newID;
            myConnection.Close();
        }

        public void AddInstrumentRate(string rateName, double rate, int instrumentID) {

            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Instrument_Rate (Rate_Type, Rate, InstrumentID)" +
                "VALUES (@rateType, @rate, @instrumentID)",
                myConnection);

            myCommand.Parameters.AddWithValue("@rateType", rateName);
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

        public char GetUserType(string username) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT Type FROM Users " +
                                                  "WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);

            char userType = 'U';

            try {
                userType = Convert.ToChar(myCommand.ExecuteScalar());
            } catch (Exception e) {
                Debug.Write(e.ToString());
            }

            myConnection.Close();
            return userType;
        }

        public bool CheckPassword(string username, string password) {

            password = PasswordHash.getHashSha512(password);

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

        public bool CheckUsername(string username)
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "SELECT COUNT(Username) FROM Users " +
                "WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);

            int count = 0;

            try
            {
                count = (int)myCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }

            myConnection.Close();
            return (count == 0);
        }

        public bool CheckAccountNumber(string accountNumber)
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "SELECT COUNT(Account_Number) FROM Account " +
                "WHERE Account_Number = @accountNumber", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

            int count = 0;

            try
            {
                count = (int)myCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }

            myConnection.Close();
            return (count == 0);
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

        public DataTable GetAccount(string accountNumber)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null)
            {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "SELECT * FROM Account WHERE Account_Number = @accountNumber", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetAccounts() {
            return GetAccounts(false);
        }

        public DataTable GetAccounts(bool includeInvalid) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }
            //Account_Number, Name, Max_Charge_Limit, Balance, First_Name, Last_Name
            string myCommand = "SELECT * FROM Account" + ((includeInvalid) ? "" : " WHERE Account_Expiration > GETDATE() and Active = 'Y'");
            
            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        // TO-DO: not used, we should remove this if we don't actually need it
        public DataTable GetAccountsForExport()
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            //Account_Number, Name, Max_Charge_Limit, Balance, First_Name, Last_Name
            string myCommand = "SELECT * FROM Account acct left outer join Point_of_Contact poc on acct.PointOfContactID = poc.PersonID left outer join Person psn on poc.PersonID = psn.PersonID " +
                                "WHERE acct.Account_Expiration > GETDATE()";
            
            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

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

        public DataTable GetInstruments(bool excludePerUse = false) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT Name, Billing_Unit, Time_Increment, InstrumentID FROM Instrument" + 
                ((excludePerUse) ? " Where Billing_Unit != 'Per Use'" : "");

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetSupply(string supplyName) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT * FROM Supply WHERE Supply_Name = @supplyName", myConnection);

            myCommand.Parameters.AddWithValue("@supplyName", supplyName);

            DataTable table = new DataTable();
            try {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetSupplies() {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT * FROM Supply";

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetTimeLogsFromRange(DateTime startDate, DateTime endDate, bool acceptNull = false)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "Select tl.Account_Number, acct.Name, i.InstrumentID, i.Name, tl.Start_Time, tl.End_Time, tl.Current_Rate, tl.Time_Increment " +
                "From Time_Log tl INNER JOIN Account acct on tl.Account_Number = acct.Account_Number INNER JOIN Instrument i on tl.InstrumentID = i.InstrumentID " +
                "WHERE tl.Start_Time between @startDate and @endDate" + ((!acceptNull) ? " and tl.End_Time IS NOT NULL" : "")
                , myConnection);

            myCommand.Parameters.AddWithValue("@startDate", startDate);
            myCommand.Parameters.AddWithValue("@endDate", endDate);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetUnbilledTimeLogs(string accountNumber, DateTime startDate, DateTime endDate, bool includeExceptions = false) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "Select tl.Account_Number, tl.UserID, acct.Name, i.InstrumentID, i.Name, tl.Start_Time, tl.End_Time, tl.Current_Rate, tl.Time_Increment, i.Billing_Unit " +
                "From Time_Log tl INNER JOIN Account acct on tl.Account_Number = acct.Account_Number INNER JOIN Instrument i on tl.InstrumentID = i.InstrumentID " +
                "WHERE tl.Account_Number = @accountNumber and tl.Start_Time between @startDate and @endDate and tl.Billed IS NULL" + ((!includeExceptions) ? " and tl.End_Time IS NOT NULL and tl.Approved = 'Y'" : "")
                , myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@startDate", startDate);
            myCommand.Parameters.AddWithValue("@endDate", endDate);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetTimeLogsExceptions() {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "Select u.Username, acct.Name as Account_Name, i.Name as Instrument_Name, tl.Start_Time, tl.End_Time, tl.Approved, tl.Account_Number, i.InstrumentID, tl.Current_Rate, u.PersonID " +
                "From Users u INNER JOIN Time_Log tl on u.PersonID = tl.UserID INNER JOIN Account acct on tl.Account_Number = acct.Account_Number INNER JOIN Instrument i on tl.InstrumentID = i.InstrumentID " +
                "WHERE tl.End_Time IS NULL OR tl.Approved IS NULL", myConnection);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }
        
        public DataTable GetUnbilledSupplyUse(string accountNumber, DateTime startDate, DateTime endDate) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "Select su.Account_Number, su.Date, su.Supply_Name, su.Quantity, su.Current_Cost " +
                "FROM Supply_Use su Inner JOIN Account acct on su.Account_Number = acct.Account_Number " +
                "WHERE su.Date Between @startDate and @endDate and su.Account_Number = @accountNumber and Billed IS NULL and Approved = 'Y'", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@startDate", startDate);
            myCommand.Parameters.AddWithValue("@endDate", endDate);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetSupplyUseExceptions() {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "Select su.Account_Number, su.Supply_Name, su.Approved, su.Quantity, su.Current_Cost, su.Date " +
                "FROM Supply_Use su Inner JOIN Account acct on su.Account_Number = acct.Account_Number " +
                "WHERE Approved IS NULL", myConnection);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetUser(int userID){
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "SELECT usr.*, psn.*, ptc.First_Name as 'Contact_First_Name', ptc.Last_Name as 'Contact_Last_Name' " +
                "FROM Users usr left outer join Person psn on usr.PersonID = psn.PersonID left outer join Person ptc on usr.ContactID = ptc.PersonID " + 
                "WHERE usr.PersonID = @userID", myConnection);

            myCommand.Parameters.AddWithValue("@userID", userID);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetUsers() {
            return GetUsers(false);
        }

        public DataTable GetUsers(bool includeAll) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT First_Name, Last_Name, Username, psn.PersonID, Department " + ((includeAll) ? ", Password, Type ":"") + 
                "FROM Users usr left outer join Person psn on usr.PersonID = psn.PersonID";

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetInstrument(int instrumentID) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT * FROM Instrument WHERE InstrumentID = @instrumentID", myConnection);

            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            DataTable table = new DataTable();
            try {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetInvoice(int invoiceID)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT * " + 
                                                  "From Invoice iv INNER JOIN Account acct on iv.Account_Number = acct.Account_Number " +  
                                                  "Where InvoiceID = @invoiceID", myConnection);

            myCommand.Parameters.AddWithValue("@invoiceID", invoiceID);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetInvoiceTimeLine(int invoiceID)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand(
                "SELECT * " +
                "From Invoice_Time_Line tl INNER JOIN Instrument i on tl.InstrumentID = i.InstrumentID " +
                "Where InvoiceID = @invoiceID", myConnection);

            myCommand.Parameters.AddWithValue("@invoiceID", invoiceID);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetInvoiceSupplyLine(int invoiceID)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT i.*, su.Unit From Invoice_Supply_Line i INNER JOIN Supply su on su.Supply_Name = i.Supply_Name " +
                "Where InvoiceID = @invoiceID", myConnection);

            myCommand.Parameters.AddWithValue("@invoiceID", invoiceID);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetPointOfContact(int personID) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT * From Point_of_Contact pc INNER JOIN Person psn on psn.PersonID = pc.PersonID " +
                "Where psn.PersonID = @personID", myConnection);

            myCommand.Parameters.AddWithValue("@personID", personID);

            DataTable table = new DataTable();
            try {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetContacts() {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT First_Name, Last_Name, psn.PersonID, Email FROM Point_of_Contact poc left outer join Person psn on poc.PersonID = psn.PersonID";

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetUserAccounts(string username) {
            return GetUserAccounts(username, false);
        }

        public DataTable GetUserAccounts(string username, bool includeInvalid, bool includePerUse = true) {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }


            SqlCommand myCommand = new SqlCommand("SELECT ua.Account_Number, a.Name " +
                    "FROM User_Account ua INNER JOIN Users u on ua.PersonID = u.PersonID INNER JOIN Account a on ua.Account_Number = a.Account_Number " +
                    " WHERE Username = @username" + ((includeInvalid) ? "" : " and a.Account_Expiration > GETDATE() and Active = 'Y'"), myConnection);

            myCommand.Parameters.AddWithValue("@username", username);


            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                Debug.Write(e.Message);
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }

        
            myConnection.Close();
            return table;
        }

        public DataTable GetAccountInstruments(string accountNumber)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null)
            {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT Account_Number, InstrumentID " +
                "FROM Account_Instrument WHERE Account_Number = @accountNumber", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administrator.");
            }

            myConnection.Close();
            return table;
        }

        public DataTable GetUserInstruments(string username)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null)
            {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT ui.InstrumentID, i.Name " +
                    "FROM User_Instrument ui INNER JOIN Users u on ui.PersonID = u.PersonID INNER JOIN Instrument i on ui.InstrumentID = i.InstrumentID " +
                    " WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);

            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administrator.");
            }

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

        public DataTable GetRateTypes()
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT * FROM Rate_Type";

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetInstrumentRates( int instrumentID)
        {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            SqlCommand myCommand = new SqlCommand("SELECT * FROM Instrument_Rate WHERE InstrumentID = @instrumentID", myConnection);

            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            DataTable table = new DataTable();
            try{
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }


        public DataTable GetImportDataTimeLog() {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT acct.Account_Number, ir.InstrumentID, ir.Rate, i.Time_Increment " + 
                "FROM Account acct  INNER JOIN Rate_Type rt on rt.Name = acct.Rate_Type " + 
                "INNER JOIN Instrument_Rate ir on ir.Rate_Type = rt.Name INNER JOIN Instrument i on i.InstrumentID = ir.InstrumentID";

            DataTable table = new DataTable();
            try {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        public DataTable GetImportDataSupplyUse() {
            SqlConnection myConnection = DBConnect();
            if (myConnection == null) {
                return new DataTable();
            }

            string myCommand = "SELECT Supply_Name, Cost FROM Supply";

            DataTable table = new DataTable();
            try {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);
                dataAdapter.Fill(table);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("There was an error connecting to the server. Please try again or contact your system administator.");
            }


            myConnection.Close();
            return table;
        }

        #endregion End Get Region

        public void GenerateAllInvoices(DateTime startDate, DateTime endDate, out List<int> invoicesGenerated) {
            List<string> accounts = GetAccountNumberList();
            List<int> invoiceNumbers = new List<int>();

            foreach (string currentAccount in accounts) {
                int invoiceNumber;
                if (GenerateInvoice(currentAccount, startDate, endDate, out invoiceNumber))
                {
                    invoiceNumbers.Add(invoiceNumber);
                }
            }

            invoicesGenerated = invoiceNumbers;
        }

        public bool GenerateInvoice(string accountNumber, DateTime startDate, DateTime endDate)
        {
            int throwaway;
            return GenerateInvoice(accountNumber, startDate, endDate, out throwaway);
        }

        public bool GenerateInvoice(string accountNumber, DateTime startDate, DateTime endDate, out int invoiceNumber) {
            // Used as a default value in the event that this terminates early
            invoiceNumber = 0;

            // Create an invoice for the account and set it's values, this will be used to build an SQL Query later
            Invoice invoice = new Invoice();
            invoice.accountNumber = accountNumber;
            invoice.dateGenerated = DateTime.Now;
            invoice.totalBalance = 0;

            // Initialize and populate the lines that will represent a line item billing for an instrument
            invoice.instrumets = new List<InvoiceInstrumentLine>();
            DataTable timeLogs = GetUnbilledTimeLogs(accountNumber, startDate, endDate, false);
            GenerateInvoiceInstrumentLines(invoice, timeLogs);

            // Initialize and populate the lines that will represent a line item billing for a supply
            invoice.supplies = new List<InvoiceSupplyLine>();
            DataTable supplyUses = GetUnbilledSupplyUse(accountNumber, startDate, endDate);
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

            GenerateInstrumentUse(timeLogs, invoiceID);

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
            invoiceNumber = invoiceID;
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

                    // Call Davids fuction here

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
                    instrumentToUpdate.billingUnit = currentRow["Billing_Unit"].ToString();
                    instrumentToUpdate.uses = 1;
                    invoice.instrumets.Add(instrumentToUpdate);

                } else {
                    instrumentToUpdate.uses++;
                    instrumentToUpdate.hours += duration.TotalHours;
                }

                UpdateTimeLogBillingStatus(currentRow["Account_Number"].ToString(),
                                           Convert.ToInt32(currentRow["UserID"]),
                                           Convert.ToInt32(currentRow["InstrumentID"]),
                                           (DateTime)currentRow["Start_Time"]);
                
            }

            foreach (InvoiceInstrumentLine currentLine in invoice.instrumets) {
                if (currentLine.billingUnit == "Time") {
                    double lineMin = currentLine.hours * 60;
                    int timeIncrements = (int)lineMin / currentLine.timeIncrement;
                    currentLine.charges = timeIncrements * currentLine.rate;
                    currentLine.hours = (double)timeIncrements * (double)currentLine.timeIncrement / 60;
                    invoice.totalBalance += currentLine.charges;
                } else {
                    currentLine.charges = currentLine.uses * currentLine.rate;
                    currentLine.hours = currentLine.uses;
                    invoice.totalBalance += currentLine.charges;
                }
            }

        }

        private void GenerateInvoiceSupplyLines(Invoice invoice, DataTable supplyUses) {

            DataRowCollection rows = supplyUses.Rows;
            InvoiceSupplyLine supplyToUpdate = null;

            foreach (DataRow currentRow in rows) {

                bool foundFlag = false;

                foreach (InvoiceSupplyLine currentSupply in invoice.supplies) {

                    // Call Davids Supply Function Here
                    //GenerateInstrumentUse();

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

                UpdateSupplyBillingStatus(currentRow["Account_Number"].ToString(), 
                                          currentRow["Supply_Name"].ToString(),
                                          (DateTime)currentRow["Date"]);
            }

            foreach (InvoiceSupplyLine currentLine in invoice.supplies) {
                currentLine.charges = currentLine.currentCost * currentLine.quantity;
                invoice.totalBalance += currentLine.charges;
            }
        }

        private void GenerateInstrumentUse(DataTable timeLogsTable, int invoiceID)
        {
            //string to save the instrument use

            List<string[]> instrumentUse = new List<string[]>();

            string exportpath = "Instrument Use - " + invoiceID + ".pdf";

            foreach (DataRow currentRow in timeLogsTable.Rows)
            {
                TimeSpan durationDT = ((DateTime)currentRow["End_Time"]).Subtract( (DateTime) currentRow["Start_Time"]);
                string duration = durationDT.TotalMinutes.ToString();

                string[] temp = new string[]{
                currentRow["Name1"].ToString(),
                currentRow["Start_Time"].ToString(),
                duration,
                currentRow["Current_Rate"].ToString()
                };
            }

            PDFManager pdfManager = new PDFManager();
            //pdfManager.GenerateInstrumentUsePDF();

        }

        // Used to add a group of rows from a DataTable to a table on the db
        private bool SendDataTable(DataTable tableToSend, string destinationTable) {

            SqlConnection myConnection = DBConnect();

            SqlBulkCopy bulkCopy = new SqlBulkCopy(myConnection);

            bulkCopy.DestinationTableName = destinationTable;


            bulkCopy.WriteToServer(tableToSend);

            return true;
        }

        #region Update Functions

        public void UpdateTimeLogBillingStatus(string accountNumber, int userID, int instrumentID, DateTime startTime) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "UPDATE Time_Log " +
                "SET Billed = @invoiceDate " +
                "WHERE Account_Number = @accountNumber and UserID = @userID and InstrumentID = @instrumentID and Start_Time = @startTime", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@userID", userID);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);
            myCommand.Parameters.AddWithValue("@startTime", startTime);

            DateTime serverTime;
            GetServerDateTime(out serverTime);
            myCommand.Parameters.AddWithValue("@invoiceDate", serverTime);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void UpdateSupplyBillingStatus(string accountNumber, string supplyName, DateTime date) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "UPDATE Supply_Use " +
                "SET Billed = @invoiceDate " +
                "WHERE Account_Number = @accountNumber and Supply_Name = @supplyName and Date = @date", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@supplyName", supplyName);
            myCommand.Parameters.AddWithValue("@date", date);

            DateTime serverTime;
            GetServerDateTime(out serverTime);
            myCommand.Parameters.AddWithValue("@invoiceDate", serverTime);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void UpdateUser(int userID, string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email,
            string username, string password, string department, string type, string notes, int contactID = -1) {

            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "updateUser";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@userID", userID);

            if (firstName != "" ) myCommand.Parameters.AddWithValue("@firstName", firstName);
            if (lastName != "" ) myCommand.Parameters.AddWithValue("@lastName", lastName);
            if (street != "" ) myCommand.Parameters.AddWithValue("@street", street);
            if (city != "" ) myCommand.Parameters.AddWithValue("@city", city);
            if (state != "" ) myCommand.Parameters.AddWithValue("@state", state);
            if (zip != "" ) myCommand.Parameters.AddWithValue("@zip", zip);
            if (phoneNumber != "" ) myCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            if (email != "" ) myCommand.Parameters.AddWithValue("@email", email);
            if (username != "" ) myCommand.Parameters.AddWithValue("@userName", username);

            if (password != "") {
                password = PasswordHash.getHashSha512(password);
                myCommand.Parameters.AddWithValue("@password", password);
            }

            if (department != "" ) myCommand.Parameters.AddWithValue("@department", department);
            if (type != "" ) myCommand.Parameters.AddWithValue("@type", type);
            myCommand.Parameters.AddWithValue("@notes", notes);
            if (contactID > 0) myCommand.Parameters.AddWithValue("@contactID", contactID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void UpdateTimeLogApproval(string accountNumber, int userID, int instrumentID, DateTime startTime, char approval) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "UPDATE Time_Log " +
                "SET Approved = @approval " +
                "WHERE Account_Number = @accountNumber and UserID = @userID and InstrumentID = @instrumentID and Start_Time = @startTime", myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@userID", userID);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);
            myCommand.Parameters.AddWithValue("@startTime", startTime);
            myCommand.Parameters.AddWithValue("@approval", approval);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }


        public void UpdateInstrument(int instrumentID, string name, string billingUnit, int timeIncrement, char active) {
            string tableName = "Instrument";
            string tableKeyName = "InstrumentID";

            string[] colNames = new string[]{
                "Name", "Billing_Unit", "Time_Increment", "Active"
            };

            object[] paramValues = new object[]{
                name, billingUnit, timeIncrement, active
            };

            UpdateTable(tableName, tableKeyName, instrumentID, colNames, paramValues);
        }

        public void UpdateSupply(string supplyName, double cost, string unit, char active) {
            string tableName = "Supply";
            string tableKeyName = "Supply_Name";

            string[] colNames = new string[]{
              "Cost", "Unit", "Active"  
            };

            object[] paramValues = new object[]{
                cost, unit, active
            };

            UpdateTable(tableName, tableKeyName, supplyName, colNames, paramValues);
        }

        public void UpdateAccount(string accountNumber, string name, double maxCharge, DateTime accountExpiration,
            string rateType, int pointOfContactID, string notes, string costCenter, string wbsNumber, double balance,
            string street, string city, string state, int zip, string taxID, char Active) {
            
            string tableName = "Account";
            string tableKeyName = "Account_Number";


            string[] colNames = new string[]{
                "Name", "Max_Charge_Limit", "Account_Expiration",
                "Rate_Type", "PointOfContactID", "Notes", "Cost_Center", "WBS_Number",
                "Balance", "Street", "City", "State", "Zip", "Tax_ID", "Active"
            };

            object[] paramValues = new object[]{
                name, maxCharge, accountExpiration,
                rateType, pointOfContactID, notes, costCenter, wbsNumber,
                balance, street, city, state, zip, taxID, Active
            };

            UpdateTable(tableName, tableKeyName, accountNumber, colNames, paramValues);

        }

        public void UpdatePointOfContact(int personID, string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email,
            string notes) {
            string tableName = "Person";
            string tableKeyName = "PersonID";

            string[] colNames = new string[]{
                "First_Name", "Last_Name", "Street", "City", "State", "Zip", "Phone_Number", "Email", "Notes"
            };

            object[] paramValues = new object[]{
                firstName, lastName, street, city, state, zip, phoneNumber, email, notes
            };

            UpdateTable(tableName, tableKeyName, personID, colNames, paramValues);
        }


        private void UpdateTable(string tableName, string tableKeyName, object tableKeyValue, string[] colNames, object[] paramValues) {
            UpdateTable(tableName, new string[] { tableKeyName }, new object[] { tableKeyValue }, colNames, paramValues);
        }

        private void UpdateTable(string tableName, string[] tableKeyNames, object[] tableKeyValues, string[] colNames, object[] paramValues) {
            
            // don't execute if the # of columns doesn't match the number of values
            if (paramValues.Length != colNames.Length && tableKeyNames.Length != tableKeyValues.Length)
                return;

            // used for debugging, remove in production
            int earlyCut = 0;

            SqlConnection myConnection = DBConnect();
            string commandString = "UPDATE " + tableName + " SET ";
            for (int i = 0; i + earlyCut < colNames.Length; i++ ) {
                if (paramValues[i].ToString() != "") {
                    commandString += colNames[i] + " = @param" + i;
                    if (i + 1 + earlyCut < colNames.Length) commandString += ", ";
                }
            }
            commandString += " WHERE ";

            for (int i = 0; i < tableKeyNames.Length; i++) {
                commandString += tableKeyNames[i] + " = @filterparam" + i;
            }

            

            SqlCommand myCommand = new SqlCommand(commandString, myConnection);

            for (int i = 0; i + earlyCut < colNames.Length; i++) {
                if (paramValues[i].ToString() != "") {
                    myCommand.Parameters.AddWithValue("@param" + i, paramValues[i]);
                }
            }

            for (int i = 0; i < tableKeyNames.Length; i++) {
                myCommand.Parameters.AddWithValue("@filterparam" + i, tableKeyValues[i]);
            }


            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void UpdateUserAccounts(DataTable userAccounts, int personID)
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("DELETE FROM User_Account " +
                                                  "WHERE PersonID = @personID", myConnection);

            myCommand.Parameters.AddWithValue("@personID", personID);

            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            AddUserAccounts(userAccounts);

            myConnection.Close();
        }

        public void UpdateInstrumentRates(DataTable rates, int instrumentID) {

            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("DELETE FROM Instrument_Rate " +
                                                  "WHERE InstrumentID = @instrumentID", myConnection);

            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            rates.Columns.Add("InstrumentID", Type.GetType("System.Int32"));

            foreach (DataRow row in rates.Rows) {
                row["InstrumentID"] = instrumentID;
            }

            SendDataTable(rates, "Instrument_Rate");
        }

        #endregion

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
            public string billingUnit { get; set; }
            public int uses { get; set; }
            public int timeIncrement { get; set; }
        }
        #endregion

        internal void BindForm(frmCUITAdminMain pmainForm) {
            this.mainForm = pmainForm;
        }

        internal void UpdateSupplyApproval(string accountNumber, string supplyName, DateTime date, char approved) {
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand(
                "UPDATE Supply_Use " +
                "SET Approved = @approved " +
                "WHERE Account_Number = @accountNumber and Supply_Name = @supplyName and Date = @date", myConnection);

            myCommand.Parameters.AddWithValue("@approved", approved);
            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@supplyName", supplyName);
            myCommand.Parameters.AddWithValue("@date", date);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }
    }
}
