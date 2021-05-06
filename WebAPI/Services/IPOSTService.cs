using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IPOSTService
    {
        Task<ServiceResponse<POSTFridgeProducts>> CreateFridgeProducts(POSTFridgeProducts addFridgeProducts);

        Task<ServiceResponse<PUTFridge>> UpadateFridge(PUTFridge updateFridge);
    }
}
