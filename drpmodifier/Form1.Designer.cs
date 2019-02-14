﻿namespace drpmodifier
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
            this.largeImageTextBox.Location = new System.Drawing.Point(13, 102);
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
            this.endLabel.Location = new System.Drawing.Point(188, 72);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(101, 13);
            this.endLabel.TabIndex = 8;
            this.endLabel.Text = "End Time (seconds)";
            // 
            // largeImageLabel
            // 
            this.largeImageLabel.AutoSize = true;
            this.largeImageLabel.Location = new System.Drawing.Point(188, 105);
            this.largeImageLabel.Name = "largeImageLabel";
            this.largeImageLabel.Size = new System.Drawing.Size(90, 13);
            this.largeImageLabel.TabIndex = 9;
            this.largeImageLabel.Text = "Large Image Text";
            // 
            // clientIDTextBox
            // 
            this.clientIDTextBox.Location = new System.Drawing.Point(11, 301);
            this.clientIDTextBox.Name = "clientIDTextBox";
            this.clientIDTextBox.Size = new System.Drawing.Size(167, 27);
            this.clientIDTextBox.TabIndex = 10;
            this.clientIDTextBox.Text = "";
            // 
            // clientIDLabel
            // 
            this.clientIDLabel.AutoSize = true;
            this.clientIDLabel.Location = new System.Drawing.Point(186, 304);
            this.clientIDLabel.Name = "clientIDLabel";
            this.clientIDLabel.Size = new System.Drawing.Size(47, 13);
            this.clientIDLabel.TabIndex = 11;
            this.clientIDLabel.Text = "Client ID";
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(11, 345);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(75, 23);
            this.initializeButton.TabIndex = 12;
            this.initializeButton.Text = "Initialize";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
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
            this.endTimeBox.Location = new System.Drawing.Point(12, 70);
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
            this.endTimeBox.ValueChanged += new System.EventHandler(this.endTimeBox_ValueChanged);
            // 
            // smallImageTextBox
            // 
            this.smallImageTextBox.Location = new System.Drawing.Point(13, 168);
            this.smallImageTextBox.Name = "smallImageTextBox";
            this.smallImageTextBox.Size = new System.Drawing.Size(167, 27);
            this.smallImageTextBox.TabIndex = 15;
            this.smallImageTextBox.Text = "Smaller epic text";
            // 
            // smallImageLabel
            // 
            this.smallImageLabel.AutoSize = true;
            this.smallImageLabel.Location = new System.Drawing.Point(186, 171);
            this.smallImageLabel.Name = "smallImageLabel";
            this.smallImageLabel.Size = new System.Drawing.Size(88, 13);
            this.smallImageLabel.TabIndex = 16;
            this.smallImageLabel.Text = "Small Image Text";
            this.smallImageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // largeImageKeyTextBox
            // 
            this.largeImageKeyTextBox.Location = new System.Drawing.Point(13, 135);
            this.largeImageKeyTextBox.Name = "largeImageKeyTextBox";
            this.largeImageKeyTextBox.Size = new System.Drawing.Size(167, 27);
            this.largeImageKeyTextBox.TabIndex = 17;
            this.largeImageKeyTextBox.Text = "large_image";
            // 
            // smallImageKeyTextBox
            // 
            this.smallImageKeyTextBox.Location = new System.Drawing.Point(13, 202);
            this.smallImageKeyTextBox.Name = "smallImageKeyTextBox";
            this.smallImageKeyTextBox.Size = new System.Drawing.Size(167, 27);
            this.smallImageKeyTextBox.TabIndex = 18;
            this.smallImageKeyTextBox.Text = "small_image";
            // 
            // smallImageKeyLabel
            // 
            this.smallImageKeyLabel.AutoSize = true;
            this.smallImageKeyLabel.Location = new System.Drawing.Point(186, 205);
            this.smallImageKeyLabel.Name = "smallImageKeyLabel";
            this.smallImageKeyLabel.Size = new System.Drawing.Size(85, 13);
            this.smallImageKeyLabel.TabIndex = 19;
            this.smallImageKeyLabel.Text = "Small Image Key";
            this.smallImageKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // largeImageKeyLabel
            // 
            this.largeImageKeyLabel.AutoSize = true;
            this.largeImageKeyLabel.Location = new System.Drawing.Point(186, 138);
            this.largeImageKeyLabel.Name = "largeImageKeyLabel";
            this.largeImageKeyLabel.Size = new System.Drawing.Size(87, 13);
            this.largeImageKeyLabel.TabIndex = 20;
            this.largeImageKeyLabel.Text = "Large Image Key";
            this.largeImageKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // partyIDTextBox
            // 
            this.partyIDTextBox.Location = new System.Drawing.Point(11, 235);
            this.partyIDTextBox.Name = "partyIDTextBox";
            this.partyIDTextBox.Size = new System.Drawing.Size(167, 27);
            this.partyIDTextBox.TabIndex = 21;
            this.partyIDTextBox.Text = "";
            // 
            // joinSecretTextBox
            // 
            this.joinSecretTextBox.Location = new System.Drawing.Point(11, 268);
            this.joinSecretTextBox.Name = "joinSecretTextBox";
            this.joinSecretTextBox.Size = new System.Drawing.Size(167, 27);
            this.joinSecretTextBox.TabIndex = 22;
            this.joinSecretTextBox.Text = "";
            // 
            // joinSecretLabel
            // 
            this.joinSecretLabel.AutoSize = true;
            this.joinSecretLabel.Location = new System.Drawing.Point(188, 268);
            this.joinSecretLabel.Name = "joinSecretLabel";
            this.joinSecretLabel.Size = new System.Drawing.Size(60, 13);
            this.joinSecretLabel.TabIndex = 23;
            this.joinSecretLabel.Text = "Join Secret";
            this.joinSecretLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // partyIDLabel
            // 
            this.partyIDLabel.AutoSize = true;
            this.partyIDLabel.Location = new System.Drawing.Point(186, 238);
            this.partyIDLabel.Name = "partyIDLabel";
            this.partyIDLabel.Size = new System.Drawing.Size(45, 13);
            this.partyIDLabel.TabIndex = 24;
            this.partyIDLabel.Text = "Party ID";
            this.partyIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(92, 345);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 25;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(173, 345);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(75, 23);
            this.createFileButton.TabIndex = 26;
            this.createFileButton.Text = "Create File";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 380);
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
    }
}

