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
            components = new System.ComponentModel.Container();
            timerCodeRefresh = new System.Windows.Forms.Timer(components);
            listBoxTotps = new ListBox();
            textBoxTOTPCode = new TextBox();
            progressBarTimeRemaining = new ProgressBar();
            buttonNew = new Button();
            buttonDelete = new Button();
            splitContainer1 = new SplitContainer();
            linkLabel1 = new LinkLabel();
            labelCopyHelper = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // timerCodeRefresh
            // 
            timerCodeRefresh.Enabled = true;
            timerCodeRefresh.Tick += TimerCodeRefresh_Tick;
            // 
            // listBoxTotps
            // 
            listBoxTotps.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxTotps.FormattingEnabled = true;
            listBoxTotps.ItemHeight = 15;
            listBoxTotps.Location = new Point(3, 31);
            listBoxTotps.Name = "listBoxTotps";
            listBoxTotps.ScrollAlwaysVisible = true;
            listBoxTotps.Size = new Size(210, 124);
            listBoxTotps.TabIndex = 1;
            listBoxTotps.SelectedIndexChanged += ListBoxTotps_SelectedIndexChanged;
            // 
            // textBoxTOTPCode
            // 
            textBoxTOTPCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTOTPCode.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTOTPCode.Location = new Point(17, 31);
            textBoxTOTPCode.Name = "textBoxTOTPCode";
            textBoxTOTPCode.ReadOnly = true;
            textBoxTOTPCode.Size = new Size(246, 35);
            textBoxTOTPCode.TabIndex = 11;
            textBoxTOTPCode.Text = "123456";
            textBoxTOTPCode.TextAlign = HorizontalAlignment.Center;
            textBoxTOTPCode.MouseClick += TextBoxTOTPCode_MouseClick;
            // 
            // progressBarTimeRemaining
            // 
            progressBarTimeRemaining.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarTimeRemaining.Location = new Point(17, 68);
            progressBarTimeRemaining.Name = "progressBarTimeRemaining";
            progressBarTimeRemaining.Size = new Size(246, 14);
            progressBarTimeRemaining.TabIndex = 12;
            progressBarTimeRemaining.Value = 50;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(11, 3);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 14;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += ButtonNew_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(92, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 15;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBoxTotps);
            splitContainer1.Panel1.Controls.Add(buttonDelete);
            splitContainer1.Panel1.Controls.Add(buttonNew);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(linkLabel1);
            splitContainer1.Panel2.Controls.Add(labelCopyHelper);
            splitContainer1.Panel2.Controls.Add(textBoxTOTPCode);
            splitContainer1.Panel2.Controls.Add(progressBarTimeRemaining);
            splitContainer1.Size = new Size(497, 163);
            splitContainer1.SplitterDistance = 216;
            splitContainer1.TabIndex = 16;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(17, 133);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(101, 15);
            linkLabel1.TabIndex = 16;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Change password";
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // labelCopyHelper
            // 
            labelCopyHelper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCopyHelper.Location = new Point(15, 11);
            labelCopyHelper.Name = "labelCopyHelper";
            labelCopyHelper.Size = new Size(250, 15);
            labelCopyHelper.TabIndex = 15;
            labelCopyHelper.Text = "Click code to copy to clipboard";
            labelCopyHelper.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(497, 163);
            Controls.Add(splitContainer1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TOTP App";
            Load += Main_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
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
        private LinkLabel linkLabel1;
    }
}