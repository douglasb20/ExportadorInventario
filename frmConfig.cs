using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportadorInventario
{
    public partial class frmConfig : Form
    {
        public static ToolTip tool = new ToolTip { ShowAlways = true, InitialDelay = 200 };
        public frmConfig()
        {
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
                // MAIL
                txtMailHost.Text = ConfigReader.GetConfigValue("mail_host").Trim();
                txtMailPort.Text = ConfigReader.GetConfigValue("mail_port").Trim();
                txtMailUser.Text = ConfigReader.GetConfigValue("mail_user").Trim();
                txtMailPass.Text = Funcoes.Decrypt(ConfigReader.GetConfigValue("mail_pwd")).Trim();
                txtMailFrom.Text = ConfigReader.GetConfigValue("mail_from").Trim();
                txtMailSuport.Text = ConfigReader.GetConfigValue("mail_suport").Trim();

                if (ConfigReader.GetConfigValue("primeiro_acesso") == "1")
                {
                    btSaveConfig.Enabled = true;
                }
                else
                {
                    this.MouseMove += Form_MouseMove; // Detecta o movimento do mouse
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            if (
                txtMailHost.Text == string.Empty ||
                txtMailPort.Text == string.Empty ||
                txtMailUser.Text == string.Empty ||
                txtMailPass.Text == string.Empty ||
                txtMailFrom.Text == string.Empty ||
                txtMailSuport.Text == string.Empty
               )
            {
                Funcoes.ErrorMessage("Revise as configurações de Email.");
                return;
            }

            // MAIL
            ConfigReader.SetConfigValue("mail_host", txtMailHost.Text.Trim());
            ConfigReader.SetConfigValue("mail_port", txtMailPort.Text.Trim());
            ConfigReader.SetConfigValue("mail_user", txtMailUser.Text.Trim());
            ConfigReader.SetConfigValue("mail_pwd", Funcoes.Encrypt(txtMailPass.Text.Trim().ToLower()));
            ConfigReader.SetConfigValue("mail_from", txtMailFrom.Text.Trim());
            ConfigReader.SetConfigValue("mail_suport", txtMailSuport.Text.Trim());


            if (ConfigReader.GetConfigValue("primeiro_acesso") == "0")
            {
                ConfigReader.SetConfigValue("primeiro_acesso", "1");
                this.DialogResult = DialogResult.OK;
            }
            this.Close();

        }

        private void TextMailChange(object sender, EventArgs e)
        {
            if (
                    txtMailHost.Text == string.Empty ||
                    txtMailPort.Text == string.Empty ||
                    txtMailUser.Text == string.Empty ||
                    txtMailPass.Text == string.Empty ||
                    txtMailFrom.Text == string.Empty ||
                    txtMailSuport.Text == string.Empty
                )
            {
                btSendTest.Enabled = false;
            }
            else
            {
                btSendTest.Enabled = true;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // Verifica se o mouse está sobre o botão desabilitado
            if (!btSaveConfig.Enabled && btSaveConfig.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                tool.Show("Faça um teste de conexão para habilitar este botão", btSaveConfig, btSaveConfig.Width / 2, btSaveConfig.Height / 2);
            }
            else
            {
                tool.Hide(btSaveConfig); // Oculta o ToolTip quando o mouse não estiver sobre o botão
            }
        }

        private async void btSendTest_Click(object sender, EventArgs e)
        {
            try
            {
                btSendTest.Enabled = false;
                btSendTest.Text = "Aguarde...";
                await Task.Delay(50);
                Mail mail = new Mail();
                mail.SendTest(txtMailHost.Text,
                              int.Parse(txtMailPort.Text),
                              txtMailUser.Text,
                              txtMailPass.Text,
                              txtMailFrom.Text,
                              txtMailSuport.Text);
                Funcoes.ChamaAlerta("Teste enviado com sucesso");
            }
            catch (SmtpException ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
            finally
            {
                btSendTest.Enabled = true;
                btSendTest.Text = "Teste envio";
            }


        }
    }
}
