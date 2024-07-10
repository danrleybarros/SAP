using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;

namespace Gcsb.Connect.SAP.Domain
{
    public abstract  class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        [NotMapped]
        public bool Valid { get; set; }

        [NotMapped]       
        public ValidationResult ValidationResult { get; private set; }    

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
