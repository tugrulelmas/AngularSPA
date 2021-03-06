﻿using AngularSPA.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AngularSPA.Api.Data.Mock
{
    public class Repository : IRepository
    {
        public void Add<T>(T entity) where T : class, new() {
            GetCollection<T>().Add(entity);
        }

        public bool Update<T>(T entity) where T : class, new() {
            return true;
        }

        public void Remove<T>(T entity) where T : class, new() {
            GetCollection<T>().Remove(entity);
        }

        public T GetByKey<T>(object key) where T : class, new() {
            return GetCollection<T>().GetByKey(key);
        }

        public IEnumerable<T> GetAll<T>() where T : class, new() {
            return GetCollection<T>().ToList();
        }

        public IEnumerable<T> GetBy<T>(Expression<Func<T, bool>> predicate, object order = null) where T : class, new() {
            return GetCollection<T>().GetBy(predicate);
        }

        private CollectionBase<T> GetCollection<T>() where T : class, new() {
            if (typeof(T) == typeof(Customer)) {
                return new CustomerCollection() as CollectionBase<T>;
            } else if (typeof(T) == typeof(Product)) {
                return new ProductCollection() as CollectionBase<T>;
            } else if (typeof(T) == typeof(User)) {
                return new UserCollection() as CollectionBase<T>;
            }
            throw new NotSupportedException();
        }
    }
}