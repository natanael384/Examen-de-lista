using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen_de_lista
{
    internal class Program
    {
        /*Una tienda de barrio necesita un programa de consola para llevar el inventario de sus productos*/

        // Analisis
        // Entrada:  Producto (nombre), Precio
        // Proceso:  Agregar, Modificar, Buscar, Eliminar, Estadisticas
        // Salida:   Mostrar productos, Estadisticas, Listas ordenadas, Busquedas, Resultados de operaciones

        static List<string> Producto = new List<string>();
        static List<double> Precio = new List<double>();

        static void Main(string[] args)
        {


            static void MenuOpciones()
            {
                Console.WriteLine("Menu de Opciones de Mantenimiento del inventario");
                Console.WriteLine();
                Console.WriteLine("Opcion 1: Agregar un Producto");
                Console.WriteLine("Opcion 2: Mostrar todos los productos");
                Console.WriteLine("Opcion 3: Buscar un producto");
                Console.WriteLine("Opcion 4: Modificar un producto");
                Console.WriteLine("Opcion 5: Eliminar un producto");
                Console.WriteLine("Opcion 6: Mostrar estadisticas");
                Console.WriteLine("Opcion 7: Ordenar la lista");
                Console.WriteLine("Opcion 0: Salir");
            }

            static void MostrarProductos()
            {
                if (Producto.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                Console.WriteLine("==== Lista de Productos ====");
                for (int i = 0; i < Producto.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Producto : {Producto[i]}  Precio : ${Precio[i]}");
                }
            }

            static string AgregarProducto(string nombre, double precio)
            {
                if (precio <= 0)
                {
                    return "Los precios deben tener valores positivos";
                }
                if (nombre == "")
                {
                    return "El nombre del producto no puede estar vacio";
                }
                if (Producto.Contains(nombre))
                {
                    return "La lista ya contiene ese producto";
                }

                Producto.Add(nombre);
                Precio.Add(precio);
                return "Se agrego el producto correctamente";
            }


        }
    }
}