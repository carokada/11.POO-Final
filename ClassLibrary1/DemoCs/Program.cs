using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCs;

namespace DemoCs
{
   class Program
   {
      static void Main(string[] args)
      {
         string divisor = "----------------------------------------------------------";

         Console.WriteLine(divisor);
         Console.WriteLine(" creando compradores");
         Comprador comprador1 = new Comprador("Mario Gomez");
         Comprador comprador2 = new Comprador("Elisa Goldwing");
         try
         {
            Comprador comprador3 = new Comprador("Al");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine(" mostrando compradores creados:");
         Console.WriteLine(comprador1);
         Console.WriteLine(comprador2);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" creando vendedores");
         Vendedor vendedor1 = new Vendedor("Omar Ayuso");
         Vendedor vendedor2 = new Vendedor("Amanda Ramirez");
         Console.WriteLine(" mostrando vendedores creados:");
         Console.WriteLine(vendedor1);
         Console.WriteLine(vendedor2);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" creando publicaciones");
         vendedor1.CrearPublicacion("skateboard", 350, 10);
         vendedor1.CrearPublicacion("stickers x10", 20, 50);
         vendedor1.CrearPublicacion("monopatin electrico", 500, 3);
         vendedor2.CrearPublicacion("Remera", 40, 5);
         vendedor2.CrearPublicacion("Camisa", 60, 2);
         try
         {
            vendedor2.CrearPublicacion("Po", 60, 2);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            vendedor2.CrearPublicacion("Polainas", -5, 2);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine(" mostrando publicaciones creadas:");
         MostrarPublicacionesPorVendedor(vendedor1);
         MostrarPublicacionesPorVendedor(vendedor2);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" realizando compras");
         Console.WriteLine(" compra directa ");
         vendedor1.ListarPublicaciones()[0].Comprar(comprador2, DateTime.Now, 3);
         Console.WriteLine(" compra por carrito ");
         comprador1.CrearCarrito();
         comprador1.ListarCarritos()[0].AgregarPublicacion(vendedor2.ListarPublicaciones()[0]);
         comprador1.ListarCarritos()[0].AgregarPublicacion(vendedor2.ListarPublicaciones()[1]);
         MostrarItemsEnCarrito(comprador1.ListarCarritos()[0]);
         comprador1.Comprar(comprador1.ListarCarritos()[0], DateTime.Now, 2);

         Console.WriteLine("\n mostrando operaciones por comprador:");
         MostrarOperacionesPorComprador(comprador1);
         MostrarOperacionesPorComprador(comprador2);

         //Console.WriteLine($"\n {divisor}");
         //Console.WriteLine(" creando carritos");
         //comprador1.CrearCarrito();
         //comprador2.CrearCarrito();




         //Console.WriteLine($"\n {divisor}");
         //Console.WriteLine("");
         //Console.WriteLine();
         Console.WriteLine(divisor);
         Console.WriteLine("\n presione una tecla para salir ");
         Console.ReadKey();
      }

      private static void MostrarPublicacionesPorVendedor(Vendedor vendedor)
      {
         Console.WriteLine($" publicaciones de {vendedor}");
         foreach (var publicacion in vendedor.ListarPublicaciones())
            Console.WriteLine($"\t ~ {publicacion}");
         Console.WriteLine();
      }

      private static void MostrarItemsEnCarrito(Carrito carrito)
      {
         Console.WriteLine($"{carrito}");
         foreach (var item in carrito.ListarPublicaciones())
            Console.WriteLine($"\t ~ {item}");
         Console.WriteLine();
      }

      private static void MostrarOperacionesPorComprador(Comprador comprador)
      {
         Console.WriteLine($" operaciones de {comprador}");
         foreach (var operacion in comprador.ListarOperaciones())
            Console.WriteLine($"\t ~ {operacion}");
         Console.WriteLine();
      }
   }
}
