using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasses
{
    public class Imagen
    {
        public Imagen()
        {}
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Image { get; set; }
    }
}
