using DigitalTreasury.Objects.DataObjects.Collections;

namespace DigitalTreasury.Objects.DataObjects
{
    public class Ledger
    {
        private decimal m_principle;
        private TransactionCollection m_transactions;
        private bool m_hasChanges = false;

        public Ledger()
        {
            m_transactions = new TransactionCollection();
        }

        public void ResetHasChanges()
        {
            m_hasChanges = false;
            m_transactions.ResetHasChanges();
        }

        public DateOnly GetLatestDate()
        {
            DateOnly latest = new();
            
            foreach (Transaction t in  m_transactions)
            {
                if (t.Date > latest)
                {
                    latest = t.Date;
                }
            }

            return latest;
        }

        public decimal GetBalance()
        {
            decimal total = m_principle;
            foreach (Transaction t in m_transactions)
            {
                total += t.Amount;
            }
            return total;
        }

        #region "Public Properties"
        public decimal Principle
        {
            get { return m_principle; }
            set
            {
                if (m_principle != value)
                {
                    m_hasChanges = true;
                    m_principle = value;
                }
            }
        }

        public TransactionCollection Transactions
        {
            get { return m_transactions; }
            set { m_transactions = value; }
        }

        public bool HasChanges
        {
            get
            {
                return m_hasChanges || m_transactions.HasChanges;
            }
        }
        #endregion

        #region "Collection Methods"
        public void SortTransactionsByDate()
        {
            List<Transaction> sorted = this.Transactions
                .OrderBy(item => item.Date)
                .ThenByDescending(item => item.Index)
                .ToList();

            this.Transactions.Clear();

            foreach (Transaction item in sorted)
            {
                this.Transactions.Add(item);
            }
        }

        public void NewTransaction()
        {
            m_transactions.NewTransaction();
        }

        public void RemoveTransaction(Transaction transaction)
        {
            m_transactions.RemoveTransaction(transaction);
        }

        public void RemoveTransactionAt(int index)
        {
            m_transactions.RemoveTransactionAt(index);
        }

        public void RemoveTransactions(TransactionCollection transactions)
        {
            foreach (Transaction t in transactions)
            {
                m_transactions.RemoveTransaction(t);
            }
        }

        public void RemoveTransactionsAt(IEnumerable<int> indexes)
        {
            foreach (int i in indexes)
            {
                m_transactions.RemoveTransactionAt(i);
            }
        }
        #endregion
    }
}
