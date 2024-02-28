using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFEJEdnik
{
    public class JsonSD
    {
        public static void Serialize<T>(IEnumerable<T> data, string sohrn)// сохраняем 
        {
            string sohrndannh = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string uesfile = System.IO.Path.Combine(sohrndannh, sohrn);
            string jsondata = JsonConvert.SerializeObject(data);

            File.WriteAllText(uesfile, jsondata);

        }
        
        public static IEnumerable<T> Deserialize<T>(string sohrn) //передаем данные
        {
            string sohrndannh = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string uesfile = System.IO.Path.Combine(sohrndannh, sohrn);


            if (File.Exists(uesfile))
            {
                string jsongata = File.ReadAllText(uesfile);
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsongata);

            }
            return null;

        }

    }
}
