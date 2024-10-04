using ArchivoVisual.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivoVisual
{
    public partial class Form1 : Form
    {
        List<Estudiante> estudiantes = new List<Estudiante>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btmIngresar_Click(object sender, EventArgs e)
        {
            
            string Nombre = tbNombre.Text;
            int Long = Nombre.Length;
            int Edad = int.Parse(tbEdad.Text);
            double Nota = int.Parse(tbNota.Text);
            char Genero = char.Parse(tbGenero.Text);
            Estudiante estudiante = new Estudiante(Long, Nombre, Edad, Nota, Genero);
            FileStream mArchivoEscritor = new FileStream("datos.dat", FileMode.OpenOrCreate, FileAccess.Write);
            using (BinaryWriter escritor = new BinaryWriter(mArchivoEscritor))
            {
                escritor.Write(estudiante.Long);
                escritor.Write(estudiante.Nombre);
                escritor.Write(estudiante.Edad);
                escritor.Write(estudiante.Nota);
                escritor.Write(estudiante.Genero);
            }
        }

        private void btmMostrar_Click(object sender, EventArgs e)
        {
            FileStream mArchivoLector = new FileStream("datos.dat", FileMode.Open, FileAccess.Read);
            using (BinaryReader lector = new BinaryReader(mArchivoLector))
            {
                
                while (mArchivoLector.Position != mArchivoLector.Length)
                {

                    int lenght = lector.ReadInt32();
                    char[] nombrearreglo= lector.ReadChars(lenght);
                    string Nombre= new string(nombrearreglo);
                    int Edad = lector.ReadInt32();
                    double Nota = lector.ReadInt32();
                    char Genero= lector.ReadChar();
                    Estudiante estudiante = new Estudiante(lenght, Nombre, Edad, Nota, Genero);
                    estudiantes.Add(estudiante);
                }
            }

            dgvSalida.DataSource = estudiantes;
        }
    }
}
