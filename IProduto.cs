using System.Collections.Generic;

namespace Excel
{
    public interface IProduto
    {
         void Alterar(Produto _produtoAlterado);
         void Cadastrar(Produto prod);
         void Remover(string _termo);
         List<Produto> Ler();
    }
}