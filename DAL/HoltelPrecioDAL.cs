using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;


namespace DAL
{
    public class HoltelPrecioDAL
    {

        //Llena el gridview
        public static List<HotelPrecio> getAllHotelesPrecio()
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.PrecioHotelDetail
                                 where c.Deleted == false
                                 orderby c.FechaDesde ascending
                                 select c);
                    List<HotelPrecio> list = new List<HotelPrecio>();
                    foreach (var _hotelPrecio in query)
                    {
                        HotelPrecio hoteldetail = new HotelPrecio();
                        hoteldetail.Id = _hotelPrecio.Id;
                        hoteldetail.NameHabitacion = _hotelPrecio.TipoHabitacion.ToString();
                        hoteldetail.FDesde = Convert.ToDateTime(_hotelPrecio.FechaDesde);
                        hoteldetail.FHasta = Convert.ToDateTime(_hotelPrecio.FechaHasta);
                        hoteldetail.FDesdeString = hoteldetail.FDesde.ToString("M/d/yyyy");
                        hoteldetail.FHastaString = hoteldetail.FHasta.ToString("M/d/yyyy");
                        hoteldetail.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(_hotelPrecio.IdHotel));
                        if (!String.IsNullOrEmpty(hoteldetail.Hotel.Nombre))
                        {
                            hoteldetail.Ciudad = hoteldetail.Hotel.NombreCiudad;
                            hoteldetail.Name = hoteldetail.Hotel.Nombre ;//+ " " + hoteldetail.;
                            hoteldetail.PrecioDolar = Convert.ToDecimal(_hotelPrecio.PrecioDolar);
                            hoteldetail.PrecioPeso = Convert.ToDecimal(_hotelPrecio.PrecioPeso);
                            if (!hoteldetail.Hotel.Delete && hoteldetail.Hotel.Ciudad.Id != 0)
                            {
                                list.Add(hoteldetail);
                            }
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

        //Guarda nuevo
        public static void newHotelPrecio(HotelPrecio _hotelPrecio)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //CHA - El Chaltén
                    var last = Contexto.PrecioHotelDetail.OrderByDescending(u => u.Id).FirstOrDefault();
                    PrecioHotelDetail hoteldetail = new PrecioHotelDetail();
                    hoteldetail.FechaDesde = _hotelPrecio.FDesde;
                    hoteldetail.FechaHasta = _hotelPrecio.FHasta;
                    hoteldetail.IdHotel = _hotelPrecio.Hotel.Id;
                    hoteldetail.TipoHabitacion = _hotelPrecio.NameHabitacion;
                    hoteldetail.Nombre = _hotelPrecio.Hotel.Nombre + " - " + _hotelPrecio.Hotel.Ciudad.Nombre;
                    if (last != null) { hoteldetail.Id = last.Id + 1; }
                    else { hoteldetail.Id = 1; }
                    hoteldetail.PrecioDolar = _hotelPrecio.PrecioDolar;
                    hoteldetail.PrecioPeso = _hotelPrecio.PrecioPeso;
                    hoteldetail.Deleted = false;
                    Contexto.AddToPrecioHotelDetail(hoteldetail);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, hoteldetail);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        //Obtiene 1 - Para Edit o presupuesto
        public static HotelPrecio GetOneById(int ID)
        {
            try
            {
                HotelPrecio hoteldetail = new HotelPrecio();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //var _hotelPrecio = (from c in Contexto.PrecioHotelDetail
                    //                    orderby c.Id == _ID
                    //                    select c).FirstOrDefault();
                    var hotel = (from p in Contexto.PrecioHotelDetail
                                 where p.Id == ID && p.Deleted == false
                                 select p).FirstOrDefault();

                    hoteldetail.Id = hotel.Id;
                    hoteldetail.FDesde = Convert.ToDateTime(hotel.FechaDesde);
                    hoteldetail.FHasta = Convert.ToDateTime(hotel.FechaHasta);
                    hoteldetail.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(hotel.IdHotel));
                    hoteldetail.Name = hotel.Nombre;
                    hoteldetail.NameHabitacion = hotel.TipoHabitacion;
                    hoteldetail.PrecioDolar = Convert.ToDecimal(hotel.PrecioDolar);
                    hoteldetail.PrecioPeso = Convert.ToDecimal(hotel.PrecioPeso);
                }
                return hoteldetail;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static void EditPrecioHotel(PrecioHotelDetail _hotelPrecio)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var hoteldetail = (from p in Contexto.PrecioHotelDetail
                                       where p.Id == _hotelPrecio.Id
                                       select p).FirstOrDefault();

                    PrecioHotelDetail HotelPrecio = new PrecioHotelDetail();
                    hoteldetail.Id = _hotelPrecio.Id;
                    hoteldetail.FechaDesde = Convert.ToDateTime(_hotelPrecio.FechaDesde);
                    hoteldetail.FechaHasta = Convert.ToDateTime(_hotelPrecio.FechaHasta);
                    //hoteldetail.IdHotel = _hotelPrecio.IdHotel;
                    hoteldetail.TipoHabitacion = _hotelPrecio.TipoHabitacion;
                    hoteldetail.PrecioDolar = _hotelPrecio.PrecioDolar;
                    hoteldetail.PrecioPeso = _hotelPrecio.PrecioPeso;
                    hoteldetail.Deleted = false;
                    Contexto.PrecioHotelDetail.ApplyCurrentValues(hoteldetail);
                    Contexto.SaveChanges();
                    //Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, HotelPrecio);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static void DeletePrecioHotel(HotelPrecio _hotelPrecio)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var hotelPrecio = (from p in Contexto.PrecioHotelDetail
                                       where p.Id == _hotelPrecio.Id
                                       select p).FirstOrDefault();
                    hotelPrecio.Deleted = true;
                    Contexto.PrecioHotelDetail.ApplyCurrentValues(hotelPrecio);
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