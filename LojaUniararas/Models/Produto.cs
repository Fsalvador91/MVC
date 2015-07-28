using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaUniararas.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome inválido.")]
        [StringLength(40, ErrorMessage = "O tamanho máximo são 40 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preço é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:n2}",
           ApplyFormatInEditMode = true,
           NullDisplayText = "Sem preço")]
        [Range(1, 4000, ErrorMessage = "O preço deverá ser entre 1 e 4.000,00")]
        public decimal? Preco { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public int CategoriaID { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Quantidade inválida.")]
        public int Quantidade { get; set; }
    }
}