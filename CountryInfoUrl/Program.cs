using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CountryInfoUrl
{
    class Program
    {
        static void Main(string[] args)
        {
			string url = "https://restcountries.eu/rest/v2/name/eesti";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			var webResponse = request.GetResponse();
			var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                List<CountryDetails.RootObject> country = JsonConvert.DeserializeObject<List<CountryDetails.RootObject>>(response);

                Console.WriteLine($"Name: {country[0].name}");
                //Console.WriteLine(country[0].altSpellings[1]);
                Console.WriteLine($"Cioc: {country[0].cioc}");
                Console.WriteLine($"Country: {country[0].topLevelDomain[0]}");
                Console.WriteLine($"Capital: {country[0].capital}");
                Console.WriteLine($"Region: {country[0].region}");
                Console.WriteLine($"Population: {country[0].population}");
                Console.WriteLine($"Language: {country[0].languages[0].nativeName}");



            }
        }
    }
}
