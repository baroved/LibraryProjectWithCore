using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class PublisherService : IPublisherService
    {
        #region Properties
        private readonly IPublisherRepository _publisherRepository;
        #endregion

        #region Constructor
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Publisher>> GetAllPublisherAsync()
        {
            return await _publisherRepository.GetAllPublisherAsync();
        }
        #endregion
    }
}
