namespace ProjetoDepartamento.Api.DTOs
{
    public class CriarFuncionarioDto
    {
        public string Nome {  get; set; }
        public string CPF { get; set; }
        public decimal Salario { get; set; }
        public int DepartamentoId { get; set; }
    }
}
