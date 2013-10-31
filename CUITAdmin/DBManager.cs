using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


using System.Diagnostics;
using System.ComponentModel;
using System.Data;
namespace CUITAdmin
{
    class DBManager {

        static DBManager globalManager;

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

        
        public SqlConnection DBConnect() {
             SqlConnection theConnection = new SqlConnection("Data Source=CUITS\\CUITS;" + 
                "Initial Catalog=CUIT;" + 
                "User ID=DataAdmin;" + 
                "Password=JazBarne$411");
             try {
                 theConnection.Open();
             } catch (Exception e) {
                 Debug.WriteLine(e.Message);
             }
            return theConnection;
        }


        public void AddUser(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, 
            string username, string password, string department, string type, string notes, int contactID) 
        {

            string personID;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, true, false, out personID);


            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Users (PersonID, Username, Password, Department, Type, Notes, ContactID) " +
                                                  "VALUES (@personID, @username, @password, @department, @type, @notes, @contactID)", 
                                                  myConnection);

            myCommand.Parameters.AddWithValue("@personID", personID);
            myCommand.Parameters.AddWithValue("@username", username);
            myCommand.Parameters.AddWithValue("@password", password);
            myCommand.Parameters.AddWithValue("@department", department);
            myCommand.Parameters.AddWithValue("@type", type.ToCharArray()[0]);
            myCommand.Parameters.AddWithValue("@notes", notes);
            myCommand.Parameters.AddWithValue("@contactID", contactID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();

        }


        public void AddUserAccount(int personID, int accountNumber) {


            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT INTO User_Account (PersonID, Account_Number) " +
                                                  "VALUES (@personID, @accountNumber)",myConnection);

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
            string newPersonID;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, false, true, out newPersonID);
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Point_of_Contact (PersonID, Notes) " +
                                                  "VALUES (@personID, @notes)",
                                                  myConnection);

            myCommand.Parameters.AddWithValue("@personID", newPersonID);
            myCommand.Parameters.AddWithValue("@notes", notes);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            personID = newPersonID;

            myConnection.Close();
        }


        public void AddAccount(int accountNumber, string name, int maxChargeLimit, DateTime accountExpiration, 
                string rateType, int managerID, string notes, string costCenter, string wbsNumber, int balance) 
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT into Account " +
            "(Account_Number, Name, Max_Charge_Limit, Account_Expiration, Rate_Type, PointOfContactID, Notes, Cost_Center, " +
            "WBS_Number, Balance) " +

            "VALUES (@accountNumber, @name, @maxChargeLimit, @accountExpiration, @rateType, @pointOfContact, " +
            "@notes, @costCenter, @wbsNumber, @balance)", myConnection);


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

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            myConnection.Close();

        }

        public void AddPerson(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, bool isUser, bool isPointOfContact) {
            string throwaway;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, isUser, isPointOfContact, out throwaway);
        }
        public void AddPerson(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, bool isUser, bool isPointOfContact, out string personID) {

            string personColumn = (isUser) ? ", IsUser" : ", IsPoint_of_Contact";
            string personParameter = (isUser) ? "@isUser" : "@isPointOfContact";
            
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Person (First_Name, Last_Name, Street, City, State, Zip, Phone_Number, Email" + personColumn + ")" +
                "VALUES (@firstName, @lastName, @street, @city, @state, @zip, @phoneNumber, @email, " + personParameter + ")" +
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
        
        public void AddSupplyUse(string accountNumber, string supplyName, DateTime date, int quantity){
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "insertSupplyUse";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue( "@AccountNumber", accountNumber);
            myCommand.Parameters.AddWithValue( "@Supply_Name", supplyName);
            myCommand.Parameters.AddWithValue( "@Date", date);
            myCommand.Parameters.AddWithValue( "@Quantity", quantity);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }



        public void AddTimeLog(string accountNumber, string userID, char approved, DateTime startTime, DateTime endTime, int currentRate, string instrumentID) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Time_Log (Account_Number, UserID, Approved, Start_Time, End_Time, Current_Rate, InstrumentID)" +
                "VALUES (@accountNumber, @userID, @approved, @startTime, @endTime, @currentRate, @instrumentID)",
                myConnection);

            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@userID", userID);
            myCommand.Parameters.AddWithValue("@approved", approved);
            myCommand.Parameters.AddWithValue("@startTime", startTime);
            myCommand.Parameters.AddWithValue("@endTime", endTime);
            myCommand.Parameters.AddWithValue("@currentRate", currentRate);
            myCommand.Parameters.AddWithValue("@instrumentID", instrumentID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            myConnection.Close();
        }



        public void AddInvoice(DateTime dateGenerated, DateTime postingStartDate, DateTime postingEndDate, string accountNumber, int totalBalance) {
            int throwaway;
             AddInvoice(dateGenerated, postingStartDate,  postingEndDate,  accountNumber,  totalBalance, out throwaway);
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

        public void GetUser(string username) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("SELECT Password FROM Users" +
                                                  "WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);



            myConnection.Close();
        }


        public DataTable GetAccounts()
        {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT Account_Number, Name, Max_Charge_Limit, Balance, First_Name, Last_Name FROM Account acct left outer join Point_of_Contact poc on acct.PointOfContactID = poc.PersonID left outer join Person psn on poc.PersonID = psn.PersonID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetInstruments()
        {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT Name, Billing_Unit, Time_Increment FROM Instrument";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetSupplies()
        {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT * FROM Supply";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetUsers()
        {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT First_Name, Last_Name, Username, Department FROM Users usr left outer join Person psn on usr.PersonID = psn.PersonID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public DataTable GetContacts()
        {
            SqlConnection myConnection = DBConnect();
            string myCommand = "SELECT First_Name, Last_Name, psn.PersonID, Email FROM Point_of_Contact poc left outer join Person psn on poc.PersonID = psn.PersonID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand, myConnection);

            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            myConnection.Close();
            return table;
        }

        public List<string> GetUserAccountNumbers(string username) {
            SqlDataReader myReader = null;
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM [CUIT].[dbo].[Users] u left outer join CUIT.dbo.User_Account ua on u.PersonID = ua.PersonID where u.Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);

            try
            {
                myReader = myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            List<string> userAccounts = new List<string>();

            while (myReader.Read()) {
                userAccounts.Add(myReader["Account_Number"].ToString());
            }

            myConnection.Close();
            return userAccounts;
        }

        public BindingList<Data> GetInstrumentsData() {
            SqlDataReader myReader = null;
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Instrument",myConnection);

            try
            {
                myReader = myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            BindingList<Data> instruments = new BindingList<Data>();

            while (myReader.Read())
            {
                instruments.Add(new Data
                    {
                        Value = myReader["InstrumentID"].ToString(),
                        Name = myReader["Name"].ToString()
                    }
                );
            }

            myConnection.Close();
            return instruments;
        }
    }
}
