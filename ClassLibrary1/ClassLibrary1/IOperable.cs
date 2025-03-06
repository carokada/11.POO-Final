using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public interface IOperable
   {
      Operacion Operacion { get; set; }

      decimal CalcularTotal();
      void Comprar(Comprador comprador, DateTime fecha, uint cantidad);
   }
}
