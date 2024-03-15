using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab2Anikina.Models;
using Lab2Anikina.Views;
using Lab2Anikina.Tools;

namespace Lab2Anikina.ViewModels
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person = new Person();
        //private Person _person;
        private RelayCommand<object> _proceedCommand;
        private string _info1;
        private string _info2;
        private bool _isEnabled = true;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

       

        #region Properties

        public bool IsEnabled
        {
            set { _isEnabled = value; OnPropertyChanged("IsEnabled"); }
            get { return _isEnabled; }
        }
        public string FirstName
        {
            get { return _person.FirstName; }
            set { 
                _person.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value; OnPropertyChanged("LastName"); }
        }

        public DateTime BirthDate
        {
            get { return _person.BirthDate; }
            set { _person.BirthDate = value; OnPropertyChanged("BirthDate"); }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; OnPropertyChanged("Email"); }
        }

        public bool IsAdult
        {
            get { return _person.IsAdult; }
        }

        public string SunSign
        {
            get { return _person.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person.ChineseSign; }
        }

        public bool IsBirthday
        {
            get { return _person.IsBirthday; }
        }


        public string Info1
        {
            set
            {
                _info1 = value;
                OnPropertyChanged("Info1");
            }
            get { return _info1; }
        }


        public string Info2
        {
            set
            {
                _info2 = value;
                OnPropertyChanged("Info2");
            }
            get { return _info2; }
        }

        #endregion

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        private async void Proceed()
        {
            IsEnabled = false;
            await Task.Run(() =>
            {
                if (BirthDate.CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show("Error\nHaven't been born yet?");

                }
                else
                if (DateTime.Now.Year - BirthDate.Year > 136)
                {
                    MessageBox.Show("Error\nToo old to be true");

                }
                else
                {
                    if (IsBirthday)
                    {
                        MessageBox.Show("HAPPY BIRTHDAY!!!");
                    }
                    Task.Delay(2000).Wait();

                    Info1 = $"First name: {FirstName} \nLast name: {LastName}\n" +
                        $"Birthday: {BirthDate.Date.ToString("dd/MM/yyyy")} \nEmail: {Email}";
                    Info2 = $"IsAdult: {IsAdult} \nSunSign: {SunSign}\n" +
                        $"ChineseSign: {ChineseSign} \nIsBirthday: {IsBirthday}";
                }
            });
            IsEnabled = true;
        }


        private bool CanExecute(object obj)
        {
            //return true;
            return !String.IsNullOrWhiteSpace(_person.FirstName) &&
                !String.IsNullOrWhiteSpace(_person.LastName) &&
                (DateTime.MinValue != _person.BirthDate) &&
                !String.IsNullOrWhiteSpace(_person.Email);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
