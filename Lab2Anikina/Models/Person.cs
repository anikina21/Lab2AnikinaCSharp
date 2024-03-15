using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab2Anikina.Models
{
    #region enums
    enum WesternZodiac
    {
        Aquarius = 1,
        Pieces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn
    }

    enum ChineseZodiac
    {
        Monkey = 0,
        Rooster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Sheep
    }
    #endregion
    internal class Person
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;
        #endregion

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue)
        {
        }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, "", birthDate)
        {
        }

        public Person() : this("", "", "", DateTime.MinValue){ }

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public bool IsAdult
        {
            get { return CheckIfAdult(); }
        }

        public string SunSign
        {
            get { return findWestZodiac(); }
        }
        public string ChineseSign
        {
            get { return findChinazodiac(); }
        }

        public bool IsBirthday
        {
            get { return CheckIfBirthDay(); }
        }
        #endregion

        private bool CheckIfAdult() 
        {
            if (PersonAge() >= 18)
            {
                return true;
            }
            return false; 
        }

        private bool CheckIfBirthDay()
        {
            if (BirthDate.Day == DateTime.Now.Day && BirthDate.Month == DateTime.Now.Month)
            {
                return true;
            }
            return false;
        }

        private int PersonAge()
        {
            int res = DateTime.Now.Year - this._birthDate.Year;
            if (DateTime.Now.DayOfYear < this._birthDate.DayOfYear) res -= 1;
            return res;

        }

        #region findingZodiac
        private string findChinazodiac()
        {
            ChineseZodiac res;
            if (BirthDate.Month == 1)
            {
                if (BirthDate.Year % 12 != 0) res = (ChineseZodiac)(BirthDate.Year % 12 - 1);
                else res = (ChineseZodiac)12;
            }
            else res = (ChineseZodiac)(BirthDate.Year % 12);

            return res.ToString();
        }
        private string findWestZodiac()
        {
            int m = BirthDate.Month;
            int d = BirthDate.Day;
            WesternZodiac res = (WesternZodiac)12;
            switch (m)
            {
                case 1:
                    if (d < 21) res = (WesternZodiac)12;
                    else res = (WesternZodiac)1;
                    break;
                case 2:
                    if (d < 20) res = (WesternZodiac)1;
                    else res = (WesternZodiac)2;
                    break;
                case 3:
                    if (d < 21) res = (WesternZodiac)2;
                    else res = (WesternZodiac)3;
                    break;
                case 4:
                    if (d < 21) res = (WesternZodiac)3;
                    else res = (WesternZodiac)4;
                    break;
                case 5:
                    if (d < 22) res = (WesternZodiac)4;
                    else res = (WesternZodiac)5;
                    break;
                case 6:
                    if (d < 22) res = (WesternZodiac)5;
                    else res = (WesternZodiac)6;
                    break;
                case 7:
                    if (d < 24) res = (WesternZodiac)6;
                    else res = (WesternZodiac)7;
                    break;
                case 8:
                    if (d < 24) res = (WesternZodiac)7;
                    else res = (WesternZodiac)8;
                    break;
                case 9:
                    if (d < 24) res = (WesternZodiac)8;
                    else    res = (WesternZodiac)9;
                    break;
                case 10:
                    if (d < 24) res = (WesternZodiac)9;
                    else res = (WesternZodiac)10;
                    break;
                case 11:
                    if (d < 23) res = (WesternZodiac)10;
                    else res = (WesternZodiac)11;
                    break;
                case 12:
                    if (d < 26) res = (WesternZodiac)11;
                    else res = (WesternZodiac)12;
                    break;
            }
            return res.ToString();
        }

        #endregion
    }
}
