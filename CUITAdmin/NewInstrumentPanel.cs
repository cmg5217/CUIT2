using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CUITAdmin
{
    class NewInstrumentPanel : Panel
    {
        Button btnSubmit = new Button();
        TextBox txtIndustry = new TextBox();
        TextBox txtExternalAcademic = new TextBox();
        TextBox txtInternalAcademic = new TextBox();
        TextBox txtTimeIncrement = new TextBox();
        TextBox txtBillingType = new TextBox();
        TextBox txtInstrumentName = new TextBox();
        Label lblIndustry = new Label();
        Label lblExternalAcademic = new Label();
        Label lblInternalAcademic = new Label();
        Label lblTimeIncrement = new Label();
        Label lblBillingType = new Label();
        Label lblInstrumentName = new Label();

        public NewInstrumentPanel(NewEntryForm pForm)
        {
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();

        }

        private void addControls()
        {
            // 
            // pnlNewInstrument
            // 
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtIndustry);
            this.Controls.Add(this.txtExternalAcademic);
            this.Controls.Add(this.txtInternalAcademic);
            this.Controls.Add(this.txtTimeIncrement);
            this.Controls.Add(this.txtBillingType);
            this.Controls.Add(this.txtInstrumentName);
            this.Controls.Add(this.lblIndustry);
            this.Controls.Add(this.lblExternalAcademic);
            this.Controls.Add(this.lblInternalAcademic);
            this.Controls.Add(this.lblTimeIncrement);
            this.Controls.Add(this.lblBillingType);
            this.Controls.Add(this.lblInstrumentName);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlNewInstrument";
            this.Size = new System.Drawing.Size(285, 228);
            this.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(190, 179);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // txtIndustry
            // 
            this.txtIndustry.Location = new System.Drawing.Point(166, 152);
            this.txtIndustry.Name = "txtIndustry";
            this.txtIndustry.Size = new System.Drawing.Size(100, 20);
            this.txtIndustry.TabIndex = 11;
            // 
            // txtExternalAcademic
            // 
            this.txtExternalAcademic.Location = new System.Drawing.Point(166, 125);
            this.txtExternalAcademic.Name = "txtExternalAcademic";
            this.txtExternalAcademic.Size = new System.Drawing.Size(100, 20);
            this.txtExternalAcademic.TabIndex = 10;
            // 
            // txtInternalAcademic
            // 
            this.txtInternalAcademic.Location = new System.Drawing.Point(166, 98);
            this.txtInternalAcademic.Name = "txtInternalAcademic";
            this.txtInternalAcademic.Size = new System.Drawing.Size(100, 20);
            this.txtInternalAcademic.TabIndex = 9;
            // 
            // txtTimeIncrement
            // 
            this.txtTimeIncrement.Location = new System.Drawing.Point(166, 71);
            this.txtTimeIncrement.Name = "txtTimeIncrement";
            this.txtTimeIncrement.Size = new System.Drawing.Size(100, 20);
            this.txtTimeIncrement.TabIndex = 8;
            // 
            // txtBillingType
            // 
            this.txtBillingType.Location = new System.Drawing.Point(166, 44);
            this.txtBillingType.Name = "txtBillingType";
            this.txtBillingType.Size = new System.Drawing.Size(100, 20);
            this.txtBillingType.TabIndex = 7;
            // 
            // txtInstrumentName
            // 
            this.txtInstrumentName.Location = new System.Drawing.Point(166, 17);
            this.txtInstrumentName.Name = "txtInstrumentName";
            this.txtInstrumentName.Size = new System.Drawing.Size(100, 20);
            this.txtInstrumentName.TabIndex = 6;
            // 
            // lblIndustry
            // 
            this.lblIndustry.AutoSize = true;
            this.lblIndustry.Location = new System.Drawing.Point(18, 155);
            this.lblIndustry.Name = "lblIndustry";
            this.lblIndustry.Size = new System.Drawing.Size(73, 13);
            this.lblIndustry.TabIndex = 5;
            this.lblIndustry.Text = "Industry Rate:";
            // 
            // lblExternalAcademic
            // 
            this.lblExternalAcademic.AutoSize = true;
            this.lblExternalAcademic.Location = new System.Drawing.Point(18, 128);
            this.lblExternalAcademic.Name = "lblExternalAcademic";
            this.lblExternalAcademic.Size = new System.Drawing.Size(124, 13);
            this.lblExternalAcademic.TabIndex = 4;
            this.lblExternalAcademic.Text = "External Academic Rate:";
            // 
            // lblInternalAcademic
            // 
            this.lblInternalAcademic.AutoSize = true;
            this.lblInternalAcademic.Location = new System.Drawing.Point(18, 101);
            this.lblInternalAcademic.Name = "lblInternalAcademic";
            this.lblInternalAcademic.Size = new System.Drawing.Size(121, 13);
            this.lblInternalAcademic.TabIndex = 3;
            this.lblInternalAcademic.Text = "Internal Academic Rate:";
            // 
            // lblTimeIncrement
            // 
            this.lblTimeIncrement.AutoSize = true;
            this.lblTimeIncrement.Location = new System.Drawing.Point(18, 74);
            this.lblTimeIncrement.Name = "lblTimeIncrement";
            this.lblTimeIncrement.Size = new System.Drawing.Size(83, 13);
            this.lblTimeIncrement.TabIndex = 2;
            this.lblTimeIncrement.Text = "Time Increment:";
            // 
            // lblBillingType
            // 
            this.lblBillingType.AutoSize = true;
            this.lblBillingType.Location = new System.Drawing.Point(18, 47);
            this.lblBillingType.Name = "lblBillingType";
            this.lblBillingType.Size = new System.Drawing.Size(64, 13);
            this.lblBillingType.TabIndex = 1;
            this.lblBillingType.Text = "Billing Type:";
            // 
            // lblInstrumentName
            // 
            this.lblInstrumentName.AutoSize = true;
            this.lblInstrumentName.Location = new System.Drawing.Point(18, 20);
            this.lblInstrumentName.Name = "lblInstrumentName";
            this.lblInstrumentName.Size = new System.Drawing.Size(90, 13);
            this.lblInstrumentName.TabIndex = 0;
            this.lblInstrumentName.Text = "Instrument Name:";
        }
    }
}
