using System.Collections.Generic;

namespace Sanatorium.Models
{
    public class HomeViewModels
    {
        public IList<Article> Articles { get; set; }
        public IList<Sanatorium> Sanatoriums { get; set; }
        public IList<Region> Regions { get; set; }

    }
}