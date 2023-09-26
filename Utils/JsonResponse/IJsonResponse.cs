using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hugosEcommerce_api.Utils;

public interface IJsonResponse
{
    JsonResult CreateJsonResponse<Data>(int serverStatus, string serverMessage, Data otherData);
    JsonResult CreateJsonResponse<Data>(int serverStatus, string serverMessage, List<Data> otherData);


}
