using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalTreasury.Objects.DataObjects;
using DigitalTreasury.Objects;
using DigitalTreasury.AppForms;
using System.Security.Cryptography;
using System.Globalization;

namespace DigitalTreasury.Objects
{
    public class Session
    {
        private readonly DataManager m_dm;
        private readonly Organization m_org;
        private NumberFormatInfo m_numberFormat;

        public Session()
        {
            m_dm = new DataManager();

            m_org = m_dm.GetOrganizationFromId(m_dm.Settings.LastOrgId);

            m_numberFormat = GetNewNumberFormat();
        }

        public Organization Organization
        {
            get { return m_org; }
        }

        public Settings Settings
        {
            get { return m_dm.Settings; }
        }

        public bool IsDebug
        {
            get { return m_dm.Settings.IsDebug; }
        }

        public NumberFormatInfo NumberFormat
        {
            get { return m_numberFormat; }
        }

        public DataManager DataManager
        {
            get { return m_dm; }
        }

        public static NumberFormatInfo GetNewNumberFormat()
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyNegativePattern = 1;
            return nfi;
        }
    }
}
