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
        private float m_amount;
        private string m_desc;
        private bool m_verified;

        #region "Constructors"
        public Transaction(int index, DateOnly date, float amount)
        {
            m_index = index;
            m_date = date;
            m_amount = amount;
            m_desc = string.Empty;
            m_verified = false;
        }
        public Transaction(DateOnly date, float amount)
        {
            m_index = 0;
            m_date = date;
            m_amount = amount;
            m_desc = string.Empty;
            m_verified = false;
        }
        public Transaction(int index, DateOnly date, float amount, string description)
        {
            m_index = index;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = false;
        }
        public Transaction(DateOnly date, float amount, string description)
        {
            m_index = 0;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = false;
        }
        public Transaction(int index, DateOnly date, float amount, string description, bool verified)
        {
            m_index = index;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = verified;
        }
        public Transaction(DateOnly date, float amount, string description, bool verified)
        {
            m_index = 0;
            m_date = date;
            m_amount = amount;
            m_desc = description;
            m_verified = verified;
        }
        #endregion

        #region "Public Properties"
        public int Index
        {
            get { return m_index; }
            set { m_index = value; }
        }

        public DateOnly Date
        {
            get { return m_date; }
            set { m_date = value; }
        }

        public float Amount
        {
            get { return m_amount; }
            set { m_amount = value; }
        }

        public string Description
        {
            get { return m_desc; }
            set { m_desc = value; }
        }

        public bool Verified
        {
            get { return m_verified; }
            set { m_verified = value; }
        }
        #endregion
    }
}
