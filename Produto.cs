using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            produtos = produtos.OrderBy(y => y.Nome).ToList();
            return produtos;
        }
        
        public void Remover(string _termo){
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH)){
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha); 

                }
            }
            linhas.RemoveAll(x => x.Contains(_termo));

            // Usar o using tira a obritoriedade de abrir e fechar as conexões
            using(StreamWriter output = new StreamWriter(PATH)){
                foreach (string ln in linhas)
                {
                    output.Write(ln + "\n");
                }
            }
        }   
        public void Alterar(Produto _produtoAlterado){
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH)){
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha); 

                }
            }
            // linhas.RemoveAll(x => x.Split(";")[0].Contains(_produtoAlterado.Codigo.ToString()));
            linhas.RemoveAll(z => z.Split(";")[0].Split("=")[1] == _produtoAlterado.Codigo.ToString());


            linhas.Add(PrepararLinha(_produtoAlterado));
            
            // Usar o using tira a obritoriedade de abrir e fechar as conexões
            using(StreamWriter output = new StreamWriter(PATH)){
                foreach (string ln in linhas)
                {
                    output.Write(ln + "\n");
                }
            }
        }
        public List<Produto> Filtrar (string _nome){
                return Ler().FindAll(x => x.Nome == _nome);

        }
        private string Separar (string _coluna) {
            return _coluna.Split ("=")[1];
        }

    }
}