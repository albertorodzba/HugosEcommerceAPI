using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hugosEcommerce_api.Utils.JsonResponse;

namespace hugosEcommerce_api.Helpers.SQLHandler;

public interface ISQLQueryHandler
{
    string Escape(string property);

    
}
