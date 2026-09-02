using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class CD_Categoria
    {
        public List<CategoriaEstacional> Listar()
        {
            List<CategoriaEstacional> lista = new List<CategoriaEstacional>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select IdCategoria,Descripcion,Activo from CategoriaEstacional";
                    SqlCommand cmd = new SqlCommand(query, oconexion); ;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CategoriaEstacional()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"]),
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<CategoriaEstacional>();
            }
            return lista;
        }

        public int Registrar(CategoriaEstacional obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(CategoriaEstacional obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        //public List<CategoriaEstacional> ListarCategoriaporEstatus(int idestatus)
        //{
        //    List<CategoriaEstacional> lista = new List<CategoriaEstacional>();

        //    try
        //    {
        //        using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
        //        {
        //            StringBuilder sb = new StringBuilder();

        //            sb.AppendLine("select distinct e.IdEstatus,e.Descripcion from Ave a");
        //            sb.AppendLine("inner join EstatusProteccion e on e.IdEstatus = a.IdEstatus");
        //            sb.AppendLine("inner join CategoriaEstacional c on c.idCategoria = a.IdCategoria and c.Activa = 1");
        //            sb.AppendLine("where e.IdEstatus = iif(@idestatus = 0, e.IdEstatus, @idestatus)");


        //            SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);

        //            cmd.Parameters.AddWithValue("@idestatus", idestatus);
        //            cmd.CommandType = CommandType.Text;

        //            oconexion.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    lista.Add(new CategoriaEstacional()
        //                    {
        //                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
        //                        Descripcion = dr["Descripcion"].ToString()

        //                    });
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        lista = new List<CategoriaEstacional>();
        //    }
        //    return lista;
        //}
    }
}
