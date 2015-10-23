using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularSPA.Api.Entities
{
    public abstract class DeletableEntity : Entity, IDeletableEntity
    {
        public virtual bool RecordStatus { get; set; }
    }
}