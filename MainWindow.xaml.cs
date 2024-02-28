using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace WPFEJEdnik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Note> notes { get; set; } = new ObservableCollection<Note>();
        private Note selecNote;


        public MainWindow()
        {
            InitializeComponent();
            calendarik.SelectedDate = DateTime.Today;
            Note.ItemsSource = notes;
            LoasNote();


        }



        private void LoasNote()
        {
            notes.Clear();
            IEnumerable<Note> loasNote = JsonSD.Deserialize<Note>("eje.json");
            if (loasNote != null)
            { 
                foreach (Note note in loasNote)
                {
                    notes.Add(note);

                }
                DatePicker_SelectedDateChanged(null, null);
            
            }
        }
        private void SaohrnNotes ()
        {
            JsonSD.Serialize(notes, "eje.json");

        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e) //относиться к календарю 
        { 

            DateTime date = calendarik.SelectedDate ?? DateTime.Today;
            var filNotes = notes.Where(n => n.Date.Date == date.Date).ToList();
            ObservableCollection<Note> observableNotes = new ObservableCollection<Note>(filNotes);

            Note.ItemsSource = observableNotes;
            
        
        }





        
        

        private void izmen_note_Click(object sender, RoutedEventArgs e)
        {
            string zagl = zagl_note.Text.Trim();
            string opisn = opisn_note.Text.Trim();
            DateTime date = calendarik.SelectedDate ?? DateTime.Today;

            if (!string.IsNullOrWhiteSpace(zagl) || !string.IsNullOrWhiteSpace(opisn))
            {
                Note nuwNote = new Note(zagl, opisn, date); 
                notes.Add(nuwNote);
                DatePicker_SelectedDateChanged(null, null);
                SaohrnNotes();

            
            }
        }

        private void delete_note_Click(object sender, RoutedEventArgs e)
        {
            if (selecNote != null)
            { 
                notes.Remove(selecNote);
                DatePicker_SelectedDateChanged(null, null);
                SaohrnNotes();

            }
        }

        private void sohrn_note_Click(object sender, RoutedEventArgs e)
        {
            if (selecNote != null)
            { 
                selecNote.Zagl = zagl_note.Text;
                selecNote.Opisn = opisn_note.Text;
                titleList_note.Items.Refresh();
                SaohrnNotes();
            }
        }

        private void note_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selecNote = titleList_note.SelectedItem as Note;

            if (selecNote != null)
            { 
                zagl_note.Text = selecNote.Zagl;
                opisn_note.Text=selecNote.Opisn;
            
            }
        }

       
    }
}



