using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public class MovieVector : Movie
    {
        public double RecentlyFeaturedScore { get; set; }
        public double RatingsScore { get; set; }
        public double PopularScore { get; set; }

        public double ComputeAggregatedScore()
        {
            return RatingsScore * 10 + RecentlyFeaturedScore * 20 + PopularScore * 5;
        }
    }
}
