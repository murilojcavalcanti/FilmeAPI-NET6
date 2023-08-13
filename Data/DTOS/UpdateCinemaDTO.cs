﻿using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
    }
}