using System;
using System.Collections.Generic;
using System.IO;

namespace Excel
{    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set;}
        public float Preco { get; set; }
        private const string PATH = "Database/produto.csv";
        List<Produto> lista = new List<Produto>();
        public Produto(){
            if(!Directory.Exists(PATH)){
                Directory.CreateDirectory("Database");
            }else if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        public void Cadastrar(Produto prod){
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Produto p){
            return $"codigo = {p.Codigo};nome = {p.Nome};preco = {p.Preco}";
        }
        
        public List<Produto> Ler(){

            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var linha in linhas)
            {
                string[] dados = linha.Split(";");
                Produto prod = new Produto();
                prod.Codigo = Int32.Parse(Separar(dados[0]));
                prod.Nome = Separar(dados[1]);
                prod.Preco = float.Parse(Separar(dados[2]));

                produtos.Add(prod);
            }

            return produtos;
        }

        private string Separar (string _coluna) {
            return _coluna.Split ("=")[1];
        }

    }
}