using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class HttpExtensions
    {
        public static DownloadManagerUser GetDownloadManagerUser(this HttpRequestBase request)
        {

            var hasAuthorization = request.Headers.AllKeys.All(x => x == "Authorization");

            if (!hasAuthorization)
            {
                return default(DownloadManagerUser);
            }
            
            var authorization = request.Headers.Get("Authorization")

                // remove Header schema form header value, that it's Basic 
                .Replace("Basic", "")

                // remove all wight spaces form header value
                .Trim();

            // the default format of the header value is base64 we should decode 
            // it to get its value
            var encodeToken = authorization.Base64Decode();

            // the passed information format is like this username:password 
            // If we wanna to get this details we have to split theme with `:` character 
            var fetchDetails = encodeToken.Split(':');

            
            return new DownloadManagerUser(
                userName: fetchDetails[0],
                password: fetchDetails[1]
            );
        }


        private static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}