using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS
{
    public class CreateEnderecoDTO
    {
        [Required(ErrorMessage = "Logradouro Obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Numero Obrigatório")]
        public int Numero { get; set; }
    }
}