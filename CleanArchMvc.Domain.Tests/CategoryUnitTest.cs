using CleanArchMvc.Domain;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category with valid parameters resulting in object with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        
        [Fact(DisplayName = "Create category with invalid id")]
        public void CreateCategory_WithInvalidId_ResultObjectInvalidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }
        
        [Fact(DisplayName = "Create category with invalid name (short name)")]
        public void CreateCategory_WithInvalidName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("O Nome passado é menor que 3 caracteres.");
        }
        
        [Fact(DisplayName = "Create category with missing name")]
        public void CreateCategory_WithoutName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido, nome é obrigatório.");
        }
    }
}
