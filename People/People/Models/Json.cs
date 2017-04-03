using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace People.Models
{
    public class Json
    {
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        public string Reader()
        {
            string response;

            using (Stream s = GenerateStreamFromString("D:\belli\\Bureau\\workshop\\Application_Huka\\People\\People\\Assets\\ExempleJson.json"))
            {
                StreamReader strm = new StreamReader(s);
                response = strm.ReadToEnd();
                return response;
            }
        }
        
        public IList<JToken> Deserializing()
        {

            JObject json = JObject.Parse(Reader());

            IList<JToken> results = json["FastFood"].Children().ToList();
            return results;
        }


    }
    

}
