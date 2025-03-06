using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Operacion //: IOperable
   {
      private Comprador comprador;
      private IOperable Operable { get; set; }

      public DateTime Fecha { get; set; }
      public decimal Monto { get; set; }
      private uint Cantidad { get; set; }

      public Operacion(Comprador comprador, DateTime fecha, decimal monto)
      {
         Fecha = fecha;
         Monto = monto;
         Comprador = comprador;
      }

      public Comprador Comprador
      {
         get => comprador;
         set
         {
            comprador = value ?? throw new ArgumentException(" el comprador no puede ser nulo.");
            comprador.AgregarOperacion(this);
         }
      }

      public override string ToString()
      {
         return $"[{Fecha.ToString("dd/MM/yy")}] comprador: {Comprador} \t total: {Monto}";
      }
   }
}
