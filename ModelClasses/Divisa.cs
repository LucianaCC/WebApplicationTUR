using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelClasses
{


    public class Divisa
    {
        public Divisa() { }


        private int _Id = new int();
        private string _nombre = string.Empty;
        private decimal _cambio;
        private string _codigo = string.Empty;
        private string _simbolo = string.Empty;
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

        public decimal Cambio
        {
            get
            { return _cambio; }
            set
            { _cambio = value; }
        }

        public string Codigo
        {
            get
            { return _codigo; }
            set
            { _codigo = value; }
        }


        public string Nombre
        {
            get
            { return _nombre; }
            set
            { _nombre = value; }
        }

        public string Simbolo
        {
            get
            { return _simbolo; }
            set
            { _simbolo = value; }
        }
    }

}