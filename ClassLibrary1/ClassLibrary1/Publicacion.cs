using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Publicacion : IOperable
   {
      private Vendedor vendedor;
      public Operacion Operacion { get; set; }

      private string nombre;
      private decimal precio;
      public int Stock { get; set; }
      public bool Habilitada { get; set; } = true;

      public Publicacion (string nombre, Vendedor vendedor)
      {
         Nombre = nombre;
         Vendedor = vendedor;
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = value.Length >= 3 ? value : throw new ArgumentException(" el nombre debe tener por lo menos 3 caracteres.");
      }

      public decimal Precio
      {
         get => precio;
         set => precio = value > 0? value : throw new ArgumentException(" el precio debe ser mayor a cero.");
      }

      public Vendedor Vendedor
      {
         get => vendedor;
         internal set => vendedor = value ?? throw new ArgumentException(" el vendedor no puede ser nulo.");
      }

      public decimal CalcularTotal()
      {
         return precio;
      }

      public void Comprar(Comprador comprador, DateTime fecha, uint cantidad)
      {
         if (!Habilitada)
            throw new ArgumentException(" la publicacion no esta habilitada.");
         if (Stock < cantidad)
            throw new ArgumentException(" no hay suficientes unidades en stock.");
         Operacion operacion = new Operacion(comprador, fecha, (CalcularTotal() * cantidad));
         Stock -= (int) cantidad;
      }

      public override string ToString()
      {
         return $"{Nombre} [{Stock} unidades] \t ${Precio} {(!Habilitada ? "(no habilitada)" : "")}";
      }
   }
}
