using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;

namespace DAL
{
    public class DivisasDAL
    {
        public static void newDivisas(Divisa _Divisas)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var last = Contexto.Divisas.OrderByDescending(u => u.Id).FirstOrDefault();
                    Divisas divisas = new Divisas();
                    divisas.Codigo = _Divisas.Codigo;
                    divisas.Nombre = _Divisas.Nombre;
                    divisas.Cambio = Convert.ToDecimal(_Divisas.Cambio);
                    divisas.Simbolo = _Divisas.Simbolo;
                    divisas.Deleted = false;
                    //divisas.Id = last.Id + 1;
                    if (last == null)
                    {
                        divisas.Id = 1;
                    }
                    else
                    {
                        divisas.Id = last.Id + 1;
                    }
                    Contexto.AddToDivisas(divisas);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, divisas);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static Divisa getone(int _id)
        {
            try
            {
                Divisa divisa_ = new Divisa();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var divisa = (from p in Contexto.Divisas
                                  where p.Id == _id && p.Deleted == false
                                  select p).FirstOrDefault();

                    divisa_.Id = divisa.Id;
                    divisa_.Codigo = divisa.Codigo;
                    divisa_.Nombre = divisa.Nombre;
                    divisa_.Simbolo = divisa.Simbolo;
                    divisa_.Cambio = Convert.ToDecimal(divisa.Cambio);

                }

                return divisa_;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<ModelClasses.Divisa> getAllDivisas()
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Divisas
                                 where c.Deleted == false
                                 select c);

                    List<ModelClasses.Divisa> list = new List<ModelClasses.Divisa>();
                    foreach (Divisas item in query)
                    {
                        ModelClasses.Divisa divisa = new ModelClasses.Divisa();
                        divisa.Id = item.Id;
                        divisa.Cambio = Convert.ToDecimal(item.Cambio);
                        divisa.Nombre = item.Nombre;
                        divisa.Codigo = item.Codigo;
                        divisa.Simbolo = item.Simbolo;
                        list.Add(divisa);
                    }
                    return list;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditDivisa(Divisa _divisa)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var divisa = (from p in Contexto.Divisas
                                  where p.Id == _divisa.Id
                                  select p).FirstOrDefault();
                    divisa.Codigo = _divisa.Codigo;
                    divisa.Nombre = _divisa.Nombre;
                    divisa.Deleted = false;
                    divisa.Cambio = Convert.ToDecimal( _divisa.Cambio);
                    divisa.Simbolo = _divisa.Simbolo;
                    Contexto.Divisas.ApplyCurrentValues(divisa);
                    Contexto.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void DeleteDivisa(Divisa _divisa)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var divisa = (from p in Contexto.Divisas
                                  where p.Id == _divisa.Id
                                  select p).FirstOrDefault();
                    divisa.Deleted = true;
                    Contexto.Divisas.ApplyCurrentValues(divisa);
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