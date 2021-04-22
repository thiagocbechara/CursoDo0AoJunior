using Banco.Domain.Database;

namespace Banco.Domain.Repositories
{
    public interface IContaRepository
    {
        /// <summary>
        /// Obtem a conta a partir do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ContaEntity Obter(long id);

        /// <summary>
        /// Obterm a conta a partir do número da conta
        /// </summary>
        /// <param name="numeroConta"></param>
        /// <returns></returns>
        ContaEntity Obter(string numeroConta);

        /// <summary>
        /// Verifica se a conta existe no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ContaExistente(long id);

        /// <summary>
        /// Verifica se a conta está ativa no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ContaAtiva(long Id);

        /// <summary>
        /// Insere ou atualiza a conta fornecida
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        ContaEntity InserirOuAtualizar(ContaEntity conta);

        /// <summary>
        /// Atualiza o saldo da conta informada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saldo"></param>
        /// <returns></returns>
        bool AtualizarSaldo(long id, decimal saldo);

        /// <summary>
        /// Inativa a conta fornecida
        /// </summary>
        /// <param name="id">ID da conta a ser inativada</param>
        /// <returns></returns>
        bool Inativar(long id);

        /// <summary>
        /// Retorna o saldo disponível da conta no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        decimal SaldoDisponivel(long id);

        /// <summary>
        /// Indica se o número de conta está em uso
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        bool NumeroContaEmUso(string numero);
    }
}
