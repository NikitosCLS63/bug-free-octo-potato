using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WPFEJEdnik
{
    public class Note
    {

        public string Zagl { get; set; }
        public string Opisn { get; set; }

        public DateTime Date { get; set; }
        public static ObservableCollection<Note> ItemsSource { get; internal set; }
        

        public Note(string zagl, string opisn, DateTime date)
        {

            Zagl = zagl;
            Opisn = opisn;
            Date = date;
        }

    }
    

}



