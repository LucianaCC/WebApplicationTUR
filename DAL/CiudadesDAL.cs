using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelClasses;


/// <summary>
/// Descripción breve de CiudadesDAL
/// </summary>

namespace DAL
{
    public class CiudadesDAL
    {

        public CiudadesDAL() { }

        public static List<Ciudad> getAllCiudades()
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Ciudades
                                 where c.Deleted == false
                                 orderby c.CodInt ascending
                                 select c);
                    List<Ciudad> list = new List<Ciudad>();
                    foreach (Ciudades item in query)
                    {
                        Ciudad ciudad = new Ciudad();
                        ciudad.Id = item.Id;
                        ciudad.CodigoInterno = item.CodInt;
                        ciudad.Nombre = item.Nombre;
                        ciudad.Codigo = item.Codigo;
                        ciudad.Pais = item.Pais;
                        list.Add(ciudad);
                    }
                    return list;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void newciudad(ModelClasses.Ciudad _ciudad)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //CHA - El Chaltén
                    var last = Contexto.Ciudades.OrderByDescending(u => u.Id).FirstOrDefault();
                    
                   
                    Ciudades ciudad = new Ciudades();
                    ciudad.Codigo = _ciudad.Codigo.Trim();
                    ciudad.Nombre = _ciudad.Nombre.Trim();
                    ciudad.Pais = _ciudad.Pais.Trim();
                    ciudad.Deleted = false;
                    //ciudad.Id = last.Id + 1;
                    if (last == null)
                    {
                        ciudad.Id = 1;
                    }
                    else
                    {
                        ciudad.Id = last.Id + 1;
                    }
                    ciudad.CodInt = _ciudad.Codigo + " - " + _ciudad.Nombre;
                    Contexto.AddToCiudades(ciudad);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, ciudad);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static Ciudad GetOneById(int _IDciudad)
        {
            try
            {
                Ciudad ciudad = new Ciudad();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var _ciudad = (from c in Contexto.Ciudades
                                   where c.Id == _IDciudad && c.Deleted == false
                                   select c).FirstOrDefault();
                    if (_ciudad != null)
                    {
                        ciudad.Codigo = _ciudad.Codigo;
                        ciudad.Nombre = _ciudad.Nombre;
                        ciudad.Pais = _ciudad.Pais;
                        ciudad.Id = _ciudad.Id;
                        ciudad.CodigoInterno = _ciudad.CodInt;
                    }
                }
                return ciudad;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditCiudad(Ciudades _ciudad)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var ciudad = (from p in Contexto.Ciudades
                                  where p.Id == _ciudad.Id
                                  select p).FirstOrDefault();
                    ciudad.Codigo = _ciudad.Codigo;
                    ciudad.Nombre = _ciudad.Nombre;
                    ciudad.Pais = _ciudad.Pais;
                    ciudad.CodInt = _ciudad.Codigo + " - " + _ciudad.Nombre;
                    Contexto.Ciudades.ApplyCurrentValues(ciudad);
                    Contexto.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void DeleteCiudad(Ciudad _ciudad)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var ciudad = (from p in Contexto.Ciudades
                                  where p.Id == _ciudad.Id
                                  select p).FirstOrDefault();
                    ciudad.Deleted = true;
                    Contexto.Ciudades.ApplyCurrentValues(ciudad);
                    //Contexto.Ciudades.DeleteObject(ciudad);
                    Contexto.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}