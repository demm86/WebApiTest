using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Services.Impl
{
    public class FileServices : IFileServices
    {
        public string ReadFile(string url, string fileName)
        {
            try
            {

                string fullUrl = string.Concat(url, fileName);
                StreamReader reader = new StreamReader(fullUrl);

                string jsonString = reader.ReadToEnd();
                JsonDocument document = JsonDocument.Parse(jsonString);
                JsonElement root = document.RootElement;

                return jsonString;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public bool WriteFile(string url, string fileName,string content)
        {
            try
            {

                string fullUrl = string.Concat(url, fileName);  

                using (StreamWriter outputFile = new StreamWriter(fullUrl))
                {
                    outputFile.WriteLine(content);
                    outputFile.Close();
                }

                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }


        }
    }
}
