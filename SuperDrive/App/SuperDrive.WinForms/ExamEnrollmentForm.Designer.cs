namespace SuperDrive.WinForms
{
    partial class ExamEnrollmentForm
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
            this.components = new System.ComponentModel.Container();
            this.lblDateHint = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblCapacityHint = new System.Windows.Forms.Label();
            this.dgvEnrolledStudents = new System.Windows.Forms.DataGridView();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrolledStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateHint
            // 
            this.lblDateHint.AutoSize = true;
            this.lblDateHint.Location = new System.Drawing.Point(23, 18);
            this.lblDateHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateHint.Name = "lblDateHint";
            this.lblDateHint.Size = new System.Drawing.Size(80, 17);
            this.lblDateHint.TabIndex = 0;
            this.lblDateHint.Text = "Exam Date:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(111, 18);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(76, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Exam Date";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(307, 18);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(62, 17);
            this.lblCapacity.TabIndex = 3;
            this.lblCapacity.Text = "Capacity";
            // 
            // lblCapacityHint
            // 
            this.lblCapacityHint.AutoSize = true;
            this.lblCapacityHint.Location = new System.Drawing.Point(233, 18);
            this.lblCapacityHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapacityHint.Name = "lblCapacityHint";
            this.lblCapacityHint.Size = new System.Drawing.Size(66, 17);
            this.lblCapacityHint.TabIndex = 2;
            this.lblCapacityHint.Text = "Capacity:";
            // 
            // dgvEnrolledStudents
            // 
            this.dgvEnrolledStudents.AllowUserToAddRows = false;
            this.dgvEnrolledStudents.AllowUserToDeleteRows = false;
            this.dgvEnrolledStudents.AutoGenerateColumns = false;
            this.dgvEnrolledStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnrolledStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrolledStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.dateOfBirthDataGridViewTextBoxColumn,
            this.entryDateDataGridViewTextBoxColumn});
            this.dgvEnrolledStudents.DataSource = this.studentBindingSource;
            this.dgvEnrolledStudents.Location = new System.Drawing.Point(26, 58);
            this.dgvEnrolledStudents.Name = "dgvEnrolledStudents";
            this.dgvEnrolledStudents.ReadOnly = true;
            this.dgvEnrolledStudents.Size = new System.Drawing.Size(489, 471);
            this.dgvEnrolledStudents.TabIndex = 4;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(SuperDrive.Domain.Students.Student);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            this.dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn.HeaderText = "Date Of Birth";
            this.dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            this.dateOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // entryDateDataGridViewTextBoxColumn
            // 
            this.entryDateDataGridViewTextBoxColumn.DataPropertyName = "EntryDate";
            this.entryDateDataGridViewTextBoxColumn.HeaderText = "Entry Date";
            this.entryDateDataGridViewTextBoxColumn.Name = "entryDateDataGridViewTextBoxColumn";
            this.entryDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(407, 12);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(108, 29);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // ExamEnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 554);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.dgvEnrolledStudents);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblCapacityHint);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDateHint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExamEnrollmentForm";
            this.Text = "Exam Enrollment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrolledStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateHint;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblCapacityHint;
        private System.Windows.Forms.DataGridView dgvEnrolledStudents;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDone;
    }
}