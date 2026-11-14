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

            static string BuscarProducto(string nombre)
            {
                int i = Producto.IndexOf(nombre);
                if (i == -1)
                {
                    return "Producto no encontrado";
                }
                return $"Producto : {Producto[i]}  Precio : ${Precio[i]}";
            }

            static string ModificacionProducto(string actual, string nuevo, double precio)
            {
                if (precio <= 0)
                {
                    return "Los precios deben tener valores positivos";
                }
                if (nuevo == "")
                {
                    return "El nombre del producto no puede estar vacio";
                }

                int i = Producto.IndexOf(actual);
                if (i == -1)
                {
                    return "Producto no encontrado";
                }

                int otro = Producto.IndexOf(nuevo);
                if (otro != -1 && otro != i)
                {
                    return "Ya existe otro producto con ese nombre";
                }

                Producto[i] = nuevo;
                Precio[i] = precio;
                return "Se modifico el producto correctamente";
            }

            static string eliminarProducto(string nombre)
            {
                int i = Producto.IndexOf(nombre);
                if (i == -1)
                {
                    return "Producto no encontrado";
                }

                Producto.RemoveAt(i);
                Precio.RemoveAt(i);
                return "Se elimino el producto correctamente";
            }

            static void MostrarEstadistica()
            {
                if (Producto.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                int Maximo = Precio.IndexOf(Precio.Max());
                int Minimo = Precio.IndexOf(Precio.Min());

                Console.WriteLine("==== Estadistica ====");
                Console.WriteLine($"Total de Productos: {Producto.Count}");
                Console.WriteLine($"Producto con Precio Mayor: {Producto[Maximo]} (${Precio[Maximo]})");
                Console.WriteLine($"Producto con Precio Menor: {Producto[Minimo]} (${Precio[Minimo]})");
                Console.WriteLine($"Promedio de Precios: ${Precio.Average():F2}");
            }

            static void Ordenlista()
            {
                if (Producto.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                Console.WriteLine("Opcion 1: Ordenar por Nombre");
                Console.WriteLine("Opcion 2: Ordenar de Menor a Mayor");
                Console.WriteLine("Opcion 3: Ordenar de Mayor a Menor");
                Console.WriteLine();
                Console.Write("Elige la opcion de orden: ");

                int op;
                while (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.Write("Entrada invalida. Elige la opcion de orden: ");
                }


                var pares = Producto.Zip(Precio, (n, p) => (Nombre: n, Precio: p));
                List<(string Nombre, double Precio)> ordenado;

                switch (op)
                {
                    case 1:
                        ordenado = pares.OrderBy(x => x.Nombre, StringComparer.OrdinalIgnoreCase).ToList();
                        break;
                    case 2:
                        ordenado = pares.OrderBy(x => x.Precio).ToList();
                        break;
                    case 3:
                        ordenado = pares.OrderByDescending(x => x.Precio).ToList();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        return;
                }

                Producto = ordenado.Select(x => x.Nombre).ToList();
                Precio = ordenado.Select(x => x.Precio).ToList();

                Console.WriteLine("Lista ordenada correctamente.");
                MostrarProductos();
            }
        }
    }
}