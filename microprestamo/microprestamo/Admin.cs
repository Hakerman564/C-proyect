using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    internal class Admin : Usuario
    {


        public Admin() 
        {
            operador = true;
        }

        public void registrar(List<Estudiante> usuarios)
        {
            string nombre ="" , clave = "";
            bool becado, op,n = true;
            Console.WriteLine("Registro De Estudiantes");

            while (n)
            {
                Console.WriteLine("Nombre: ");
                nombre = Console.ReadLine();

                foreach (var item in usuarios)
                {
                    if (item.nombre != nombre) { n = false; }
                    else { Console.WriteLine("ese nombre Ya existe");}
                }
            }
           
            Console.WriteLine("Clave: ");
            clave = Console.ReadLine();
            Console.WriteLine("Tiene Beca Escribe(true,false):");
            becado = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Tendra derechos de administrador  Escribe(true,false):");
            op = Convert.ToBoolean(Console.ReadLine());

            Estudiante Estudio = new Estudiante(becado, nombre, clave , op);
            usuarios.Add(Estudio);
        }

        public void Borrar(List<Estudiante> usuarios)
        {
            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();

            foreach (var item in usuarios)
            {
                if (item.nombre == nombre) 
                {
                    usuarios.Remove(item);
                    Console.WriteLine("Elemento eliminado");
                    return;
                }
  
            }
            Console.WriteLine("No Existe el usuario");
        }

        public void consultar(List<Estudiante> usuarios)
        {
            Console.WriteLine("Consulta");
            Console.WriteLine("Inserte nombre:");
            string nombre = Console.ReadLine();

            Estudiante alumno = usuarios.FirstOrDefault(u => u.nombre == nombre);

            if (alumno != null)
            {
                alumno.funcion.celda(alumno);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }

        }

        public void Resumir(List<Estudiante> usuarios) 
        {
            funcion.ImpresionResumen(usuarios);
        }
    }
}
