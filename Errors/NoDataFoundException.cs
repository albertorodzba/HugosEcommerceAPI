using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hugosEcommerce_api.Errors
{
    public class NoDataFoundException : Exception
    {
        // public string message(){
        //     if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMEN").Equals("Development")){
        //         return 
        //     }
        // }
        public NoDataFoundException() : base("No data found") 
        {
        }
    }
}