using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Comprador : Usuario
   {
      private List<Carrito> carritos;
      private List<Operacion> operaciones;

      public Comprador(string nombre) : base(nombre)
      {
         carritos = new List<Carrito>();
         operaciones = new List<Operacion>();
      }

      public void CrearCarrito()
      {
         Carrito carrito = new Carrito(this);
         AgregarCarrito(carrito);
      }

      internal void AgregarCarrito(Carrito carrito)
      {
         if (carrito == null)
            throw new ArgumentException(" el carrito no puede ser nulo.");
         if (carritos.Contains(carrito))
            throw new ArgumentException(" el carrito ya esta en la lista.");
         carritos.Add(carrito);
      }

      public List<Carrito> ListarCarritos()
      {
         return carritos;
      }

      internal void EliminarCarrito(Carrito carrito)
      {
         if (carrito == null)
            throw new ArgumentException(" el carrito no puede ser nulo.");
         if (!carritos.Contains(carrito))
            throw new ArgumentException(" el carrito no esta en la lista.");
         carritos.Remove(carrito);
      }

      internal void AgregarOperacion(Operacion operacion)
      {
         if (operacion == null)
            throw new ArgumentException(" la operacion no puede ser nula.");
         if (operaciones.Contains(operacion))
            throw new ArgumentException(" la operacion ya esta en la lista.");
         operaciones.Add(operacion);
      }

      public List<Operacion> ListarOperaciones()
      {
         return operaciones;
      }

      internal void EliminarOperacion(Operacion operacion)
      {
         if (operacion == null)
            throw new ArgumentException(" la operacion no puede ser nula.");
         if (!operaciones.Contains(operacion))
            throw new ArgumentException(" la operacion no esta en la lista.");
         operaciones.Remove(operacion);
      }

      // comprar (ioperable, fecha) debe invocar a ioperable comprar
      public void Comprar(IOperable compra, DateTime fecha, uint cantidad)
      {
         compra.Comprar(this, fecha, cantidad);
      }
      // solo se puede comprar si la publicacion esta habilitada y tiene stock suficiente. debe crear la operacion, esta se debe agregar al comprador y descontar stock.
     


      public override string ToString()
      {
         return $"{Nombre}";
      }
   }
}
