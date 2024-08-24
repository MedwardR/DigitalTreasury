using DigitalTreasury.Objects;
using DigitalTreasury.Objects.DataObjects;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DigitalTreasury.Forms
{
    public partial class frmCheckbook : Form
    {
        private readonly Session m_session;
        private Ledger m_ledger;

        public frmCheckbook(Session session)
        {
            m_session = session;

            InitializeComponent();

            GetData();

            SetBindings();

            ShowStatus(Status.None);
        }

        private void SetBindings()
        {
            dgvTransactions.DataSource = m_ledger.Transactions;
            tsLblSessionOrg.Text = m_session.Organization.Name;
            RefreshBalance();
        }

        private void GetData()
        {
            m_ledger = m_session.DataManager.GetLedger();
        }

        private void SaveData()
        {
            if (m_ledger.HasChanges)
            {
                m_session.DataManager.SaveLedger(m_ledger);
                ShowStatus(Status.SaveSuccessful);
            }
            else
            {
                ShowStatus(Status.NoChanges);
            }
        }

        private List<int> GetSelectedRowIndexes()
        {
            List<int> indexes = [];
            foreach (DataGridViewRow r in dgvTransactions.SelectedRows)
            {
                indexes.Add(r.Index);
            }
            return indexes;
        }

        private void ShowStatus(Status status)
        {
            switch (status)
            {
                case Status.None:
                    tsLblStatus.Text = String.Empty;
                    break;

                case Status.SaveSuccessful:
                    tsLblStatus.Text = "Data saved successfully!";
                    break;

                case Status.NoChanges:
                    tsLblStatus.Text = "No changes to save!";
                    break;
            }
        }

        private void RefreshBalance()
        {
            if (m_ledger != null && m_ledger.HasChanges)
            {
                decimal balance = m_ledger.GetBalance();
                tsTbBalance.Text = balance.ToString("C2", m_session.NumberFormat);
            }
        }

        private enum Status
        {
            None,
            SaveSuccessful,
            NoChanges
        }

        private void tsBtnNewRecord_Click(object sender, EventArgs e)
        {
            m_ledger.NewTransaction();
        }

        private void tsBtnDeleteRecord_Click(object sender, EventArgs e)
        {
            m_ledger.RemoveTransactionsAt(GetSelectedRowIndexes());
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            dgvTransactions.EndEdit();
            SaveData();
        }

        private void frmCheckbook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_ledger.HasChanges)
            {
                DialogResult choice = MessageBox.Show("You have unsaved changes. Would you like to save now?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (choice == DialogResult.Yes)
                {
                    SaveData();
                }
                else if (choice == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvTransactions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RefreshBalance();
        }

        private void dgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvTransactions.Columns[e.ColumnIndex];
            if (column == colAmount)
            {
                if (e.Value != null)
                {
                    e.Value = String.Format(m_session.NumberFormat, "{0:C2}", e.Value);

                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvTransactions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue != null)
            {
                if (e.FormattedValue is string text)
                {
                    DataGridViewColumn column = dgvTransactions.Columns[e.ColumnIndex];
                    DataGridViewCell cell = dgvTransactions.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (column == colCheckNo)
                    {
                        if (!int.TryParse(text, out int result))
                        {
                            cell.Value = null;
                            dgvTransactions.CancelEdit();
                        }
                    }
                    else if (column == colDate)
                    {
                        if (!DateTime.TryParse(text, out DateTime result))
                        {
                            dgvTransactions.CancelEdit();
                        }
                    }
                    else if (column == colAmount)
                    {
                        if (!decimal.TryParse(text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out decimal result))
                        {
                            cell.Value = 0m;
                            dgvTransactions.CancelEdit();
                        }
                    }
                }
            }
        }
    }
}
