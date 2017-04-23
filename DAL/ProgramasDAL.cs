using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;

namespace DAL
{
   public class ProgramasDAL
    {
        public ProgramasDAL() { }

        public static List<Programa> getAllProgramaes()
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Programas
                                 where c.Deleted == false
                                 //orderby c.CodInt ascending
                                 select c);
                    List<Programa> list = new List<Programa>();
                    //foreach (Programaes item in query)
                    //{
                    //    Programa Programa = new Programa();
                    //    Programa.Id = item.Id;
                    //    Programa.CodigoInterno = item.CodInt;
                    //    Programa.Nombre = item.Nombre;
                    //    Programa.Codigo = item.Codigo;
                    //    Programa.Pais = item.Pais;
                    //    list.Add(Programa);
                    //}
                    return list;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void newPrograma(ModelClasses.Programa _Programa)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //CHA - El Chaltén
                    var last = Contexto.Programas.OrderByDescending(u => u.Id).FirstOrDefault();
                    
                   
                    //Programaes Programa = new Programaes();
                    //Programa.Codigo = _Programa.Codigo.Trim();
                    //Programa.Nombre = _Programa.Nombre.Trim();
                    //Programa.Pais = _Programa.Pais.Trim();
                    //Programa.Deleted = false;
                    ////Programa.Id = last.Id + 1;
                    //if (last == null)
                    //{
                    //    Programa.Id = 1;
                    //}
                    //else
                    //{
                    //    Programa.Id = last.Id + 1;
                    //}
                    //Programa.CodInt = _Programa.Codigo + " - " + _Programa.Nombre;
                    //Contexto.AddToProgramaes(Programa);
                    //Contexto.SaveChanges();
                    //Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, Programa);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static Programa GetOneById(int _IDPrograma)
        {
            try
            {
                Programa Programa = new Programa();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var _Programa = (from c in Contexto.Programas
                                   where c.Id == _IDPrograma && c.Deleted == false
                                   select c).FirstOrDefault();
                    if (_Programa != null)
                    {
                        //Programa.Codigo = _Programa.Codigo;
                        //Programa.Nombre = _Programa.Nombre;
                        //Programa.Pais = _Programa.Pais;
                        //Programa.Id = _Programa.Id;
                        //Programa.CodigoInterno = _Programa.CodInt;
                    }
                }
                return Programa;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditPrograma(Programas _Programa)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Programa = (from p in Contexto.Programas
                                  where p.Id == _Programa.Id
                                  select p).FirstOrDefault();
                    //Programa.Codigo = _Programa.Codigo;
                    //Programa.Nombre = _Programa.Nombre;
                    //Programa.Pais = _Programa.Pais;
                    //Programa.CodInt = _Programa.Codigo + " - " + _Programa.Nombre;
                    //Contexto.Programaes.ApplyCurrentValues(Programa);
                    //Contexto.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void DeletePrograma(Programa _Programa)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Programa = (from p in Contexto.Programas
                                  where p.Id == _Programa.Id
                                  select p).FirstOrDefault();
                    Programa.Deleted = true;
                    Contexto.Programas.ApplyCurrentValues(Programa);
                    //Contexto.Programaes.DeleteObject(Programa);
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
