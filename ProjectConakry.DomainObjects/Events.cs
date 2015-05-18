using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public class Events : MongoEntity
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDateString { get; set; }
        public string Venue { get; set; }
        public string Time { get; set; }
        public string ImageThumbNailPath { get; set; }
        public string ImageBigPath { get; set; }
        public string TicketPrice { get; set; }
        public bool IsFreeEvent { get; set; }
        public string CoverArtistName { get; set; }

        public string EventDescription { get; set; }
       
    }
}
