using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivoVisual.model
{
    internal class Estudiante
    {
        public int Long {  get; set; }
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public double Nota { get; set; }
        public char Genero {  get; set; }

       public Estudiante(int @long, string nombre, int edad, double nota, char genero)
        {
            Long = @long;
            Nombre = nombre;
            Edad = edad;
            Nota = nota;
            Genero = genero;
        }
    }
}
