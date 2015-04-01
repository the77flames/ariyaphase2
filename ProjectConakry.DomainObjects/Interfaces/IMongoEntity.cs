using System;
using MongoDB.Bson;

namespace ProjectConakry.DomainObjects
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
