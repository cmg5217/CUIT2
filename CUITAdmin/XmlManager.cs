using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace CUITAdmin {
    class XmlManager {

        private static XmlManager globalManager;

        private const string FILE_LOCATION = "records.xml";
        private XmlDocument xmlDoc;

        public XmlManager() {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(FILE_LOCATION);
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


            if (accountNumbers != null) {
                foreach (string accountNumber in accountNumbers) {
                    XmlElement accountNumberElement = xmlDoc.CreateElement("account_number");
                    accountNumberElement.InnerText = accountNumber;
                }
            }

            // finally add the user to the users element
            usersElement.AppendChild(userElement);

            xmlDoc.Save(FILE_LOCATION);
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



        public bool FindUser(string username, ref XmlElement outElement) {

            foreach (XmlElement innerElement in xmlDoc.SelectSingleNode("//root/users")) {
                XmlElement usernameElement = (XmlElement)innerElement.SelectSingleNode("username");
                if (usernameElement != null && usernameElement.InnerText == username) {
                    outElement = innerElement;
                    return true;
                }
            }
            return false;
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


        // Searches through the child elements of the parent element passed in looking for 
        private bool FindElementByInnerElementValue(XmlElement parentElement, string childElementName, string childValue, XmlElement outElement) {

            foreach (XmlElement innerElement in parentElement) {
                XmlElement checkElement = (XmlElement)innerElement.SelectSingleNode(childElementName);
                if (childValue == checkElement.InnerText) return true;
            }
            return false;
        }

        // Checks the xml to see if the username and password match, returns false if no user found or invalid password
        public bool CheckPassword(string username, string password) {
            
            // go to the users element
            XmlElement userElements = (XmlElement)xmlDoc.SelectSingleNode("//root/users");

            // loop through each user
            foreach (XmlElement userElement in userElements) {

                // get the username element
                XmlElement usernameElement = (XmlElement)userElement.SelectSingleNode("username");

                // check to see if it is the same as the passed username
                if (username == usernameElement.InnerText) {
                    // if it is the same user check to see if their password matches, return accordingly
                    if (userElement.SelectSingleNode("password").InnerText != password) {
                        return false;
                    } else {
                        return true;
                    }
                }
            }

            // no user found, return false
            return false;
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
