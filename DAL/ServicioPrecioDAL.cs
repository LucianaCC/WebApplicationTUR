using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;

namespace DAL
{
    public class ServicioPrecioDAL
    {
        public static void newServicioPrecio(ModelClasses.ServicioPrecio ServicioPrecio_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var last = Contexto.ServicioPrecio.OrderByDescending(u => u.Id).FirstOrDefault();
                    ServicioPrecio ServicioPrecio = new ServicioPrecio();
                    ServicioPrecio.IdOperador = ServicioPrecio_.IdOperador;
                    ServicioPrecio.IdServicio = ServicioPrecio_.IdServicio;
                    ServicioPrecio.Moneda = ServicioPrecio_.Moneda;
                    ServicioPrecio.FechaDesde = ServicioPrecio_.FechaDesde;
                    ServicioPrecio.FechaHasta = ServicioPrecio_.FechaHasta;
                    ServicioPrecio.Precio = ServicioPrecio_.Precio;
                    ServicioPrecio.TipoServicio = ServicioPrecio_.TipoServicio;
                    if (ServicioPrecio_.UnitarioGrupal == "Unit")
                    {
                        ServicioPrecio.Unit =true;
                    }
                    else
                    {
                        ServicioPrecio.Unit = false;    
                    }
                   

                    if (last == null)
                    {
                        ServicioPrecio.Id = 1;
                    }
                    else
                    {
                        ServicioPrecio.Id = last.Id + 1;
                    }
                    //ServicioPrecio.Id = last.Id + 1;
                    ServicioPrecio.Deleted = false;
                    Contexto.AddToServicioPrecio(ServicioPrecio);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, ServicioPrecio);

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

        public static List<ModelClasses.ServicioPrecio> getAllServicioPrecio()
        {
            try
            {
                List<ModelClasses.ServicioPrecio> list = new List<ModelClasses.ServicioPrecio>();


                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.ServicioPrecio
                                 where c.Deleted == false
                                 orderby c.FechaDesde ascending
                                 select c);
                    foreach (var item in query)
                    {
                        ModelClasses.ServicioPrecio ServicioPrecio = new  ModelClasses.ServicioPrecio ();
                        ServicioPrecio.Id = item.Id;
                        ServicioPrecio.IdOperador = Convert.ToInt32(item.IdOperador);
                        ServicioPrecio.IdServicio = Convert.ToInt32(item.IdServicio);
                        ServicioPrecio.FechaDesde = Convert.ToDateTime(item.FechaDesde);
                        ServicioPrecio.FechaHasta = Convert.ToDateTime(item.FechaHasta);
                        ServicioPrecio.TipoServicio =item.TipoServicio;
                        ServicioPrecio.Precio =Convert.ToDecimal(item.Precio);
                        ModelClasses.Servicio servicio = ServicioDAL.GetoneServicio(Convert.ToInt32(item.IdServicio));
                        ServicioPrecio.NombreServicio = servicio.Nombre;
                        ModelClasses.Operador Operador = OperadorDAL.GetoneOperador(Convert.ToInt32(item.IdOperador));
                        if (!String.IsNullOrEmpty(servicio.Nombre) && !String.IsNullOrEmpty(Operador.Nombre))
                        {
                            ServicioPrecio.OperadorServicio = Operador.Nombre;
                            ServicioPrecio.CiudadServicio = servicio.Ciudad;
                            ServicioPrecio.ActividadServicio = servicio.Actividad;
                            ServicioPrecio.FdesdeServicio = ServicioPrecio.FechaDesde.ToString("M/d/yyyy");
                            ServicioPrecio.FHastaServicio = ServicioPrecio.FechaHasta.ToString("M/d/yyyy");
                            ModelClasses.Divisa divisas = new ModelClasses.Divisa();
                            divisas = DAL.DivisasDAL.getone(Convert.ToInt32(item.Moneda));
                            ServicioPrecio.MonedaServicio = divisas.Simbolo;
                            if (item.Unit == true || item.Unit == null)
                            {
                                ServicioPrecio.UnitarioGrupal = "Unit";
                            }
                            else
                            {
                                ServicioPrecio.UnitarioGrupal = "Grup";
                            }

                            list.Add(ServicioPrecio);
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

        public static ModelClasses.ServicioPrecio GetoneServicioPrecio(int id)
        {
            try
            {
               ModelClasses.ServicioPrecio ServicioPrecio = new ModelClasses.ServicioPrecio();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var item = (from p in Contexto.ServicioPrecio
                                          where p.Id == id && p.Deleted == false
                                          select p).FirstOrDefault();

                    ServicioPrecio.Id = item.Id;
                    ServicioPrecio.IdOperador = Convert.ToInt32(item.IdOperador);
                    ServicioPrecio.IdServicio = Convert.ToInt32(item.IdServicio);
                    ServicioPrecio.FechaDesde = Convert.ToDateTime(item.FechaDesde);
                    ServicioPrecio.FechaHasta = Convert.ToDateTime(item.FechaHasta);
                    ServicioPrecio.TipoServicio = item.TipoServicio;
                    ServicioPrecio.Precio = Convert.ToDecimal(item.Precio);
                    ModelClasses.Servicio servicio = ServicioDAL.GetoneServicio(Convert.ToInt32(item.IdServicio));
                    ServicioPrecio.NombreServicio = servicio.Nombre;
                    ModelClasses.Operador Operador = OperadorDAL.GetoneOperador(Convert.ToInt32(item.IdOperador));
                    ServicioPrecio.OperadorServicio = Operador.Nombre;
                    ServicioPrecio.CiudadServicio = servicio.Ciudad;
                    ServicioPrecio.ActividadServicio = servicio.Actividad;
                    ServicioPrecio.FdesdeServicio = ServicioPrecio.FechaDesde.ToString("M/d/yyyy");
                    ServicioPrecio.FHastaServicio = ServicioPrecio.FechaHasta.ToString("M/d/yyyy");
                    ModelClasses.Divisa divisas = new ModelClasses.Divisa();
                    divisas = DAL.DivisasDAL.getone(Convert.ToInt32(item.Moneda));
                    ServicioPrecio.MonedaServicio = divisas.Simbolo;
                    ServicioPrecio.Moneda = item.Moneda.ToString();
                    if (item.Unit == true || item.Unit == null)
                    {
                        ServicioPrecio.UnitarioGrupal = "Unit";
                    }
                    else
                    {
                        ServicioPrecio.UnitarioGrupal = "Grup";
                    }



                }
                return ServicioPrecio;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditServicioPrecio(ModelClasses.ServicioPrecio ServicioPrecio_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    
                    var servicioPrecio = (from p in Contexto.ServicioPrecio
                                          where p.Id == ServicioPrecio_.Id
                                          select p).FirstOrDefault();
                    servicioPrecio.Moneda = ServicioPrecio_.Moneda;
                    servicioPrecio.Deleted = false;
                    servicioPrecio.FechaDesde = ServicioPrecio_.FechaDesde;
                    servicioPrecio.FechaHasta = ServicioPrecio_.FechaHasta;
                    servicioPrecio.Precio = ServicioPrecio_.Precio;
                    servicioPrecio.TipoServicio = ServicioPrecio_.TipoServicio;
                    if (ServicioPrecio_.UnitarioGrupal == "Unit")
                    {
                        servicioPrecio.Unit = true;
                    }
                    else
                    {
                        servicioPrecio.Unit = false;
                    }
                    Contexto.ServicioPrecio.ApplyCurrentValues(servicioPrecio);
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
                    //var ServicioPrecio = from p in Contexto.ServicioPrecio
                    //               where p.Nombre == name && p.Ciudad == cityID
                    //               select p;
                    //if (ServicioPrecio.Count() > 0)
                    { return true; }
                    //else { return false; }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void DeleteServicio(int deleteServ)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var serv = (from p in Contexto.ServicioPrecio
                                where p.Id == deleteServ
                                  select p).FirstOrDefault();
                    serv.Deleted = true;
                    Contexto.ServicioPrecio.ApplyCurrentValues(serv);
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