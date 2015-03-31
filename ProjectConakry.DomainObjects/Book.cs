using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public class Book : Media
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
       


       
    }
}
