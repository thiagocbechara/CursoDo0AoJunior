using Banco.Domain.Database;
using Banco.Domain.Enums;
using Banco.Domain.Repositories;
using Moq;
using NUnit.Framework;

namespace Banco.Domain.UnitTest
{
    public class ContaTest
    {
        [Test]
        public void Sacar_Should_Be_Allowed()
        {
            // Instanciar a Conta
            var contaEntity = new ContaEntity { Saldo = 100 };
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.AtualizarSaldo(It.IsAny<long>(), It.IsAny<decimal>())).Returns(true);
            var conta = new Conta(contaEntity, mockRepository.Object);

            // Realizar o saque
            var saqueFoiRealizado = conta.Sacar(50);

            // Verificar o resultado
            Assert.IsTrue(saqueFoiRealizado);
            Assert.AreEqual(50, conta.Saldo);
        }

        [TestCase(-1)]
        [TestCase(50)]
        public void Sacar_Should_Not_Be_Allowed(decimal value)
        {
            // Instanciar a Conta
            var contaEntity = new ContaEntity();
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            var conta = new Conta(contaEntity, mockRepository.Object);

            // Realizar o saque
            var saqueFoiRealizado = conta.Sacar(value);

            // Verificar o resultado
            Assert.IsFalse(saqueFoiRealizado);
        }

        [Test]
        public void Depositar_Should_Be_Allowed()
        {
            var contaEntity = new ContaEntity();
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.AtualizarSaldo(It.IsAny<long>(), It.IsAny<decimal>())).Returns(true);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var depositoFoiRealizado = conta.Depositar(100);

            Assert.IsTrue(depositoFoiRealizado);
            Assert.AreEqual(100, conta.Saldo);
        }

        [Test]
        public void Depositar_Should_Not_Be_Allowed()
        {
            var contaEntity = new ContaEntity();
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var depositoFoiRealizado = conta.Depositar(-1);

            Assert.IsFalse(depositoFoiRealizado);
        }

        [Test]
        public void Inativar_Should_Returns_IdZero()
        {
            var contaEntity = new ContaEntity();
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var inativarSituacao = conta.Inativar();

            Assert.AreEqual(SituacaoInativarContaEnum.IdZero, inativarSituacao);
        }

        [Test]
        public void Inativar_Should_Returns_ContaNaoEncontrada()
        {
            var contaEntity = new ContaEntity { Id = 1 };
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.ContaExistente(It.IsAny<long>())).Returns(false);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var inativarSituacao = conta.Inativar();

            Assert.AreEqual(SituacaoInativarContaEnum.ContaNaoEncontrada, inativarSituacao);
        }

        [Test]
        public void Inativar_Should_Returns_ContaJaInativa()
        {
            var contaEntity = new ContaEntity { Id = 1 };
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.ContaExistente(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.ContaAtiva(It.IsAny<long>())).Returns(false);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var inativarSituacao = conta.Inativar();

            Assert.AreEqual(SituacaoInativarContaEnum.ContaJaInativa, inativarSituacao);
        }

        [Test]
        public void Inativar_Should_Returns_SaldoNaoZerado()
        {
            var contaEntity = new ContaEntity { Id = 1 };
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.ContaExistente(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.ContaAtiva(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.SaldoDisponivel(It.IsAny<long>())).Returns(1);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var inativarSituacao = conta.Inativar();

            Assert.AreEqual(SituacaoInativarContaEnum.SaldoNaoZerado, inativarSituacao);
        }

        [Test]
        public void Inativar_Should_Returns_ErroGenerico()
        {
            var contaEntity = new ContaEntity { Id = 1 };
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.ContaExistente(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.ContaAtiva(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.SaldoDisponivel(It.IsAny<long>())).Returns(0);
            mockRepository.Setup(x => x.Inativar(It.IsAny<long>())).Returns(false);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var inativarSituacao = conta.Inativar();

            Assert.AreEqual(SituacaoInativarContaEnum.ErroGenerico, inativarSituacao);
        }

        [Test]
        public void Inativar_Should_Returns_Sucesso()
        {
            var contaEntity = new ContaEntity { Id = 1 };
            var mockRepository = new Mock<IContaRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.ContaExistente(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.ContaAtiva(It.IsAny<long>())).Returns(true);
            mockRepository.Setup(x => x.SaldoDisponivel(It.IsAny<long>())).Returns(0);
            mockRepository.Setup(x => x.Inativar(It.IsAny<long>())).Returns(true);
            var conta = new Conta(contaEntity, mockRepository.Object);

            var inativarSituacao = conta.Inativar();

            Assert.AreEqual(SituacaoInativarContaEnum.Sucesso, inativarSituacao);
        }
    }
}
