using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Ciudad
/// </summary>

namespace ModelClasses
{

    public class Ciudad 
    {
        public Ciudad() { }

        

        private string _nombre = string.Empty;
        private int _Id = new int();
        private string _pais = string.Empty;
        private string _codigo = string.Empty;
        private string _codigoInterno = string.Empty;
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
        public string Pais
        {
            get
            { return _pais; }
            set
            { _pais = value; }
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
        public string CodigoInterno
        {
            get
            { return _codigoInterno; }
            set
            { _codigoInterno = value; }
        }





    }
}