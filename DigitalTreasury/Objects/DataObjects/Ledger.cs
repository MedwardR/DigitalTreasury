using DigitalTreasury.Objects.DataObjects.Collections;
using System.Security.Policy;

namespace DigitalTreasury.Objects.DataObjects
{
    public class Ledger
    {
        private decimal m_principle;
        private TransactionCollection m_transactions;

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

        #region "Public Properties"
        public decimal Principle
        {
            get { return m_principle; }
            set { m_principle = value; }
        }

        public TransactionCollection Transactions
        {
            get { return m_transactions; }
            set { m_transactions = value; }
        }

        public decimal Total
        {
            get
            {
                decimal total = Principle;
                foreach (Transaction t in Transactions)
                {
                    total += t.Amount;
                }
                return total;
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
