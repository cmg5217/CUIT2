using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.ComponentModel;

namespace CUITAdmin {
    class XmlManager {

        List<XmlElement> startedLogs;

        private static XmlManager globalManager;

        private const string FILE_LOCATION = "records.xml";
        private XmlDocument xmlDoc;

        private XmlManager() {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(FILE_LOCATION);
            startedLogs = new List<XmlElement>();
        }

        public static XmlManager Instance {
            get {
                if (globalManager == null)
                    globalManager = new XmlManager(); 
                return globalManager;
            }
        }

        

        ////////////////////////////////////////////////// AddUser() ///////////////////////////////////////////////
        //
        // Adds a user to the records file. Returns false if user already exists and
        // an optional XmlElement can be passed in to return it.

        // AddUser() that accepts a single account number
        public bool AddUser(string username, string password, string accountNumber) {
            XmlElement nullElement = null;
            return AddUser(username, password, accountNumber, ref nullElement);
        }


        public bool AddUser(string username, string password, string accountNumber, ref XmlElement outElement) {
            List<string> accountNumbers = new List<string> { accountNumber };
            return AddUser(username, password, ref outElement, accountNumbers);
        }


        public bool AddUser(string username, string password) {
            XmlElement nullElement = null;
            return AddUser(username, password, ref nullElement);
        }


        public bool AddUser(string username, string password, ref XmlElement outElement, List<string> accountNumbers = null) {
            if (FindUser(username, ref outElement)) {
                return false;
            }

            // get the users element
            XmlElement usersElement = (XmlElement) xmlDoc.SelectSingleNode("//root/users");

            // create a user element to add to users
            XmlElement userElement = xmlDoc.CreateElement("user");

            // create a username element to add to the user
            XmlElement usernameElement = xmlDoc.CreateElement("username");
            usernameElement.InnerText = username;

            // create a password element to add to the user
            XmlElement passwordElement = xmlDoc.CreateElement("password");
            passwordElement.InnerText = password;

            // add the username and password elements to the user element
            userElement.AppendChild(usernameElement);
            userElement.AppendChild(passwordElement);

            XmlElement accountNumbersElement = xmlDoc.CreateElement("account_numbers");
            if (accountNumbers != null) {
                foreach (string accountNumber in accountNumbers) {
                    XmlElement accountNumberElement = xmlDoc.CreateElement("account_number");
                    accountNumberElement.InnerText = accountNumber;
                    accountNumbersElement.AppendChild(accountNumberElement);
                } 
            }

            userElement.AppendChild(accountNumbersElement);


            // finally add the user to the users element
            usersElement.AppendChild(userElement);

            xmlDoc.Save(FILE_LOCATION);
            return true;
        }


        public bool AddLog(string username, string account, string instrument, string startTime, string endTime)
        {
            string parentXPath = "//root/logs";
            string node = "log";
            string[] nodeNames = new string[]{
                "username", "account_number", "instrument", "start_time", "end_time"
            };

            string[] nodeValues = new string[]{
                username, account, instrument, startTime, endTime
            };
            return AddToXml(parentXPath, node, nodeNames, nodeValues);
        }


        public bool AddPartialLog(string username, string account, string instrument, string startTime)
        {
            string parentXPath = "//root/logs";
            string node = "log";
            string[] nodeNames = new string[]{
                "username", "account_number","instrument",  "start_time"
            };

            string[] nodeValues = new string[]{
                username, account, instrument, startTime
            };
            return AddToXml(parentXPath, node, nodeNames, nodeValues);
        }


        public bool AddLogEndTime(string username, string accountNumber, string instrument, string startTime, string endTime)
        {
            foreach (XmlElement currentElement in startedLogs) {
                if (currentElement.SelectSingleNode("start_time").InnerText == startTime && 
                    currentElement.SelectSingleNode("username").InnerText == username &&
                    currentElement.SelectSingleNode("account_number").InnerText == accountNumber &&
                    currentElement.SelectSingleNode("instrument").InnerText == instrument
                    )
                {
                    XmlElement endTimeNode = xmlDoc.CreateElement("end_time");
                    endTimeNode.InnerText = endTime;
                    currentElement.AppendChild(endTimeNode);
                    xmlDoc.SelectSingleNode("logs").AppendChild(currentElement);
                    return true;
                }
            }

            return false;
        }


        public bool AddSupplyUse(string username, string accountnumber, string supply, int quanity)
        {
            return AddSupplyUse(username, accountnumber, supply, quanity.ToString());
        }

        public bool AddSupplyUse(string username, string accountnumber, string supply, string quantity) {
            string parentXPath = "//root/supply_uses";
            string node = "supply_use";
            string[] nodeNames = new string[]{
                "username", "account_number","supply_name",  "quantity"
            };
            string[] nodeValues = new string[]{
                username, accountnumber, supply, quantity
            };
            return AddToXml(parentXPath, node, nodeNames, nodeValues);
        }

        // Private method used to shorten method bodies. 
        // Adds a new node to the specified path. 
        // The new node may have children passed into the array
        // with innerText passed into the values array
        private bool AddToXml(string parentXPath, string nodeName, string[] childNodes, string[] values) {
            XmlElement throwaway = null;
            return AddToXml(parentXPath, nodeName, childNodes, values, out throwaway);
        }

        private bool AddToXml(string parentXPath, string nodeName, string[] childNodes, string[] values, out XmlElement outElement) {
            if (childNodes.Length != values.Length) {
                outElement = null;
                return false;
            }

            XmlNode parentNode = xmlDoc.SelectSingleNode(parentXPath);

            XmlElement node = xmlDoc.CreateElement(nodeName);

            XmlElement loopElement;
            for (int i = 0; i < childNodes.Length; i++) {
                loopElement = xmlDoc.CreateElement(childNodes[i]);
                loopElement.InnerText = values[i];
                node.AppendChild(loopElement);
            }

            parentNode.AppendChild(node);
            xmlDoc.Save(FILE_LOCATION);

            outElement = node;
            return true;
        }





        ////////////////////////////////////////////////// EditUser() ///////////////////////////////////////////////
        //
        // Looks for a user in the records file and an optional XmlElement can be passed in to return it.
        //  Returns false if user doesn't exists.

        //
        public bool EditUser(string username, LinkedList<string> newAccountNumbers = null) {
            string newPassword = null;
            XmlElement nullElement = null;
            return EditUser(username, newPassword, ref nullElement, newAccountNumbers);
        }

        public bool EditUser(string username, string newPassword, LinkedList<string> newAccountNumbers = null) {
            XmlElement nullElement = null;
            return EditUser(username, newPassword, ref nullElement, newAccountNumbers);
        }
        
        public bool EditUser(string username, string newPassword, ref XmlElement outElement, LinkedList<string> newAccountNumbers = null) {
            XmlElement user = null;

            // no user found, return false
            if (!FindUser(username, ref user))
                return false;

            // if a password was provided, change the password elements inner text
            if (newPassword != null) {
                user.SelectSingleNode("password").InnerText = newPassword;
            }

            if (newAccountNumbers != null) {
                bool duplicate;
                XmlElement userAccountNumbers = (XmlElement)user.SelectSingleNode("account_numbers");
                foreach (string newAccountNumber in newAccountNumbers) {
                    duplicate = false;

                    foreach (XmlElement userAccountNumber in userAccountNumbers) {
                        if (userAccountNumber.InnerText == newAccountNumber) {
                            duplicate = true;
                            break;
                        }
                    }

                    if (!duplicate) {
                        XmlElement addAccountNumber = xmlDoc.CreateElement("account_number");
                        addAccountNumber.InnerText = newAccountNumber;
                        userAccountNumbers.AppendChild(addAccountNumber);
                    }
                }
            }

            xmlDoc.Save(FILE_LOCATION);

            return true;
        }


////////////////////////////////////////////////////////////////////////////////////////////////////////////END LOG

        

        public bool FindUser(string username, ref XmlElement outElement) {
            return FindElementByInnerElementValue("//root/users", "username", username, ref outElement);
        }

        public bool FindElementByInnerText(List<XmlElement> searchElementList, string innerText, XmlElement outElement) {
            foreach (XmlElement searchElement in searchElementList) {
                if (searchElement.InnerText == innerText) {
                    outElement = searchElement;
                    return true;
                }
            }
            return false;
        }

        // Searches through the child elements of the parent element passed in looking for the string passed in
        private bool FindElementByInnerElementValue(string parentElementxpath, string childElementName, string childValue, ref XmlElement outElement) {
            XmlNode parentElement = xmlDoc.SelectSingleNode(parentElementxpath);
            foreach (XmlElement innerElement in parentElement) {
                XmlElement checkElement = (XmlElement)innerElement.SelectSingleNode(childElementName);
                if (childValue == checkElement.InnerText) {
                    outElement = innerElement;
                    return true;
                }
            }
            return false;
        }

        // Checks the xml to see if the username and password match, returns false if no user found or invalid password
        public bool CheckPassword(string username, string password) {

            XmlElement userElement = null;

            // Find the user
            if (FindUser(username, ref userElement)) {
                // Compare password
                if (userElement.SelectSingleNode("password").InnerText != password) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return false; // no user found
            }
        }

        public bool GetUserAccounts(string username, out BindingList<Data> accounts)
        {
            BindingList<Data> outAccounts = new BindingList<Data>();
            XmlElement userElement = null;

            // Find the user
            if (FindUser(username, ref userElement))
            {
                XmlNode userAccounts = userElement.SelectSingleNode("account_numbers");
                // loop through each account in the user
                foreach (XmlElement currentAccount in userAccounts)
                {

                    XmlElement currentAccountDetails = null;
                    // Look up the account details in the //root/accounts node
                    FindElementByInnerElementValue("//root/accounts",
                        "account_number",
                        currentAccount.InnerText,
                        ref currentAccountDetails);
                    outAccounts.Add(new Data
                    {
                        Name = currentAccountDetails.SelectSingleNode("account_name").InnerText,
                        Value = currentAccountDetails.SelectSingleNode("account_number").InnerText
                    });
                }
            }

            accounts = outAccounts;

            if (accounts.Count == 0)
                return false;
            return true;
        }

        /*
         XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(FILE_LOCATION);
                XmlElement userElements = xmlDoc.SelectSingleNode("//root/users");

                foreach (XmlElement userElement in userElements) {
                   
                    XmlElement usernameElement = userElement.SelectSingleNode("username");
                    if (txtUsername.Text == usernameElement.InnerText) {
                        if (userElement.SelectSingleNode("password").InnerText != txtPassword.Text) {

                            lblAuthenticating.Invoke(new MethodInvoker(delegate { lblAuthenticating.Text = "Error: Password Invalid"; }));
                            cboFundingSource.Invoke(new MethodInvoker(delegate { cboFundingSource.Enabled = false; }));
                            cboInstrument.Invoke(new MethodInvoker(delegate { cboInstrument.Enabled = false; }));

                            return;
                        } else {
                            if (lblAuthenticating.InvokeRequired) {
                                lblAuthenticating.Invoke(new MethodInvoker(delegate { lblAuthenticating.Text = "Authentication Successful"; }));
                            }

                            cboFundingSource.Invoke(new MethodInvoker(delegate { cboFundingSource.Enabled = true; }));
                            cboInstrument.Invoke(new MethodInvoker(delegate { cboInstrument.Enabled = true; }));
                        }
                    }
                }
         */
    }
}
