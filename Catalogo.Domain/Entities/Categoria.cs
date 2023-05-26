using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities
{
    public sealed class Categoria : Entity 
    {
        public Categoria(string nome, string imagemUrl) 
        {
            ValidateDomain(nome, imagemUrl); 
        }

        public Categoria(int id, string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(id < 0, "O valor do Id é inválido!");
            Id = id;
            ValidateDomain(nome, imagemUrl);
        }

        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos { get; set; }

        public void ValidateDomain(string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório! ");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl), "Url inválido!");
            DomainExceptionValidation.When(nome.Length < 3, "O nome deve ter no mínimo 3 caracteres");
            DomainExceptionValidation.When(imagemUrl.Length < 5, "A Url deve conter no mínimo 5 caracteres");

            Nome = nome; 
            ImagemUrl = imagemUrl;
        }
    }
}
