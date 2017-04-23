using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{
   public class Programa
    {
       public Programa() { }

        private int _Id = new int();        
        private string _nombreTituloES = string.Empty;
        private string _nombreTituloEN = string.Empty;
        private string _nombreTituloIT = string.Empty;
        private string _nombreTituloPT = string.Empty;
        private DateTime _fdesde;
        private DateTime _fhasta;
        private DateTime _fvalidez;
        private decimal _preciopeso = 0;
        private decimal _preciodolar = 0;
        private decimal _margen = 0;
        private decimal _descuento = 0;
        private string _Idioma = string.Empty;
        private int _cantDias =0;
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
        public int CantDias
        {
            get
            { return _cantDias; }
            set
            { _cantDias = value; }
        }
        public string TituloPrograma
        {
            get
            { return _nombreTituloEN; }
            set
            { _nombreTituloEN = value; }
        }
        public string Idioma
        {
            get
            { return _Idioma; }
            set
            { _Idioma = value; }
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
        public DateTime FValidez
        {
            get
            { return _fvalidez; }
            set
            { _fvalidez = value; }
        }
        public decimal Preciopeso
        {
            get
            { return _preciopeso; }
            set
            { _preciopeso = value; }
        }
        public decimal PrecioDolar
        {
            get
            { return _preciodolar; }
            set
            { _preciodolar = value; }
        }
        public decimal Margen
        {
            get
            { return _margen; }
            set
            { _margen = value; }
        }

        public decimal Descuento
        {
            get
            { return _descuento; }
            set
            { _descuento = value; }
        }

        public List<ServicioPrograma> ServiciosList = new List<ServicioPrograma>();
    }

   public class ServicioPrograma
   {

       public ServicioPrograma() { }

       private int _Id = new int();
       private int _IdPrograma = new int();
       private DateTime _fecha;
       private DateTime _fechaOut;
       private int _IdServicio = new int();//Aereo o Transfer o servicio o Hotel       
       private string _tipo = string.Empty;
       private int _cantPasajeros = 0;
       private int _cantNoche = 0;
       private int _cantHabitaciones = 0;
       private string _tipoHabitacion = string.Empty;
       private decimal _precioUnitario = 0;
       private decimal _precioTotal = 0;
       private bool _delete = new bool();

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
       public int IdServicio
       {
           get
           { return _IdServicio; }
           set
           { _IdServicio = value; }
       }
       public DateTime Fecha
       {
           get
           { return _fecha; }
           set
           { _fecha = value; }
       }
       public DateTime FechaOut
       {
           get
           { return _fechaOut; }
           set
           { _fechaOut = value; }
       }       
       public int CantPasajeros
       {
           get
           { return _cantPasajeros; }
           set
           { _cantPasajeros = value; }
       }
       public string Tipo
       {
           get
           { return _tipo; }
           set
           { _tipo = value; }
       }
       public decimal PrecioUnitario
       {
           get
           { return _precioUnitario; }
           set
           { _precioUnitario = value; }
       }
       public decimal PrecioTotal
       {
           get
           { return _precioTotal; }
           set
           { _precioTotal = value; }
       }
       public int CantNoche
       {
           get
           { return _cantNoche; }
           set
           { _cantNoche = value; }
       }
       public int CantHabitaciones
       {
           get
           { return _cantHabitaciones; }
           set
           { _cantHabitaciones = value; }
       }
       public string TipoHabitacion
       {
           get
           { return _tipoHabitacion; }
           set
           { _tipoHabitacion = value; }
       }
       
   }

  


}
