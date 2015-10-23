using AngularSPA.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AngularSPA.Api.Data.Mock
{
    public class UserCollection : CollectionBase<User>
    {
        public UserCollection()
            : base() {
            list.Add(new User { Code = "ELMAST", Name = "Tuğrul Elmas", RecordStatus = true });
            list.Add(new User { Code = "VELIA", Name = "Ali Veli", RecordStatus = true });
            list.Add(new User { Code = "MEHMETA", Name = "Ahmet Mehmet", RecordStatus = false });
        }

        public override User GetByKey(object key) {
            return list.FirstOrDefault(l => l.Code == key.ToString());
        }
    }
}