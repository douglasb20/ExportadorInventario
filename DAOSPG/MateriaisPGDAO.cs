using System;
using System.Data;

namespace ExportadorInventario
{
    internal class MateriaisPGDAO : DefaultModelPG
    {
        public MateriaisPGDAO()
        {
            this.tabela = "materiais";
        }

        public DataTable PegaProdutosInventario()
        {
            try
            {
                string query = $@"
                                    SELECT 
	                                    MT.MAT_004 as ""Código"",
	                                    MT.MAT_003 as ""Descrição"",
	                                    U.UNI_003 as ""Unid"",
	                                    SEM.QUANTIDADE as ""Quantidade"",
	                                    MT.mat_012 as ""Vlr Custo"",
	                                    SEM.QUANTIDADE  * MT.mat_012 as ""Valor Total""
                                    FROM MATERIAIS AS MT
                                    INNER JOIN SETOR_ESTOQUE_MATERIAL AS SEM ON SEM.ID_MATERIAL = MT.MAT_001
                                    INNER JOIN unidades AS u ON u.uni_001 = mt.uni_001
                                    AND SEM.QUANTIDADE > 0
                                    ORDER BY MT.MAT_003 ASC
                                ";

                return this.ExecuteQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
