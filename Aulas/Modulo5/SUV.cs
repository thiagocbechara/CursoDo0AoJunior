using System;

namespace CursoDo0AoJunior.Modulo5
{
    public class SUV : Carro, IAcelerar
    {
        public SUV() : base("SUV")
        {
        }

        public int Estepes { get; set; }

        public bool Acelerar()
        {
            // Acelera a SUV
            Console.WriteLine("Acelera a SUV");
            return true;
        }
    }
}