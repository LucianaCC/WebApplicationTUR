using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{

    public class Servicio
    {

        public Servicio() { }
        private int _Id;
        public int Id
        {
            get
            { return _Id; }
            set
            { _Id = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get
            { return _Nombre; }
            set
            { _Nombre = value; }
        }

        private string _DiasCant;
        public string DiasCant
        {
            get
            { return _DiasCant; }
            set
            { _DiasCant = value; }
        }

        private string _Actividad;
        public string Actividad
        {
            get
            { return _Actividad; }
            set
            { _Actividad = value; }
        }
                
        private string _TipoTranfer;
        public string TipoTranfer
        {
            get
            { return _TipoTranfer; }
            set
            { _TipoTranfer = value; }
        }

        private Operador _operador;
        public Operador Operador
        {
            get
            { return _operador; }
            set
            { _operador = value; }
        }

        private Ciudad _ciudadOperador;
        public Ciudad CiudadOperador
        {
            get
            { return _ciudadOperador; }
            set
            { _ciudadOperador = value; }
        }

        private Ciudad _ciudadO;
        public Ciudad CiudadO
        {
            get
            { return _ciudadO; }
            set
            { _ciudadO = value; }
        }

        private Ciudad _ciudadD;
        public Ciudad CiudadD
        {
            get
            { return _ciudadD; }
            set
            { _ciudadD = value; }
        }

        private string _HoraSalida;
        public string HoraSalida
        {
            get
            { return _HoraSalida; }
            set
            { _HoraSalida = value; }
        }

        private string _HoraLlegada;
        public string HoraLlegada
        {
            get
            { return _HoraLlegada; }
            set
            { _HoraLlegada = value; }
        }

        private List<ServicioDetalleIdioma>_detalleIdiomas;
        public List<ServicioDetalleIdioma> DetalleIdiomas
        {
            get
            { return _detalleIdiomas; }
            set
            { _detalleIdiomas = value; }
        }

        private string _Ciudad;
        public string Ciudad
        {
            get
            { return _Ciudad; }
            set
            { _Ciudad = value; }
        }

        private string _NombreOperador;
        public string NombreOperador
        {
            get
            { return _NombreOperador; }
            set
            { _NombreOperador = value; }
        }

        private string _Obs;
        public string ObservacionServicio
        {
            get
            { return _Obs; }
            set
            { _Obs = value; }
        }

        private bool _delete = new bool();
        public bool Delete
        {
            get
            { return _delete; }
            set
            { _delete = value; }
        }
        //Imagenes
        private int _IdImagen;
        public int IdImagen
        {
            get
            { return _IdImagen; }
            set
            { _IdImagen = value; }
        }
        private string _ImgUrl;
        public string ImgUrl
        {
            get
            { return _ImgUrl; }
            set
            { _ImgUrl = value; }
        }
    }

}