using Banco.Domain.Database;
using Banco.Domain.Repositories;
using Banco.Infra.Db;
using System;
using System.Linq;

namespace Banco.Infra.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AtualizarSaldo(long id, decimal saldo)
        {
            try
            {
                var conta = Obter(id);
                conta.Saldo = saldo;
                InserirOuAtualizar(conta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ContaAtiva(long id) =>
            _context.Contas.Any(conta => conta.Id == id && conta.Ativa);

        public bool ContaExistente(long id) =>
            _context.Contas.Any(conta => conta.Id == id);

        public bool Inativar(long id)
        {
            try
            {
                var conta = Obter(id);
                conta.Ativa = false;
                InserirOuAtualizar(conta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ContaEntity InserirOuAtualizar(ContaEntity conta)
        {
            ContaEntity contaDb;
            if (ContaExistente(conta.Id))
            {
               contaDb = _context.Contas.Add(conta).Entity;
            }
            else
            {
                contaDb = _context.Contas.Update(conta).Entity;
            }
            _context.SaveChanges();
            return contaDb;
        }

        public bool NumeroContaEmUso(string numero) =>
            _context.Contas.Any(conta => conta.Numero == numero);

        public ContaEntity Obter(long id) =>
            _context.Contas.FirstOrDefault(conta => conta.Id == id);

        public ContaEntity Obter(string numeroConta) =>
            _context.Contas.FirstOrDefault(conta => conta.Numero == numeroConta);

        public decimal SaldoDisponivel(long id) =>
            Obter(id).Saldo;
    }
}
