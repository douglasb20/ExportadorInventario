using System;
using System.Windows.Forms;

namespace ExportadorInventario
{
    public partial class frmDBConfig : Form
    {
        public ToolTip tool = new ToolTip { ShowAlways = true, InitialDelay = 200 };
        public bool isConOkay = false;
        public frmMain pai = null;

        public frmDBConfig(frmMain pai)
        {
            this.pai = pai;
            InitializeComponent();
        }

        public void CloseConfig()
        {
            this.Close();
        }

        private void btnCancelCLose_Click(object sender, EventArgs e)
        {
            CloseConfig();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConfigReader.isNeededTest)
                {
                    btSaveConfig.Enabled = false;
                }

                // MAIL
                txtHost.Text = ConfigReader.dbhost;
                txtPort.Text = ConfigReader.dbport;
                txtUser.Text = ConfigReader.dbuser;
                txtPwd.Text = ConfigReader.dbpwd;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigReader.isNeededTest = false;
                string host = txtHost.Text;
                string port = txtPort.Text;
                string user = txtUser.Text;
                string pwd = txtPwd.Text;

                ConfigReader.dbhost = host;
                ConfigReader.dbport = port;
                ConfigReader.dbuser = user;
                ConfigReader.dbpwd = pwd;

                pai.ApllyConfig();
                this.Close();
            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
        }

        private void ChangeInputTest(object sender, KeyEventArgs e)
        {
            btSaveConfig.Enabled = false;
            TextBox inputText = (TextBox)sender;
            string campo = inputText.Name.Replace("txt", "").ToLower();

            if (ConfigReader.dbhost == txtHost.Text &&
                ConfigReader.dbport == txtPort.Text &&
                ConfigReader.dbuser == txtUser.Text &&
                ConfigReader.dbpwd == txtPwd.Text &&
                !ConfigReader.isNeededTest
                )
            {
                btSaveConfig.Enabled = true;
            }
        }

        private void btTestCon_Click(object sender, EventArgs e)
        {
            try
            {
                isConOkay = false;
                btSaveConfig.Enabled = false;

                string host = txtHost.Text;
                string port = txtPort.Text;
                string user = txtUser.Text;
                string pwd = txtPwd.Text;

                if (ConfigReader.sistema.ToLower() == "vr")
                {
                    ConnectionVR.TesteConn(host, port, user, pwd);
                }
                else
                {
                    ConnectionPG.TesteConn(host, port, user, pwd);
                }

                Funcoes.ChamaAlerta("Teste relizado com sucesso");
                isConOkay = true;
                btSaveConfig.Enabled = true;
                ConfigReader.isNeededTest = false;
            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
        }
    }
}
