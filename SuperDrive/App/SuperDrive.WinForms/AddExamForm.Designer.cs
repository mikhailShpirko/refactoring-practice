namespace SuperDrive.WinForms
{
    partial class AddExamForm
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
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblCapacityHint = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateHint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCapacity
            // 
            this.nudCapacity.Location = new System.Drawing.Point(224, 42);
            this.nudCapacity.Margin = new System.Windows.Forms.Padding(4);
            this.nudCapacity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(125, 23);
            this.nudCapacity.TabIndex = 0;
            // 
            // lblCapacityHint
            // 
            this.lblCapacityHint.AutoSize = true;
            this.lblCapacityHint.Location = new System.Drawing.Point(224, 18);
            this.lblCapacityHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapacityHint.Name = "lblCapacityHint";
            this.lblCapacityHint.Size = new System.Drawing.Size(62, 17);
            this.lblCapacityHint.TabIndex = 1;
            this.lblCapacityHint.Text = "Capacity";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(21, 42);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 23);
            this.dtpDate.TabIndex = 2;
            // 
            // lblDateHint
            // 
            this.lblDateHint.AutoSize = true;
            this.lblDateHint.Location = new System.Drawing.Point(18, 18);
            this.lblDateHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateHint.Name = "lblDateHint";
            this.lblDateHint.Size = new System.Drawing.Size(76, 17);
            this.lblDateHint.TabIndex = 3;
            this.lblDateHint.Text = "Exam Date";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 86);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 157);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDateHint);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblCapacityHint);
            this.Controls.Add(this.nudCapacity);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddExamForm";
            this.Text = "Create exam";
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblCapacityHint;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDateHint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}