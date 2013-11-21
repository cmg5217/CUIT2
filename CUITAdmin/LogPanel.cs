using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Timers;

namespace CUITAdmin {
    public partial class LogPanel : Panel {



        const int BOTTOM_PADDING = 10;

        private string username, password, account, instrument, startTime;
        private DateTime currentTime;

        // an object reference to the control that this panel is contained in
        // used to add additional panels
        private Control container;

        // All controls displayed on this panel
        private ComboBox cboInstrument = new ComboBox();
        private ComboBox cboFundingSource = new ComboBox();
        private Label lblInstrument = new Label();
        private Label lblFundingSource = new Label();
        private Label lblAuthenticating = new Label();
        private Label lblPassword = new Label();
        private Label lblLoading = new Label();
        private Label lblUsername = new Label();
        private Label lblTimeElapsed = new Label();
        private Label lblMessage = new Label();
        private TextBox txtPassword = new TextBox();
        private TextBox txtUsername = new TextBox();
        private Button btnStartLog = new Button();
        private Button btnValidate = new Button();
        private DateTime logTime = new DateTime();
        DataTable userInstruments;
        System.Timers.Timer timer = new System.Timers.Timer();


        bool logStarted = false;
        bool passwordValidated = false;
        bool standalone = false;

        private LogPanel parentPanel;
        private LogPanel childPanel;

        XmlManager xmlManager;
        DBManager dbManager;

        /////////////////////////////////////////// CONSTRUCTORS & DESTRUCTORS /////////////////////////////////////////////////////

        public LogPanel(Control container) {
            InitializeComponent();
            this.container = container;
            container.Controls.Add(this);
            this.Visible = true;
            AddControls();



            xmlManager = XmlManager.Instance;
            dbManager = DBManager.Instance;



            if (Properties.Settings.Default.StandaloneMode) {
                standalone = true;

                BindingList<Data> instruments;
                xmlManager.GetInstruments(out instruments);

                cboInstrument.DataSource = instruments;
                cboInstrument.DisplayMember = "Name";
                cboInstrument.ValueMember = "Value";

            } else {
                standalone = false;
            }

        }

        public LogPanel(Control container, Point location)
            : this(container) {
            this.Location = location;
        }

        // only called by other instances of LogPanel when adding children
        private LogPanel(Control container, LogPanel parentPanel)
            : this(container) {
            this.parentPanel = parentPanel;
        }


        // Destructor to handle child nodes
        ~LogPanel() {

            //When an object of this class is destroyed, if there is a child, link it to the parent panel
            if (childPanel != null) {
                if (parentPanel != null) {
                    childPanel.parentPanel = parentPanel;
                }
            }
        }

        // Adds the initial controls to the panel
        private void AddControls() {

            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cboInstrument);
            this.Controls.Add(this.lblInstrument);
            this.Controls.Add(this.lblFundingSource);
            this.Controls.Add(this.cboFundingSource);
            this.Controls.Add(this.lblAuthenticating);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnStartLog);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTimeElapsed);
            this.Name = "panel1";
            this.Size = new System.Drawing.Size(655, 177);
            this.TabIndex = 0;

            //Initialize timer
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;

            this.btnValidate.Location = new System.Drawing.Point(200, 106);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 3;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new EventHandler(btnValidate_Clicked);
            //
            // lblMessage
            //
            this.lblMessage.Location = new System.Drawing.Point((this.Width / 2) - 50, 10);
            this.lblMessage.Text = "";

            // 
            // btnStartLog
            // 
            this.btnStartLog.Location = new System.Drawing.Point(462, 106);
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.Size = new System.Drawing.Size(75, 23);
            this.btnStartLog.TabIndex = 6;
            this.btnStartLog.Text = "Start";
            this.btnStartLog.UseVisualStyleBackColor = true;
            this.btnStartLog.Enabled = false;
            this.btnStartLog.Click += new EventHandler(btnStartLog_Clicked);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(174, 52);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(174, 79);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.PasswordChar = '*';

            txtPassword.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnValidate.PerformClick();
                }
            };
            //
            // lblTimeElapsed
            //
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(406, 110);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Text = "";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(111, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(114, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";

            // 
            // lblAuthenticating
            // 
            this.lblAuthenticating.AutoSize = true;
            this.lblAuthenticating.Location = new System.Drawing.Point(150, 30);
            this.lblAuthenticating.Name = "lblAuthenticating";
            this.lblAuthenticating.Size = new System.Drawing.Size(75, 13);
            this.lblAuthenticating.TabIndex = 5;
            this.lblAuthenticating.Text = "";
            // 
            // cboFundingSource
            // 
            this.cboFundingSource.FormattingEnabled = true;
            this.cboFundingSource.Enabled = false;
            this.cboFundingSource.Location = new System.Drawing.Point(416, 77);
            this.cboFundingSource.Name = "cboFundingSource";
            this.cboFundingSource.Size = new System.Drawing.Size(121, 21);
            this.cboFundingSource.TabIndex = 4;
            this.cboFundingSource.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblFundingSource
            // 
            this.lblFundingSource.AutoSize = true;
            this.lblFundingSource.Location = new System.Drawing.Point(329, 81);
            this.lblFundingSource.Name = "lblFundingSource";
            this.lblFundingSource.Size = new System.Drawing.Size(85, 13);
            this.lblFundingSource.TabIndex = 7;
            this.lblFundingSource.Text = "Funding Source:";
            // 
            // lblInstrument
            // 
            this.lblInstrument.AutoSize = true;
            this.lblInstrument.Location = new System.Drawing.Point(326, 55);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(59, 13);
            this.lblInstrument.Text = "Instrument:";
            // 
            // cboInstrument
            // 
            this.cboInstrument.FormattingEnabled = true;
            this.cboInstrument.Enabled = false;
            this.cboInstrument.Location = new System.Drawing.Point(416, 51);
            this.cboInstrument.Name = "cboInstrument";
            this.cboInstrument.Size = new System.Drawing.Size(121, 21);
            this.cboInstrument.TabIndex = 4;
            this.cboInstrument.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboInstrument.SelectedIndexChanged += new EventHandler(cboInstrument_SelectedIndexChanged);

        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (lblTimeElapsed.InvokeRequired)
            {
                TimeSpan span = (DateTime.Now - logTime);
                try
                {
                    lblTimeElapsed.Invoke(new MethodInvoker(() => { lblTimeElapsed.Text = span.ToString("hh") + ":" + span.ToString("mm") + ":" + span.ToString("ss"); }));
                }
                catch (Exception e2)
                { }
            }
            else
            {
                lblTimeElapsed.Text = (DateTime.Now - logTime).TotalMinutes.ToString();
            }
        }

        // Adjust the controls for an active log, called on btnStart_Clicked
        private void StartLog() {

            if (cboFundingSource.Items.Count == 0) {
                MessageBox.Show("There were no accounts for the selected instrument. Either you don't have access to the account or the account isn't assigned to this instrument.");
                DisableStartControls();
                return;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Start Standalone Section

            //if (invalid) return;

            childPanel = new LogPanel(container, this);
            childPanel.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height + BOTTOM_PADDING);

            logStarted = true;

            // --Adjust Controls--
            cboInstrument.Enabled = false;
            instrument = cboInstrument.SelectedValue.ToString();


            cboFundingSource.Enabled = false;
            account = cboFundingSource.SelectedValue.ToString();
            cboFundingSource.DataSource = null;

            lblAuthenticating.Text = "Authentification Successful";

            txtUsername.Enabled = false;
            txtPassword.Clear();

            btnStartLog.Text = "End";

            passwordValidated = false; // Set passwordValidated back to false, used to validate before ending the log


            logTime = DateTime.Now;
            timer.Start();
            startTime = logTime.ToString();

            if (standalone) {
                xmlManager.AddPartialLog(txtUsername.Text,
                    account,
                    instrument,
                    startTime);
            } else {

                if (dbManager.GetServerDateTime(out currentTime)) {
                    dbManager.AddTimeLog(account, dbManager.GetUserID(username), 'Y',
                                         int.Parse(instrument), currentTime);
                } else {
                    MessageBox.Show("Error: Could not connect to server. \r\nCheck connection or contact your server administrater");
                }
            }

        }


        // Disposes of the this panel and moves it's children
        private void EndLog() {
            if (standalone) {
                xmlManager.AddLogEndTime(username, account, instrument, startTime, DateTime.Now.ToString());

            } else {
                DateTime endTime;
                if (dbManager.GetServerDateTime(out endTime)) {
                    dbManager.AddTimeLogEndTime(account, dbManager.GetUserID(username), int.Parse(instrument), currentTime, endTime);
                } else {
                    MessageBox.Show("Could not connect to server, \r\nPlease contact your server admin");
                }
            }
            MoveChildren(-1 * (this.Size.Height + BOTTOM_PADDING)); //Multiply by -1 bacause the panel need to move up
            this.Dispose();
        }

        private void ValidatePassword() {

            username = txtUsername.Text;
            password = txtPassword.Text;

            bool valid = false;

            // ------------------------------------ Standalone Section ---------------------------------------------- //

            if (standalone) {
                valid = xmlManager.CheckPassword(username, password);

            } else { // ------------------------------------ Server Section ----------------------------------------- //
                valid = dbManager.CheckPassword(username, password);
            }

            if (logStarted) { // ----------------------------- End Log ----------------------------------------------- //
                if (valid) {
                    passwordValidated = true;
                    btnStartLog.Enabled = true;
                } else {
                    btnStartLog.Enabled = false;
                }
            } else { // ------------------------------------- Start Log ---------------------------------------------- //
                if (valid) {
                    passwordValidated = true;

                    // Adjust form controls to allow user to start the log
                    LoadStartLogControls();

                } else {
                    // Prevent the user from starting the log
                    lblAuthenticating.Text = "Error: Password Invalid";

                    DisableStartControls();

                }
            }
        }


        // Control Management functions
        private void DisableStartControls() {

            txtUsername.Clear();
            txtPassword.Clear();
            lblAuthenticating.Text = "";

            cboFundingSource.Enabled = false;
            cboInstrument.Enabled = false;

            cboFundingSource.DataSource = null;
            cboInstrument.DataSource = null;

            txtUsername.Focus();

        }

        public void LoadStartLogControls() {

            if (standalone) {
                BindingList<Data> instruments = new BindingList<Data>();

                if (!xmlManager.GetUserInstruments(txtUsername.Text, out instruments)) {
                    StartErrorMsg("No instruments were found for this user");
                }

                cboInstrument.DataSource = instruments;
                cboInstrument.DisplayMember = "Name";
                cboInstrument.ValueMember = "Value";

                string currentID = instruments[0].Value;

                LoadInstrumentAccounts(currentID);

            } else {

                DataTable userInstruments = dbManager.GetUserInstruments(txtUsername.Text);
                if (userInstruments.Rows.Count == 0) {
                    StartErrorMsg("There are no instruments assigned to your username");
                    return;
                }


                cboInstrument.DataSource = userInstruments;
                cboInstrument.DisplayMember = "Name";
                cboInstrument.ValueMember = "InstrumentID";

                LoadFunding();

            }

            cboFundingSource.Enabled = true;
            cboInstrument.Enabled = true;
            btnStartLog.Enabled = true;
            lblAuthenticating.Text = "Authentication Successful";
        }

        private void LoadInstrumentAccounts(string currentID) {

            BindingList<Data> accounts = new BindingList<Data>();
            xmlManager.GetFilteredUserAccounts(txtUsername.Text, currentID, out accounts);

            cboFundingSource.DataSource = accounts;
            cboFundingSource.DisplayMember = "Name";
            cboFundingSource.ValueMember = "Value";
            cboFundingSource.Refresh();
            cboFundingSource.Focus();
        }

        private void LoadFunding() {
            DataTable accounts = dbManager.GetFilteredUserAccounts(username, int.Parse(cboInstrument.SelectedValue.ToString()));
            if (accounts.Rows.Count == 0) {
            }

            cboFundingSource.DataSource = accounts;
            cboFundingSource.DisplayMember = "Name";
            cboFundingSource.ValueMember = "Account_Number";
        }





        private void StartErrorMsg(string message) {
            MessageBox.Show(message);
            passwordValidated = false;
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void MoveChildren(int yOffset) {
            if (childPanel != null) {
                childPanel.MoveChildrenRecursive(yOffset);
            }
        }

        private void MoveChildrenRecursive(int yOffset) {
            this.Location = new Point(this.Location.X, this.Location.Y + yOffset);
            if (childPanel != null) {
                childPanel.MoveChildrenRecursive(yOffset);
            }
        }

        private LogPanel GetChildPanel() {
            return this.childPanel;
        }

        private void cboInstrument_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboFundingSource.Enabled)
                if (standalone) {
                    LoadInstrumentAccounts(cboInstrument.SelectedValue.ToString());
                } else { LoadFunding(); }
        }

        private void btnValidate_Clicked(object sender, EventArgs e) {
            ValidatePassword();
            cboInstrument.Focus();
        }

        private void btnStartLog_Clicked(object sender, EventArgs e) {
            if (logStarted) {
                if (passwordValidated) EndLog();
            } else {
                StartLog();
                lblAuthenticating.Text = "";
                btnStartLog.Enabled = false;
            }

        }

    }
}
