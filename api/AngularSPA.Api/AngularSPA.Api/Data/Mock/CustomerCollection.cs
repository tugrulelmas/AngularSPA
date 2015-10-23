using AngularSPA.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AngularSPA.Api.Data.Mock
{
    public class CustomerCollection : CollectionBase<Customer>
    {
        public CustomerCollection()
            : base() {
            list.Add(new Customer { Code = "1234", Name = "Tuğrul Elmas", PhoneNumber = "4444", RecordStatus = true });
            list.Add(new Customer { Code = "1235", Name = "Ali Veli", PhoneNumber = "2222", RecordStatus = true });
            list.Add(new Customer { Code = "1236", Name = "Ahmet Mehmet", PhoneNumber = "8888", RecordStatus = false });
        }

        public override Customer GetByKey(object key) {
            return list.FirstOrDefault(l => l.Code == key.ToString());
        }
    }
}