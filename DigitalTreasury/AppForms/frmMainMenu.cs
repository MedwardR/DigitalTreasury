using DigitalTreasury.Forms;
using DigitalTreasury.Objects;

namespace DigitalTreasury
{
    public partial class frmMainMenu : Form
    {
        private readonly Session m_session;

        public frmMainMenu()
        {
            m_session = new Session();

            InitializeComponent();

            SetBindings();
        }

        private void SetBindings()
        {
            bsOrganization.DataSource = m_session.Organization;
        }

        public void btnCheckbook_Click(object sender, EventArgs e)
        {
            frmCheckbook checkbook = new frmCheckbook(m_session);
            checkbook.Show();
            this.Hide();

            checkbook.FormClosed += (sender, eventArgs) => this.Show();
        }
    }
}
