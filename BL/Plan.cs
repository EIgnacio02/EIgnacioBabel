using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plan
    {
        public static ML.Result GetAll()
        {
            ML.Result result= new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "PlanesGetAll";

                    using (SqlCommand cmd= new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText= query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable PlanTable= new DataTable();

                        SqlDataAdapter sqlDataAdapter= new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(PlanTable);

                        if (PlanTable.Rows.Count>0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow obj in PlanTable.Rows)
                            {
                                ML.Planes planes = new ML.Planes();

                                planes.IdPlanes = int.Parse(obj[0].ToString());
                                planes.Descripcion = obj[1].ToString();
                                planes.FechaModicacionPlanes = DateTime.Parse(obj[2].ToString());

                                result.Objects.Add(planes);

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
