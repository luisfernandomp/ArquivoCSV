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

            Produto p2 = new Produto();

            p2.Codigo = 2;
            p2.Nome = "Sla";
            p2.Preco = 4332f;
            
            p1.Cadastrar(p1);
            p1.Remover("Fender");

            p2.Cadastrar(p2);

            Produto alterado = new Produto();
            alterado.Codigo = 3;
            alterado.Nome = "Anime";
            alterado.Preco = 34.60f;

            p1.Alterar(alterado);

            List<Produto> lista = new List<Produto>();
            lista = p1.Ler();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($"R${item.Preco} - {item.Nome}");
            }
        }
    }
}
