﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularSPA.Api.Entitites.Validation
{
    public interface IValidatableObject
    {
        ValidationResult Validate(ActionType actionType);
    }
}
