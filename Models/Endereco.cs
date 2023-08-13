using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Logradouro Obrigatório")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage ="Numero Obrigatório")]
    public int Numero { get; set; }

    public virtual Cinema Cinema { get; set; }
}
