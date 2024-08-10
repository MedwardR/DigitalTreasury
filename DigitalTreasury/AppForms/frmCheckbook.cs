using DigitalTreasury.Objects;
using DigitalTreasury.Objects.DataObjects;
using DigitalTreasury.Objects.DataObjects.Collections;

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

        private void tsBtnRollBack_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void tsTbTotalAmount_TextChanged(object sender, EventArgs e)
        {
            tsTbBalance.Text = m_ledger.Balance.ToString("C2", m_session.NumberFormat);
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
    }
}
