using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AV1.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public int Estoque { get; set; }
        [Required]
        public double Preco { get; set; }
        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}