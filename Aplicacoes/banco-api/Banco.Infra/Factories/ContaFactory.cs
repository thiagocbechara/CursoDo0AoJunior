using Banco.Domain;
using Banco.Domain.Factories;
using System;
using Microsoft.Extensions.DependencyInjection;
using Banco.Domain.Repositories;
using Banco.Domain.Database;

namespace Banco.Infra.Factories
{
    public class ContaFactory : IContaFactory
    {
        private readonly IServiceProvider ServiceProvider;
        public ContaFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public Conta Criar(string numero, decimal saldoInicial)
        {
            var contaRepository = ServiceProvider.GetService<IContaRepository>();
            var conta = new Conta(CriarEntity(numero, saldoInicial), contaRepository);
            return conta;
        }

        private IContaRepository GetContaRepository() => ServiceProvider.GetService<IContaRepository>();

        private ContaEntity CriarEntity(string numeroConta, decimal saldoInicial)
        {
            var conta = new ContaEntity
            {
                Numero = GerarNumeroConta(numeroConta),
                Ativa = true,
                Saldo = saldoInicial
            };
            return GetContaRepository().InserirOuAtualizar(conta);
        }

        private string GerarNumeroConta(string numeroConta)
        {
            var numeroContaGerado = numeroConta;
            var rng = new Random();
            var minRadomValue = int.TryParse(numeroConta, out int min) ? min : 1;
            var repository = GetContaRepository();
            while (string.IsNullOrEmpty(numeroContaGerado) || repository.NumeroContaEmUso(numeroContaGerado))
            {
                numeroContaGerado = rng.Next(minRadomValue).ToString();
            }
            return numeroContaGerado;
        }

        public Conta Criar() => Criar(string.Empty, 0);

        public Conta Criar(string numero) => Criar(numero, 0);

        public Conta Criar(decimal saldoInicial) => Criar(string.Empty, saldoInicial);
    }
}
