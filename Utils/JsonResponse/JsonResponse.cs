using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hugosEcommerce_api.Utils.JsonResponse;

public class JsonResponse: IJsonResponse
{
    public JsonResult CreateJsonResponse<Data>(int serverStatus, string serverMessage, Data otherData)
    {
        return new JsonResult(new { status = serverStatus, message = serverMessage, data = otherData });
    }


    public JsonResult CreateJsonResponse<Data>(int serverStatus, string serverMessage, List<Data> otherData)
    {
        return new JsonResult(new { status = serverStatus, message = serverMessage, data = otherData });
    }


}
