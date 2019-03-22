using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lab4.exceptions;
using Lab4.models;
using Lab4.tools;

namespace Lab4.viewmodels
{
    class EditUserViewModel : PropertyChanger
    {
        private Person _user;
        private Window _window;

        private DateTime? _birthDate = null;
        private string _nameText;
        private string _surnameText;
        private string _emailText;

        private bool[] _validFields = new bool[4];
        private bool[] ValidFields { get => _validFields; set => _validFields = value; }

        private ICommand _proceedCommand;

        public DateTime BirthDate { get => (DateTime)_birthDate; set => _birthDate = value; }
        public string NameText { get => _nameText; set => _nameText = value; }
        public string SurnameText { get => _surnameText; set => _surnameText = value; }
        public string EmailText { get => _emailText; set => _emailText = value; }

        private Person User
        {
            get => _user;
            set => _user = value;
        }

        private Window Window
        {
            get => _window;
            set => _window = value;
        }

        public bool ValidName
        {
            get => ValidFields[0];
            set
            {
                ValidFields[0] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool ValidSurName
        {
            get => ValidFields[1];
            set
            {
                ValidFields[1] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool ValidEmail
        {
            get => ValidFields[2];
            set
            {
                ValidFields[2] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool ValidBirth
        {
            get => ValidFields[3];
            set
            {
                ValidFields[3] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool FilledFields
        {
            get
            {
                return ValidFields.All(x => x);
            }

        }

        public ICommand ProceedCommand
        {
            get => _proceedCommand;
            set
            {
                _proceedCommand = value;
            }
        }

        public EditUserViewModel(Window w,Person person,bool editing) //for editing existing users
        {
            ProceedCommand = new RelayCommand(new Action<object>(ProceedAction));
            User = person;
            Window = w;
            if (editing)
            {
                NameText = User.Name;
                SurnameText = User.Surname;
                EmailText = User.Email;
                BirthDate = User.BirthDate;
                ValidFields = new []{ true, true, true, true };
            }
        }

       
        private async void ProceedAction(object obj)
        {
            await Task.Run(() => Submit());
        }

        private void Submit()
        {
            Application.Current.Dispatcher.Invoke((Action) delegate
            {
                try
                {
                    //check if all values are valid
                    new Person(NameText, SurnameText, BirthDate, EmailText);
                        
                    User.Email = EmailText;
                    User.Name = NameText;
                    User.Surname = SurnameText;
                    User.BirthDate = BirthDate;
                    (Window as EditUserWindow).SubmitClosed = true;
                    Window.Close();
                }
                catch (FutureBirthDateException e)
                {
                    MessageBox.Show("Future birth date selected: " + e.InvalidBirthDate.ToLongDateString());
                }
                catch (DeadPersonBirthDateException e)
                {
                    MessageBox.Show("Dead person birth date selected: " + e.InvalidBirthDate.ToLongDateString());
                }
                catch (InvalidEmailException e) // for email
                {
                    MessageBox.Show(e.Message);
                }
                catch (ArgumentException e) // name and surname
                {
                    MessageBox.Show(e.Message);
                }

            });
        }


    }
}
