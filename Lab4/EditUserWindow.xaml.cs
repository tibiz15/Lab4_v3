using System.Windows;
using Lab4.models;
using Lab4.viewmodels;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private bool _submitClosed = false;

        public bool SubmitClosed
        {
            get => _submitClosed;
            set => _submitClosed = value;
        }

        public EditUserWindow(Person data,bool editing = true)
        {
            InitializeComponent();
            DataContext = new EditUserViewModel(this,data,editing);
        }
    }
}
