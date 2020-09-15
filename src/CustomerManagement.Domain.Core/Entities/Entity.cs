using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.IO.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            //ValidationResult = new ValidationResult();
        }

        public void CreateGuid() => Id = Guid.NewGuid();

        [NotMapped] // Para não dar problemas com mapeamento EF
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = {Id}]";
        }
    }
}
