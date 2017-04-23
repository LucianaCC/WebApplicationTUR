using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{
   public class Cliente
    {
       private int _Id;
       public int Id
       {
           get
           { return _Id; }
           set
           { _Id = value; }
       }
       private bool _delete;
       public bool Delete
       {
           get
           { return _delete; }
           set
           { _delete = value; }
       }

       private string _apellido;
       public string Apellido
       {
           get
           { return _apellido; }
           set
           { _apellido = value; }
       }

       private string _nombre;
       public string Nombre
       {
           get
           { return _nombre; }
           set
           { _nombre = value; }
       }

       private string _passport;
       public string Pasaporte
       {
           get
           { return _passport; }
           set
           { _passport = value; }
       }

       private string _lenguaje;
       public string Lenguaje
       {
           get
           { return _lenguaje; }
           set
           { _lenguaje = value; }
       }

       private string _direecion;
       public string Direecion
       {
           get
           { return _direecion; }
           set
           { _direecion = value; }
       }

       private string _telefono;
       public string Telefono
       {
           get
           { return _telefono; }
           set
           { _telefono = value; }
       }
       
       private string _email1;
       public string Email1
       {
           get
           { return _email1; }
           set
           { _email1 = value; }
       }

       private string _email2;
       public string Email2
       {
           get
           { return _email2; }
           set
           { _email2 = value; }
       }

       private string _contacto;
       public string Contacto
       {
           get
           { return _contacto; }
           set
           { _contacto = value; }
       }
      
       private string _ticketAereo;
       public string TicketAereo
       {
           get
           { return _ticketAereo; }
           set
           { _ticketAereo = value; }
       }

       private string _observaciones;
       public string Observaciones
       {
           get
           { return _observaciones; }
           set
           { _observaciones = value; }
       }

       private string _PAX;//CantidaddePaksajeros
       public string PAX
       {
           get
           { return _PAX; }
           set
           { _PAX = value; }
       }

       private string _IDPrograma;
       public string IDPrograma
       {
           get
           { return _IDPrograma; }
           set
           { _IDPrograma = value; }
       }

       private DateTime _fArribo;
       public DateTime FArribo
       {
           get
           { return _fArribo; }
           set
           { _fArribo = value; }
       }

       private DateTime _fRegreso;
       public DateTime FRegreso
       {
           get
           { return _fRegreso; }
           set
           { _fRegreso = value; }
       }
      
       private Ciudad _ciudad;
       public Ciudad Ciudad
       {
           get
           { return _ciudad; }
           set
           { _ciudad = value; }
       }

       private VueloInternacional _vuelosNacionales;
       public VueloInternacional VuelosNacionales
       {
           get
           { return _vuelosNacionales; }
           set
           { _vuelosNacionales = value; }
       }

       private List<pasajeros> _pasajeros;
       public List<pasajeros> Pasajeros
       {
           get
           { return _pasajeros; }
           set
           { _pasajeros = value; }
       }    
       
       
    }

   public class VueloInternacional {
       
       private int _IdCliente;
       public int IdCliente
       {
           get
           { return _IdCliente; }
           set
           { _IdCliente = value; }
       }
       private int _Id;
       public int Id
       {
           get
           { return _Id; }
           set
           { _Id = value; }
       }
       //VuelosInternacionales
       private string _rutaAereaIda;
       public string RutaAereaIda
       {
           get
           { return _rutaAereaIda; }
           set
           { _rutaAereaIda = value; }
       }

       private string _nroVueloIda;
       public string NroVueloIda
       {
           get
           { return _nroVueloIda; }
           set
           { _nroVueloIda = value; }
       }

       private string _companiaAereaIda;
       public string CompaniaAereaIda
       {
           get
           { return _companiaAereaIda; }
           set
           { _companiaAereaIda = value; }
       }

       private DateTime _fyhSalidaIda;
       public DateTime FyHSalidaIda
       {
           get
           { return _fyhSalidaIda; }
           set
           { _fyhSalidaIda = value; }
       }

       private DateTime _fyhLlegadaIda;
       public DateTime FyHLlegadaIda
       {
           get
           { return _fyhLlegadaIda; }
           set
           { _fyhLlegadaIda = value; }
       }

       private string _rutaAereaReg;
       public string RutaAereaReg
       {
           get
           { return _rutaAereaReg; }
           set
           { _rutaAereaReg = value; }
       }

       private string _nroVueloReg;
       public string NroVueloReg
       {
           get
           { return _nroVueloReg; }
           set
           { _nroVueloReg = value; }
       }

       private string _companiaAereaReg;
       public string CompaniaAereaReg
       {
           get
           { return _companiaAereaReg; }
           set
           { _companiaAereaReg = value; }
       }

       private DateTime _fyhSalidaReg;
       public DateTime FyHSalidaReg
       {
           get
           { return _fyhSalidaReg; }
           set
           { _fyhSalidaReg = value; }
       }

       private DateTime _fyhLlegadaReg;
       public DateTime FyHLlegadaReg
       {
           get
           { return _fyhLlegadaReg; }
           set
           { _fyhLlegadaReg = value; }
       }
   
   
   }

   public class pasajeros {

       private int _IdCliente;
       public int IdCliente
       {
           get
           { return _IdCliente; }
           set
           { _IdCliente = value; }
       }
       private int _Id;
       public int Id
       {
           get
           { return _Id; }
           set
           { _Id = value; }
       }
       
       private string _apellidoYnombre;
       public string ApellidoyNombre
       {
           get
           { return _apellidoYnombre; }
           set
           { _apellidoYnombre = value; }
       }

       private DateTime _fNacimiento;
       public DateTime FNacimiento
       {
           get
           { return _fNacimiento; }
           set
           { _fNacimiento = value; }
       }

       private string _telefono;
       public string Telefono
       {
           get
           { return _telefono; }
           set
           { _telefono = value; }
       }
       private string _telefonodeviaje;
       public string TelefonoDeViaje
       {
           get
           { return _telefonodeviaje; }
           set
           { _telefonodeviaje = value; }
       }
       private string _nacionalidad;
       public string Nacionalidad
       {
           get
           { return _nacionalidad; }
           set
           { _nacionalidad = value; }
       }

       private string _email;
       public string Email
       {
           get
           { return _email; }
           set
           { _email = value; }
       }
       private string _passportNro;
       public string PasaporteNro
       {
           get
           { return _passportNro; }
           set
           { _passportNro = value; }
       }

       private string _lugarEmision;
       public string LugarEmision
       {
           get
           { return _lugarEmision; }
           set
           { _lugarEmision = value; }
       }

       

       private DateTime _fEmisionPasaporte;
       public DateTime FEmisionPasaporte
       {
           get
           { return _fEmisionPasaporte; }
           set
           { _fEmisionPasaporte = value; }
       }
       private DateTime _fValidezPasaporte;
       public DateTime FValidezPasaporte
       {
           get
           { return _fValidezPasaporte; }
           set
           { _fValidezPasaporte = value; }
       }

   
   
   }
}
