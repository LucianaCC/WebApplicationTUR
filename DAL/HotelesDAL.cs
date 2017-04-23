using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelClasses;

namespace DAL
{

    public class HotelesDAL
    {
        public static void newhotel(ModelClasses.Hotel hotel_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var last = Contexto.Hotel.OrderByDescending(u => u.Id).FirstOrDefault();
                    Hotel hotel = new Hotel();
                    hotel.Categoria = hotel_.Categoria;
                    hotel.Nombre = hotel_.Nombre;
                    hotel.Ciudad = Convert.ToInt32(hotel_.Ciudad.Id);
                    hotel.Direccion = hotel_.Direcion;
                    hotel.Telefono = hotel_.Telefono;
                    hotel.Contacto = hotel_.Contacto;
                    hotel.Email = hotel_.Email;
                    hotel.NombreBco = hotel_.NombreBco;
                    hotel.NroCuenta = hotel_.NumeroCuenta;
                    hotel.DireccionBco = hotel_.DireccionBco;
                    hotel.Cuit = hotel_.Cuit;
                    hotel.CBU = hotel_.CBU;
                    hotel.ObservacionBco = hotel_.ObservacionBco;
                    hotel.Observacion = hotel_.Observacion;
                    hotel.Checkin = hotel_.CheckIn;
                    hotel.Checkout = hotel_.CheckOut;
                    hotel.Deleted = false;
                    //hotel.Id = last.Id + 1;
                    if (last == null)
                    {
                        hotel.Id = 1;
                    }
                    else
                    {
                        hotel.Id = last.Id + 1;
                    }
                    Contexto.AddToHotel(hotel);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, hotel);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<ModelClasses.Hotel> getAllHoteles()
        {
            try
            {

                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Hotel
                                 where c.Deleted == false
                                 select c);


                    List<ModelClasses.Hotel> list = new List<ModelClasses.Hotel>();
                    foreach (var hotel in query)
                    {
                        ModelClasses.Hotel hotel_ = new ModelClasses.Hotel();
                        hotel_.Id = hotel.Id;
                        if (hotel.Ciudad > 0)
                        {
                            hotel_.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(hotel.Ciudad));//hotel.Ciudad.ToString();
                        }
                        hotel_.Categoria = hotel.Categoria;
                        hotel_.Nombre = hotel.Nombre;
                        hotel_.Direcion = hotel.Direccion;
                        hotel_.Telefono = hotel.Telefono;
                        hotel_.Contacto = hotel.Contacto;
                        hotel_.Email = hotel.Email;
                        hotel_.NombreBco = hotel.NombreBco;
                        hotel_.NumeroCuenta = hotel.NroCuenta;
                        hotel_.DireccionBco = hotel.DireccionBco;
                        hotel_.Cuit = hotel.Cuit;
                        hotel_.CBU = hotel.CBU;
                        hotel_.Observacion = hotel.Observacion;
                        hotel_.ObservacionBco = hotel.ObservacionBco;
                        hotel_.CheckIn = hotel.Checkin;
                        hotel_.CheckOut = hotel.Checkout;
                        hotel_.NombreCiudad = hotel_.Ciudad.CodigoInterno;
                        if (!String.IsNullOrEmpty( hotel_.Ciudad.Nombre ))
                        {
                            list.Add(hotel_);
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

        public static ModelClasses.Hotel GetoneHotel(int id)
        {
            try
            {
                ModelClasses.Hotel hotel_ = new ModelClasses.Hotel();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var hotel = (from p in Contexto.Hotel
                                 where p.Id == id && p.Deleted== false
                                 select p).FirstOrDefault();
                    if (hotel != null)
                    {
                        hotel_.Id = hotel.Id;
                        if (hotel.Ciudad > 0)
                        {
                            hotel_.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(hotel.Ciudad));//hotel.Ciudad.ToString();
                        }
                        hotel_.Categoria = hotel.Categoria;
                        hotel_.Nombre = hotel.Nombre;
                        hotel_.Direcion = hotel.Direccion;
                        hotel_.Telefono = hotel.Telefono;
                        hotel_.Contacto = hotel.Contacto;
                        hotel_.Email = hotel.Email;
                        hotel_.NombreBco = hotel.NombreBco;
                        hotel_.NumeroCuenta = hotel.NroCuenta;
                        hotel_.DireccionBco = hotel.DireccionBco;
                        hotel_.Cuit = hotel.Cuit;
                        hotel_.CBU = hotel.CBU;
                        hotel_.Observacion = hotel.Observacion;
                        hotel_.ObservacionBco = hotel.ObservacionBco;
                        hotel_.CheckIn = hotel.Checkin;
                        hotel_.CheckOut = hotel.Checkout;
                        hotel_.NombreCiudad = hotel_.Ciudad.Nombre;
                        hotel_.Delete = hotel_.Delete;

                    }
                }
                return hotel_;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<ModelClasses.Hotel> GetHotelesporCiudad(int idCiudad)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var query = (from c in Contexto.Hotel
                                 where c.Ciudad == idCiudad && c.Deleted == false
                                 select c);


                    List<ModelClasses.Hotel> list = new List<ModelClasses.Hotel>();
                    foreach (var hotel in query)
                    {
                        ModelClasses.Hotel hotel_ = new ModelClasses.Hotel();
                        hotel_.Id = hotel.Id;
                        if (hotel.Ciudad > 0)
                        {
                            hotel_.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(hotel.Ciudad));//hotel.Ciudad.ToString();
                        }
                        hotel_.Id = hotel.Id;
                        hotel_.Categoria = hotel.Categoria;
                        hotel_.Nombre = hotel.Nombre;
                        hotel_.Direcion = hotel.Direccion;
                        hotel_.Telefono = hotel.Telefono;
                        hotel_.Contacto = hotel.Contacto;
                        hotel_.Email = hotel.Email;
                        hotel_.NombreBco = hotel.NombreBco;
                        hotel_.NumeroCuenta = hotel.NroCuenta;
                        hotel_.DireccionBco = hotel.DireccionBco;
                        hotel_.Cuit = hotel.Cuit;
                        hotel_.CBU = hotel.CBU;
                        hotel_.Observacion = hotel.Observacion;
                        hotel_.ObservacionBco = hotel.ObservacionBco;
                        hotel_.CheckIn = hotel.Checkin;
                        hotel_.CheckOut = hotel.Checkout;
                        hotel_.NombreCiudad = hotel_.Ciudad.Nombre;
                        list.Add(hotel_);
                    }
                    return list;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EditHotel(ModelClasses.Hotel hotel_)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //          Contexto.Products.ApplyCurrentValues(updatedProduct);
                    //model.SaveChanges();
                    var hotel = (from p in Contexto.Hotel
                                 where p.Id == hotel_.Id
                                 select p).FirstOrDefault();
                    hotel.Nombre = hotel_.Nombre;
                    hotel.Categoria = hotel_.Categoria;
                    hotel.Nombre = hotel_.Nombre;
                    hotel.Ciudad = Convert.ToInt32(hotel_.Ciudad.Id);
                    hotel.Direccion = hotel_.Direcion;
                    hotel.Telefono = hotel_.Telefono;
                    hotel.Contacto = hotel_.Contacto;
                    hotel.Email = hotel_.Email;
                    hotel.NombreBco = hotel_.NombreBco;
                    hotel.NroCuenta = hotel_.NumeroCuenta;
                    hotel.DireccionBco = hotel_.DireccionBco;
                    hotel.Cuit = hotel_.Cuit;
                    hotel.CBU = hotel_.CBU;
                    hotel.ObservacionBco = hotel_.ObservacionBco;
                    hotel.Observacion = hotel_.Observacion;
                    hotel.Checkin = hotel_.CheckIn;
                    hotel.Checkout = hotel_.CheckOut;
                    hotel.Deleted = false;
                    Contexto.Hotel.ApplyCurrentValues(hotel);
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
                Hotel hotel_ = new Hotel();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var hotel = from p in Contexto.Hotel
                                where p.Nombre == name && p.Ciudad == cityID
                                select p;
                    if (hotel.Count() > 0)
                    { return true; }
                    else { return false; }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static void DeleteHotel(Hotel _hotel)
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var hotel_ = (from p in Contexto.Hotel
                                  where p.Id == _hotel.Id
                                  select p).FirstOrDefault();
                    hotel_.Deleted = true;
                    Contexto.Hotel.ApplyCurrentValues(hotel_);
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