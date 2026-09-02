using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Ave
    {
        public List<Ave> Listar()
        {
            List<Ave> lista = new List<Ave>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                   
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select a.IdAve,a.Nombre,a.Descripcion,");
                    sb.AppendLine("f.IdFamilia, f.Descripcion[DesFamilia],");
                    sb.AppendLine("c.IdCategoria,c.Descripcion[DesCategoria],");
                    sb.AppendLine("e.IdEstatus, e.Descripcion[DesEstatus],");
                    sb.AppendLine("h.IdHabitat, h.Descripcion[DesHabitat],");
                    sb.AppendLine("a.Alimentacion, a.FuncionEcos, a.RutaImagen, a.NombreImagen, a.Activa, a.ListaRoja");
                    sb.AppendLine("from Ave a");
                    sb.AppendLine("inner join Familia f on f.IdFamilia= a.IdFamilia");
                    sb.AppendLine("inner join CategoriaEstacional c on c.IdCategoria= a.IdCategoria");
                    sb.AppendLine("inner join EstatusProteccion e on e.IdEstatus= a.IdEstatus");
                    sb.AppendLine("inner join Habitat h on h.IdHabitat= a.IdHabitat");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Ave()
                            {
                                IdAve = Convert.ToInt32(dr["IdAve"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oFamilia = new Familia() { IdFamilia = Convert.ToInt32(dr["IdFamilia"]), Descripcion = dr["DesFamilia"].ToString() },
                                oCategoriaEstacional = new CategoriaEstacional() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DesCategoria"].ToString() },
                                oEstatusProteccion = new EstatusProteccion() { IdEstatus = Convert.ToInt32(dr["IdEstatus"]), Descripcion = dr["DesEstatus"].ToString() },
                                oHabitat = new Habitat() { IdHabitat = Convert.ToInt32(dr["IdHabitat"]), Descripcion = dr["DesHabitat"].ToString() },
                                Alimentacion = dr["Alimentacion"].ToString(),
                                FuncionEcos = dr["FuncionEcos"].ToString(),
                                RutaImagen = dr["RutaImagen"].ToString(),
                                NombreImagen = dr["NombreImagen"].ToString(),
                                Activa = Convert.ToBoolean(dr["Activa"]),
                                ListaRoja = Convert.ToBoolean(dr["ListaRoja"]),
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Ave>();
            }
            return lista;
        }

        public int Registrar(Ave obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarAve", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdFamilia", obj.oFamilia.IdFamilia);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoriaEstacional.IdCategoria);
                    cmd.Parameters.AddWithValue("IdEstatus", obj.oEstatusProteccion.IdEstatus);
                    cmd.Parameters.AddWithValue("IdHabitat", obj.oHabitat.IdHabitat);
                    cmd.Parameters.AddWithValue("Alimentacion", obj.Alimentacion);
                    cmd.Parameters.AddWithValue("FuncionEcos", obj.FuncionEcos);
                    cmd.Parameters.AddWithValue("Activa", obj.Activa);
                    cmd.Parameters.AddWithValue("ListaRoja", obj.ListaRoja);
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

        public bool Editar(Ave obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarAve", oconexion);
                    cmd.Parameters.AddWithValue("IdAve", obj.IdAve);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdFamilia", obj.oFamilia.IdFamilia);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoriaEstacional.IdCategoria);
                    cmd.Parameters.AddWithValue("IdEstatus", obj.oEstatusProteccion.IdEstatus);
                    cmd.Parameters.AddWithValue("IdHabitat", obj.oHabitat.IdHabitat);
                    cmd.Parameters.AddWithValue("Alimentacion", obj.Alimentacion);
                    cmd.Parameters.AddWithValue("FuncionEcos", obj.FuncionEcos);
                    cmd.Parameters.AddWithValue("Activa", obj.Activa);
                    cmd.Parameters.AddWithValue("ListaRoja", obj.ListaRoja);
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

        public bool GuardarDatosImagen(Ave obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "update ave set RutaImagen=@rutaimagen, NombreImagen=@nombreimagen where IdAve=@idave";
                    SqlCommand cmd = new SqlCommand(query, oconexion);

                    cmd.Parameters.AddWithValue("@rutaimagen", obj.RutaImagen);
                    cmd.Parameters.AddWithValue("@nombreimagen", obj.NombreImagen);
                    cmd.Parameters.AddWithValue("@idave", obj.IdAve);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {

                        resultado = true;


                    }
                    else
                    {
                        Mensaje = "No se pudo actualizar imagen";
                    }

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
                    SqlCommand cmd = new SqlCommand("delete top(1) from ave where IdAve=@id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;


                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;


        }
    }
}
