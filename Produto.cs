using System;
using System.IO;

namespace Excel
{    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set;}
        public float Preco { get; set; }
        private const string PATH = "Database/produto.csv";

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
        
    }
}