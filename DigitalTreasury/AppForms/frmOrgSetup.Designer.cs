namespace DigitalTreasury.AppForms
{
    partial class frmOrgSetup
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
            lblCreateNewDb = new Label();
            tbOrgName = new TextBox();
            label1 = new Label();
            btnInitialize = new Button();
            SuspendLayout();
            // 
            // lblCreateNewDb
            // 
            lblCreateNewDb.AutoSize = true;
            lblCreateNewDb.Font = new Font("Segoe UI", 18F);
            lblCreateNewDb.Location = new Point(97, 70);
            lblCreateNewDb.Name = "lblCreateNewDb";
            lblCreateNewDb.Size = new Size(282, 32);
            lblCreateNewDb.TabIndex = 0;
            lblCreateNewDb.Text = "Create New Organization";
            lblCreateNewDb.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbOrgName
            // 
            tbOrgName.Location = new Point(63, 159);
            tbOrgName.Name = "tbOrgName";
            tbOrgName.Size = new Size(351, 23);
            tbOrgName.TabIndex = 1;
            tbOrgName.KeyDown += tbOrgName_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 141);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 2;
            label1.Text = "Organization Name:";
            // 
            // btnInitialize
            // 
            btnInitialize.Location = new Point(195, 188);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(75, 23);
            btnInitialize.TabIndex = 3;
            btnInitialize.Text = "Initialize";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += btnInitialize_Click;
            // 
            // frmDbSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 289);
            Controls.Add(btnInitialize);
            Controls.Add(label1);
            Controls.Add(tbOrgName);
            Controls.Add(lblCreateNewDb);
            Name = "frmDbSetup";
            Text = "Setup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCreateNewDb;
        private TextBox tbOrgName;
        private Label label1;
        private Button btnInitialize;
    }
}