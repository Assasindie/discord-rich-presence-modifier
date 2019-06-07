namespace drpmodifier
{
    partial class Form1
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
            this.detailsTextBox = new System.Windows.Forms.RichTextBox();
            this.largeImageTextBox = new System.Windows.Forms.RichTextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.largeImageLabel = new System.Windows.Forms.Label();
            this.clientIDTextBox = new System.Windows.Forms.RichTextBox();
            this.clientIDLabel = new System.Windows.Forms.Label();
            this.initializeButton = new System.Windows.Forms.Button();
            this.stateTextBox = new System.Windows.Forms.RichTextBox();
            this.endTimeBox = new System.Windows.Forms.NumericUpDown();
            this.smallImageTextBox = new System.Windows.Forms.RichTextBox();
            this.smallImageLabel = new System.Windows.Forms.Label();
            this.largeImageKeyTextBox = new System.Windows.Forms.RichTextBox();
            this.smallImageKeyTextBox = new System.Windows.Forms.RichTextBox();
            this.smallImageKeyLabel = new System.Windows.Forms.Label();
            this.largeImageKeyLabel = new System.Windows.Forms.Label();
            this.partyIDTextBox = new System.Windows.Forms.RichTextBox();
            this.joinSecretTextBox = new System.Windows.Forms.RichTextBox();
            this.joinSecretLabel = new System.Windows.Forms.Label();
            this.partyIDLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.endTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.timeElapsedCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.RichTextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.stopPresenceButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.endTimeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Location = new System.Drawing.Point(11, 3);
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(167, 27);
            this.detailsTextBox.TabIndex = 1;
            this.detailsTextBox.Text = "Big Game";
            // 
            // largeImageTextBox
            // 
            this.largeImageTextBox.Location = new System.Drawing.Point(11, 130);
            this.largeImageTextBox.Name = "largeImageTextBox";
            this.largeImageTextBox.Size = new System.Drawing.Size(167, 27);
            this.largeImageTextBox.TabIndex = 4;
            this.largeImageTextBox.Text = "Epic Text";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(186, 36);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(32, 13);
            this.stateLabel.TabIndex = 5;
            this.stateLabel.Text = "State";
            // 
            // detailLabel
            // 
            this.detailLabel.AutoSize = true;
            this.detailLabel.Location = new System.Drawing.Point(186, 9);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(39, 13);
            this.detailLabel.TabIndex = 6;
            this.detailLabel.Text = "Details";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(186, 100);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(101, 13);
            this.endLabel.TabIndex = 8;
            this.endLabel.Text = "End Time (seconds)";
            // 
            // largeImageLabel
            // 
            this.largeImageLabel.AutoSize = true;
            this.largeImageLabel.Location = new System.Drawing.Point(186, 133);
            this.largeImageLabel.Name = "largeImageLabel";
            this.largeImageLabel.Size = new System.Drawing.Size(90, 13);
            this.largeImageLabel.TabIndex = 9;
            this.largeImageLabel.Text = "Large Image Text";
            // 
            // clientIDTextBox
            // 
            this.clientIDTextBox.Location = new System.Drawing.Point(9, 332);
            this.clientIDTextBox.Name = "clientIDTextBox";
            this.clientIDTextBox.Size = new System.Drawing.Size(167, 27);
            this.clientIDTextBox.TabIndex = 10;
            this.clientIDTextBox.Text = "";
            // 
            // clientIDLabel
            // 
            this.clientIDLabel.AutoSize = true;
            this.clientIDLabel.Location = new System.Drawing.Point(184, 332);
            this.clientIDLabel.Name = "clientIDLabel";
            this.clientIDLabel.Size = new System.Drawing.Size(47, 13);
            this.clientIDLabel.TabIndex = 11;
            this.clientIDLabel.Text = "Client ID";
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(11, 380);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(75, 23);
            this.initializeButton.TabIndex = 12;
            this.initializeButton.Text = "Initialize";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(12, 36);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(166, 27);
            this.stateTextBox.TabIndex = 13;
            this.stateTextBox.Text = "Gaming";
            // 
            // endTimeBox
            // 
            this.endTimeBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.endTimeBox.Location = new System.Drawing.Point(10, 98);
            this.endTimeBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.endTimeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(167, 20);
            this.endTimeBox.TabIndex = 14;
            this.endTimeBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // smallImageTextBox
            // 
            this.smallImageTextBox.Location = new System.Drawing.Point(11, 196);
            this.smallImageTextBox.Name = "smallImageTextBox";
            this.smallImageTextBox.Size = new System.Drawing.Size(167, 27);
            this.smallImageTextBox.TabIndex = 15;
            this.smallImageTextBox.Text = "Smaller epic text";
            // 
            // smallImageLabel
            // 
            this.smallImageLabel.AutoSize = true;
            this.smallImageLabel.Location = new System.Drawing.Point(184, 199);
            this.smallImageLabel.Name = "smallImageLabel";
            this.smallImageLabel.Size = new System.Drawing.Size(88, 13);
            this.smallImageLabel.TabIndex = 16;
            this.smallImageLabel.Text = "Small Image Text";
            this.smallImageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // largeImageKeyTextBox
            // 
            this.largeImageKeyTextBox.Location = new System.Drawing.Point(11, 163);
            this.largeImageKeyTextBox.Name = "largeImageKeyTextBox";
            this.largeImageKeyTextBox.Size = new System.Drawing.Size(167, 27);
            this.largeImageKeyTextBox.TabIndex = 17;
            this.largeImageKeyTextBox.Text = "large_image";
            // 
            // smallImageKeyTextBox
            // 
            this.smallImageKeyTextBox.Location = new System.Drawing.Point(11, 230);
            this.smallImageKeyTextBox.Name = "smallImageKeyTextBox";
            this.smallImageKeyTextBox.Size = new System.Drawing.Size(167, 27);
            this.smallImageKeyTextBox.TabIndex = 18;
            this.smallImageKeyTextBox.Text = "small_image";
            // 
            // smallImageKeyLabel
            // 
            this.smallImageKeyLabel.AutoSize = true;
            this.smallImageKeyLabel.Location = new System.Drawing.Point(184, 233);
            this.smallImageKeyLabel.Name = "smallImageKeyLabel";
            this.smallImageKeyLabel.Size = new System.Drawing.Size(85, 13);
            this.smallImageKeyLabel.TabIndex = 19;
            this.smallImageKeyLabel.Text = "Small Image Key";
            this.smallImageKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // largeImageKeyLabel
            // 
            this.largeImageKeyLabel.AutoSize = true;
            this.largeImageKeyLabel.Location = new System.Drawing.Point(184, 166);
            this.largeImageKeyLabel.Name = "largeImageKeyLabel";
            this.largeImageKeyLabel.Size = new System.Drawing.Size(87, 13);
            this.largeImageKeyLabel.TabIndex = 20;
            this.largeImageKeyLabel.Text = "Large Image Key";
            this.largeImageKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // partyIDTextBox
            // 
            this.partyIDTextBox.Location = new System.Drawing.Point(9, 263);
            this.partyIDTextBox.Name = "partyIDTextBox";
            this.partyIDTextBox.Size = new System.Drawing.Size(167, 27);
            this.partyIDTextBox.TabIndex = 21;
            this.partyIDTextBox.Text = "";
            // 
            // joinSecretTextBox
            // 
            this.joinSecretTextBox.Location = new System.Drawing.Point(9, 296);
            this.joinSecretTextBox.Name = "joinSecretTextBox";
            this.joinSecretTextBox.Size = new System.Drawing.Size(167, 27);
            this.joinSecretTextBox.TabIndex = 22;
            this.joinSecretTextBox.Text = "";
            // 
            // joinSecretLabel
            // 
            this.joinSecretLabel.AutoSize = true;
            this.joinSecretLabel.Location = new System.Drawing.Point(186, 296);
            this.joinSecretLabel.Name = "joinSecretLabel";
            this.joinSecretLabel.Size = new System.Drawing.Size(60, 13);
            this.joinSecretLabel.TabIndex = 23;
            this.joinSecretLabel.Text = "Join Secret";
            this.joinSecretLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // partyIDLabel
            // 
            this.partyIDLabel.AutoSize = true;
            this.partyIDLabel.Location = new System.Drawing.Point(184, 266);
            this.partyIDLabel.Name = "partyIDLabel";
            this.partyIDLabel.Size = new System.Drawing.Size(45, 13);
            this.partyIDLabel.TabIndex = 24;
            this.partyIDLabel.Text = "Party ID";
            this.partyIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(92, 380);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 25;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(200, 409);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(75, 23);
            this.createFileButton.TabIndex = 26;
            this.createFileButton.Text = "Create File";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.CreateFileButton_Click);
            // 
            // endTimeCheckBox
            // 
            this.endTimeCheckBox.AutoSize = true;
            this.endTimeCheckBox.Checked = true;
            this.endTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.endTimeCheckBox.Location = new System.Drawing.Point(9, 70);
            this.endTimeCheckBox.Name = "endTimeCheckBox";
            this.endTimeCheckBox.Size = new System.Drawing.Size(71, 17);
            this.endTimeCheckBox.TabIndex = 27;
            this.endTimeCheckBox.Text = "End Time";
            this.endTimeCheckBox.UseVisualStyleBackColor = true;
            this.endTimeCheckBox.CheckedChanged += new System.EventHandler(this.EndTimeCheckBox_CheckedChanged);
            // 
            // timeElapsedCheckBox
            // 
            this.timeElapsedCheckBox.AutoSize = true;
            this.timeElapsedCheckBox.Location = new System.Drawing.Point(92, 69);
            this.timeElapsedCheckBox.Name = "timeElapsedCheckBox";
            this.timeElapsedCheckBox.Size = new System.Drawing.Size(90, 17);
            this.timeElapsedCheckBox.TabIndex = 28;
            this.timeElapsedCheckBox.Text = "Time Elapsed";
            this.timeElapsedCheckBox.UseVisualStyleBackColor = true;
            this.timeElapsedCheckBox.CheckedChanged += new System.EventHandler(this.TimeElapsedCheckBox_CheckedChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(171, 380);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 29;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(72, 409);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(122, 27);
            this.fileNameTextBox.TabIndex = 30;
            this.fileNameTextBox.Text = " ";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(12, 414);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(54, 13);
            this.fileNameLabel.TabIndex = 31;
            this.fileNameLabel.Text = "File Name";
            // 
            // stopPresenceButton
            // 
            this.stopPresenceButton.Location = new System.Drawing.Point(9, 447);
            this.stopPresenceButton.Name = "stopPresenceButton";
            this.stopPresenceButton.Size = new System.Drawing.Size(260, 23);
            this.stopPresenceButton.TabIndex = 32;
            this.stopPresenceButton.Text = "Stop Presence";
            this.stopPresenceButton.UseVisualStyleBackColor = true;
            this.stopPresenceButton.Click += new System.EventHandler(this.StopPresenceButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(11, 477);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(258, 23);
            this.previewButton.TabIndex = 33;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(293, 519);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.stopPresenceButton);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.timeElapsedCheckBox);
            this.Controls.Add(this.endTimeCheckBox);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.partyIDLabel);
            this.Controls.Add(this.joinSecretLabel);
            this.Controls.Add(this.joinSecretTextBox);
            this.Controls.Add(this.partyIDTextBox);
            this.Controls.Add(this.largeImageKeyLabel);
            this.Controls.Add(this.smallImageKeyLabel);
            this.Controls.Add(this.smallImageKeyTextBox);
            this.Controls.Add(this.largeImageKeyTextBox);
            this.Controls.Add(this.smallImageLabel);
            this.Controls.Add(this.smallImageTextBox);
            this.Controls.Add(this.endTimeBox);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.clientIDLabel);
            this.Controls.Add(this.clientIDTextBox);
            this.Controls.Add(this.largeImageLabel);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.largeImageTextBox);
            this.Controls.Add(this.detailsTextBox);
            this.Name = "Form1";
            this.Text = "DRP Modifier!";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.endTimeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox detailsTextBox;
        private System.Windows.Forms.RichTextBox largeImageTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label largeImageLabel;
        private System.Windows.Forms.RichTextBox clientIDTextBox;
        private System.Windows.Forms.Label clientIDLabel;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.RichTextBox stateTextBox;
        private System.Windows.Forms.NumericUpDown endTimeBox;
        private System.Windows.Forms.RichTextBox smallImageTextBox;
        private System.Windows.Forms.Label smallImageLabel;
        private System.Windows.Forms.RichTextBox largeImageKeyTextBox;
        private System.Windows.Forms.RichTextBox smallImageKeyTextBox;
        private System.Windows.Forms.Label smallImageKeyLabel;
        private System.Windows.Forms.Label largeImageKeyLabel;
        private System.Windows.Forms.RichTextBox partyIDTextBox;
        private System.Windows.Forms.RichTextBox joinSecretTextBox;
        private System.Windows.Forms.Label joinSecretLabel;
        private System.Windows.Forms.Label partyIDLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.CheckBox endTimeCheckBox;
        private System.Windows.Forms.CheckBox timeElapsedCheckBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.RichTextBox fileNameTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button stopPresenceButton;
        private System.Windows.Forms.Button previewButton;
    }
}

