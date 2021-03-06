﻿namespace OpenCBS.GUI.Batch
{
    partial class FrmScheduledBatches
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
            this.label5 = new System.Windows.Forms.Label();
            this.lvScheduledBatches = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.dtpScheduledBatchDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewResult = new System.Windows.Forms.Button();
            this.btnViewLogFile = new System.Windows.Forms.Button();
            this.btnScheduleABatch = new System.Windows.Forms.Button();
            this.btnRunBatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, -2);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(920, 36);
            this.label5.TabIndex = 57;
            this.label5.Text = "Scheduled Batches";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvScheduledBatches
            // 
            this.lvScheduledBatches.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvScheduledBatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvScheduledBatches.FullRowSelect = true;
            this.lvScheduledBatches.GridLines = true;
            this.lvScheduledBatches.Location = new System.Drawing.Point(6, 37);
            this.lvScheduledBatches.Name = "lvScheduledBatches";
            this.lvScheduledBatches.Size = new System.Drawing.Size(701, 530);
            this.lvScheduledBatches.TabIndex = 58;
            this.lvScheduledBatches.UseCompatibleStateImageBehavior = false;
            this.lvScheduledBatches.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "S. No.";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Batch Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 117;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Scheduled Date";
            this.columnHeader8.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Batch Result";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 169;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "User";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 196;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Log File Path";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 172;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "No Of Runs";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(713, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Scheduled Batch Date";
            // 
            // dtpScheduledBatchDate
            // 
            this.dtpScheduledBatchDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpScheduledBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduledBatchDate.Location = new System.Drawing.Point(713, 56);
            this.dtpScheduledBatchDate.Name = "dtpScheduledBatchDate";
            this.dtpScheduledBatchDate.Size = new System.Drawing.Size(76, 20);
            this.dtpScheduledBatchDate.TabIndex = 60;
            // 
            // btnViewResult
            // 
            this.btnViewResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewResult.Location = new System.Drawing.Point(713, 82);
            this.btnViewResult.Name = "btnViewResult";
            this.btnViewResult.Size = new System.Drawing.Size(141, 26);
            this.btnViewResult.TabIndex = 62;
            this.btnViewResult.Text = "View Result";
            this.btnViewResult.Click += new System.EventHandler(this.btnViewResult_Click);
            // 
            // btnViewLogFile
            // 
            this.btnViewLogFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewLogFile.Location = new System.Drawing.Point(713, 114);
            this.btnViewLogFile.Name = "btnViewLogFile";
            this.btnViewLogFile.Size = new System.Drawing.Size(141, 26);
            this.btnViewLogFile.TabIndex = 63;
            this.btnViewLogFile.Text = "View Log File";
            this.btnViewLogFile.Click += new System.EventHandler(this.btnViewLogFile_Click);
            // 
            // btnScheduleABatch
            // 
            this.btnScheduleABatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnScheduleABatch.Location = new System.Drawing.Point(713, 146);
            this.btnScheduleABatch.Name = "btnScheduleABatch";
            this.btnScheduleABatch.Size = new System.Drawing.Size(141, 26);
            this.btnScheduleABatch.TabIndex = 64;
            this.btnScheduleABatch.Text = "Schedule  A Batch";
            this.btnScheduleABatch.Click += new System.EventHandler(this.btnScheduleABatch_Click);
            // 
            // btnRunBatch
            // 
            this.btnRunBatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRunBatch.Location = new System.Drawing.Point(713, 178);
            this.btnRunBatch.Name = "btnRunBatch";
            this.btnRunBatch.Size = new System.Drawing.Size(141, 26);
            this.btnRunBatch.TabIndex = 65;
            this.btnRunBatch.Text = "Run Scheduled Batch";
            this.btnRunBatch.Click += new System.EventHandler(this.btnRunBatch_Click);
            // 
            // FrmScheduledBatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 678);
            this.Controls.Add(this.btnRunBatch);
            this.Controls.Add(this.btnScheduleABatch);
            this.Controls.Add(this.btnViewLogFile);
            this.Controls.Add(this.btnViewResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpScheduledBatchDate);
            this.Controls.Add(this.lvScheduledBatches);
            this.Controls.Add(this.label5);
            this.Name = "FrmScheduledBatches";
            this.Text = "Scheduled Batches";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvScheduledBatches;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpScheduledBatchDate;
        private System.Windows.Forms.Button btnViewResult;
        private System.Windows.Forms.Button btnViewLogFile;
        private System.Windows.Forms.Button btnScheduleABatch;
        private System.Windows.Forms.Button btnRunBatch;
    }
}