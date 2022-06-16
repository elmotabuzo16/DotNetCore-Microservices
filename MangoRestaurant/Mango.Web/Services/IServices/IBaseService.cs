using Mango.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Services.IServices
{
    // Generic method to call the service
    public interface IBaseService : IDisposable
    {
        // This is where we will receive
        ResponseDto responseModel { get; set; }
        // This is to send the request
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
