namespace Excel
{
    public interface IProduto
    {
         void Alterar(Produto prod);
         void Cadastrar();
         void Remover(string _termo);
         void Ler(Produto _produtoAlterado);
    }
}