using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{
   public class ProgramaDetalle
    {
       public ProgramaDetalle() { }

        private int _Id = new int();
        private int _IdPrograma = 0;
        private int _IdHotel = 0;
        private int _IdServicio = 0;
        private int _noches = 0;
        private int _cantPasajeros = 0;
        private DateTime _fdesde;
        private DateTime _fhasta;
        private decimal _precioUni = 0;
        private decimal _precioTotal = 0;
        private string _tipoAereo = string.Empty;
        private string _tipoServicio = string.Empty;
        private string _tipoHabitacion = string.Empty;
        private Hotel _hotel = new Hotel() ;
        private Servicio _servicio = new Servicio();
        private bool _delete = new bool();
        public bool Delete
        {
            get
            { return _delete; }
            set
            { _delete = value; }
        }


        public int Id
        {
            get
            { return _Id; }
            set
            { _Id = value; }
        }
        public int IdPrograma
        {
            get
            { return _IdPrograma; }
            set
            { _IdPrograma = value; }
        }
        public int IdHotel
        {
            get
            { return _IdHotel; }
            set
            { _IdHotel = value; }
        }
        public int IdServicio
        {
            get
            { return _IdServicio; }
            set
            { _IdServicio = value; }
        }
        public Hotel Hotel
        {
            get
            { return _hotel; }
            set
            { _hotel = value; }
        }
        public Servicio Servicio
        {
            get
            { return _servicio; }
            set
            { _servicio = value; }
        }
        public int Noches
        {
            get
            { return _noches; }
            set
            { _noches = value; }
        }
        public int CantPasajeros
        {
            get
            { return _cantPasajeros; }
            set
            { _cantPasajeros = value; }
        }
        public string TipoAereo
        {
            get
            { return _tipoAereo; }
            set
            { _tipoAereo = value; }
        }
        public string TipoServicio
        {
            get
            { return _tipoServicio; }
            set
            { _tipoServicio = value; }
        }
        public string TipoHabitacion
        {
            get
            { return _tipoHabitacion; }
            set
            { _tipoHabitacion = value; }
        }    
        public DateTime FHasta
        {
            get
            { return _fhasta; }
            set
            { _fhasta = value; }
        }
        public DateTime FDesde
        {
            get
            { return _fdesde; }
            set
            { _fdesde = value; }
        }        
        public decimal PrecioUni
        {
            get
            { return _precioUni; }
            set
            { _precioUni = value; }
        }
        public decimal PrecioTotal
        {
            get
            { return _precioTotal; }
            set
            { _precioTotal = value; }
        }
       
    }
}
