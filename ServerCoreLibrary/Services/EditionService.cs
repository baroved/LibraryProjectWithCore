using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class EditionService : IEditionService
    {
        #region Properties
        private readonly IEditionRepository _editionRepository;
        #endregion

        #region Constructor
        public EditionService(IEditionRepository editionRepository)
        {
            _editionRepository = editionRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Edition>> GetAllEditions()
        {
            return await _editionRepository.GetAllEditions();
        }
        #endregion
    }
}
