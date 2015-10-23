using AngularSPA.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AngularSPA.Api.Data.Mock
{
    public class ProductCollection : CollectionBase<Product>
    {
        public ProductCollection()
            : base() {
            list.Add(new Product { Code = "1234", Name = "Mouse", RecordStatus = true });
            list.Add(new Product { Code = "1235", Name = "Monitor", RecordStatus = true });
            list.Add(new Product { Code = "1236", Name = "Keyboard", RecordStatus = false });
        }

        public override Product GetByKey(object key) {
            return list.FirstOrDefault(l => l.Code == key.ToString());
        }
    }
}