using CleanArchMvc.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Foto")]
        public string ImagePath { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
