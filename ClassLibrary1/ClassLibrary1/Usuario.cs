using System;

namespace EntidadesCs
{
   public abstract class Usuario
   {
      private string nombre;

      public Usuario (string nombre)
      {
         Nombre = nombre;
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = value.Length >= 3 ? value : throw new ArgumentException(" el nombre debe tener por lo menos 3 caracteres.");
      }


   }
}
