using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    class program
    {
        static void Main(string[] args)
        {
            int salir = -1;
            List<Estudiante> Usuarios = new List<Estudiante>();
            Estudiante prueva = new Estudiante(true, "jose", "23d", false);
            Estudiante prueva1 = new Estudiante(true, "lucas", "23d", false);
            Estudiante prueva2 = new Estudiante(true, "pedro", "23d", false);

            string y;
            Admin administrador = new Admin();
            administrador.nombre = "admin";
            administrador.clave = "piso231";
            administrador.operador = true;

            Usuarios.Add(prueva);
            Usuarios.Add(prueva1);
            Usuarios.Add(prueva2);
            string username;
            string password;
            Estudiante usuarioEncontrado;



            // Crear un diccionario para almacenar usuarios y contraseñas
            //Dictionary<string, string> users = new Dictionary<string, string>
            // {
            //     { "admin", "password" },
            //     { "estudiante", "password" }
            // };

            // Solicitar al usuario que ingrese su nombre de usuario y contraseña
            while (true) {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔══════════════════════════════════╗");
                Console.WriteLine("║   Bienvenido a Micro-Prestamos   ║");
                Console.WriteLine("║      * Estudiantiles UCSD *      ║");
                Console.WriteLine("║            Inicie sesión         ║");
                Console.WriteLine("╚══════════════════════════════════╝");
                Console.ResetColor();

                Console.Write("Usuario:");
                username = Console.ReadLine();
            
                Console.Write("Contraseña:");
                password = Console.ReadLine();

            // Verificar si el usuario y la contraseña son válidos

            if (username == "admin")
            {
                if (password == administrador.clave)
                {
                    Console.WriteLine("\nInicio de sesión exitoso. Bienvenido, Administrador !");

                    while (salir != 0)
                    {
                        ShowAdminMenu(ref salir, administrador, Usuarios);
                    }

                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta");
                }

            }
            else
            {

                usuarioEncontrado = Usuarios.FirstOrDefault(u => u.nombre == username);

                if (usuarioEncontrado != null)
                {
                    if (usuarioEncontrado.clave == password)
                    {
                        while (salir != 0)
                        {
                            ShowStudentMenu(ref salir, usuarioEncontrado);
                            
                        }

                    }
                    else
                    {
                        Console.WriteLine("contraseña incorreta");
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }

            }

                Console.WriteLine("Salir del programa Escribe y|n");
                y = Console.ReadLine(); // Esperar a que el usuario presione Enter antes de salir
                if (y== "y")
                {
                    return;
                }
                Console.Clear();
                salir = -1;
        }

        }


        static void ShowAdminMenu(ref int salir, Admin admin, List<Estudiante> usuarios)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n╔══════════════════════════╗");
            Console.WriteLine("║  Menú del Administrador  ║");
            Console.WriteLine("╚══════════════════════════╝");
            Console.ResetColor();

            // Mostrar el menú para el usuario "Admin"
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Crear Estudiante.");
            Console.WriteLine("2. Borrar Estudiante.");
            Console.WriteLine("3. Consultar Prestamos.");
            Console.WriteLine("4. Resumen de prestamos.");
            Console.WriteLine("5. Salir.");

            // Leer la opción seleccionada por el usuario
            int option;
            bool isValidOption = int.TryParse(Console.ReadLine(), out option);

            if (isValidOption)
            {
                switch (option)
                {
                        case 1:
                        admin.registrar(usuarios);
                        break;
                    case 2:
                        admin.Borrar(usuarios);
                        break;
                    case 3:
                        admin.consultar(usuarios);
                        break;
                    case 4:
                        admin.Resumir(usuarios);
                        break;
                    case 5:
                        salir = 0;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Asegúrate de ingresar un número válido.");
            }
            Console.WriteLine("presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowStudentMenu(ref int salir, Estudiante alumno)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔════════════════════════╗");
            Console.WriteLine("║  Menú del Estudiante   ║");
            Console.WriteLine("╚════════════════════════╝");
            Console.ResetColor();

            // Mostrar el menú para el usuario "Estudiante"
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Tomar Prestamo");
            Console.WriteLine("2. Consultar Prestamo");
            Console.WriteLine("3. Pagar Prestamo");
            Console.WriteLine("4. Salir");

            // Leer la opción seleccionada por el usuario
            int option;
            bool isValidOption = int.TryParse(Console.ReadLine(), out option);

            if (isValidOption)
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Capital: ");
                        decimal monto = Convert.ToDecimal(Console.ReadLine());
                        alumno.Crear(monto);
                        break;
                    case 2:
                        alumno.consultar();
                        break;
                    case 3:
                        alumno.pagar();
                        break;

                    case 4:
                        salir = 0;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Asegúrate de ingresar un número válido.");
            }


            //Console.WriteLine(DateTime.Now);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}