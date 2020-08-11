namespace SuperDrive.WinForms
{
    partial class AddEditStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.lblAddressHint = new System.Windows.Forms.Label();
            this.lblEntryDateHint = new System.Windows.Forms.Label();
            this.lblDateOfBirthHint = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(13, 40);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(397, 23);
            this.tbxName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Full Name";
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(15, 107);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(395, 23);
            this.tbxAddress.TabIndex = 2;
            // 
            // lblAddressHint
            // 
            this.lblAddressHint.AutoSize = true;
            this.lblAddressHint.Location = new System.Drawing.Point(12, 86);
            this.lblAddressHint.Name = "lblAddressHint";
            this.lblAddressHint.Size = new System.Drawing.Size(60, 17);
            this.lblAddressHint.TabIndex = 3;
            this.lblAddressHint.Text = "Address";
            // 
            // lblEntryDateHint
            // 
            this.lblEntryDateHint.AutoSize = true;
            this.lblEntryDateHint.Location = new System.Drawing.Point(229, 157);
            this.lblEntryDateHint.Name = "lblEntryDateHint";
            this.lblEntryDateHint.Size = new System.Drawing.Size(75, 17);
            this.lblEntryDateHint.TabIndex = 4;
            this.lblEntryDateHint.Text = "Entry Date";
            // 
            // lblDateOfBirthHint
            // 
            this.lblDateOfBirthHint.AutoSize = true;
            this.lblDateOfBirthHint.Location = new System.Drawing.Point(12, 157);
            this.lblDateOfBirthHint.Name = "lblDateOfBirthHint";
            this.lblDateOfBirthHint.Size = new System.Drawing.Size(87, 17);
            this.lblDateOfBirthHint.TabIndex = 4;
            this.lblDateOfBirthHint.Text = "Date of Birth";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(13, 177);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(175, 23);
            this.dtpDateOfBirth.TabIndex = 5;
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntryDate.Location = new System.Drawing.Point(232, 177);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(178, 23);
            this.dtpEntryDate.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 37);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(178, 37);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 292);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpEntryDate);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirthHint);
            this.Controls.Add(this.lblEntryDateHint);
            this.Controls.Add(this.lblAddressHint);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbxName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddEditStudentForm";
            this.Text = "AddEditStudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label lblAddressHint;
        private System.Windows.Forms.Label lblEntryDateHint;
        private System.Windows.Forms.Label lblDateOfBirthHint;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}