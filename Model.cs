using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HW4_dataMVP
{
    public class Model : IModel
    {
        public string name { get; set; }
        public string age { get; set; }

        public string keyWord { get; set; }
        public string List { get; set; }

        public void Save()
        {
            File.AppendAllText("data.txt", $"Name: {name} \tAge: {age}\n");
        }

        public void Delete()
        {
        
        }

        public void ShowAll()
        {
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            string dataInTextFile = sr.ReadToEnd();
            string copyOfTextfile = dataInTextFile;
            string text = null;

            fs.Close();
        }

        public void Search()
        {

        }
    }
}
