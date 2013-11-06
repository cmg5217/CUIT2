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

        private string username, password, account, instrument;
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
        private TextBox txtPassword = new TextBox();
        private TextBox txtUsername = new TextBox();
        private Button btnStartLog = new Button();
        private DateTime logTime = new DateTime();


        private System.Timers.Timer timeElapsed;
        private System.Timers.Timer passwordTimer;     // Timer for when the user pauses while typing in their password

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

            passwordTimer = new System.Timers.Timer(600);
            passwordTimer.Elapsed += new ElapsedEventHandler(pauseTimer_Elapsed);

            xmlManager = XmlManager.Instance;
            dbManager = DBManager.Instance;



            if (Properties.Settings.Default.StandaloneMode == "true") {
                standalone = true;
            } else {
                standalone = false;
                cboInstrument.DataSource = dbManager.GetInstruments();
                cboInstrument.DisplayMember = "Name";
                cboInstrument.ValueMember = "InstrumentID";
            }

        }

        public LogPanel(Control container, Point location) 
            :this(container){
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
            this.Name = "panel1";
            this.Size = new System.Drawing.Size(655, 177);
            this.TabIndex = 0;
            // 
            // btnStartLog
            // 
            this.btnStartLog.Location = new System.Drawing.Point(462, 106);
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.Size = new System.Drawing.Size(75, 23);
            this.btnStartLog.TabIndex = 0;
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
            this.txtPassword.TextChanged += txtPassword_TextChanged;
            this.txtPassword.Enter += txtPassword_Enter;
            this.txtPassword.PasswordChar = '*';
            //
            // lblTimeElapsed
            //
            this.lblTimeElapsed.Location = new System.Drawing.Point(416, 72);
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
            this.lblAuthenticating.Location = new System.Drawing.Point(174, 111);
            this.lblAuthenticating.Name = "lblAuthenticating";
            this.lblAuthenticating.Size = new System.Drawing.Size(75, 13);
            this.lblAuthenticating.TabIndex = 5;
            this.lblAuthenticating.Text = "";
            // 
            // cboFundingSource
            // 
            this.cboFundingSource.FormattingEnabled = true;
            this.cboFundingSource.Enabled = false;
            this.cboFundingSource.Location = new System.Drawing.Point(416, 51);
            this.cboFundingSource.Name = "cboFundingSource";
            this.cboFundingSource.Size = new System.Drawing.Size(121, 21);
            this.cboFundingSource.TabIndex = 6;
            // 
            // lblFundingSource
            // 
            this.lblFundingSource.AutoSize = true;
            this.lblFundingSource.Location = new System.Drawing.Point(326, 55);
            this.lblFundingSource.Name = "lblFundingSource";
            this.lblFundingSource.Size = new System.Drawing.Size(85, 13);
            this.lblFundingSource.TabIndex = 7;
            this.lblFundingSource.Text = "Funding Source:";
            // 
            // lblInstrument
            // 
            this.lblInstrument.AutoSize = true;
            this.lblInstrument.Location = new System.Drawing.Point(329, 81);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(59, 13);
            this.lblInstrument.TabIndex = 8;
            this.lblInstrument.Text = "Instrument:";
            // 
            // cboInstrument
            // 
            this.cboInstrument.FormattingEnabled = true;
            this.cboInstrument.Enabled = false;
            this.cboInstrument.Location = new System.Drawing.Point(416, 77);
            this.cboInstrument.Name = "cboInstrument";
            this.cboInstrument.Size = new System.Drawing.Size(121, 21);
            this.cboInstrument.TabIndex = 9;
        }

        // Adjust the controls for an active log, called on btnStart_Clicked
        private void StartLog() {

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Start Standalone Section
            
            //if (invalid) return;

            childPanel = new LogPanel(container, this);
            childPanel.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height + BOTTOM_PADDING);

            logStarted = true;

            // --Adjust Controls--
            cboInstrument.Enabled = false;
            cboFundingSource.Enabled = false;
            lblAuthenticating.Text = "Authentification Successful";

            txtUsername.Enabled = false;
            txtPassword.Clear();
            


            btnStartLog.Text = "End";

            timeElapsed = new System.Timers.Timer();
            timeElapsed.Start();

            passwordValidated = false; // Set passwordValidated back to false, used to validate before ending the log

            if (standalone) {
                account = cboFundingSource.SelectedValue.ToString();
                instrument = cboInstrument.SelectedItem.ToString();
                xmlManager.AddPartialLog(txtUsername.Text, 
                    account, 
                    instrument,
                    DateTime.Now.ToString());
            } else {
            // To-Do: Add Query to add partial log with start time
                

                if (dbManager.GetServerDateTime(out currentTime)) {
                    dbManager.AddTimeLog(cboFundingSource.SelectedValue.ToString(), dbManager.GetUserID(username), 'Y',
                                         int.Parse(cboInstrument.SelectedValue.ToString()), currentTime);
                } else {
                    MessageBox.Show("Error: Could not connect to server. \r\nCheck connection or contact your server administrater");
                }
            }

            
            
        }

       
        // Disposes of the this panel and moves it's children
        private void EndLog() {
            // To-Do:: Add database interactions to add an end time to the created log
            if (standalone) {


            } else {
                DateTime endTime;
                
                if(dbManager.GetServerDateTime(out endTime)){
                    //dbManager.AddTimeLogEndTime(account, dbManager.GetUserID(username), instrument, currentTime, endTime)
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
                    CustomInvoke(btnStartLog, delegate { btnStartLog.Enabled = true; });
                } else {
                    CustomInvoke(btnStartLog, delegate { btnStartLog.Enabled = false; });
                }
            } else { // ------------------------------------- Start Log ---------------------------------------------- //
                if (valid) {
                    passwordValidated = true;

                    // Adjust form controls to allow user to start the log
                    LoadStartLogControls();

                } else {
                    // Prevent the user from starting the log
                    CustomInvoke(lblAuthenticating, delegate { lblAuthenticating.Text = "Error: Password Invalid"; });
                    CustomInvoke(cboFundingSource, delegate {
                        cboFundingSource.Enabled = false;
                        cboFundingSource.DataSource = null;
                    });
                    CustomInvoke(cboInstrument, delegate {
                        cboInstrument.Enabled = false;
                    });
                }
            }
            passwordTimer.Stop();
        }

        public void LoadStartLogControls() {
            CustomInvoke(cboFundingSource, delegate {cboFundingSource.Enabled = true;});
            CustomInvoke(cboInstrument, delegate { cboInstrument.Enabled = true; });
            CustomInvoke(btnStartLog, delegate { btnStartLog.Enabled = true; });
            CustomInvoke(lblAuthenticating, delegate { lblAuthenticating.Text = "Authentication Successful"; });

            if (standalone) {

            } else {
                CustomInvoke(cboFundingSource,
                    delegate {
                        cboFundingSource.DataSource = dbManager.GetUserAccounts(username);
                        cboFundingSource.DisplayMember = "Name";
                        cboFundingSource.ValueMember = "Account_Number";
                    });
            }

        }

        // This prevents me from writing about 15 if statements, it's kinda like $() in javascript
        // Checks to see if invoke is needed before performing methods on the control
        private void CustomInvoke(Control control, Action action){
            // check to see if invoke is required
            if (control.InvokeRequired) {
                // if it is, use invoke on the control
                control.Invoke(new MethodInvoker(action.Invoke));
            } else {
                // if it isn't let the function passed in be executed
                action.Invoke();
            }
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

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        private void btnStartLog_Clicked(object sender, EventArgs e) {
            if (logStarted) {
                if(passwordValidated) EndLog();
            } else {
                StartLog();
                btnStartLog.Enabled = false;
            }

        }

        // Used so that this only gets called once
        bool firstEnter = true;
        private void txtPassword_Enter(object sender, EventArgs e) {
            if (firstEnter) {
                firstEnter = false;
                txtUsername.TextChanged += txtPassword_TextChanged;
            }
        }


        private void txtPassword_TextChanged(object sender, EventArgs e) {
            passwordTimer.Stop();
            passwordTimer.Start();
        }

        // Uses a background worker to change the authentification lbls text
        // background worker needed for threadsafe calls to the form
        
        private void pauseTimer_Elapsed(object sender, EventArgs e) {
            this.ValidatePassword();
            //this.verifyPasswordBGW.RunWorkerAsync();
        }

        private void timeElapsed_Elapsed(object sender, EventArgs e) {
            // lblTimeElapsed.Text = int.Parse(lblTimeElapsed) + 1
        }
    }


}
