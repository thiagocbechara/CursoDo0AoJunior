namespace Banco.Domain.Factories
{
    public interface IContaFactory
    {
        Conta Criar();
        Conta Criar(string numero);
        Conta Criar(string numero, decimal saldoInicial);
        Conta Criar(decimal saldoInicial);
    }
}
