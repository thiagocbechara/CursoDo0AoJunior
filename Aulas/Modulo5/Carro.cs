using System;

namespace CursoDo0AoJunior.Modulo5
{
    public abstract class Carro
    {
        public Carro()
        {
            Fabricante = "Não Aplicável";
        }

        public Carro(string cor) : this()
        {
            Cor = cor;
        }
        
        public Carro(string cor, string modelo, string combustivel) : this(cor)
        {
            Modelo = modelo;
            Combustivel = combustivel;
        }

        public string Cor { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Combustivel { get; set; }

        public bool LigarCarro()
        {
            // Ligar o carro
            Console.WriteLine("Liga o carro");
            return true;
        }

        public bool LigarCarro(bool situacao)
        {
            // Ligar o carro
            return situacao;
        }
    }
}