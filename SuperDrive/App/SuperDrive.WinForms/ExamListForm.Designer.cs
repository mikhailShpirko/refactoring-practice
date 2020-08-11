namespace SuperDrive.WinForms
{
    partial class ExamListForm
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
            this.dgvExamList = new System.Windows.Forms.DataGridView();
            this.examBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.examBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExamList
            // 
            this.dgvExamList.AllowUserToAddRows = false;
            this.dgvExamList.AllowUserToDeleteRows = false;
            this.dgvExamList.AutoGenerateColumns = false;
            this.dgvExamList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.capacityDataGridViewTextBoxColumn});
            this.dgvExamList.DataSource = this.examBindingSource;
            this.dgvExamList.Location = new System.Drawing.Point(31, 27);
            this.dgvExamList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvExamList.MultiSelect = false;
            this.dgvExamList.Name = "dgvExamList";
            this.dgvExamList.ReadOnly = true;
            this.dgvExamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamList.Size = new System.Drawing.Size(695, 261);
            this.dgvExamList.TabIndex = 0;
            // 
            // examBindingSource
            // 
            this.examBindingSource.DataSource = typeof(SuperDrive.Domain.Exams.Exam);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // capacityDataGridViewTextBoxColumn
            // 
            this.capacityDataGridViewTextBoxColumn.DataPropertyName = "Capacity";
            this.capacityDataGridViewTextBoxColumn.HeaderText = "Capacity";
            this.capacityDataGridViewTextBoxColumn.Name = "capacityDataGridViewTextBoxColumn";
            this.capacityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(777, 27);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 28);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(777, 81);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(100, 28);
            this.btnEnroll.TabIndex = 2;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // ExamListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 319);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgvExamList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExamListForm";
            this.Text = "Exams";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.examBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExamList;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource examBindingSource;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnEnroll;
    }
}