using System.ComponentModel.DataAnnotations;

namespace AdmFagil.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do serviço!")]
        public string ServNome { get; set; }

        [Required(ErrorMessage = "Digite a Descrição do serviço!")]
        public string ServDesc { get; set; }

        [Required(ErrorMessage = "Digite o Valor do serviço!")]
        public int Preco { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
    }
}