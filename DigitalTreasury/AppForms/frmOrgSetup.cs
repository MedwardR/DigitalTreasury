using DigitalTreasury.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalTreasury.AppForms
{
    public partial class frmOrgSetup : Form
    {
        private string m_orgName;
        private decimal m_principle = 0;
        private NumberFormatInfo m_numberFormat;

        public frmOrgSetup()
        {
            InitializeComponent();
            m_numberFormat = Session.GetNewNumberFormat();
        }

        private void tbOrgName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPrinciple.Focus();
            }
        }

        private void tbPrinciple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInitialize_Click(sender, e);
            }
        }

        private void tbPrinciple_Leave(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbPrinciple.Text, out decimal value))
            {
                tbPrinciple.Text = value.ToString("C2", m_numberFormat);
            }
            else
            {
                tbPrinciple.Text = 0.ToString("C2", m_numberFormat);
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            bool orgNameIsValid = !String.IsNullOrWhiteSpace(tbOrgName.Text);
            bool principleIsValid = Decimal.TryParse(tbPrinciple.Text, out decimal principle);

            if (orgNameIsValid)
            {
                m_orgName = tbOrgName.Text;

                if (principleIsValid)
                {
                    m_principle = principle;
                }
                else
                {
                    m_principle = 0;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter an organization name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbOrgName.Focus();
            }
        }

        private void frmOrgSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool orgNameIsValid = !String.IsNullOrWhiteSpace(m_orgName);

            if (!orgNameIsValid)
            {
                Environment.Exit(0);
            }
        }

        public string OrgName
        {
            get { return m_orgName; }
        }

        public decimal Principle
        {
            get { return m_principle; }
        }
    }
}
