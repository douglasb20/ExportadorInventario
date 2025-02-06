using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ExportadorInventario
{
    internal class TemplateMail
    {
        public static string JsonTemplate<T>(string title, List<T> list)
        {
            string content = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            return $@"
            <html>
            <body>
                <p style='font-weight:bold;font-size: 1.2rem;'>{title}</p>
                <pre>{content}</pre>
            </body>
            </html>";
        }

        public static string TableTemplate<T>(string title, List<T> items)
        {
            string rows = string.Join("", items.Select((item, key) => $@"
            <tr>
                <td>{key + 1}</td>
                <td>{item.GetType().GetProperty("Cfop")?.GetValue(item)}</td>                
                <td>{item.GetType().GetProperty("IcmsCst")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("IcmsAliquota")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("IcmsAliquotaReduzida")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("PisCst")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("PisAliquota")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("CofinsAliquota")?.GetValue(item)}</td>

            </tr>"));

            return $@"
            <html>
            <body>
                <h2>{title}</h2>
                <div style='margin-bottom: 1rem;'>
                    <h3 style='
                            padding: 0;
                            margin: 0;'
                    >
                        Cliente: {ConfigReader.GetConfigValue("cliente_nome")}
                    </h3>
                    <h4 style='
                        padding: 0;
                        margin: 0;'
                    >
                        CNPJ: {ConfigReader.GetConfigValue("cliente_cnpj")}
                    </h4>
                </div>
                <table border='1' style='border-collapse: collapse; width: 100%;'>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>CFOP</th>
                            <th>ICMS CST</th>
                            <th>ICMS Aliquota</th>
                            <th>ICMS Aliquota Reduzida</th>
                            <th>Pis/Cofins Cst</th>
                            <th>Pis Aliquota</th>
                            <th>Cofins Aliquota</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rows}
                    </tbody>
                </table>
            </body>
            </html>";
        }

        public static string PlainTextTemplate(string message)
        {
            return $@"
            <html>
            <body>
                <p>{message}</p>
            </body>
            </html>";
        }
    }

}
