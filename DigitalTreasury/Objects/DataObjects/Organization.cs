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
        private float m_principle;

        public Organization(int id, string name)
        {
            m_id = id;
            m_name = name;
        }
        public Organization(int id, string name, float principle)
        {
            m_id = id;
            m_name = name;
            m_principle = principle;
        }

        public int Id
        {
            get { return m_id; }
        }

        public string Name
        {
            get { return m_name; }
        }

        public float Principle
        {
            get { return m_principle; }
            set { m_principle = value; }
        }
    }
}
