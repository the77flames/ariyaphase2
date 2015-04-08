using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public class News : MongoEntity
    {
        public DateTime CreatedDate{ get; set; }
        public DateTime ExpireDate { get; set; }
        public string Caption { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }  
       
    }
}
