using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//using MySql.Data.MySqlClient;

namespace Pract03_Hashtable
{

    class Alumno
    {
        int codigo;
        string nombre;

        public Alumno()
        {
            codigo = 0;
            nombre = "";
        }

        public void asignarNombre(string n)
        {
            nombre = n;
        }

        public void asignarCodigo(int c)
        {
            codigo = c;
        }

        public string obtenerNombre()
        {
            return nombre;
        }

        public int obtenerCodigo()
        {
            return codigo;
        }
    }


    public class AppAlumnos
    {
        private static Hashtable tabla;

        private static void AgregarAlumno()
        {
            Alumno a = new Alumno();
            try
            {
                Console.Write("Codigo de alumno: ");
                a.asignarCodigo(int.Parse(Console.ReadLine()));
                Console.Write("Nombre completo de alumno: ");
                a.asignarNombre(Console.ReadLine());
                int clave = a.obtenerCodigo();
                tabla.Add(clave, a);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error: " + e.Message + "\nSe esperaba un entero.");
            }
            
        }

        private static void EliminarAlumno(int clave)
        {
            if(tabla.ContainsKey(clave))
            {
                tabla.Remove(clave);
                Console.WriteLine("Alumno con código {0:0000} eliminado", clave);
            }
            else
            {
                Console.WriteLine("No se encontró el alumno con código: {0:0000}", clave);
            }
        }

        private static void MostrarHashtable()
        {
            Console.WriteLine("\nRelación de Alumnos:\n{0,-12}{1,-12}", "Clave:", "Alumno:");
            foreach (object clave in tabla.Keys)
                Console.WriteLine("{0,-12}{1,-12}", clave, ((Alumno)(tabla[clave])).obtenerNombre());
            Console.WriteLine("\ntamaño: {0}", tabla.Count);
        }

        /*public static MySqlConnection conexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=Alumnos; Uid=root; pwd=bi$onB0t;");
            conectar.Open();
            return conectar;
        }*/

        public static void Main(string[] args)
        {
            char opcion;
            tabla = new Hashtable();

            //conexion();
            do
            {
                Console.Clear();
                Console.WriteLine("A-D-M-I-N-I-S-T-R-A-C-I-O-N - D-E - A-L-U-M-N-O-S\n\t\tasinusware\u00a9 2015");
                Console.Write("\n1. Agregar\n2. Eliminar\n3. Ver\n4. Salir\nOpcion: ");
                opcion = (char)Console.ReadLine().ElementAt(0);

                switch(opcion)
                {
                    case '1':
                        Console.WriteLine("\nAgregar alumno");
                        AgregarAlumno();
                        break;
                    case '2':
                        Console.WriteLine("\nEliminar alumno");
                        Console.WriteLine("\nCodigo de alumno a eliminar: ");
                        try
                        {
                            EliminarAlumno(int.Parse(Console.ReadLine()));
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("Error: " + e.Message + "\nSe esperaba un entero.");
                        }
                        break;
                    case '3':
                        Console.WriteLine("Ver alumnos");
                        MostrarHashtable();
                        break;
                    case '4':
                        Console.WriteLine("\nSalida del Sistema");
                        break;
                    default:
                        Console.WriteLine("\nOpcion no valida");
                        break;
                }
                Console.WriteLine("\nPresiona una tecla para continuar");
                Console.ReadLine();
            }
            while(opcion != '4');
        }
    }
}
