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
        private int? m_checkNo = null;
        private DateOnly m_date;
        private decimal m_amount;
        private string m_collection;
        private string m_desc;
        private bool m_verified;
        private bool m_hasChanges = false;

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

        public int? CheckNo
        {
            get { return m_checkNo; }
            set
            {
                if (m_checkNo != value)
                {
                    m_hasChanges = true;
                    m_checkNo = value;
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

        public string Collection
        {
            get { return m_collection; }
            set
            {
                if (m_collection != value)
                {
                    m_hasChanges = true;
                    m_collection = value;
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
