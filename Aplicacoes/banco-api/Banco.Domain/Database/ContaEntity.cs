namespace Banco.Domain.Database
{
    public class ContaEntity : BaseEntity
    {
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
    }
}
