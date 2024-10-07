using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivoVisual.model
{
    internal class Estudiante
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public double Nota { get; set; }
        public char Genero {  get; set; }

       public Estudiante(string nombre, int edad, double nota, char genero)
        {
           
            Nombre = nombre;
            Edad = edad;
            Nota = nota;
            Genero = genero;
        }
    }
}
