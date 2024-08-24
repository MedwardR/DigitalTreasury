using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTreasury.Objects.DataObjects
{
    public class Organization
    {
        private int m_id;
        private string m_name;
        private decimal m_principle;

        public Organization(int id)
        {
            m_id = id;
        }

        public int Id
        {
            get { return m_id; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public decimal Principle
        {
            get { return m_principle; }
            set { m_principle = value; }
        }
    }
}
