using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cobertura
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "CoberturaGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable CoberturaTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(CoberturaTable);

                        if (CoberturaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow obj in CoberturaTable.Rows)
                            {
                                ML.Cobertura cobertura = new ML.Cobertura();

                                cobertura.IdCobertura = int.Parse(obj[0].ToString());
                                cobertura.Descripcion = obj[1].ToString();
                                cobertura.FechaModicacionCobertura = DateTime.Parse(obj[2].ToString());

                                result.Objects.Add(cobertura);
                            }
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
