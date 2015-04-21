using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public interface IMedia : IMongoEntity
    {
        string ThumbNailImagePath { get; set; }
        string BiggerThumbNailImagePath { get; set; }
        string FullSizeImagePath { get; set; }
        string Name { get; set; }
        DateTime? ReleaseDate { get; set; }
        Sections SectionId { get; set; }
        string StreamingUrl { get; set; }
        string CoverArtistDisplayName { get; set; }
        Genres Genre { get; set; }
        int NumberOfViews { get; set; }
        int AverageRating { get; set; }
        int TotalVoters { get; set; }
    }
}
