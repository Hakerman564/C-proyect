using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    internal class Estudiante : Usuario
    {
        public bool becado { get; set; }

        public Prestamo prestamo = new Prestamo();

       
        public Estudiante(bool zecado, string zombre, string zlave, bool op) 
        {
            this.becado = false;

            this.operador = op;
            this.becado = zecado;
            this.nombre = zombre;
            this.clave = zlave;
        }

        public void Crear(decimal monto)
        {
            if ((monto <= 20000) && (monto >= 4000) && !prestamo.cuota.activo && becado)
            {
                prestamo.fecha = DateTime.Now;
                DateTime calendaio = prestamo.fecha;
                prestamo.cuota.monto = monto;
                prestamo.cuota.fecha1 = calendaio.AddMonths(1);
                prestamo.cuota.fecha2 = calendaio.AddMonths(2);
                prestamo.cuota.fecha3 = calendaio.AddMonths(3);
                prestamo.cuota.fecha4 = calendaio.AddMonths(4);

                prestamo.cuota.pago = monto / 4;
                prestamo.cuota.pago1 = false;
                prestamo.cuota.pago2 = false;
                prestamo.cuota.pago3 = false;
                prestamo.cuota.pago4 = false;
                prestamo.cuota.activo = true;
            }
            else {
                Console.WriteLine("Prestamo Denegado Por:");
                if (prestamo.cuota.activo) { Console.WriteLine("Hay un prestamos vigente");}
                if (monto >= 20000) { Console.WriteLine("El Monto ingresado es demasiado grande"); }
                if (monto <= 4000 ) { Console.WriteLine("el monto ingresado es muy poco"); }
                if (!becado) { Console.WriteLine("Esta Servicio solo es para estudiantes becados"); }
            }

        }

        public void pagar()
        {
            if (!prestamo.cuota.pago1)
            {
                prestamo.cuota.pago1 = true;
                Console.WriteLine("Primer pago Completado");
            }
            else if (!prestamo.cuota.pago2) 
            {
                prestamo.cuota.pago2 = true;
                Console.WriteLine("Segundo pago completado");
            }
            else if (!prestamo.cuota.pago3)
            {
                prestamo.cuota.pago3 = true;
                Console.WriteLine("Tercer pago completado");
            }
            else if (!prestamo.cuota.pago4)
            {
                prestamo.cuota.pago4 = true;
                Console.WriteLine("Ultimo pago completado pago completado");
                Console.WriteLine("*Prestamos completado*");
                prestamo.cuota.pago1 = false;
                prestamo.cuota.pago2 = false;
                prestamo.cuota.pago3 = false;
                prestamo.cuota.pago4 = false;
                prestamo.cuota.activo = false;
                prestamo.cuota.monto = 0;
            }
        }
        
        public void consultar()
        {
            if(prestamo.cuota.activo)
            {
                funcion.celda(this);
            }
            else
            {
                Console.WriteLine("*No Existe prestamos vijentes*");
            }
        }
    }
}
