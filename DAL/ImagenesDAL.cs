using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class ImagenesDAL
    {
        public static ModelClasses.Imagen GetOneById(int _ID)
        {
            try
            {
                ModelClasses.Imagen imagen = new ModelClasses.Imagen();
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    var _imagen = (from c in Contexto.Imagenes
                                   where c.ID == _ID 
                                   select c).FirstOrDefault();
                    if (_imagen != null)
                    {
                        imagen.Nombre = _imagen.NombreImagen;
                        imagen.Image = _imagen.Imagen;
                        imagen.Id = _imagen.ID;
                        
                    }
                }
                return imagen;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static int newImagen(string name, byte[] image )
        {
            try
            {
                using (var Contexto = new TurismoReceptivoEntities())
                {
                    //CHA - El Chaltén
                    var last = Contexto.Imagenes.OrderByDescending(u => u.ID).FirstOrDefault();


                    Imagenes imagen = new Imagenes();
                    imagen.Imagen =image;
                    imagen.NombreImagen = name;
                    //imagen.Deleted = false;
                    
                    if (last == null)
                    {
                        imagen.ID = 1;
                    }
                    else
                    {
                        imagen.ID = last.ID + 1;
                    }
                    Contexto.AddToImagenes(imagen);
                    Contexto.SaveChanges();
                    Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, imagen);
                    return imagen.ID;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
    
    
}
