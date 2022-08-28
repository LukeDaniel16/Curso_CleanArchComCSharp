using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string ImagePath { get; private set; }

        public Product(string name, string description, decimal price, int stock, string imagePath)
        {
            ValidateDomain(name, description, price, stock, imagePath);
        }
        
        public Product(int id, string name, string description, decimal price, int stock, string imagePath)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(name, description, price, stock, imagePath);
        }
        
        public void Update(int id, string name, string description, decimal price, int stock, string imagePath, int categoryId)
        {            
            ValidateDomain(name, description, price, stock, imagePath);
            CategoryId = categoryId;
        }

        public void ValidateDomain(string name, string description, decimal price, int stock, string imagePath)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, nome é obrigatório.");
            DomainExceptionValidation.When(name.Length < 3, "O Nome passado é menor que 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida, nome é obrigatório.");
            DomainExceptionValidation.When(description.Length < 3, "A Descrição passado é menor que 5 caracteres.");
            DomainExceptionValidation.When(price < 0, "O preço passado é menor que 0.");
            DomainExceptionValidation.When(stock < 0, "O estoque passado é menor que 0.");
            DomainExceptionValidation.When(imagePath.Length > 250, "O link para a imagem passado é muito grande.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ImagePath = imagePath;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
