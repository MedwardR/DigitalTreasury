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
            lblOrgName = new Label();
            btnInitialize = new Button();
            lblPrinciple = new Label();
            tbPrinciple = new TextBox();
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
            tbOrgName.TabIndex = 100;
            tbOrgName.KeyDown += tbOrgName_KeyDown;
            // 
            // lblOrgName
            // 
            lblOrgName.AutoSize = true;
            lblOrgName.Location = new Point(63, 141);
            lblOrgName.Name = "lblOrgName";
            lblOrgName.Size = new Size(113, 15);
            lblOrgName.TabIndex = 2;
            lblOrgName.Text = "Organization Name:";
            // 
            // btnInitialize
            // 
            btnInitialize.Location = new Point(339, 212);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(75, 23);
            btnInitialize.TabIndex = 300;
            btnInitialize.Text = "Initialize";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += btnInitialize_Click;
            // 
            // lblPrinciple
            // 
            lblPrinciple.AutoSize = true;
            lblPrinciple.Location = new Point(63, 194);
            lblPrinciple.Name = "lblPrinciple";
            lblPrinciple.Size = new Size(103, 15);
            lblPrinciple.TabIndex = 4;
            lblPrinciple.Text = "Principle Amount:";
            // 
            // tbPrinciple
            // 
            tbPrinciple.Location = new Point(63, 212);
            tbPrinciple.Name = "tbPrinciple";
            tbPrinciple.Size = new Size(253, 23);
            tbPrinciple.TabIndex = 200;
            tbPrinciple.KeyDown += tbPrinciple_KeyDown;
            tbPrinciple.Leave += tbPrinciple_Leave;
            // 
            // frmOrgSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 289);
            Controls.Add(tbPrinciple);
            Controls.Add(lblPrinciple);
            Controls.Add(btnInitialize);
            Controls.Add(lblOrgName);
            Controls.Add(tbOrgName);
            Controls.Add(lblCreateNewDb);
            Name = "frmOrgSetup";
            Text = "Organization Setup";
            FormClosing += frmOrgSetup_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCreateNewDb;
        private TextBox tbOrgName;
        private Label lblOrgName;
        private Button btnInitialize;
        private Label lblPrinciple;
        private TextBox tbPrinciple;
    }
}