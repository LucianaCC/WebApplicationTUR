using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{


    public class ServicioPrecio
    {
        //  [Id]

        private int _Id;
        public int Id
        {
            get
            { return _Id; }
            set
            { _Id = value; }
        }
        //,[IdOperador]
        private int _IdOperador;
        public int IdOperador
        {
            get
            { return _IdOperador; }
            set
            { _IdOperador = value; }
        }
        //,[FechaDesde]
        private DateTime _FechaDesde;
        public DateTime FechaDesde
        {
            get
            { return _FechaDesde; }
            set
            { _FechaDesde = value; }
        }
        //,[FechaHasta]
        private DateTime _FechaHasta;
        public DateTime FechaHasta
        {
            get
            { return _FechaHasta; }
            set
            { _FechaHasta = value; }
        }
        //,[Moneda]
        private string _Moneda;
        public string Moneda
        {
            get
            { return _Moneda; }
            set
            { _Moneda = value; }
        }
        //,[IdServicio]
        private int _IdServicio;
        public int IdServicio
        {
            get
            { return _IdServicio; }
            set
            { _IdServicio = value; }
        }
        //,[Privado]
        private string _tipoServicio;
        public string TipoServicio
        {
            get
            { return _tipoServicio; }
            set
            { _tipoServicio = value; }
        }
        //,[Regular]
        
        private decimal _Precio;
        public decimal Precio
        {
            get
            { return _Precio; }
            set
            { _Precio = value; }
        }
        //,[Type]
        private string _Type;
        public string Type
        {
            get
            { return _Type; }
            set
            { _Type = value; }
        }
        //,[Nombre para la grilla]
        private string _NameServicio;
        public string NombreServicio
        {
            get
            { return _NameServicio; }
            set
            { _NameServicio = value; }
        }

        //,[Nombre para la grilla]
        private string _CiudadServicio;
        public string CiudadServicio
        {
            get
            { return _CiudadServicio; }
            set
            { _CiudadServicio = value; }
        }

        //,[Nombre para la grilla]
        private string _ActividadServicio;
        public string ActividadServicio
        {
            get
            { return _ActividadServicio; }
            set
            { _ActividadServicio = value; }
        }

        //,[Nombre para la grilla]
        private string _OperadorServicio;
        public string OperadorServicio
        {
            get
            { return _OperadorServicio; }
            set
            { _OperadorServicio = value; }
        }

        //,[Nombre para la grilla]
        private string _FDesdeServicio;
        public string FdesdeServicio
        {
            get
            { return _FDesdeServicio; }
            set
            { _FDesdeServicio = value; }
        }
        //,[Nombre para la grilla]
        private string _FHastaServicio;
        public string FHastaServicio
        {
            get
            { return _FHastaServicio; }
            set
            { _FHastaServicio = value; }
        }

        //,[Nombre para la grilla]
        private string _MonedaServicio;
        public string MonedaServicio
        {
            get
            { return _MonedaServicio; }
            set
            { _MonedaServicio = value; }
        }

        private bool _delete = new bool();
        public bool Delete
        {
            get
            { return _delete; }
            set
            { _delete = value; }
        }

        private string _UnitarioGrupal = String.Empty;
        //G o U
        public string UnitarioGrupal
        {
            get
            { return _UnitarioGrupal; }
            set
            { _UnitarioGrupal = value; }
        }

        
    
    }

}