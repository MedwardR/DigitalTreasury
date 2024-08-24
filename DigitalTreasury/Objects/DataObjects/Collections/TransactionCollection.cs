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
            Transaction t = new();
            t.Index = 0;
            t.CheckNo = null;
            t.Date = DateOnly.FromDateTime(DateTime.Now);
            t.Amount = 0;
            t.Collection = String.Empty;
            t.Description = String.Empty;
            t.Verified = false;
            Add(t);

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
