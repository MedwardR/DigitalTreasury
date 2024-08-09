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
        private Ledger m_ledger;
        private NumberFormatInfo m_numberFormet;

        public Session()
        {
            m_dm = new DataManager();

            m_ledger = m_dm.GetLedger();
            m_org = m_dm.GetOrganizationFromId(m_dm.Settings.LastOrgId);

            m_numberFormet = GetNewNumberFormat();
        }

        public Organization Organization
        {
            get { return m_org; }
        }

        public Ledger Ledger
        {
            get { return m_ledger; }
            set { m_ledger = value; }
        }

        public Settings Settings
        {
            get { return m_dm.Settings; }
        }

        public bool IsDebug
        {
            get { return m_dm.Settings.IsDebug; }
        }

        public void SaveLedger()
        {
            this.SaveLedger(m_ledger);
        }
        public void SaveLedger(Ledger ledger)
        {
            m_dm.SaveLedger(ledger);
        }

        public static NumberFormatInfo GetNewNumberFormat()
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyNegativePattern = 1;
            return nfi;
        }
    }
}
