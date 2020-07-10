using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpService
    {
        #region Methods
        Task<R> PostAsync<T, R>(string url, T payload);
        Task<R> PostAsyncJson<T, R>(string url, T payload);
        Task<R> GetAsync<R>(string url);
        Task<R> GetAsyncJason<R>(string url);
        #endregion
    }
}
