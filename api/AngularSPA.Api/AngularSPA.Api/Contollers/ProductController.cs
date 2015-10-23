using AngularSPA.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularSPA.Api.Contollers
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseDeletableRepositoryController<Product>
    {

    }
}
