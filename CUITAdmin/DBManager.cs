using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


using System.Diagnostics;
using System.ComponentModel;
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

        public void AddNewUser(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, 
            string username, string password, string department, string type, string notes, string contactID) 
        {

            string personID;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, out personID);


            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Users (PersonID, Username, Password, Department, Type, Notes, ContactID) " +
                                                  "VALUES (@personID, @username, @password, @department, @type, @notes, @contactID)", 
                                                  myConnection);

            myCommand.Parameters.AddWithValue("@personID", personID);
            myCommand.Parameters.AddWithValue("@username", username);
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

        public void AddNewContact(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, string notes) {
            string personID;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, out personID);
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Contact (PersonID, Notes) " +
                                                  "VALUES (@personID, @notes)",
                                                  myConnection);

            myCommand.Parameters.AddWithValue("@notes", notes);
            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }

        public void AddNewManager(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email) {
            
            string personID;
            AddPerson(firstName, lastName, street, city, state, zip, phoneNumber, email, out personID);
            SqlConnection myConnection = DBConnect();
            SqlCommand myCommand = new SqlCommand("INSERT INTO Contact (PersonID) " +
                                                  "VALUES (@personID)",
                                                  myConnection);
            myCommand.Parameters.AddWithValue("@personID", personID);

            try {
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            myConnection.Close();
        }




        public void AddAccount(string accountNumber, string name, string maxChargeLimit, string accountExpiration, 
                string rateType, string managerID, string notes, string costCenter, string wbsNumber, string balance) 
        {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("INSERT into Account " +
            "(Account_Number, Name, Max_Charge_Limit, Account_Expiration, Rate_Type, ManagerID, Notes, Cost_Center, " +
            "WBS_Number, Balance) " +

            "VALUES (@accountNumber, @name, @maxChargeLimit, @accountExpiration, @rateType, @managerID, " +
            "@notes, @costCenter, @wbsNumber, @balance)", myConnection);


            myCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@maxChargeLimit", maxChargeLimit);
            myCommand.Parameters.AddWithValue("@accountExpiration", DateTime.Now);
            myCommand.Parameters.AddWithValue("@rateType", rateType);
            myCommand.Parameters.AddWithValue("@managerID", managerID);
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

        public void GetUser(string username) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand("SELECT Password FROM Users" +
                                                  "WHERE Username = @username", myConnection);

            myCommand.Parameters.AddWithValue("@username", username);



            myConnection.Close();
        }


        public void AddPerson(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email) {

        }

        public void AddPerson(string firstName, string lastName, string street, string city, string state, string zip, string phoneNumber, string email, out string personID) {
            SqlConnection myConnection = DBConnect();

            SqlCommand myCommand = new SqlCommand(
                "INSERT INTO Person (First_Name, Last_Name, Street, City, State, Zip, Phone_Number, Email)" +
                "VALUES (@firstName, @lastName, @street, @city, @state, @zip, @phoneNumber, @email)" +
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

        public BindingList<Data> GetInstruments() {
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
