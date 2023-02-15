using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "ClienteGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText= query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        context.Open();

                        DataTable clienteTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(clienteTable);
                        if (clienteTable.Rows.Count>0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in clienteTable.Rows)
                            {
                                ML.Cliente cliente = new ML.Cliente();

                                cliente.IdCliente = int.Parse(row[0].ToString());
                                cliente.Nombre = row[1].ToString();
                                cliente.ApellidoPaterno= row[2].ToString();
                                cliente.ApellidoMaterno= row[3].ToString();
                                cliente.FechaModificacion = DateTime.Parse(row[4].ToString());

                                cliente.Planes =new  ML.Planes();
                                cliente.Planes.IdPlanes= int.Parse(row[5].ToString());
                                cliente.Planes.Descripcion= row[6].ToString();
                                cliente.Planes.FechaModicacionPlanes = DateTime.Parse(row[7].ToString());

                                cliente.Coberturas =new  ML.Cobertura();
                                cliente.Coberturas.IdCobertura = int.Parse(row[8].ToString());
                                cliente.Coberturas.Descripcion= row[9].ToString();
                                cliente.Coberturas.FechaModicacionCobertura= DateTime.Parse(row[10].ToString());
                                result.Objects.Add(cliente);
                            }
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
        public static ML.Result GetById(int IdCliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioBabelEntities context= new DL_EF.EIgnacioBabelEntities())
                {
                    var query = context.ClienteGetById(IdCliente).SingleOrDefault();
                    result.Objects = new List<object>();

                    if (query!=null)
                    {
                        ML.Cliente cliente = new ML.Cliente();

                        cliente.IdCliente = query.IdCliente;
                        cliente.Nombre = query.Nombre;
                        cliente.ApellidoPaterno = query.ApellidoPaterno;
                        cliente.ApellidoMaterno=query.ApellidoMaterno;
                        cliente.FechaModificacion = (DateTime)query.FechaModificacion;

                        cliente.Planes=new ML.Planes();
                        cliente.Planes.IdPlanes = (int)query.IdPlanes;
                        cliente.Planes.Descripcion=query.Descripcion;
                        cliente.Planes.FechaModicacionPlanes = (DateTime)query.FechaModificacionPlanes;

                        cliente.Coberturas = new ML.Cobertura();
                        cliente.Coberturas.IdCobertura = (int)query.IdCobertura;
                        cliente.Coberturas.Descripcion = query.Descripcion1;
                        cliente.Planes.FechaModicacionPlanes = (DateTime)query.FechaModificacionPlanes;

                        result.Object=cliente;
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public static ML.Result Add(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioBabelEntities context = new DL_EF.EIgnacioBabelEntities())
                {
                    int query = context.ClienteAdd(cliente.Nombre,cliente.ApellidoPaterno,cliente.ApellidoMaterno,cliente.Planes.IdPlanes,cliente.Coberturas.IdCobertura);

                    if (query>0)
                    {
                        result.Message = "Se registraron correctamente los clientes";
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
