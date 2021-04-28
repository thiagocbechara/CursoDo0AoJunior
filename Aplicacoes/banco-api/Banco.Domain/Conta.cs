using Banco.Domain.Database;
using Banco.Domain.Enums;
using Banco.Domain.Repositories;

namespace Banco.Domain
{
    public class Conta
    {
        public Conta(ContaEntity entity, IContaRepository repository)
        {
            Repository = repository;
            Entity = entity;
        }

        private readonly IContaRepository Repository;
        private readonly ContaEntity Entity;

        private long Id => Entity.Id;

        public string Numero { get => Entity.Numero; }
        public decimal Saldo { get => Entity.Saldo; }
        public bool Ativa { get => Entity.Ativa; }

        public bool Sacar(decimal valor)
        {
            if (valor <= 0 || valor > Saldo)
            {
                return false;
            }
            Entity.Saldo -= valor;
            AtualizarSaldo();
            return true;
        }

        public bool Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                return false;
            }

            Entity.Saldo += valor;
            AtualizarSaldo();
            return true;
        }

        private void AtualizarSaldo() => Repository.AtualizarSaldo(Id, Saldo);

        public SituacaoInativarContaEnum Inativar()
        {

            if (Id == 0)
            {
                return SituacaoInativarContaEnum.IdZero;
            }

            if (!Repository.ContaExistente(Id))
            {
                return SituacaoInativarContaEnum.ContaNaoEncontrada;
            }

            if (!Repository.ContaAtiva(Id))
            {
                return SituacaoInativarContaEnum.ContaJaInativa;
            }

            if (Repository.SaldoDisponivel(Id) > 0)
            {
                return SituacaoInativarContaEnum.SaldoNaoZerado;
            }

            var contaFoiInativada = Repository.Inativar(Id);
            return contaFoiInativada ?
                SituacaoInativarContaEnum.Sucesso :
                SituacaoInativarContaEnum.ErroGenerico;
        }
    }
}
