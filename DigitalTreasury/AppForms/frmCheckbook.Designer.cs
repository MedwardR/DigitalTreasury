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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckbook));
            dgvTransactions = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colVerified = new DataGridViewCheckBoxColumn();
            bsTransactions = new BindingSource(components);
            bsLedger = new BindingSource(components);
            toolStripBottom = new ToolStrip();
            tsBtnNewRecord = new ToolStripButton();
            tsBtnDeleteRecord = new ToolStripButton();
            tsLblSessionOrg = new ToolStripLabel();
            bsSessionOrg = new BindingSource(components);
            bsSession = new BindingSource(components);
            tsSeparator1 = new ToolStripSeparator();
            tsBtnSave = new ToolStripButton();
            tsBtnRollBack = new ToolStripButton();
            toolStripTop = new ToolStrip();
            tsTbTotalAmount = new ToolStripTextBox();
            lblTotal = new ToolStripLabel();
            tsBtnPrevMonth = new ToolStripButton();
            tsBtnSelectedMonth = new ToolStripTextBox();
            tsBtnNextMonth = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsLedger).BeginInit();
            toolStripBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsSessionOrg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsSession).BeginInit();
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
            dgvTransactions.DataSource = bsTransactions;
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
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDate.DataPropertyName = "Date";
            dataGridViewCellStyle1.Format = "M";
            dataGridViewCellStyle1.NullValue = null;
            colDate.DefaultCellStyle = dataGridViewCellStyle1;
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 100;
            colDate.Name = "colDate";
            // 
            // colDesc
            // 
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.DataPropertyName = "Description";
            dataGridViewCellStyle2.NullValue = null;
            colDesc.DefaultCellStyle = dataGridViewCellStyle2;
            colDesc.HeaderText = "Description";
            colDesc.MinimumWidth = 100;
            colDesc.Name = "colDesc";
            // 
            // colAmount
            // 
            colAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            colAmount.DefaultCellStyle = dataGridViewCellStyle3;
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 100;
            colAmount.Name = "colAmount";
            // 
            // colVerified
            // 
            colVerified.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colVerified.DataPropertyName = "Verified";
            colVerified.HeaderText = "✓";
            colVerified.MinimumWidth = 25;
            colVerified.Name = "colVerified";
            colVerified.Width = 25;
            // 
            // bsTransactions
            // 
            bsTransactions.DataMember = "Transactions";
            bsTransactions.DataSource = bsLedger;
            // 
            // bsLedger
            // 
            bsLedger.DataSource = typeof(Ledger);
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
            tsLblSessionOrg.DataBindings.Add(new Binding("Text", bsSessionOrg, "Name", true, DataSourceUpdateMode.Never));
            tsLblSessionOrg.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsLblSessionOrg.Margin = new Padding(2);
            tsLblSessionOrg.Name = "tsLblSessionOrg";
            tsLblSessionOrg.Size = new Size(216, 23);
            tsLblSessionOrg.Text = "The Organization of the Current Session";
            // 
            // bsSessionOrg
            // 
            bsSessionOrg.DataMember = "Organization";
            bsSessionOrg.DataSource = bsSession;
            // 
            // bsSession
            // 
            bsSession.DataSource = typeof(Session);
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
            toolStripTop.Items.AddRange(new ToolStripItem[] { tsTbTotalAmount, lblTotal, tsBtnPrevMonth, tsBtnSelectedMonth, tsBtnNextMonth });
            toolStripTop.Location = new Point(0, 683);
            toolStripTop.Name = "toolStripTop";
            toolStripTop.Padding = new Padding(2, 2, 2, 0);
            toolStripTop.RenderMode = ToolStripRenderMode.Professional;
            toolStripTop.ShowItemToolTips = false;
            toolStripTop.Size = new Size(1035, 29);
            toolStripTop.TabIndex = 200;
            toolStripTop.Text = "toolStrip1";
            // 
            // tsTbTotalAmount
            // 
            tsTbTotalAmount.Alignment = ToolStripItemAlignment.Right;
            tsTbTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            tsTbTotalAmount.CausesValidation = false;
            tsTbTotalAmount.DataBindings.Add(new Binding("Text", bsLedger, "Total", true, DataSourceUpdateMode.OnValidation, "0", "C2"));
            tsTbTotalAmount.Margin = new Padding(2);
            tsTbTotalAmount.Name = "tsTbTotalAmount";
            tsTbTotalAmount.ReadOnly = true;
            tsTbTotalAmount.Size = new Size(100, 23);
            tsTbTotalAmount.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            lblTotal.Alignment = ToolStripItemAlignment.Right;
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(35, 24);
            lblTotal.Text = "Total:";
            // 
            // tsBtnPrevMonth
            // 
            tsBtnPrevMonth.Image = (Image)resources.GetObject("tsBtnPrevMonth.Image");
            tsBtnPrevMonth.ImageTransparentColor = Color.Magenta;
            tsBtnPrevMonth.Margin = new Padding(2);
            tsBtnPrevMonth.Name = "tsBtnPrevMonth";
            tsBtnPrevMonth.Size = new Size(72, 23);
            tsBtnPrevMonth.Text = "Previous";
            tsBtnPrevMonth.Click += tsBtnPrevMonth_Click;
            // 
            // tsBtnSelectedMonth
            // 
            tsBtnSelectedMonth.BorderStyle = BorderStyle.FixedSingle;
            tsBtnSelectedMonth.Margin = new Padding(2);
            tsBtnSelectedMonth.Name = "tsBtnSelectedMonth";
            tsBtnSelectedMonth.ReadOnly = true;
            tsBtnSelectedMonth.Size = new Size(100, 23);
            tsBtnSelectedMonth.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // tsBtnNextMonth
            // 
            tsBtnNextMonth.Image = (Image)resources.GetObject("tsBtnNextMonth.Image");
            tsBtnNextMonth.ImageTransparentColor = Color.Magenta;
            tsBtnNextMonth.Margin = new Padding(2);
            tsBtnNextMonth.Name = "tsBtnNextMonth";
            tsBtnNextMonth.Size = new Size(52, 23);
            tsBtnNextMonth.Text = "Next";
            tsBtnNextMonth.TextImageRelation = TextImageRelation.TextBeforeImage;
            tsBtnNextMonth.Click += tsBtnNextMonth_Click;
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
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsLedger).EndInit();
            toolStripBottom.ResumeLayout(false);
            toolStripBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsSessionOrg).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsSession).EndInit();
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
        private BindingSource bsSessionOrg;
        private ToolStripButton tsBtnRollBack;
        private ToolStripSeparator tsSeparator1;
        private ToolStrip toolStripTop;
        private ToolStripTextBox tsTbTotalBalance;
        private ToolStripLabel lblTotal;
        private BindingSource bsSession;
        private BindingSource bsLedger;
        private BindingSource bsTransactions;
        private ToolStripLabel lblMonth;
        private ToolStripTextBox tsTbCurrentMonth;
        private ToolStripButton tsBtnNextMonth;
        private ToolStripButton tsBtnPrevMonth;
        private ToolStripTextBox tsTbTotalAmount;
        private ToolStripTextBox tsBtnSelectedMonth;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewCheckBoxColumn colVerified;
        private ToolStripButton tsBtnSave;
    }
}