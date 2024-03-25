namespace Pedidos.Domain.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
        public string EmailContato { get; set; }
        public string NomeContato { get; set; }
    }
}
