using DigitalTreasury.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalTreasury.AppForms
{
    public partial class frmOrgSetup : Form
    {
        private string m_orgName;

        public frmOrgSetup()
        {
            InitializeComponent();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            m_orgName = tbOrgName.Text;
            this.Close();
        }

        private void tbOrgName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_orgName = tbOrgName.Text;
                this.Close();
            }
        }

        public string OrgName
        {
            get { return m_orgName; }
        }
    }
}
