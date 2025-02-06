using System.Data;
using System;

namespace ExportadorInventario
{
    internal class ProdutoDAO : DefaultModel
    {
        public ProdutoDAO()
        {
            this.tabela = "produto";
        }

        public DataTable PegaProdutosInventario()
        {
            try
            {
                string query = $@"
                                    SELECT
                                      p.Codigo_Fabricante1 [Código]
                                     ,p.Nome [Descrição]
                                     ,CASE
                                        WHEN um.Codigo = 'UNID' THEN 'UN'
                                        ELSE um.Codigo
                                      END [Unid]
                                     ,cast(ea.Qtde as DECIMAL(18,2)) [Quantidade]
                                     ,cast(PP.Preco as decimal(18,2)) [Vlr Custo]
                                     ,cast(ea.Qtde * PP.Preco as decimal(18,2)) [Valor Total]
                                    FROM Produto AS p
                                    INNER JOIN Estoque_Atual AS ea
                                      ON ea.Produto__Ide = p.Ide
                                    INNER JOIN UnidadeMedida AS um
                                      ON um.Ide = p.Unidade_Venda__Ide
                                    INNER JOIN ProdutoPreco pp
                                      ON pp.Produto__Ide = p.ide
                                        AND pp.TabelaPreco__Ide = (SELECT
                                            ide
                                          FROM TabelaPreco
                                          WHERE Custo = 1)

                                    WHERE pp.Preco > 0
                                    AND ea.Qtde > 0
                                ";

                return this.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
