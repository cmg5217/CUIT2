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
 
namespace CUITAdmin {
    public partial class LogPanel : Panel {

        const int BOTTOM_PADDING = 10;

        private string username, password;

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

        private Timer timeElapsed;

        bool running = false;


        private LogPanel parentPanel;
        private LogPanel childPanel;



        public LogPanel(Control container) {
            InitializeComponent();
            this.container = container;
            container.Controls.Add(this);
            this.Visible = true;
            AddControls();
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
            this.lblAuthenticating.Text = "Authenticating";
            // 
            // cboFundingSource
            // 
            this.cboFundingSource.FormattingEnabled = true;
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
            this.cboInstrument.Location = new System.Drawing.Point(416, 77);
            this.cboInstrument.Name = "cboInstrument";
            this.cboInstrument.Size = new System.Drawing.Size(121, 21);
            this.cboInstrument.TabIndex = 9;
        }

        // Adjust the controls for an active log, called on btnStart_Clicked
        private void StartLog() {

            bool invalid = false;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../records.xml");
            XmlNode userNodes = xmlDoc.SelectSingleNode("//root/users");
            System.Diagnostics.Debug.WriteLine(userNodes.OuterXml);

            XmlNode testNode = xmlDoc.SelectSingleNode("//root/users/user");
            System.Diagnostics.Debug.WriteLine("test" + testNode.InnerText);

            
            foreach(XmlNode userNode in userNodes){
                System.Diagnostics.Debug.WriteLine("In foreach");
                XmlNode usernameNode = userNode.SelectSingleNode("username");
                if (usernameNode != null)System.Diagnostics.Debug.WriteLine("UserName: " + usernameNode.InnerText);
                if (txtUsername.Text == usernameNode.InnerText) {
                    if (userNode.SelectSingleNode("password").InnerText != txtPassword.Text) {
                        MessageBox.Show("you don't know your fucking password dumbass");
                        invalid = true;
                        return;
                    }
                }
            }


            if (invalid) return;

            childPanel = new LogPanel(container, this);
            childPanel.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height + BOTTOM_PADDING);

            running = true;

            // --Adjust Controls--
            cboInstrument.Enabled = false;
            cboFundingSource.Enabled = false;

            txtUsername.Enabled = false;
            txtPassword.Clear();

            btnStartLog.Text = "End";

            timeElapsed = new Timer();
            timeElapsed.Start();

            // To-Do: Add Query to add partial log with start time


            
            
        }

        // Disposes of the this panel and moves it's children
        private void EndLog() {
            // To-Do:: Add database interactions to add an end time to the created log

            MoveChildren(-1 * (this.Size.Height + BOTTOM_PADDING)); //Multiply by -1 bacause the panel need to move up
            this.Dispose();
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
            if (running) {
                EndLog();
            } else {
                StartLog();
            }
        }

        private void timeElapsed_Elapsed(object sender, EventArgs e) {
            // lblTimeElapsed.Text = int.Parse(lblTimeElapsed) + 1
        }
    }
}
