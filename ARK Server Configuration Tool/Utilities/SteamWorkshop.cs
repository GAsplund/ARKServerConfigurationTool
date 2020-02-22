using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ARK_Server_Configuration_Tool.Structs;
using Newtonsoft.Json;

namespace ARK_Server_Configuration_Tool.Utilities
{
    class SteamWorkshop
    {
        public static PublishedFileDetailsResponse GetSteamModDetails(List<string> modIdList)
        {
            const int MAX_IDS = 20;
            const string SteamWebApiKey = "2C3F17EA493B9FF3EACC3D6D2FA29859";

            PublishedFileDetailsResponse response = null;

            try
            {
                if (modIdList.Count == 0)
                    return new PublishedFileDetailsResponse();

                //modIdList = ModUtils.ValidateModList(modIdList);

                int remainder;
                var totalRequests = Math.DivRem(modIdList.Count, MAX_IDS, out remainder);
                if (remainder > 0)
                    totalRequests++;

                var requestIndex = 0;
                while (requestIndex < totalRequests)
                {
                    var count = 0;
                    var postData = "";
                    for (var index = requestIndex * MAX_IDS; count < MAX_IDS && index < modIdList.Count; index++)
                    {
                        postData += $"&publishedfileids[{count}]={modIdList[index]}";
                        count++;
                    }

                    postData = $"key={SteamWebApiKey}&format=json&itemcount={count}{postData}";

                    var data = Encoding.ASCII.GetBytes(postData);

                    var httpRequest = WebRequest.Create("https://api.steampowered.com/ISteamRemoteStorage/GetPublishedFileDetails/v1/");
                    httpRequest.Timeout = 30000;
                    httpRequest.Method = "POST";
                    httpRequest.ContentType = "application/x-www-form-urlencoded";
                    httpRequest.ContentLength = data.Length;

                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    var responseString = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();

                    var result = JsonConvert.DeserializeObject<PublishedFileDetailsResult>(responseString);
                    if (result != null && result.response != null)
                    {
                        if (response == null)
                            response = result.response;
                        else
                        {
                            response.resultcount += result.response.resultcount;
                            response.publishedfiledetails.AddRange(result.response.publishedfiledetails);
                        }
                    }

                    requestIndex++;
                };

                return response ?? new PublishedFileDetailsResponse();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {nameof(GetSteamModDetails)}\r\n{ex.Message}");
                return null;
            }
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    }
}
