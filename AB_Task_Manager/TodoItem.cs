using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AB_Task_Manager
{
    // MODEL
    // To jest zwykła klasa (POCO - Plain Old CLR Object).
    // Reprezentuje ona nasze dane, np. rekord z bazy danych.
    internal class TodoItem : INotifyPropertyChanged
    {
        private string _title;
        private bool _isDone;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    // Powiadamiamy WPF, że zmieniła się właściwość Title
                    OnPropertyChanged(); 
                }
            }
        }

        public bool IsDone
        {
            get
            {
                return _isDone;
            }
            set
            {
                if (_isDone != value)
                {
                    _isDone = value;
                    // Powiadamiamy WPF, że zmieniła się właściwość Title
                    OnPropertyChanged();
                }
            }
        }




        // --- Standardowa implementacja interfejsu ---

        // Zdarzenie, na które "nasłuchuje" WPF
        public event PropertyChangedEventHandler PropertyChanged;

        // Metoda pomocnicza do wywoływania zdarzenia
        // [CallerMemberName] sprawia, że nie musimy pisać OnPropertyChanged("Title"),
        // kompilator sam wstawi nazwę właściwości, która wywołała tę metodę.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
