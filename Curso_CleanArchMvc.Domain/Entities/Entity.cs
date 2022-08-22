namespace Curso_CleanArchMvc.Domain.Entities
{
    // Classe base - Conceito de DDD para ter uma classe base para as entidades que possuem propriedades em comum.
    // Não será utilizado ValueObjects e/ou Aggregates para diminuir a complexidade do código.
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
