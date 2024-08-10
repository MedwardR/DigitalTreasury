using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DigitalTreasury.Objects.DataObjects.Collections
{
    public class TransactionCollection : BindingList<Transaction>
    {
        private bool m_hasChanges = false;

        #region "Public Properties"
        public bool HasChanges
        {
            get
            {
                if (m_hasChanges)
                {
                    return true;
                }
                else
                {
                    foreach (Transaction t in this)
                    {
                        if (t.HasChanges) return true;
                    }

                    return false;
                }
            }
        }
        #endregion

        public void ResetHasChanges()
        {
            m_hasChanges = false;

            foreach (Transaction t in this)
            {
                t.ResetHasChanges();
            }
        }

        #region "Collection Methods"
        public void NewTransaction()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            Transaction newTransaction = new(today, 0);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(int index, DateOnly date)
        {
            Transaction newTransaction = new(index, date);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(DateOnly date)
        {
            Transaction newTransaction = new(date);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(int index, DateOnly date, decimal amount)
        {
            Transaction newTransaction = new(index, date, amount);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(DateOnly date, decimal amount)
        {
            Transaction newTransaction = new(date, amount);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(int index, DateOnly date, decimal amount, string description)
        {
            Transaction newTransaction = new(index, date, amount, description);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(DateOnly date, decimal amount, string description)
        {
            Transaction newTransaction = new(date, amount, description);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(int index, DateOnly date, decimal amount, string description, bool verified)
        {
            Transaction newTransaction = new(index, date, amount, description, verified);
            Add(newTransaction);

            m_hasChanges = true;
        }
        public void NewTransaction(DateOnly date, decimal amount, string description, bool verified)
        {
            Transaction newTransaction = new(date, amount, description, verified);
            Add(newTransaction);

            m_hasChanges = true;
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Remove(transaction);

            m_hasChanges = true;
        }

        public void RemoveTransactionAt(int index)
        {
            index = Math.Clamp(index, 0, Count - 1);
            if (index <= Count)
            {
                RemoveAt(index);
            }

            m_hasChanges = true;
        }

        public void RemoveTransactions(TransactionCollection transactions)
        {
            foreach (Transaction t in transactions)
            {
                RemoveTransaction(t);
            }
        }

        public void RemoveTransactionsAt(IEnumerable<int> indexes)
        {
            foreach (int i in indexes)
            {
                RemoveTransactionAt(i);
            }
        }
        #endregion
    }
}
