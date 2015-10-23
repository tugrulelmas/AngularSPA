using AngularSPA.Api.Data;
using AngularSPA.Api.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularSPA.Api.Contollers
{
    public class BaseDeletableRepositoryController<T> : BaseRepositoryController<T> where T : class, IDeletableEntity, new()
    {
        [HttpPut]
        [Route("delete")]
        public override HttpResponseMessage Delete([FromBody]T entity, [FromUri]string d) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }

            entity.RecordStatus = false;
            using (IUnitOfWork unitOfWork = GetUnitOfWork()) {
                unitOfWork.Repository.Update<T>(entity);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
