using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{

    public class ServicioDetalleIdioma
    {
        public ServicioDetalleIdioma(){}
        //numero de dia
        private int _Id;
        public int Id
        {
            get
            { return _Id; }
            set
            { _Id = value; }
        }

        private int _IdServicio;
        public int IdServicio
        {
            get
            { return _IdServicio; }
            set
            { _IdServicio = value; }
        }

        private string _NombreES;
        public string NombreES
        {
            get
            { return _NombreES; }
            set
            { _NombreES = value; }
        }

        private string _DescripcionEs;
        public string DescripcionEs
        {
            get
            { return _DescripcionEs; }
            set
            { _DescripcionEs = value; }
        }

        private string _NombreEN;
        public string NombreEN
        {
            get
            { return _NombreEN; }
            set
            { _NombreEN = value; }
        }

        private string _DescripcionPT;
        public string DescripcionPT
        {
            get
            { return _DescripcionPT; }
            set
            { _DescripcionPT = value; }
        }

        private string _NombreIT;
        public string NombreIT
        {
            get
            { return _NombreIT; }
            set
            { _NombreIT = value; }
        }

        private string _DescripcionIT;
        public string DescripcionIT
        {
            get
            { return _DescripcionIT; }
            set
            { _DescripcionIT = value; }
        }

        private string _NombrePT;
        public string NombrePT
        {
            get
            { return _NombrePT; }
            set
            { _NombrePT = value; }
        }

        private string _DescripcionEN;
        public string DescripcionEN
        {
            get
            { return _DescripcionEN; }
            set
            { _DescripcionEN = value; }
        }
        //public int Id
        //{
        //    get
        //    { return _Id; }
        //    set
        //    { _Id = value; }
        //}

        private int _NumDia;
        public int NumDia
        {
            get
            { return _NumDia; }
            set
            { _NumDia = value; }
        }

    }

}