using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;

namespace DAL
{
    public class ServicioDAL
    {
        public static int newServicio(ModelClasses.Servicio Servicio_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var last = Contexto.Servicio.OrderByDescending(u => u.Id).FirstOrDefault();
                    int LastID = 0;
                    if (last != null)
                    {
                        LastID = last.Id + 1;
                    }
                    else { LastID = 1; }
                    Servicio Servicio = new Servicio();
                    Servicio.Deleted = false;
                    Servicio.Nombre = Servicio_.Nombre;
                    Servicio.Observacion = Servicio_.ObservacionServicio;
                    Servicio.Ciudad = Convert.ToInt32(Servicio_.CiudadOperador.Id);
                    Servicio.Actividad = Servicio_.Actividad;
                    Servicio.DiasCant = Convert.ToInt32(Servicio_.DiasCant);
                    Servicio.TipoTranfer = Servicio_.TipoTranfer;
                    Servicio.Operador = Servicio_.Operador.Id;
                    Servicio.CiudadOrigen = Convert.ToInt32(Servicio_.CiudadO.Id);
                    Servicio.CiudadDestino = Convert.ToInt32(Servicio_.CiudadD.Id);
                    Servicio.HoraSalida = Servicio_.HoraSalida.Trim();
                    Servicio.HoraLlegada = Servicio_.HoraLlegada.Trim();
                    Servicio.Id = LastID;
                    Servicio.Image = Servicio_.IdImagen;
                    Contexto.AddToServicio(Servicio);
                    Contexto.SaveChanges();

                    var IdAdded = Contexto.Servicio.OrderByDescending(u => u.Id).FirstOrDefault();
                    #region
                    //var lastDetalle = Contexto.ServicioDetalleIdiomas.OrderByDescending(u => u.Id).FirstOrDefault();
                    //int LastIDDet = 0;
                    //if (lastDetalle != null)
                    //{
                    //    LastIDDet = lastDetalle.Id + 1;
                    //}
                    //else { LastIDDet = 1; }
                    //DAL.ServicioDetalleIdiomas newDetalle = new DAL.ServicioDetalleIdiomas();
                    //newDetalle.Id = LastIDDet;
                    //newDetalle.IdServicio = IdAdded.Id;
                    //newDetalle.NombreES = Servicio_.DetalleIdiomas.NombreES;
                    //newDetalle.DescripcionEs = Servicio_.DetalleIdiomas.DescripcionEs;
                    //newDetalle.NombreEN = Servicio_.DetalleIdiomas.NombreEN;
                    //newDetalle.DescripcionEN = Servicio_.DetalleIdiomas.DescripcionEN;
                    //newDetalle.NombreIT = Servicio_.DetalleIdiomas.NombreIT;
                    //newDetalle.DetalleIT = Servicio_.DetalleIdiomas.DescripcionIT;
                    //newDetalle.NombrePT = Servicio_.DetalleIdiomas.NombrePT;
                    //newDetalle.DescripcionPT = Servicio_.DetalleIdiomas.DescripcionPT;
                    //newDetalle.Deleted = false;
                    ////newDetalle.Imagen = Servicio_.DetalleIdiomas.Image;
                    //Contexto.AddToServicioDetalleIdiomas(newDetalle);
                    //Contexto.SaveChanges();
                    //Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, Servicio);
                    #endregion
                    return IdAdded.Id;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void newDetServ(ModelClasses.ServicioDetalleIdioma DetServ)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {

                    var lastDetalle = Contexto.ServicioDetalleIdiomas.OrderByDescending(u => u.Id).FirstOrDefault();
                    int LastIDDet = 0;
                    if (lastDetalle != null)
                    {
                        LastIDDet = lastDetalle.Id + 1;
                    }
                    else { LastIDDet = 1; }
                    DAL.ServicioDetalleIdiomas newDetalle = new DAL.ServicioDetalleIdiomas();
                    newDetalle.Id = LastIDDet;
                    newDetalle.IdServicio = DetServ.IdServicio;
                    newDetalle.NombreES = DetServ.NombreES;
                    newDetalle.DescripcionEs = DetServ.DescripcionEs;
                    newDetalle.NombreEN = DetServ.NombreEN;
                    newDetalle.DescripcionEN = DetServ.DescripcionEN;
                    newDetalle.NombreIT = DetServ.NombreIT;
                    newDetalle.DetalleIT = DetServ.DescripcionIT;
                    newDetalle.NombrePT = DetServ.NombrePT;
                    newDetalle.DescripcionPT = DetServ.DescripcionPT;
                    newDetalle.NumeroDia = DetServ.NumDia;
                    newDetalle.Deleted = false;
                    Contexto.AddToServicioDetalleIdiomas(newDetalle);
                    Contexto.SaveChanges();
                    //Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, DAL.ServicioDetalleIdiomas);

                    
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }       
        
        public static List<ModelClasses.Servicio> getAllServicio()
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Servicio
                                 where c.Deleted == false
                                 orderby c.Nombre ascending
                                 select c);
                    List<ModelClasses.Servicio> list = new List<ModelClasses.Servicio>();
                    foreach (var Servicio_ in query)
                    {
                    ModelClasses.Servicio Servicio = new ModelClasses.Servicio();
                    Servicio.Id = Servicio_.Id;
                    Servicio.Nombre = Servicio_.Nombre;
                    Servicio.ObservacionServicio = Servicio_.Observacion;
                    Servicio.CiudadOperador =CiudadesDAL.GetOneById( Convert.ToInt32(Servicio_.Ciudad));
                    Servicio.Actividad = Servicio_.Actividad;
                    Servicio.DiasCant = Servicio_.DiasCant.ToString();
                    Servicio.TipoTranfer = Servicio_.TipoTranfer;
                    Servicio.Operador =OperadorDAL.GetoneOperador( Convert.ToInt32(Servicio_.Operador));
                    Servicio.NombreOperador = Servicio.Operador.Nombre;
                    Servicio.Ciudad = Servicio.CiudadOperador.Nombre;
                    Servicio.CiudadO = CiudadesDAL.GetOneById( Convert.ToInt32(Servicio_.CiudadOrigen));
                    Servicio.CiudadD = CiudadesDAL.GetOneById(Convert.ToInt32(Servicio_.CiudadDestino));
                    Servicio.HoraSalida = Servicio_.HoraSalida.ToString().Trim();
                    Servicio.HoraLlegada =Servicio_.HoraLlegada.ToString().Trim();
                    //string a = "data:image/jpg;base64," + Convert.ToBase64String(image);
                    if (Servicio_.Image > 0)
                    {
                       Imagen imagen = ImagenesDAL.GetOneById(Convert.ToInt32(Servicio_.Image));
                       Servicio.ImgUrl = "data:image/jpg;base64," + Convert.ToBase64String(imagen.Image) ;
                    }
                   
                    if (!String.IsNullOrEmpty(Servicio.Operador.Nombre))
                    {
                        list.Add(Servicio);
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

        public static ModelClasses.Servicio GetoneServicio(int id)
        {
            try
            {
                ModelClasses.Servicio Servicio = new ModelClasses.Servicio();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Servicio_ = (from p in Contexto.Servicio
                                where p.Id == id && p.Deleted == false
                                select p).FirstOrDefault();
                    if (Servicio_ != null)
                    {
                        Servicio.Id = Servicio_.Id;
                        Servicio.Nombre = Servicio_.Nombre;
                        Servicio.ObservacionServicio = Servicio_.Observacion;
                        Servicio.CiudadOperador = CiudadesDAL.GetOneById(Convert.ToInt32(Servicio_.Ciudad));
                        Servicio.Actividad = Servicio_.Actividad;
                        Servicio.DiasCant = Servicio_.DiasCant.ToString();
                        Servicio.TipoTranfer = Servicio_.TipoTranfer;
                        Servicio.Operador = OperadorDAL.GetoneOperador(Convert.ToInt32(Servicio_.Operador));
                        Servicio.NombreOperador = Servicio.Operador.Nombre;
                        Servicio.Ciudad = Servicio.CiudadOperador.Nombre;
                        Servicio.CiudadO = CiudadesDAL.GetOneById(Convert.ToInt32(Servicio_.CiudadOrigen));
                        Servicio.CiudadD = CiudadesDAL.GetOneById(Convert.ToInt32(Servicio_.CiudadDestino));
                        Servicio.HoraSalida = Servicio_.HoraSalida.ToString().Trim();
                        Servicio.HoraLlegada = Servicio_.HoraLlegada.ToString().Trim();
                        List<ModelClasses.ServicioDetalleIdioma> Detalle = new List<ModelClasses.ServicioDetalleIdioma>();
                        Detalle = GetDetailServic(Servicio_.Id);
                        Servicio.DetalleIdiomas = Detalle;
                        Servicio.IdImagen =Convert.ToInt32(Servicio_.Image);
                    }
                }
                return Servicio;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditServicio(ModelClasses.Servicio Servicio_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Servicio = (from p in Contexto.Servicio
                                    where p.Id == Servicio_.Id
                                    select p).FirstOrDefault();

                    Servicio.Id = Servicio_.Id;
                    Servicio.Nombre = Servicio_.Nombre;
                    //Servicio.Ciudad = Convert.ToInt32(Servicio_.CiudadOperador.Id);
                    //Servicio.Actividad = Servicio_.Actividad;
                    //Servicio.DiasCant = Convert.ToInt32(Servicio_.DiasCant);
                    //Servicio.TipoTranfer = Servicio_.TipoTranfer;
                    //Servicio.Operador = Servicio_.Operador.Id;
                    //Servicio.CiudadOrigen = Convert.ToInt32(Servicio_.CiudadO.Id);
                    //Servicio.CiudadDestino = Convert.ToInt32(Servicio_.CiudadD.Id);
                    Servicio.Image = Servicio_.IdImagen;
                    Servicio.HoraSalida = Servicio_.HoraSalida;
                    Servicio.HoraLlegada =Servicio_.HoraLlegada;
                    Servicio.Deleted = false;
                    //Servicio.Observaciones = Convert.ToDateTime(Servicio_.HoraLlegada);
                    Contexto.Servicio.ApplyCurrentValues(Servicio);
                    Contexto.SaveChanges();
                    foreach (var item in Servicio_.DetalleIdiomas)
                    {
                        var ServicioDetalle = (from p in Contexto.ServicioDetalleIdiomas
                                               where p.Id == item.Id //p.IdServicio == Servicio_.Id &&
                                               select p).FirstOrDefault();
                        ServicioDetalle.IdServicio = item.IdServicio;
                        ServicioDetalle.NombreES = item.NombreES;
                        ServicioDetalle.DescripcionEs = item.DescripcionEs;
                        ServicioDetalle.NombreEN = item.NombreEN;
                        ServicioDetalle.DescripcionEN = item.DescripcionEN;
                        ServicioDetalle.NombreIT = item.NombreIT;
                        ServicioDetalle.DetalleIT = item.DescripcionIT;
                        ServicioDetalle.NombrePT = item.NombrePT;
                        ServicioDetalle.DescripcionPT = item.DescripcionPT;
                        ServicioDetalle.NumeroDia = item.NumDia;
                        Contexto.ServicioDetalleIdiomas.ApplyCurrentValues(ServicioDetalle);
                        Contexto.SaveChanges();
                    }

                   

                    

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void DeleteServicio(Servicio _servicio)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var Servicio_ = (from p in Contexto.Servicio
                                  where p.Id == _servicio.Id
                                  select p).FirstOrDefault();
                    Servicio_.Deleted = true;
                    Contexto.Servicio.ApplyCurrentValues(Servicio_);
                    Contexto.SaveChanges();

                    var DetalleServicio = (from p in Contexto.ServicioDetalleIdiomas
                                  where p.IdServicio == _servicio.Id
                                  select p);
                    foreach (var item in DetalleServicio)
                    {
                        //item.Deleted = true;
                        //Contexto.ServicioDetalleIdiomas.ApplyCurrentValues(item);
                        //Contexto.SaveChanges();
                    }
                   
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<ModelClasses.ServicioDetalleIdioma> GetDetailServic(int idservece)
        {
            List<ModelClasses.ServicioDetalleIdioma> list = new List<ModelClasses.ServicioDetalleIdioma>();
            using (var Contexto = new TurismoReceptivoEntities())
            {
                var DetServicio_ = (from p in Contexto.ServicioDetalleIdiomas
                            where p.IdServicio == idservece && p.Deleted == false
                            select p);
                foreach (var DetSerItem_ in DetServicio_)
                {

                    ModelClasses.ServicioDetalleIdioma Detalle = new ModelClasses.ServicioDetalleIdioma();
                    Detalle.Id = DetSerItem_.Id;
                    Detalle.IdServicio = Convert.ToInt32(DetSerItem_.IdServicio);
                    Detalle.NombreES = DetSerItem_.NombreES;
                    Detalle.DescripcionEs = DetSerItem_.DescripcionEs;
                    Detalle.NombreEN = DetSerItem_.NombreEN;
                    Detalle.DescripcionEN = DetSerItem_.DescripcionEN;
                    Detalle.NombreIT = DetSerItem_.NombreIT;
                    Detalle.DescripcionIT = DetSerItem_.DetalleIT;
                    Detalle.NombrePT = DetSerItem_.NombrePT;
                    Detalle.DescripcionPT = DetSerItem_.DescripcionPT;
                    Detalle.NumDia = Convert.ToInt32(DetSerItem_.NumeroDia);
                    list.Add(Detalle);
                }
                               
            }
            return list;
        }
       
        public static List<ModelClasses.Servicio> GetServicioporOperador(int id)
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Servicio
                                 where c.Operador == id && c.Deleted == false
                                 orderby c.Nombre ascending
                                 select c);
                    List<ModelClasses.Servicio> list = new List<ModelClasses.Servicio>();
                    foreach (var Servicio_ in query)
                    {
                        ModelClasses.Servicio Servicio = new ModelClasses.Servicio();
                        Servicio.Id = Servicio_.Id;
                        int ciudadID = Convert.ToInt32(Servicio_.Ciudad);
                        Ciudad Ciudad = new Ciudad(); 
                        Ciudad = CiudadesDAL.GetOneById(ciudadID);
                        Servicio.Nombre = Servicio_.Nombre +" - "+ Servicio.TipoTranfer ;
                        Servicio.Ciudad = Ciudad.Nombre;
                        list.Add(Servicio);
                    }
                    return list;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ModelClasses.Servicio> GetServicioporTipo(string tipo)
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Servicio
                                 where c.Actividad == tipo && c.Deleted == false
                                 orderby c.Nombre ascending
                                 select c);
                    List<ModelClasses.Servicio> list = new List<ModelClasses.Servicio>();
                    foreach (var Servicio_ in query)
                    {
                        ModelClasses.Servicio Servicio = new ModelClasses.Servicio();
                        Servicio.Id = Servicio_.Id;
                        int ciudadID = Convert.ToInt32(Servicio_.Ciudad);
                        Ciudad Ciudad = new Ciudad();
                        Ciudad = CiudadesDAL.GetOneById(ciudadID);
                        Servicio.Nombre = Servicio_.Nombre + " - " + Servicio.TipoTranfer;
                        Servicio.Ciudad = Ciudad.Nombre;
                        list.Add(Servicio);
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