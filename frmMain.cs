using OfficeOpenXml;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportadorInventario
{
    public partial class frmMain : Form
    {

        DataTable produtos = null;
        public frmMain()
        {
            InitializeComponent();
        }

        // Sobrescrever o evento de fechamento do formulário
        protected override async void OnFormClosing(FormClosingEventArgs e)
        {

            await CloseConnectionFirst();

            base.OnFormClosing(e);
        }

        public async Task CloseConnectionFirst()
        {
            await Task.Run(() =>
            {
                if(ConfigReader.sistema.ToLower() == "vr")
                {
                    ConnectionVR.Close();
                }
                else
                {
                    ConnectionPG.Close();
                }
            });
        }

        public void ApllyConfig()
        {

            if (ConfigReader.sistema.ToLower() == "vr")
            {
                ConnectionVR.Connect();
            }
            else
            {
                ConnectionPG.Connect();
            }
            ReloadComponentsTest();
        }

        private void ReloadComponentsTest()
        {
            btnReadProd.Enabled = !ConfigReader.isNeededTest;
            btnGenerateInventory.Hide();
            dgvProdutos.Visible = false;
            lblAviso.Hide();
            lblRegistros.Hide();
            lblTotal.Hide();
            this.Size = new Size(this.Width, 200);
            lblVersion.Location = new Point(lblVersion.Location.X, this.Height - 65);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ConnectionConfig.Connect();
            ConfigReader.Start();
            this.Text = ConfigReader.titulo;
            lblVersion.Text = "Version: " + Application.ProductVersion.ToString();
            cboSistema.SelectedIndex = 0;

            //if (ConfigReader.GetConfigValue("primeiro_acesso") == "0")
            //{

            //    frmConfig frmConfig = new frmConfig();
            //    await Task.Delay(300);

            //    frmConfig.ShowDialog(); // Mostra o formulário de configuração como modal
            //    if (frmConfig.DialogResult == DialogResult.Cancel)
            //    {
            //        // Se o usuário fechar a configuração sem salvar, opcionalmente sair do app
            //        Application.Exit();
            //        return;
            //    }

            //    return;
            //}
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.ShowDialog();
        }

        private void cboSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigReader.sistema = cboSistema.SelectedItem.ToString();
            ConfigReader.isNeededTest = true;
            ReloadComponentsTest();
            switch (cboSistema.SelectedItem)
            {
                case "LeCheff":
                    ConfigReader.dbhost = "localhost";
                    ConfigReader.dbuser = "postgres";
                    ConfigReader.dbpwd = "123";
                    ConfigReader.dbport = "5432";
                    break;
                case "LeStore":

                    ConfigReader.dbhost = "localhost";
                    ConfigReader.dbuser = "postgres";
                    ConfigReader.dbpwd = "123";
                    ConfigReader.dbport = "5432";
                    break;
                default:
                    ConfigReader.dbhost = "localhost";
                    ConfigReader.dbuser = "sa";
                    ConfigReader.dbpwd = "senha";
                    ConfigReader.dbport = "1433";
                    break;

            }
        }

        private void btnBDConfig_Click(object sender, EventArgs e)
        {
            frmDBConfig frmDBConfig = new frmDBConfig(this);
            frmDBConfig.ShowInTaskbar = false;
            frmDBConfig.ShowDialog(this);

        }

        private async Task ProcessaProdutos()
        {
            try
            {
                ReloadComponentsTest();
                btnBDConfig.Enabled = false;
                btnConfig.Enabled = false;
                btnReadProd.Enabled = false;
                lblAviso.Show();
                lblAviso.Text = "Carregando produtos, aguarde...";
                await Task.Delay(100);

                if (ConfigReader.sistema.ToLower() == "vr")
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    produtos = produtoDAO.PegaProdutosInventario();
                }
                else
                {
                    MateriaisPGDAO materiaisPGDAO = new MateriaisPGDAO();
                    produtos = materiaisPGDAO.PegaProdutosInventario();
                }

                dgvProdutos.Invoke((MethodInvoker)delegate
                {
                    dgvProdutos.DataSource = produtos;
                });

                dgvProdutos.AutoSizeColumnsMode = produtos.Rows.Count > 0 ? DataGridViewAutoSizeColumnsMode.AllCells : DataGridViewAutoSizeColumnsMode.Fill;
                dgvProdutos.Size = new Size(960, 410);
                dgvProdutos.Visible = true;

                this.Size = new Size(this.Width, 600);
                lblVersion.Location = new Point(lblVersion.Location.X, this.Height - 65);
                var somaTotal = produtos.Compute("SUM([Valor Total])", "");
                lblRegistros.Text = $"Registros: {produtos.Rows.Count}";
                lblRegistros.Show();
                await Task.Delay(100);
                lblTotal.Text = $"Valor total: {somaTotal:c}";
                lblTotal.Show();
                await Task.Delay(100);
                lblAviso.Text = "";
                lblAviso.Hide();
                btnGenerateInventory.Visible = produtos.Rows.Count > 0;
                btnGenerateInventory.Enabled = true;
                btnBDConfig.Enabled = true;
                btnConfig.Enabled = true;
                btnReadProd.Enabled = true;

            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
                lblAviso.Hide();
            }
        }

        private async Task GeraInventario()
        {
            try
            {
                dgvProdutos.Hide();
                lblAviso.Show();
                lblAviso.Text = "Gerando inventário, aguarde...";

                lblRegistros.Hide();
                lblTotal.Hide();

                this.Size = new Size(this.Width, 200);
                lblVersion.Location = new Point(lblVersion.Location.X, this.Height - 65);

                await Task.Delay(100);
                btnBDConfig.Enabled = false;
                btnConfig.Enabled = false;
                btnReadProd.Enabled = false;
                btnGenerateInventory.Enabled = false;
                string file = $"Inventário {DateTime.Now.Year}.xlsx";
                string path = Path.Combine(dirOut.SelectedPath, file); 
                FileInfo filePath = new FileInfo(path);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var excelPack = new ExcelPackage(filePath))
                {
                    var worksheet = excelPack.Workbook.Worksheets["Produtos"];
                    if(worksheet != null)
                    {
                        excelPack.Workbook.Worksheets.Delete("Produtos");
                    }
                    var ws = excelPack.Workbook.Worksheets.Add("Produtos");
                    ws.Cells.LoadFromDataTable(produtos, true);

                    var somaTotal = produtos.Compute("SUM([Valor Total])", "");
                    int lastRow = produtos.Rows.Count + 2;

                    ws.Cells[$"F{lastRow}"].Value = somaTotal;
                    ws.Cells[$"F{lastRow}"].Style.Font.Bold = true;
                    ws.Cells[$"F{lastRow}"].Style.Font.Size = 14;

                    ws.Cells[$"E2:F{lastRow}"].Style.Numberformat.Format = @"_-R$ * #,##0.00_-;-R$ * #,##0.00_-;_-R$ * ""-""??_-;_-@_-";
                    ws.Cells.AutoFitColumns();

                    double larguraAtualE = ws.Column(ws.Cells[$"E1"].Start.Column).Width;
                    double larguraAtualF = ws.Column(ws.Cells[$"F1"].Start.Column).Width;
                    ws.Column(ws.Cells[$"E{lastRow}"].Start.Column).Width = larguraAtualE + 2;
                    ws.Column(ws.Cells[$"F{lastRow}"].Start.Column).Width = larguraAtualF + 2;

                    ws.Cells["A1:F1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                    excelPack.Save();
                }

                await Task.Delay(100);
                lblAviso.Text = "";
                lblAviso.Hide();

                ReloadComponentsTest();
                btnBDConfig.Enabled = true;
                btnConfig.Enabled = true;
                btnReadProd.Enabled = true;
                btnGenerateInventory.Hide();

                Funcoes.ChamaAlerta("Inventário gerado com sucesso!");

            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
                lblAviso.Hide();
                btnBDConfig.Enabled = true;
                btnConfig.Enabled = true;
                btnReadProd.Enabled = true;
                btnGenerateInventory.Enabled = true;
                dgvProdutos.Show();
                lblRegistros.Show();
                lblTotal.Show();

                this.Size = new Size(this.Width, 600);
                lblVersion.Location = new Point(lblVersion.Location.X, this.Height - 65);
            }
        }

        private async void btnReadProd_Click(object sender, EventArgs e)
        {
            try
            {
                await ProcessaProdutos();
            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
        }

        private async void btnGenerateInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Funcoes.ChamaAlerta("Deseja realmente gerar o inventário?", "question") == DialogResult.Yes)
                {

                    dirOut.RootFolder = Environment.SpecialFolder.Desktop; // Define o root como "Meu Computador"
                    dirOut.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Seleciona o Desktop
                    if (dirOut.ShowDialog() != DialogResult.OK) { return; }
                    await GeraInventario();
                }
            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
        }
    }
}
