using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Lab4.models;
using Lab4.tools;

namespace Lab4.viewmodels
{
    class MainViewModel : PropertyChanger
    {

        private UsersDataModel _usersData = new UsersDataModel();
        private UsersDataModel UsersData
        {
            get => _usersData;
        }

        public List<Person> Users
        {
            get
            {
                return UsersData.UserData;
            }
        }

        private bool _hintChecked = true;

        public bool HintCheck
        {
            private get => _hintChecked;
            set
            {
                _hintChecked = value;
                OnPropertyChanged("HintVisibility");
            }
        }

        public Visibility HintVisibility
        {
            get { return (HintCheck) ? Visibility.Visible : Visibility.Hidden; }
        }

        private bool _filter = false;

        public bool Filter
        {
            private get { return _filter; }
            set
            {
                _filter = value;
                OnPropertyChanged("FilterVisibility");
                OnPropertyChanged("ChineseNot");
                OnPropertyChanged("ZodiacNot");
                UpdateGrid();
            }
        }

        public Visibility FilterVisibility
        {
            get { return (Filter) ? Visibility.Visible : Visibility.Hidden; }
        }

        private object _selectedFileInfo;

        public object SelectedFileInfo
        {
            private get { return _selectedFileInfo; }
            set
            {
                if (value != _selectedFileInfo)
                {
                    _selectedFileInfo = value;
                    OnPropertyChanged("SelectedFileInfo");
                }
            }
        }

        private String _selectedSortIndex = "0";

        public String SelectedSortIndex
        {
            private get => _selectedSortIndex;
            set
            {
                _selectedSortIndex = value;
                UpdateGrid();
            }
        }

        private String _selectedZodiac = "0";

        public String SelectedZodiac
        {
            private get => _selectedZodiac;
            set
            {
                _selectedZodiac = value;

                OnPropertyChanged("ZodiacNot");
                UpdateGrid();
            }
        }

        private String _selectedChinese = "0";

        public String SelectedChinese
        {
            private get => _selectedChinese;
            set
            {
                _selectedChinese = value;
                OnPropertyChanged("ChineseNot");
                UpdateGrid();
            }
        }



        private DateTime? _olderThanDate;
        public DateTime? OlderThanDate
        {
            private get => _olderThanDate;
            set
            {
                OnPropertyChanged("OlderThanDate");
                _olderThanDate = value;
                UpdateGrid();
            }
        }

        private DateTime? _youngerThanDate;
        public DateTime? YoungerThanDate
        {
            private get => _youngerThanDate;
            set
            {
                OnPropertyChanged("YoungerThanDate");
                _youngerThanDate = value;
                UpdateGrid();
            }
        }

        private bool _notChinese;
        public bool NotChinese
        {
            private get => _notChinese;
            set
            {
                _notChinese = value;
                UpdateGrid();
            }
        }

        private bool _notZodiac;
        public bool NotZodiac
        {
            private get => _notZodiac;
            set
            {
                _notZodiac = value;
                UpdateGrid();
            }
        }

        //=========================

        private String _emailStarts;
        public String EmailStarts
        {
            private get => _emailStarts;
            set
            {
                _emailStarts = value;

                UpdateGrid();
            }
        }

        private String _emailEnds;
        public String EmailEnds
        {
            private get => _emailEnds;
            set
            {
                _emailEnds = value;
                UpdateGrid();
            }
        }

        private String _emailContains;
        public String EmailContains
        {
            private get => _emailContains;
            set
            {
                _emailContains = value;
                UpdateGrid();
            }
        }

        //=============================


        private String _nameStarts;
        public String NameStarts
        {
            private get => _nameStarts;
            set
            {
                _nameStarts = value;
                UpdateGrid();
            }
        }

        private String _nameEnds;
        public String NameEnds
        {
            private get => _nameEnds;
            set
            {
                _nameEnds = value;
                UpdateGrid();
            }
        }

        private String _nameContains;
        public String NameContains
        {
            private get => _nameContains;
            set
            {
                _nameContains = value;
                UpdateGrid();
            }
        }

        //=========================================

        private String _surnameStarts;
        public String SurnameStarts
        {
            private get => _surnameStarts;
            set
            {
                _surnameStarts = value;
                UpdateGrid();
            }
        }

        private String _surnameEnds;
        public String SurnameEnds
        {
            private get => _surnameEnds;
            set
            {
                _surnameEnds = value;
                UpdateGrid();
            }
        }

        private String _surnameContains;
        public String SurnameContains
        {
            private get => _surnameContains;
            set
            {
                _surnameContains = value;
                UpdateGrid();
            }
        }



        //===================================

        public Visibility ZodiacNot
        {
            get
            {
                return (Filter) ? (SelectedZodiac == "0" ? Visibility.Hidden : Visibility.Visible) : Visibility.Hidden;
            }
        }

        public Visibility ChineseNot
        {
            get
            {
                return (Filter) ? (SelectedChinese == "0" ? Visibility.Hidden : Visibility.Visible) : Visibility.Hidden;
            }
        }

        private bool? _adultCheck = false;
        public bool? AdultCheck
        {
            private get => _adultCheck;
            set
            {
                _adultCheck = value;
                UpdateGrid();
            }
        }

        private bool? _bdayCheck = false;
        public bool? BdayCheck
        {
            private get => _bdayCheck;
            set
            {
                _bdayCheck = value;
                UpdateGrid();
            }
        }

        private bool _ascendingSort = false;

        public bool AscendingSort
        {
            private get => _ascendingSort;
            set
            {

                _ascendingSort = value;
                UpdateGrid();
            }
        }



        private ICommand _removeUserCommand;

        public ICommand RemoveUserCommand
        {
            private get => _removeUserCommand;
            set
            {
                _removeUserCommand = value;
            }
        }

        private ICommand _editUserCommand;

        public ICommand EditUserCommand
        {
            private get => _editUserCommand;
            set
            {
                _editUserCommand = value;
            }
        }

        private ICommand _addUserCommand;

        public ICommand AddUserCommand
        {
            private get => _addUserCommand;
            set
            {
                _addUserCommand = value;
            }
        }

        private Window _window;

        public MainViewModel(Window w)
        {
            _window = w;
            RemoveUserCommand = new RelayCommand(new Action<object>(RemoveUserAction));
            EditUserCommand = new RelayCommand(new Action<object>(EditUserAction));
            AddUserCommand = new RelayCommand(new Action<object>(AddUserAction));
        }

        private async void RemoveUserAction(object obj)
        {
            await Task.Run(() => RemoveUser());
        }

        private void RemoveUser()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                var user = (SelectedFileInfo as Person);
                Users.Remove(user);

                MessageBox.Show("User removed!");

                UpdateGrid();
                SaveState();
            });
        }

        private async void EditUserAction(object obj)
        {
            await Task.Run(() => EditUser());
        }

        private void EditUser()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {

                EditUserWindow window = new EditUserWindow(SelectedFileInfo as Person);
                window.ShowDialog();

                MessageBox.Show("User edited!");

                UpdateGrid();
                SaveState();
            });
        }

        private async void AddUserAction(object obj)
        {
            await Task.Run(() => AddUser());
        }

        private void AddUser()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Person user = new Person("a", "b", DateTime.Today, "c@c.c");
                EditUserWindow window = new EditUserWindow(user, false);
                window.ShowDialog();
                if (window.SubmitClosed)
                {
                    UsersData.UserData.Add(user);
                    MessageBox.Show("User added!");
                }

                UpdateGrid();
                SaveState();
            });
        }

        private async void UpdateGrid()
        {
            await Task.Run(() =>
            {
                List<Person> operated = FilterAndSort(Users);

                //updates the grid view
                Application.Current.Dispatcher.Invoke((Action) delegate
                {
                    (_window.FindName("DataGrid") as DataGrid).ItemsSource = operated;
                    (_window.FindName("DataGrid") as DataGrid).Items.Refresh();
                });

            });
        }

        private void SaveState()
        {
            //saves the state to file
            UsersData.Serialize(UsersData.SavePath);
        }

        private List<Person> FilterAndSort(List<Person> rawData)
        {

            if (Filter)
            {
                if (AdultCheck == true)
                {
                    rawData = ListOperationModel.IsAdults(rawData, true);
                }
                else if (AdultCheck == null)
                {
                    rawData = ListOperationModel.IsAdults(rawData, false);
                }

                if (BdayCheck == true)
                {
                    rawData = ListOperationModel.HasBirthday(rawData, true);
                }
                else if (BdayCheck == null)
                {
                    rawData = ListOperationModel.HasBirthday(rawData, false);
                }

                if (OlderThanDate != null)
                {
                    rawData = ListOperationModel.OlderThan(rawData, (DateTime)OlderThanDate);
                }

                if (YoungerThanDate != null)
                {
                    rawData = ListOperationModel.YoungerThan(rawData, (DateTime)YoungerThanDate);
                }

                if (SelectedChinese != "0")
                {
                    int index = int.Parse(SelectedChinese) + 3;
                    if (index >= 12) index -= 12;
                    rawData = ListOperationModel.IsChineseZodiac(rawData, (ChineseZodiac)index, NotChinese);
                }

                if (SelectedZodiac != "0")
                {
                    int index = int.Parse(SelectedZodiac) - 1;

                    rawData = ListOperationModel.IsSunSign(rawData, (SunSign)index, NotZodiac);
                }

                //==============

                if (!String.IsNullOrEmpty(EmailStarts))
                {
                    rawData = ListOperationModel.StartsWith(rawData, EmailStarts, StrCheck.email);
                }

                if (!String.IsNullOrEmpty(EmailEnds))
                {
                    rawData = ListOperationModel.EndsWith(rawData, EmailEnds, StrCheck.email);
                }

                if (!String.IsNullOrEmpty(EmailContains))
                {
                    rawData = ListOperationModel.Contains(rawData, EmailContains, StrCheck.email);
                }

                //================

                if (!String.IsNullOrEmpty(SurnameStarts))
                {
                    rawData = ListOperationModel.StartsWith(rawData, SurnameStarts, StrCheck.surname);
                }

                if (!String.IsNullOrEmpty(SurnameEnds))
                {
                    rawData = ListOperationModel.EndsWith(rawData, SurnameEnds, StrCheck.surname);
                }

                if (!String.IsNullOrEmpty(SurnameContains))
                {
                    rawData = ListOperationModel.Contains(rawData, EmailContains, StrCheck.surname);
                }

                //================

                if (!String.IsNullOrEmpty(NameStarts))
                {
                    rawData = ListOperationModel.StartsWith(rawData, NameStarts, StrCheck.name);
                }

                if (!String.IsNullOrEmpty(NameEnds))
                {
                    rawData = ListOperationModel.EndsWith(rawData, NameEnds, StrCheck.name);
                }

                if (!String.IsNullOrEmpty(NameContains))
                {
                    rawData = ListOperationModel.Contains(rawData, EmailContains, StrCheck.name);
                }

                //===============
            }


            if (SelectedSortIndex != "0")
            {
                int index = int.Parse(SelectedSortIndex);


                rawData = ListOperationModel.Sort(rawData, (SortType)index, !AscendingSort);

            }

            return rawData;
        }
    }
}
