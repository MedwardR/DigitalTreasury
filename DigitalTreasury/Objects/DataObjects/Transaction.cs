using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTreasury.Objects.DataObjects
{
    public class Transaction
    {
        private int m_index;
        private DateOnly m_date;
        private decimal m_amount;
        private string m_desc;
        private bool m_verified;
        private bool m_hasChanges = false;

        #region "Constructors"
        public Transaction()
        {
            m_index = 0;
            m_date = DateOnly.FromDateTime(DateTime.Now);
            m_amount = 0;
            m_desc = String.Empty;
            m_verified = false;
        }
        public Transaction(int index, DateOnly date)
        {
            m_index = index;
            m_date = date;
            m_amount = 0;
            m_desc = string.Empty;
            m_verified = false;
        }
        public Transaction(DateOnly date)
        {
            m_index = 0;
            m_date = date;
            m_amount = 0;
            m_desc = string.Empty;
            m_verified = false;
        }
        public Transaction(int index, DateOnly date, decimal amount)
        {
            m_index = index;
            m_date = date;
            m_amount = amount;
            m_desc = string.Empty;
            m_verified = false;
        }
        public Transaction(DateOnly date, decimal amount)
        {
            m_index = 0;
            m_date = date;
            m_amount = amount;
            m_desc = string.Empty;
            m_verified = false;
        }
        public Transaction(int index, DateOnly date, decimal amount, string description)
        {
            m_index = index;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = false;
        }
        public Transaction(DateOnly date, decimal amount, string description)
        {
            m_index = 0;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = false;
        }
        public Transaction(int index, DateOnly date, decimal amount, string description, bool verified)
        {
            m_index = index;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = verified;
        }
        public Transaction(DateOnly date, decimal amount, string description, bool verified)
        {
            m_index = 0;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = verified;
        }
        #endregion

        public void ResetHasChanges()
        {
            m_hasChanges = false;
        }

        #region "Public Properties"
        public int Index
        {
            get { return m_index; }
            set
            {
                if (m_index != value)
                {
                    m_hasChanges = true;
                    m_index = value;
                }
            }
        }

        public DateOnly Date
        {
            get { return m_date; }
            set
            {
                if (m_date != value)
                {
                    m_hasChanges = true;
                    m_date = value;
                }
            }
        }

        public decimal Amount
        {
            get { return m_amount; }
            set
            {
                if (m_amount != value)
                {
                    m_hasChanges = true;
                    m_amount = value;
                }
            }
        }

        public string Description
        {
            get { return m_desc; }
            set
            {
                if (m_desc != value)
                {
                    m_hasChanges = true;
                    m_desc = value;
                }
            }
        }

        public bool Verified
        {
            get { return m_verified; }
            set
            {
                if (m_verified != value)
                {
                    m_hasChanges = true;
                    m_verified = value;
                }
            }
        }

        public bool HasChanges
        {
            get { return m_hasChanges; }
        }
        #endregion
    }
}
