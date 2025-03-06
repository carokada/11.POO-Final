using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Vendedor : Usuario
   {
      private List<Publicacion> publicaciones;

      public Vendedor (string nombre) : base(nombre)
      {
         publicaciones = new List<Publicacion>();
      }

      public void CrearPublicacion (string nombre, decimal precio, int stock)
      {
         Publicacion nuevaPublicacion = new Publicacion(nombre, this);
         nuevaPublicacion.Precio = precio;
         nuevaPublicacion.Stock = stock;
         AddPublicacion(nuevaPublicacion);
      }

      //private
      internal void AddPublicacion (Publicacion publicacion)
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

      public override string ToString()
      {
         return $"{Nombre}";
      }
   }
}
