using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Carrito : IOperable
   {
      private Comprador comprador;
      private List<Publicacion> publicaciones;
      public Operacion Operacion { get; set; }

      public Carrito (Comprador comprador)
      {
         publicaciones = new List<Publicacion>();

         Comprador = comprador;
      }

      public Comprador Comprador
      {
         get => comprador;
         internal set => comprador = value ?? throw new ArgumentException(" el comprador no puede ser nulo.");
      }

      public void AgregarPublicacion(Publicacion publicacion)
      {
         if (publicacion == null)
            throw new ArgumentException(" la publicacion no puede ser nula.");
         if (publicaciones.Contains(publicacion))
            throw new ArgumentException(" la publicacion ya esta en la lista.");
         publicaciones.Add(publicacion);
      }

      public List<Publicacion> ListarPublicaciones()
      {
         return publicaciones;
      }

      public void QuitarPublicacion(Publicacion publicacion)
      {
         if (publicacion == null)
            throw new ArgumentException(" la publicacion no puede ser nula.");
         if (!publicaciones.Contains(publicacion))
            throw new ArgumentException(" la publicacion no esta en la lista.");
         publicaciones.Remove(publicacion);
      }

      public decimal CalcularTotal()
      {
         decimal totalCarrito = 0;
         foreach (var publicacion in publicaciones)
            totalCarrito += publicacion.Precio;
         return totalCarrito;
      }

      public void Comprar(Comprador comprador, DateTime fecha, uint cantidad)
      {
         foreach (var publicacion in publicaciones)
         {
            if (!publicacion.Habilitada)
               throw new ArgumentException(" la publicacion no esta habilitada.");
            if (publicacion.Stock < cantidad)
               throw new ArgumentException(" no hay suficientes unidades en stock.");
            publicacion.Stock -= (int)cantidad;
         }
         Operacion operacion = new Operacion(comprador, fecha, CalcularTotal() * cantidad);
      }

      public override string ToString()
      {
         return $" carrito de {Comprador} - total acumulado: ${CalcularTotal()}";
      }
   }
}
