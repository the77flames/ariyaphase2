using Microsoft.Practices.Unity;
using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectConakry.Web.Ariya
{
    public static class DetailsViewHandler 
    {
        private static MovieManagementService _movieManagementService;
        private static SongManagementService _songManagementService;
        private static BookManagementService _bookManagementService;

        static DetailsViewHandler()
        {
            IUnityContainer uContainer = new UnityContainer();
            _movieManagementService = uContainer.Resolve<MovieManagementService>(); 
            _songManagementService = uContainer.Resolve<SongManagementService>(); 
            _bookManagementService = uContainer.Resolve<BookManagementService>(); 
        }
        public static DetailsViewModel Invoke(EntityTypes entityType, string id)
        {
            IMedia result = null;
            if (entityType == EntityTypes.Movies)
                result = _movieManagementService.GetById(id);
            if(entityType == EntityTypes.Songs)
                result = _songManagementService.GetById(id);
            if (entityType == EntityTypes.Books)
                result = _bookManagementService.GetById(id);

            return new DetailsViewModel
            {
                FullSizeImagePath = result.FullSizeImagePath,
                Name = result.Name,
                ReleaseDate = result.ReleaseDate,
                StreamingUrl = result.StreamingUrl,
                CoverArtistDisplayName = result.CoverArtistDisplayName,
                Genre = result.Genre
            };
        }
    }
}