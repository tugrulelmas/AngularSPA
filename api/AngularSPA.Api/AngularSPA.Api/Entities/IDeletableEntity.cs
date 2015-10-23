using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularSPA.Api.Entities
{
    public interface IDeletableEntity
    {
        bool RecordStatus { get; set; }
    }
}
