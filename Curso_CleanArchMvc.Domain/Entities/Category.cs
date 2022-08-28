using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {        
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);            
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(name);
        }        

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, nome é obrigatório.");
            DomainExceptionValidation.When(name.Length < 3, "O Nome passado é menor que 3 caracteres.");
            Name = name;
        }

        public ICollection<Product> Products { get; set; }
    }
}
