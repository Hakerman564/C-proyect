using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    internal class funciones
    {

        public void celda(Estudiante bio) 
        {
            Console.WriteLine("Estado de pago");


            // Encabezados de las columnas personalizados
            string encabezadoColumna1 = "#";
            string encabezadoColumna2 = "Fecha";
            string encabezadoColumna3 = "Monto";
            string encabezadoColumna4 = "Estado";

            // Tamaño de las columnas
            int columna1Width = 10;
            int columna2Width = 10;
            int columna3Width = 10;
            int columna4Width = 10;

            // Imprimir encabezados
            Console.WriteLine($"{encabezadoColumna1.PadRight(columna1Width)} | {encabezadoColumna2.PadRight(columna2Width)} | {encabezadoColumna3.PadRight(columna3Width)} | {encabezadoColumna4.PadRight(columna4Width)}");

            // Imprimir separadores
            string separador = new string('-', columna1Width + 3 + columna2Width + 3 + columna3Width + 3 + columna4Width);
            Console.WriteLine(separador);


            string dato1 = "numero";
            string dato2 = "fecha";
            string dato3 = "dinero";
            string dato4 = "estado";
            decimal dinero = bio.prestamo.cuota.monto / 4;


            if (bio.prestamo.cuota.activo) 
            {
                for (int i = 0; i < 4; i++)
                {
                    dato1 = Convert.ToString(i + 1);
                    dato3 = Convert.ToString(dinero);

                    if (i == 0)
                    {
                        dato2 = bio.prestamo.cuota.fecha1.ToString("dd/MM/yyyy");
                        dato4 = Convert.ToString(bio.prestamo.cuota.pago1);
                    }

                    if (i == 1)
                    {
                        dato2 = bio.prestamo.cuota.fecha2.ToString("dd/MM/yyyy");
                        dato4 = Convert.ToString(bio.prestamo.cuota.pago2);
                    }

                    if (i == 2)
                    {
                        dato2 = bio.prestamo.cuota.fecha3.ToString("dd/MM/yyyy");
                        dato4 = Convert.ToString(bio.prestamo.cuota.pago3);
                    }

                    if (i == 3)
                    {
                        dato2 = bio.prestamo.cuota.fecha4.ToString("dd/MM/yyyy");
                        dato4 = Convert.ToString(bio.prestamo.cuota.pago4);
                    }

                    if (dato4 == "True") { dato4 = "Pagado"; }
                    if (dato4 == "False") { dato4 = "Faltante"; }

                    // Imprimir datos en celdas y columnas
                    Console.WriteLine($"{dato1.PadRight(columna1Width)} | {dato2.PadRight(columna2Width)} | {dato3.PadRight(columna3Width)} | {dato4.PadRight(columna4Width)}");
                }
            }
            else
            {
                Console.WriteLine("Sin Prestamo");
            }

           
            Console.WriteLine(separador);


            int r = Convert.ToInt16(bio.prestamo.cuota.pago1) + Convert.ToInt16(bio.prestamo.cuota.pago2) + Convert.ToInt16(bio.prestamo.cuota.pago3) + Convert.ToInt16(bio.prestamo.cuota.pago4);

            Console.WriteLine("Total Del prestamos: ");
            Console.WriteLine(bio.prestamo.cuota.monto);
            Console.WriteLine("Pagado: ");
            Console.WriteLine(dinero * r);
            Console.WriteLine("Faltante: ");
            Console.WriteLine(bio.prestamo.cuota.monto - (dinero * r));
        }

        public void ImpresionResumen(List<Estudiante> usuarios)
        {
            Console.WriteLine("ReSumen De alumnos");


            // Encabezados de las columnas personalizados
            string encabezadoColumna1 = "#";
            string encabezadoColumna2 = "Alumno";
            string encabezadoColumna3 = "Prestamo";
            string encabezadoColumna4 = "Pagado";
            string encabezadoColumna5 = "Fecha";

            // Tamaño de las columnas
            int columna1Width = 10;
            int columna2Width = 10;
            int columna3Width = 10;
            int columna4Width = 10;
            int columna5Width = 10;

            // Imprimir encabezados
            Console.WriteLine($"{encabezadoColumna1.PadRight(columna1Width)} | {encabezadoColumna2.PadRight(columna2Width)} | {encabezadoColumna3.PadRight(columna3Width)} | {encabezadoColumna4.PadRight(columna4Width)} | {encabezadoColumna5.PadRight(columna5Width)}");

            // Imprimir separadores
            string separador = new string('-', columna1Width + 3 + columna2Width + 3 + columna3Width + 3 + columna4Width + 3 + columna5Width);
            Console.WriteLine(separador);

            decimal pagado,pago = 0;
            string dato1 = "numero";
            string dato2 = "Alumno";
            string dato3 = "Prestamo";
            string dato4 = "Pagodo";
            string dato5 = "fecha";
            decimal dinero = 0;
            int i = 0;
            int r=0;
            foreach (var item in usuarios)
            {
                i++;
                dato1 = Convert.ToString(i);
                dato2 = item.nombre;
                dato3 = Convert.ToString(item.prestamo.cuota.monto);
                 r = Convert.ToInt16(item.prestamo.cuota.pago1) + Convert.ToInt16(item.prestamo.cuota.pago2) + Convert.ToInt16(item.prestamo.cuota.pago3) + Convert.ToInt16(item.prestamo.cuota.pago4);
                dato4 = Convert.ToString(item.prestamo.cuota.pago*r);
                dato5 = Convert.ToString(item.prestamo.fecha.ToString("dd/MM/yyyy"));

                if (dato5 == "01/01/0001") { dato5 = "nunca"; }

                pago += item.prestamo.cuota.pago * r;
                dinero += item.prestamo.cuota.monto;
                // Imprimir datos en celdas y columnas
                Console.WriteLine($"{dato1.PadRight(columna1Width)} | {dato2.PadRight(columna2Width)} | {dato3.PadRight(columna3Width)} | {dato4.PadRight(columna4Width)}| {dato5.PadRight(columna5Width)}");
            }
         
            Console.WriteLine(separador);

            Console.WriteLine("Cantidad de Clientes: ");
            Console.WriteLine(i);
            Console.WriteLine("Total  Prestamo");
            Console.WriteLine(dinero);
            Console.WriteLine("Total  Pagado");
            Console.WriteLine(pago);
            Console.WriteLine("Deuda");
            Console.WriteLine(dinero - pago);
        }
    }
}
