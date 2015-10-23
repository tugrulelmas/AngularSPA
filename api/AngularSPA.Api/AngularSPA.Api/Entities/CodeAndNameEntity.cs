using AngularSPA.Api.Entitites.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularSPA.Api.Entities
{
    public abstract class CodeAndNameEntity : DeletableEntity
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public override ValidationResult Validate(ActionType actionType) {
            var collection = new ValidationMessageCollection();

            collection.AddEmptyMessage(Code, "Code");
            if (actionType != ActionType.Delete) {
                collection.AddEmptyMessage(Name, "Name");
            }

            if (actionType == ActionType.Add) {
                //TODO: db check for unique code.
            }

            return collection.ToValidationResult();
        }
    }
}