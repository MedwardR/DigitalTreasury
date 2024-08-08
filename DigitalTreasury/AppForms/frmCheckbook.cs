using DigitalTreasury.Objects.Generic;
using DigitalTreasury.Objects;
using DigitalTreasury.Objects.DataObjects;
using DigitalTreasury.Objects.DataObjects.Collections;

namespace DigitalTreasury.Forms
{
    public partial class frmCheckbook : Form
    {
        private readonly Session m_session;
        private Ledger m_ledger;
        private TransactionCollection m_visible_transactions;
        private MonthYear m_selected_month;
        private bool m_validated_events_processing = false;

        public frmCheckbook(Session session)
        {
            m_session = session;

            InitializeComponent();

            GetData();

            SetBindings();
        }

        private void SetBindings()
        {
            bsSession.DataSource = m_session;
            bsLedger.DataSource = m_ledger;
        }

        private void GetData()
        {
            m_ledger = m_session.Ledger;
            bsLedger.ResetBindings(false);
        }

        private void SaveData()
        {
            m_session.SaveLedger(m_ledger);
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

        private void tsBtnPrevMonth_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnNextMonth_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnNewRecord_Click(object sender, EventArgs e)
        {
            m_ledger.NewTransaction();
            bsLedger.ResetBindings(false);
        }

        private void tsBtnDeleteRecord_Click(object sender, EventArgs e)
        {
            m_ledger.RemoveTransactionsAt(GetSelectedRowIndexes());
            bsLedger.ResetBindings(false);
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tsBtnRollBack_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
