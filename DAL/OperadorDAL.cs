using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;

namespace DAL
{
    public class OperadorDAL
    {
        public static void newOperador(ModelClasses.Operador Operador_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var last = Contexto.Operador.OrderByDescending(u => u.Id).FirstOrDefault();
                    Operador Operador = new Operador();
                    Operador.Nombre = Operador_.Nombre;
                    Operador.Ciudad = Convert.ToInt32(Operador_.Ciudad.Id);
                    Operador.Direccion = Operador_.Direcion;
                    Operador.Telefono = Operador_.Telefono;
                    Operador.Contacto = Operador_.Contacto;
                    Operador.Email = Operador_.Email;
                    Operador.NombreBco = Operador_.NombreBco;
                    Operador.NroCuenta = Operador_.NumeroCuenta;
                    Operador.DireccionBco = Operador_.DireccionBco;
                    Operador.CUIT = Operador_.Cuit;
                    Operador.CBU = Operador_.CBU;
                    Operador.Fax = Operador_.Fax;
                    Operador.Deleted = false;
                    Operador.CodPostal = Operador_.CodPostal;
                    //Operador.Id = last.Id + 1;
                    if (last == null)
                    {
                        Operador.Id = 1;
                    }
                    else
                    {
                        Operador.Id = last.Id + 1;
                    }
                    Contexto.AddToOperador(Operador);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, Operador);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
        //GetALL
        //GET1
        //update
        //ADDNEW

        public static List<ModelClasses.Operador> getAllOperador()
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Operador
                                 where c.Deleted == false
                                 orderby c.Nombre ascending
                                 select c);
                    List<ModelClasses.Operador> list = new List<ModelClasses.Operador>();
                    foreach (var Operador_ in query)
                    {
                        ModelClasses.Operador Operador = new ModelClasses.Operador();
                        Operador.Id = Operador_.Id;
                        Operador.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(Operador_.Ciudad));
                        Operador.CiudadNombre = Operador.Ciudad.CodigoInterno;
                        Operador.Nombre = Operador_.Nombre;
                        Operador.Direcion = Operador_.Direccion;
                        Operador.Telefono = Operador_.Telefono;
                        Operador.Contacto = Operador_.Contacto;
                        Operador.Email = Operador_.Email;
                        Operador.NombreBco = Operador_.NombreBco;
                        Operador.NumeroCuenta = Operador_.NroCuenta;
                        Operador.DireccionBco = Operador_.DireccionBco;
                        Operador.Cuit = Operador_.CUIT;
                        Operador.CBU = Operador_.CBU;
                        Operador.CodPostal = Operador_.CodPostal;
                        Operador.Id = Operador_.Id;
                        Operador.Pais = Operador.Ciudad.Pais; 
                        //ciudad.CodigoInterno = item.CodInt;
                        if (!String.IsNullOrEmpty(Operador.Ciudad.Nombre))
                        {
                            list.Add(Operador);
                        }
                    }
                    return list;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ModelClasses.Operador GetoneOperador(int id)
        {
            try
            {
                ModelClasses.Operador Operador_ = new ModelClasses.Operador();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Operador = (from p in Contexto.Operador
                                    where p.Id == id && p.Deleted == false
                                    select p).FirstOrDefault();
                    if (Operador != null)
                    {
                        Operador_.Id = Operador.Id;
                        if (Operador.Ciudad > 0)
                        {
                            Operador_.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(Operador.Ciudad));//Operador.Ciudad.ToString();
                        }
                        if (!String.IsNullOrEmpty(Operador_.Ciudad.Nombre))
                        {
                            Operador_.Nombre = Operador.Nombre;
                            Operador_.Direcion = Operador.Direccion;
                            Operador_.Telefono = Operador.Telefono;
                            Operador_.Contacto = Operador.Contacto;
                            Operador_.Email = Operador.Email;
                            Operador_.Fax = Operador.Fax;
                            Operador_.NombreBco = Operador.NombreBco;
                            Operador_.NumeroCuenta = Operador.NroCuenta;
                            Operador_.DireccionBco = Operador.DireccionBco;
                            Operador_.Cuit = Operador.CUIT;
                            Operador_.CBU = Operador.CBU;
                            Operador_.CodPostal = Operador.CodPostal;
                        }

                    }

                }
                return Operador_;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditOperador(ModelClasses.Operador Operador_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //          Contexto.Products.ApplyCurrentValues(updatedProduct);
                    //model.SaveChanges();
                    var Operador = (from p in Contexto.Operador
                                    where p.Id == Operador_.Id
                                    select p).FirstOrDefault();
                    Operador.Nombre = Operador_.Nombre;
                    Operador.CodPostal = Operador_.CodPostal;
                    Operador.Ciudad = Convert.ToInt32(Operador_.Ciudad.Id);
                    Operador.Direccion = Operador_.Direcion;
                    Operador.Telefono = Operador_.Telefono;
                    Operador.Contacto = Operador_.Contacto;
                    Operador.Fax = Operador_.Fax;
                    Operador.Deleted = false;
                    Operador.Email = Operador_.Email;
                    Operador.NombreBco = Operador_.NombreBco;
                    Operador.NroCuenta = Operador_.NumeroCuenta;
                    Operador.DireccionBco = Operador_.DireccionBco;
                    Operador.CUIT = Operador_.Cuit;
                    Operador.CBU = Operador_.CBU;

                    Contexto.Operador.ApplyCurrentValues(Operador);
                    Contexto.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void DeleteOperador(Operador Operador_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var operador = (from p in Contexto.Operador
                                    where p.Id == Operador_.Id
                                    select p).FirstOrDefault();
                    operador.Deleted = true;
                    Contexto.Operador.ApplyCurrentValues(operador);
                    Contexto.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static bool validExist(string name, int cityID)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Operador = from p in Contexto.Operador
                                   where p.Nombre == name && p.Ciudad == cityID
                                   select p;
                    if (Operador.Count() > 0)
                    { return true; }
                    else { return false; }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<ModelClasses.Operador> GetOperadorporCiudad(int id)
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Operador
                                 where c.Ciudad == id && c.Deleted == false
                                 orderby c.Nombre ascending
                                 select c);
                    List<ModelClasses.Operador> list = new List<ModelClasses.Operador>();
                    foreach (var Operador_ in query)
                    {
                        ModelClasses.Operador Operador = new ModelClasses.Operador();
                        Operador.Id = Operador_.Id;
                        Operador.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(Operador_.Ciudad));
                        Operador.CiudadNombre = Operador.Ciudad.CodigoInterno;
                        Operador.Nombre = Operador_.Nombre;
                        Operador.Direcion = Operador_.Direccion;
                        Operador.Telefono = Operador_.Telefono;
                        Operador.Contacto = Operador_.Contacto;
                        Operador.Email = Operador_.Email;
                        Operador.NombreBco = Operador_.NombreBco;
                        Operador.NumeroCuenta = Operador_.NroCuenta;
                        Operador.DireccionBco = Operador_.DireccionBco;
                        Operador.Cuit = Operador_.CUIT;
                        Operador.CBU = Operador_.CBU;
                        Operador.CodPostal = Operador_.CodPostal;
                        Operador.Fax = Operador_.Fax;
                        //ciudad.CodigoInterno = item.CodInt;
                        list.Add(Operador);
                    }
                    return list;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}