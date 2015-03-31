﻿using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public class Song : Media
    {
        public List<Artist> Artists { get; set; }
        public int AlbulmID { get; set; }
       
    }
}
