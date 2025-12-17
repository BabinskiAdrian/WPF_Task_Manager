using System.Collections.ObjectModel; // Tutaj siedzi ObservableCollection
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AB_Task_Manager
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        // 1. Kolekcja zadań
        // Używamy ObservableCollection, aby UI wiedziało o dodawaniu/usuwaniu wierszy.
        // Właściwość jest 'public', żeby Widok mógł ją "widzieć".
        public ObservableCollection<TodoItem> Tasks { get; set; }

        // 2. Właściwość dla pola tekstowego
        // Tutaj będziemy trzymać tekst wpisywany przez użytkownika "w locie".
        private string _newTaskTitle;
        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set
            {
                _newTaskTitle = value;
                OnPropertyChanged(); // Powiadamiamy widok, jeśli zmienimy to z kodu
            }
        }

        // To jest "uchwyt", za który złapie przycisk w XAML
        public ICommand AddTaskCommand { get; }

        // Konstruktor - inicjalizacja danych
        public MainViewModel()
        {
            Tasks = new ObservableCollection<TodoItem>();

            // Dodajmy przykładowe dane, żeby od razu coś widzieć po uruchomieniu
            Tasks.Add(new TodoItem { Title = "Nauczyć się WPF", IsDone = true });
            Tasks.Add(new TodoItem { Title = "Zrobić kawę", IsDone = false });

            // Domyślny tekst w polu wpisywania
            NewTaskTitle = "";

            // --- BRAKUJĄCA LINIJKA ---
            // Musimy stworzyć instancję RelayCommand i przekazać jej nasze metody
            AddTaskCommand = new RelayCommand(o => AddTask(), o => CanAddTask()); // <--- TUTAJ TO DODAJ
        }

        // komendy
        // Logika dodawania (uruchamia się po kliknięciu)
        private void AddTask()
        {
            var newTask = new TodoItem
            {
                Title = NewTaskTitle,
                IsDone = false
            };

            Tasks.Add(newTask); // Dodajemy do kolekcji -> Widok sam się odświeży!
            NewTaskTitle = "";  // Czyścimy pole -> TextBox sam się wyczyści!
        }

        // Logika walidacji (uruchamia się automatycznie)
        // Jeśli zwróci false, przycisk zrobi się szary (Disabled)
        private bool CanAddTask()
        {
            return !string.IsNullOrWhiteSpace(NewTaskTitle);
        }

        // --- Implementacja INotifyPropertyChanged (tak samo jak w TodoItem) ---
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
