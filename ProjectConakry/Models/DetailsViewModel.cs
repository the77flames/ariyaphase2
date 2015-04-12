using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectConakry.Web.Ariya
{
    public class DetailsViewModel
    {
        public string FullSizeImagePath { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string StreamingUrl { get; set; }
        public string CoverArtistDisplayName { get; set; }
        public Genres Genre { get; set; }
    }
}