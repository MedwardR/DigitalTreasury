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
        #region "Collection Methods"
        public void NewTransaction()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            Transaction newTransaction = new(today, 0);
            Add(newTransaction);
        }
        public void NewTransaction(int index, DateOnly date, float amount)
        {
            Transaction newTransaction = new(index, date, amount);
            Add(newTransaction);
        }
        public void NewTransaction(DateOnly date, float amount)
        {
            Transaction newTransaction = new(date, amount);
            Add(newTransaction);
        }
        public void NewTransaction(int index, DateOnly date, float amount, string description)
        {
            Transaction newTransaction = new(index, date, amount, description);
            Add(newTransaction);
        }
        public void NewTransaction(DateOnly date, float amount, string description)
        {
            Transaction newTransaction = new(date, amount, description);
            Add(newTransaction);
        }
        public void NewTransaction(int index, DateOnly date, float amount, string description, bool verified)
        {
            Transaction newTransaction = new(index, date, amount, description, verified);
            Add(newTransaction);
        }
        public void NewTransaction(DateOnly date, float amount, string description, bool verified)
        {
            Transaction newTransaction = new(date, amount, description, verified);
            Add(newTransaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Remove(transaction);
        }

        public void RemoveTransactionAt(int index)
        {
            index = Math.Clamp(index, 0, Count - 1);
            if (index <= Count)
            {
                RemoveAt(index);
            }
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
