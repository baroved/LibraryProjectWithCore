using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class WriterService : IWriterService
    {
        #region Properties
        private readonly IWriterRepository _writerRepository;
        #endregion

        #region Constructor
        public WriterService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Writer>> GetAllWritersAsync()
        {
            return await _writerRepository.GetAllWriterAsync();
        }
        #endregion
    }
}
