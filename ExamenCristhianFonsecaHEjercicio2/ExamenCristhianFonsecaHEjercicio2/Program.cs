using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCristhianFonsecaHEjercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaración de variables
            int numFactura, cantidad;
            string nombreComprador, nombreLocalidad, cedula;
            double precioEntrada, subtotal, cargosServicios, totalPagar;
            int cantSolNorteSur = 0, cantSombraEsteOeste = 0, cantPreferencial = 0, localidad = 0;
            double acumSolNorteSur = 0, acumSombraEsteOeste = 0, acumPreferencial = 0;
            bool continuar = true;

            // Ciclo para ingresar ventas hasta que no se deseen ingresar más datos
            while (continuar)
            {
                // Leer datos de la venta
                Console.Write("Ingrese número de factura: ");
                numFactura = int.Parse(Console.ReadLine());

                Console.Write("Ingrese cédula del comprador: ");
                cedula = Console.ReadLine();

                Console.Write("Ingrese nombre del comprador: ");
                nombreComprador = Console.ReadLine();

                while (localidad < 1 || localidad > 3)
                {
                    Console.Write("\nIngrese localidad:\n 1: Sol Norte/Sur\n 2: Sombra Este/Oeste\n 3: Preferencial\n-> ");
                    if (int.TryParse(Console.ReadLine(), out localidad) == false)
                    {
                        localidad = 0;
                    }
                    if(localidad < 1 || localidad > 3)
                    {
                        Console.WriteLine("\n-----------------------------------------------------");
                        Console.WriteLine("         Entrada inválida. Intente nuevamente.");
                        Console.WriteLine("-----------------------------------------------------\n");
                    }
                }

                Console.Write("\nIngrese cantidad de entradas (máximo 4): ");
                cantidad = int.Parse(Console.ReadLine());

                // Validar cantidad de entradas
                while (cantidad > 4)
                {
                    Console.WriteLine("\n-----------------------------------------------------");
                    Console.WriteLine("Error: un cliente no puede comprar más de 4 entradas.");
                    Console.WriteLine("-----------------------------------------------------\n");
                    Console.Write("Ingrese cantidad de entradas (MAXIMO 4): ");
                    cantidad = int.Parse(Console.ReadLine());
                }

                // Asignar precio y nombre de localidad según la opción elegida
                switch (localidad)
                {
                    case 1:
                        precioEntrada = 10500;
                        nombreLocalidad = "Sol Norte/Sur";
                        cantSolNorteSur += cantidad;
                        acumSolNorteSur += precioEntrada * cantidad;
                        break;
                    case 2:
                        precioEntrada = 20500;
                        nombreLocalidad = "Sombra Este/Oeste";
                        cantSombraEsteOeste += cantidad;
                        acumSombraEsteOeste += precioEntrada * cantidad;
                        break;
                    case 3:
                        precioEntrada = 25500;
                        nombreLocalidad = "Preferencial";
                        cantPreferencial += cantidad;
                        acumPreferencial += precioEntrada * cantidad;
                        break;
                    default:
                        Console.WriteLine("Error: opción de localidad inválida.");
                        continue;
                }

                // Calculo de subtotal, cargos por servicios y total a pagar
                subtotal = precioEntrada * cantidad;
                cargosServicios = cantidad * 1000;
                totalPagar = subtotal + cargosServicios;

                // información de la venta en pantalla
                Console.WriteLine("\n---------------------Venta Registrada----------------\n");
                Console.WriteLine(" - Número de factura: {0}",numFactura);
                Console.WriteLine(" - Cédula del comprador: {0}", cedula);
                Console.WriteLine(" - Nombre del comprador: {0}", nombreComprador);
                Console.WriteLine(" - Localidad: {0}", nombreLocalidad);
                Console.WriteLine(" - Cantidad de entradas: {0}", cantidad);
                Console.WriteLine(" - Subtotal: {0:F2}", subtotal);
                Console.WriteLine(" - Cargos por servicios: {0:F2}", cargosServicios);
                Console.WriteLine(" - Total a pagar: {0:F2}", totalPagar);
                Console.WriteLine("\n-----------------------------------------------------");
                localidad = 0;
                // Preguntar si se desea continuar
                Console.Write("¿Desea ingresar otra venta? (s/n): ");
                string respuesta = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------------\n");

                if (respuesta.ToLower() == "n")
                {
                    continuar = false;
                }
            }
            

            // Calcular totales por localidad
            double totalSolNorteSur = acumSolNorteSur + (cantSolNorteSur * 1000);
            double totalSombraEsteOeste = acumSombraEsteOeste + (cantSombraEsteOeste * 1000);
            double totalPreferencial = acumPreferencial + (cantPreferencial * 1000);
            double totalVentas = totalSolNorteSur + totalSombraEsteOeste + totalPreferencial;
            // Mostrar resumen de ventas

            Console.WriteLine("\n---------------------Resumen de ventas---------------");
            Console.WriteLine("\n---- Sol Norte/Sur:");
            Console.WriteLine(" - Cantidad de entradas vendidas: " + cantSolNorteSur);
            Console.WriteLine(" - Total ventas: {0:F2}", totalSolNorteSur);

            Console.WriteLine("\n---- Sombra Este/Oeste:");
            Console.WriteLine(" - Cantidad de entradas vendidas: " + cantSombraEsteOeste);
            Console.WriteLine(" - Total ventas: {0:F2}", totalSombraEsteOeste);

            Console.WriteLine("\n---- Preferencial:");
            Console.WriteLine(" - Cantidad de entradas vendidas: " + cantPreferencial);
            Console.WriteLine(" - Total ventas: {0:F2}", totalPreferencial);
            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("\t\tTotal de ventas: {0:F2}", totalVentas);
            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("\n------------------Programa Finalizado--------------\n");
            
            Console.ReadLine();
        }
    }
}
