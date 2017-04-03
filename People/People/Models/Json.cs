using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

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
            }

            List<Json> json = JsonConvert.DeserializeObject<List<Json>>(response);

            return json.ToString();
        }
        
    }
    

}
