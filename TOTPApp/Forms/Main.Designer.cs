namespace TOTPApp.Forms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerCodeRefresh = new System.Windows.Forms.Timer(this.components);
            this.listBoxTotps = new System.Windows.Forms.ListBox();
            this.textBoxTOTPCode = new System.Windows.Forms.TextBox();
            this.progressBarTimeRemaining = new System.Windows.Forms.ProgressBar();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelCopyHelper = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCodeRefresh
            // 
            this.timerCodeRefresh.Enabled = true;
            this.timerCodeRefresh.Tick += new System.EventHandler(this.TimerCodeRefresh_Tick);
            // 
            // listBoxTotps
            // 
            this.listBoxTotps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTotps.FormattingEnabled = true;
            this.listBoxTotps.ItemHeight = 15;
            this.listBoxTotps.Location = new System.Drawing.Point(3, 31);
            this.listBoxTotps.Name = "listBoxTotps";
            this.listBoxTotps.ScrollAlwaysVisible = true;
            this.listBoxTotps.Size = new System.Drawing.Size(178, 124);
            this.listBoxTotps.TabIndex = 1;
            this.listBoxTotps.SelectedIndexChanged += new System.EventHandler(this.ListBoxTotps_SelectedIndexChanged);
            // 
            // textBoxTOTPCode
            // 
            this.textBoxTOTPCode.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxTOTPCode.Location = new System.Drawing.Point(17, 31);
            this.textBoxTOTPCode.Name = "textBoxTOTPCode";
            this.textBoxTOTPCode.ReadOnly = true;
            this.textBoxTOTPCode.Size = new System.Drawing.Size(246, 35);
            this.textBoxTOTPCode.TabIndex = 11;
            this.textBoxTOTPCode.Text = "123456";
            this.textBoxTOTPCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTOTPCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxTOTPCode_MouseClick);
            // 
            // progressBarTimeRemaining
            // 
            this.progressBarTimeRemaining.Location = new System.Drawing.Point(17, 68);
            this.progressBarTimeRemaining.Name = "progressBarTimeRemaining";
            this.progressBarTimeRemaining.Size = new System.Drawing.Size(246, 14);
            this.progressBarTimeRemaining.TabIndex = 12;
            this.progressBarTimeRemaining.Value = 50;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(11, 3);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 14;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(92, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxTotps);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer1.Panel1.Controls.Add(this.buttonNew);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelCopyHelper);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTOTPCode);
            this.splitContainer1.Panel2.Controls.Add(this.progressBarTimeRemaining);
            this.splitContainer1.Size = new System.Drawing.Size(465, 170);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 16;
            // 
            // labelCopyHelper
            // 
            this.labelCopyHelper.Location = new System.Drawing.Point(15, 11);
            this.labelCopyHelper.Name = "labelCopyHelper";
            this.labelCopyHelper.Size = new System.Drawing.Size(250, 15);
            this.labelCopyHelper.TabIndex = 15;
            this.labelCopyHelper.Text = "Click code to copy to clipboard";
            this.labelCopyHelper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 170);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TOTP App";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCodeRefresh;
        private ListBox listBoxTotps;
        private TextBox textBoxTOTPCode;
        private ProgressBar progressBarTimeRemaining;
        private Button buttonNew;
        private Button buttonDelete;
        private SplitContainer splitContainer1;
        private Label labelCopyHelper;
    }
}