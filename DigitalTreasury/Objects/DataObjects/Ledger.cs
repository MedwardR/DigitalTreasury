using DigitalTreasury.Objects.DataObjects.Collections;
using System.Security.Policy;

namespace DigitalTreasury.Objects.DataObjects
{
    public class Ledger
    {
        private decimal m_principle;
        private TransactionCollection m_transactions;
        private bool m_hasChanges = false;

        #region "Constructors"
        public Ledger()
        {
            m_principle = 0;
            m_transactions = new TransactionCollection();
        }
        public Ledger(decimal principle)
        {
            m_principle = principle;
            m_transactions = new TransactionCollection();
        }
        public Ledger(decimal principle, TransactionCollection transactions)
        {
            m_principle = principle;
            m_transactions = transactions;
        }
        #endregion

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
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            Transactions.NewTransaction(today, 0);
        }
        public void NewTransaction(int index, DateOnly date)
        {
            Transactions.NewTransaction(index, date);
        }
        public void NewTransaction(DateOnly date)
        {
            Transactions.NewTransaction(date);
        }
        public void NewTransaction(int index, DateOnly date, decimal amount)
        {
            Transactions.NewTransaction(index, date, amount);
        }
        public void NewTransaction(DateOnly date, decimal amount)
        {
            Transactions.NewTransaction(date, amount);
        }
        public void NewTransaction(int index, DateOnly date, decimal amount, string description)
        {
            Transactions.NewTransaction(index, date, amount, description);
        }
        public void NewTransaction(DateOnly date, decimal amount, string description)
        {
            Transactions.NewTransaction(date, amount, description);
        }
        public void NewTransaction(int index, DateOnly date, decimal amount, string description, bool verified)
        {
            Transactions.NewTransaction(index, date, amount, description, verified);
        }
        public void NewTransaction(DateOnly date, decimal amount, string description, bool verified)
        {
            Transactions.NewTransaction(date, amount, description, verified);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Transactions.RemoveTransaction(transaction);
        }

        public void RemoveTransactionAt(int index)
        {
            Transactions.RemoveTransactionAt(index);
        }

        public void RemoveTransactions(TransactionCollection transactions)
        {
            foreach (Transaction t in transactions)
            {
                Transactions.RemoveTransaction(t);
            }
        }

        public void RemoveTransactionsAt(IEnumerable<int> indexes)
        {
            foreach (int i in indexes)
            {
                Transactions.RemoveTransactionAt(i);
            }
        }
        #endregion
    }
}
