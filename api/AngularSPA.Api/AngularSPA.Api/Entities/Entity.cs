﻿using AngularSPA.Api.Entitites.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularSPA.Api.Entities
{
    public abstract class Entity : IEntity, IValidatableObject
    {
        public abstract ValidationResult Validate(ActionType actionType);
    }
}