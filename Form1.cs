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
            int lenght = Nombre.Length;
            int Edad = int.Parse(tbEdad.Text);
            double Nota = int.Parse(tbNota.Text);
            char Genero = char.Parse(tbGenero.Text);
            Estudiante estudiante = new Estudiante(Nombre, Edad, Nota, Genero);
            FileStream mArchivoEscritor = new FileStream("datos.dat", FileMode.OpenOrCreate, FileAccess.Write);
            
            using (BinaryWriter escritor = new BinaryWriter(mArchivoEscritor))
            {
                escritor.Write(lenght);
                escritor.Write(estudiante.Nombre.ToCharArray());
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
                estudiantes.Clear();
                while (mArchivoLector.Position != mArchivoLector.Length)
                {
                    int longitud = lector.ReadInt32();
                    char[] nom = lector.ReadChars(longitud);
                    string Nombre = new string(nom);
                    int Edad = lector.ReadInt32();
                    double Nota = lector.ReadDouble();
                    char Genero= lector.ReadChar();
                    Estudiante estudiante = new Estudiante(Nombre, Edad, Nota, Genero);
                    estudiantes.Add(estudiante);
                }
            }

            dgvSalida.DataSource = estudiantes;
            
        }
    }
}
