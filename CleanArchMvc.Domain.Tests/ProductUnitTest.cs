using CleanArchMvc.Domain;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create product with valid parameters resulting in object with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name", "Product desc", 10, 5, "https:www.example.com");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        
        [Fact(DisplayName = "Create product with negative id value resulting in object with invalid state")]
        public void CreateProduct_WithNegativeIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Product(-1,"Product Name", "Product desc", 10, 5, "https:www.example.com");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }
        
        [Fact(DisplayName = "Create product with short name resulting in object with invalid state")]
        public void CreateProduct_WithShortName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1,"Pr", "Product desc", 10, 5, "https:www.example.com");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("O Nome passado é menor que 3 caracteres.");
        }
        
        [Fact(DisplayName = "Create product without name resulting in object with invalid state")]
        public void CreateProduct_WithoutName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1,"", "Product desc", 10, 5, "https:www.example.com");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, nome é obrigatório.");
        }

        [Fact(DisplayName = "Create product with long image path resulting in object with invalid state")]
        public void CreateProduct_WithLongImagePath_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product", "Product desc", 10, 5, "https:www.example.commmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("O link para a imagem passado é muito grande.");
        }

        [Fact(DisplayName = "Create product with negative price resulting in object with invalid state")]
        public void CreateProduct_WithNegativePrice_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product", "Product desc", -10, 5, "https:www.example.com");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("O preço passado é menor que 0.");
        }
        
        [Fact(DisplayName = "Create product with image null path resulting in object with valid state")]
        public void CreateProduct_WithNullImagePath_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product", "Product desc", 10, 5, null);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        
        [Fact(DisplayName = "Create product with image empty path resulting in object with valid state")]
        public void CreateProduct_WithEmptyImagePath_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product", "Product desc", 10, 5, "");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        
        [Theory(DisplayName = "Create product with invalid stock value resulting in object with invalid state")]
        [InlineData(-50)]
        [InlineData(-1)]
        public void CreateProduct_WithInvalidStockValue_ResultObjectInvalidState(int stockValue)
        {
            Action action = () => new Product(1, "Product", "Product desc", 10, stockValue, "");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("O estoque passado é menor que 0.");
        }
    }
}
