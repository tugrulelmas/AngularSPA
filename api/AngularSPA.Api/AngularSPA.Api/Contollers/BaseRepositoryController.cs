using AngularSPA.Api.Data;
using AngularSPA.Api.Data.Mock;
using AngularSPA.Api.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularSPA.Api.Contollers
{
    [ValidationFilter()]
    public class BaseRepositoryController<T> : BaseApiController where T : class, new()
    {
        [Route("")]
        public virtual HttpResponseMessage Get() {
            IEnumerable<T> result = null;
            using (IUnitOfWork unitOfWork = GetUnitOfWork()) {
                result = unitOfWork.Repository.GetAll<T>();
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("")]
        public virtual HttpResponseMessage Get([FromUri]string id) {
            T result = null;
            using (IUnitOfWork unitOfWork = GetUnitOfWork()) {
                result = unitOfWork.Repository.GetByKey<T>(id);
            }
            if (result == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("Add")]
        public virtual HttpResponseMessage Add([FromBody]T entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }

            using (IUnitOfWork unitOfWork = GetUnitOfWork()) {
                unitOfWork.Repository.Add<T>(entity);
            }

            var response = Request.CreateResponse(HttpStatusCode.Created, entity);
            return response;
        }

        [HttpPut]
        [Route("update")]
        public virtual HttpResponseMessage Update([FromBody]T entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }

            using (IUnitOfWork unitOfWork = GetUnitOfWork()) {
                unitOfWork.Repository.Update<T>(entity);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("delete")]
        public virtual HttpResponseMessage Delete([FromBody]T entity, [FromUri]string d) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }

            using (IUnitOfWork unitOfWork = GetUnitOfWork()) {
                unitOfWork.Repository.Remove<T>(entity);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected IUnitOfWork GetUnitOfWork() {
            //mock UnitOfWork
            return new UnitOfWork();
        }
    }
}
