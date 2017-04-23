using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelClasses
{


    public class Operador
    {
        public Operador() { }

        private string _nombre = string.Empty;
        private int _Id = new int();
        private Ciudad _ciudad = new Ciudad();
        private string _direccion = string.Empty;
        private string _telefono = string.Empty;
        private string _contacto = string.Empty;
        private string _email = string.Empty;
        private string _codigoP = string.Empty;
        private string _Fax = string.Empty;
        private string _bconombre = string.Empty;
        private string _numcuenta = string.Empty;
        private string _cuit = string.Empty;
        private string _cbu = string.Empty;
        private string _bcoiDirecc = string.Empty;
        private bool _delete = new bool();
        public bool Delete
        {
            get
            { return _delete; }
            set
            { _delete = value; }
        }

        private string _CiudadNombre = "";
        public string CiudadNombre
        {
            get
            { return _CiudadNombre; }
            set
            { _CiudadNombre = value; }
        }
        public int Id
        {
            get
            { return _Id; }
            set
            { _Id = value; }
        }
        public Ciudad Ciudad
        {
            get
            { return _ciudad; }
            set
            { _ciudad = value; }
        }
        public string CodPostal
        {
            get
            { return _codigoP; }
            set
            { _codigoP = value; }
        }
        public string Nombre
        {
            get
            { return _nombre; }
            set
            { _nombre = value; }
        }
        public string Direcion
        {
            get
            { return _direccion; }
            set
            { _direccion = value; }
        }
        public string Telefono
        {
            get
            { return _telefono; }
            set
            { _telefono = value; }
        }
        public string Contacto
        {
            get
            { return _contacto; }
            set
            { _contacto = value; }
        }
        public string Email
        {
            get
            { return _email; }
            set
            { _email = value; }
        }
        public string Fax
        {
            get
            { return _Fax; }
            set
            { _Fax = value; }
        }
        public string NombreBco
        {
            get
            { return _bconombre; }
            set
            { _bconombre = value; }
        }
        public string NumeroCuenta
        {
            get
            { return _numcuenta; }
            set
            { _numcuenta = value; }
        }
        public string Cuit
        {
            get
            { return _cuit; }
            set
            { _cuit = value; }
        }
        public string CBU
        {
            get
            { return _cbu; }
            set
            { _cbu = value; }
        }
        public string DireccionBco
        {
            get
            { return _bcoiDirecc; }
            set
            { _bcoiDirecc = value; }
        }

        private string _pais = string.Empty;
        public string Pais
        {
            get
            { return _pais; }
            set
            { _pais = value; }
        }
    }

}