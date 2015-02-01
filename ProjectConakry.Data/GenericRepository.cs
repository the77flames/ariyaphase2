using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConakry.DomainObjects;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace ProjectConakry.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IMongoEntity
    {
        protected readonly MongoDBConnectionManager<T> MongoConnectionManager;
 
        public virtual void Create(T entity)
        {
            //// Save the entity with safe mode (WriteConcern.Acknowledged)
            var result = this.MongoConnectionManager.MongoCollection.Save(
                entity, 
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });
 
            if (!result.Ok)
            {
                // log the errors
            }
        }
 
        public virtual void Delete(string id)
        {
            var result = this.MongoConnectionManager.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id, 
                new ObjectId(id)), 
                RemoveFlags.None, 
                WriteConcern.Acknowledged);            
 
            if (!result.Ok)
            {
                //// Something went wrong
            }
        }

        protected GenericRepository()
        {
            MongoConnectionManager = new MongoDBConnectionManager<T>();
        }
 
        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionManager.MongoCollection.FindOne(entityQuery);
        }
 
        public abstract void Update(T entity);
    }
}
