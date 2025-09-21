using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace TrabalhoItegrador.Models
{
    [Table("reclamacao")]
    public class Reclamacao
    {
        [Key]
        public int id_reclamacao { get; set; }

        [Required]
        public string titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int id_fornecedor { get; set; }

        public int id_conta { get; set; }

        public string? imagem_url { get; set; }

          }
    }

