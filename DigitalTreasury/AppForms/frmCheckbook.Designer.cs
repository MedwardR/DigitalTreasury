using System.Transactions;
using DigitalTreasury.Objects;
using DigitalTreasury.Objects.DataObjects;

namespace DigitalTreasury.Forms
{
    partial class frmCheckbook
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckbook));
            dgvTransactions = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colVerified = new DataGridViewCheckBoxColumn();
            toolStripBottom = new ToolStrip();
            tsBtnNewRecord = new ToolStripButton();
            tsBtnDeleteRecord = new ToolStripButton();
            tsLblSessionOrg = new ToolStripLabel();
            tsSeparator1 = new ToolStripSeparator();
            tsBtnSave = new ToolStripButton();
            tsBtnRollBack = new ToolStripButton();
            toolStripTop = new ToolStrip();
            tsTbBalance = new ToolStripTextBox();
            lblTotal = new ToolStripLabel();
            tsLblStatus = new ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            toolStripBottom.SuspendLayout();
            toolStripTop.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToOrderColumns = true;
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { colDate, colDesc, colAmount, colVerified });
            dgvTransactions.DataSource = typeof(Objects.DataObjects.Collections.TransactionCollection);
            dgvTransactions.Location = new Point(0, 0);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.ShowCellErrors = false;
            dgvTransactions.ShowRowErrors = false;
            dgvTransactions.Size = new Size(1035, 686);
            dgvTransactions.TabIndex = 100;
            // 
            // colDate
            // 
            colDate.DataPropertyName = "Date";
            dataGridViewCellStyle1.Format = "M";
            dataGridViewCellStyle1.NullValue = null;
            colDate.DefaultCellStyle = dataGridViewCellStyle1;
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            // 
            // colDesc
            // 
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.DataPropertyName = "Description";
            colDesc.HeaderText = "Description";
            colDesc.Name = "colDesc";
            // 
            // colAmount
            // 
            colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            colAmount.HeaderText = "Amount";
            colAmount.Name = "colAmount";
            // 
            // colVerified
            // 
            colVerified.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colVerified.DataPropertyName = "Verified";
            colVerified.FlatStyle = FlatStyle.System;
            colVerified.HeaderText = "Verified";
            colVerified.Name = "colVerified";
            colVerified.Resizable = DataGridViewTriState.False;
            colVerified.Width = 52;
            // 
            // toolStripBottom
            // 
            toolStripBottom.BackColor = SystemColors.Control;
            toolStripBottom.Dock = DockStyle.Bottom;
            toolStripBottom.GripStyle = ToolStripGripStyle.Hidden;
            toolStripBottom.Items.AddRange(new ToolStripItem[] { tsBtnNewRecord, tsBtnDeleteRecord, tsLblSessionOrg, tsSeparator1, tsBtnSave, tsBtnRollBack });
            toolStripBottom.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStripBottom.Location = new Point(0, 712);
            toolStripBottom.Name = "toolStripBottom";
            toolStripBottom.Padding = new Padding(2, 0, 2, 2);
            toolStripBottom.RenderMode = ToolStripRenderMode.Professional;
            toolStripBottom.ShowItemToolTips = false;
            toolStripBottom.Size = new Size(1035, 29);
            toolStripBottom.TabIndex = 300;
            toolStripBottom.Text = "toolStrip";
            // 
            // tsBtnNewRecord
            // 
            tsBtnNewRecord.AutoToolTip = false;
            tsBtnNewRecord.Image = (Image)resources.GetObject("tsBtnNewRecord.Image");
            tsBtnNewRecord.ImageTransparentColor = Color.Magenta;
            tsBtnNewRecord.Margin = new Padding(2);
            tsBtnNewRecord.Name = "tsBtnNewRecord";
            tsBtnNewRecord.Size = new Size(91, 23);
            tsBtnNewRecord.Text = "New Record";
            tsBtnNewRecord.Click += tsBtnNewRecord_Click;
            // 
            // tsBtnDeleteRecord
            // 
            tsBtnDeleteRecord.AutoToolTip = false;
            tsBtnDeleteRecord.Image = (Image)resources.GetObject("tsBtnDeleteRecord.Image");
            tsBtnDeleteRecord.ImageTransparentColor = Color.Magenta;
            tsBtnDeleteRecord.Margin = new Padding(2);
            tsBtnDeleteRecord.Name = "tsBtnDeleteRecord";
            tsBtnDeleteRecord.Size = new Size(100, 23);
            tsBtnDeleteRecord.Text = "Delete Record";
            tsBtnDeleteRecord.Click += tsBtnDeleteRecord_Click;
            // 
            // tsLblSessionOrg
            // 
            tsLblSessionOrg.Alignment = ToolStripItemAlignment.Right;
            tsLblSessionOrg.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsLblSessionOrg.Margin = new Padding(2);
            tsLblSessionOrg.Name = "tsLblSessionOrg";
            tsLblSessionOrg.Size = new Size(216, 23);
            tsLblSessionOrg.Text = "The Organization of the Current Session";
            // 
            // tsSeparator1
            // 
            tsSeparator1.Margin = new Padding(2);
            tsSeparator1.Name = "tsSeparator1";
            tsSeparator1.Size = new Size(6, 23);
            // 
            // tsBtnSave
            // 
            tsBtnSave.Image = Properties.Resources.save;
            tsBtnSave.ImageTransparentColor = Color.Magenta;
            tsBtnSave.Margin = new Padding(2);
            tsBtnSave.Name = "tsBtnSave";
            tsBtnSave.Size = new Size(51, 23);
            tsBtnSave.Text = "Save";
            tsBtnSave.Click += tsBtnSave_Click;
            // 
            // tsBtnRollBack
            // 
            tsBtnRollBack.Image = (Image)resources.GetObject("tsBtnRollBack.Image");
            tsBtnRollBack.ImageTransparentColor = Color.Magenta;
            tsBtnRollBack.Margin = new Padding(2);
            tsBtnRollBack.Name = "tsBtnRollBack";
            tsBtnRollBack.Size = new Size(75, 23);
            tsBtnRollBack.Text = "Roll Back";
            tsBtnRollBack.Click += tsBtnRollBack_Click;
            // 
            // toolStripTop
            // 
            toolStripTop.Dock = DockStyle.Bottom;
            toolStripTop.GripStyle = ToolStripGripStyle.Hidden;
            toolStripTop.Items.AddRange(new ToolStripItem[] { tsTbBalance, lblTotal, tsLblStatus });
            toolStripTop.Location = new Point(0, 683);
            toolStripTop.Name = "toolStripTop";
            toolStripTop.Padding = new Padding(2, 2, 2, 0);
            toolStripTop.RenderMode = ToolStripRenderMode.Professional;
            toolStripTop.ShowItemToolTips = false;
            toolStripTop.Size = new Size(1035, 29);
            toolStripTop.TabIndex = 200;
            toolStripTop.Text = "toolStrip1";
            // 
            // tsTbBalance
            // 
            tsTbBalance.Alignment = ToolStripItemAlignment.Right;
            tsTbBalance.BorderStyle = BorderStyle.FixedSingle;
            tsTbBalance.CausesValidation = false;
            tsTbBalance.Margin = new Padding(2);
            tsTbBalance.Name = "tsTbBalance";
            tsTbBalance.ReadOnly = true;
            tsTbBalance.Size = new Size(100, 23);
            tsTbBalance.TextBoxTextAlign = HorizontalAlignment.Right;
            tsTbBalance.TextChanged += tsTbTotalAmount_TextChanged;
            // 
            // lblTotal
            // 
            lblTotal.Alignment = ToolStripItemAlignment.Right;
            lblTotal.Margin = new Padding(2, 2, 0, 2);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(51, 23);
            lblTotal.Text = "Balance:";
            // 
            // tsLblStatus
            // 
            tsLblStatus.Margin = new Padding(2);
            tsLblStatus.Name = "tsLblStatus";
            tsLblStatus.Size = new Size(39, 23);
            tsLblStatus.Text = "Status";
            // 
            // frmCheckbook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 741);
            Controls.Add(toolStripTop);
            Controls.Add(toolStripBottom);
            Controls.Add(dgvTransactions);
            Name = "frmCheckbook";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Checkbook";
            FormClosing += frmCheckbook_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            toolStripBottom.ResumeLayout(false);
            toolStripBottom.PerformLayout();
            toolStripTop.ResumeLayout(false);
            toolStripTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTransactions;
        private ToolStrip toolStripBottom;
        private ToolStripButton tsBtnDeleteRecord;
        private ToolStripButton tsBtnNewRecord;
        private ToolStripLabel tsLblSessionOrg;
        private ToolStripButton tsBtnRollBack;
        private ToolStripSeparator tsSeparator1;
        private ToolStrip toolStripTop;
        private ToolStripTextBox tsTbTotalBalance;
        private ToolStripLabel lblTotal;
        private ToolStripLabel lblMonth;
        private ToolStripTextBox tsTbCurrentMonth;
        private ToolStripTextBox tsTbBalance;
        private ToolStripButton tsBtnSave;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewCheckBoxColumn colVerified;
        private ToolStripLabel tsLblStatus;
    }
}