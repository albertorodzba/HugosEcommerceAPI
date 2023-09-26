using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hugosEcommerce_api.Utils.Secrets;

    public static class EnvironmentVariables
    {
        public static string ApiKey = Environment.GetEnvironmentVariable("HugosEcommerce_FirebaseApiKey");
        public static string FirebaseAdminEmail = Environment.GetEnvironmentVariable("HugosEcommerce_FirebaseAdminEmail");
        public static string FirebaseAdminPassword = Environment.GetEnvironmentVariable("HugosEcommerce_FirebaseAdminPassword");
        public static string MysqlConnection = Environment.GetEnvironmentVariable("HugosEcommerce_MysqlConnection");
        public static string Bucket = Environment.GetEnvironmentVariable("HugosEcommerce_FirebaseBucket");

        public static string GoogleStorageCredentials = Environment.GetEnvironmentVariable("GoogleStorageCredentials");

        public static string JWTSecret = Environment.GetEnvironmentVariable("HugosEcommerce_JWTSecret");
    }
