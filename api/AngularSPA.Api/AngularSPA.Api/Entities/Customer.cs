using AngularSPA.Api.Entitites.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularSPA.Api.Entities
{
    public class Customer : CodeAndNameEntity
    {
        public string PhoneNumber { get; set; }

        public override ValidationResult Validate(ActionType actionType) {
            var validationResult = base.Validate(actionType);
            if (actionType == ActionType.Delete) {
                return validationResult;
            }

            var collection = new ValidationMessageCollection();
            collection.AddRange(validationResult.Messages);

            collection.AddEmptyMessage(PhoneNumber, "PhoneNumber");

            return collection.ToValidationResult();
        }
    }
}