using System.Text.Json.Serialization;

namespace ExportadorInventario
{
    internal class ProdutosBanco
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("unidade")]
        public string Unidade { get; set; }

        [JsonPropertyName("estoque")]
        public float Estoque { get; set; }

        [JsonPropertyName("valor_unit")]
        public decimal ValorUnit { get; set; }

        [JsonPropertyName("valor_total")]
        public decimal ValorTotal { get; set; }
    }
}
