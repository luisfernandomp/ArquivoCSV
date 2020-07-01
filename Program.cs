using System;
using System.Collections.Generic;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            
            p1.Codigo = 1;
            p1.Nome = "Fender";
            p1.Preco = 4500f;

            p1.Cadastrar(p1);
            p1.Remover("Fender");

            List<Produto> lista = new List<Produto>();
            lista = p1.Ler();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($"R${item.Preco} - {item.Nome}");
            }
        }
    }
}
