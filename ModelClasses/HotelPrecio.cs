using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{

    public class HotelPrecio
    {
        private int _Id = new int();
        private Hotel _Hotel = new Hotel();
        private decimal _preciopeso = 0;
        private decimal _preciodolar = 0;
        private DateTime _fdesde;
        private DateTime _fhasta;
        private string _name;
        private string _nameH;
        private string _fdesdeS;
        private string _fhastaS;
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
        public string Name
        {
            get
            { return _name; }
            set
            { _name = value; }
        }
        public string NameHabitacion
        {
            get
            { return _nameH; }
            set
            { _nameH = value; }
        }
        public Hotel Hotel
        {
            get
            { return _Hotel; }
            set
            { _Hotel = value; }
        }
        public decimal PrecioPeso
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
        public DateTime FDesde
        {
            get
            { return _fdesde; }
            set
            { _fdesde = value; }
        }
        public DateTime FHasta
        {
            get
            { return _fhasta; }
            set
            { _fhasta = value; }
        }
        public string FDesdeString
        {
            get
            { return _fdesdeS; }
            set
            { _fdesdeS = value; }
        }
        public string FHastaString
        {
            get
            { return _fhastaS; }
            set
            { _fhastaS = value; }
        }
        private string _ciudad;
        public string Ciudad
        {
            get
            { return _ciudad; }
            set
            { _ciudad = value; }
        }
    }
}
