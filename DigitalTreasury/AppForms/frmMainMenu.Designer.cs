using DigitalTreasury.Objects;

namespace DigitalTreasury
{
    partial class frmMainMenu
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
            btnCheckbook = new Button();
            btnReports = new Button();
            lblMainMenu = new Label();
            btnSettings = new Button();
            btnOrgChange = new Button();
            lblSessionOrg = new Label();
            bsOrganization = new BindingSource(components);
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)bsOrganization).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCheckbook
            // 
            btnCheckbook.FlatStyle = FlatStyle.System;
            btnCheckbook.ImageAlign = ContentAlignment.MiddleLeft;
            btnCheckbook.Location = new Point(67, 132);
            btnCheckbook.Name = "btnCheckbook";
            btnCheckbook.Size = new Size(281, 91);
            btnCheckbook.TabIndex = 100;
            btnCheckbook.Text = "&Checkbook";
            btnCheckbook.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCheckbook.UseVisualStyleBackColor = true;
            btnCheckbook.Click += btnCheckbook_Click;
            // 
            // btnReports
            // 
            btnReports.FlatStyle = FlatStyle.System;
            btnReports.Location = new Point(384, 132);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(281, 91);
            btnReports.TabIndex = 200;
            btnReports.Text = "&Reports";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // lblMainMenu
            // 
            lblMainMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMainMenu.AutoSize = true;
            lblMainMenu.FlatStyle = FlatStyle.System;
            lblMainMenu.Font = new Font("Segoe UI", 18F);
            lblMainMenu.Location = new Point(293, 51);
            lblMainMenu.Name = "lblMainMenu";
            lblMainMenu.Size = new Size(138, 32);
            lblMainMenu.TabIndex = 0;
            lblMainMenu.Text = "Main Menu";
            lblMainMenu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            btnSettings.FlatStyle = FlatStyle.System;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(67, 260);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(281, 91);
            btnSettings.TabIndex = 300;
            btnSettings.Text = "&Settings";
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnOrgChange
            // 
            btnOrgChange.FlatStyle = FlatStyle.System;
            btnOrgChange.Location = new Point(536, 15);
            btnOrgChange.Name = "btnOrgChange";
            btnOrgChange.Size = new Size(56, 23);
            btnOrgChange.TabIndex = 50;
            btnOrgChange.Text = "Change";
            btnOrgChange.UseVisualStyleBackColor = true;
            // 
            // lblSessionOrg
            // 
            lblSessionOrg.AutoSize = true;
            lblSessionOrg.DataBindings.Add(new Binding("Text", bsOrganization, "Name", true));
            lblSessionOrg.Location = new Point(6, 19);
            lblSessionOrg.Name = "lblSessionOrg";
            lblSessionOrg.Size = new Size(126, 15);
            lblSessionOrg.TabIndex = 50;
            lblSessionOrg.Text = "<No organization set>";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSessionOrg);
            groupBox1.Controls.Add(btnOrgChange);
            groupBox1.Location = new Point(67, 405);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(598, 47);
            groupBox1.TabIndex = 301;
            groupBox1.TabStop = false;
            groupBox1.Text = "Organization";
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 533);
            Controls.Add(groupBox1);
            Controls.Add(btnSettings);
            Controls.Add(lblMainMenu);
            Controls.Add(btnReports);
            Controls.Add(btnCheckbook);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMainMenu";
            Text = "Digital Treasury";
            ((System.ComponentModel.ISupportInitialize)bsOrganization).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCheckbook;
        private Button btnReports;
        private Label lblMainMenu;
        private Button btnSettings;
        private BindingSource bsSession;
        private Button btnOrgChange;
        private Label lblSessionOrg;
        private GroupBox groupBox1;
        private BindingSource bsOrganization;
    }
}
