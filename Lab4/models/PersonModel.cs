using System;
using Lab4.exceptions;
using Lab4.tools;

namespace Lab4.models
{
    enum ChineseZodiac { Rat = 4, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey = 0, Rooster, Dog, Pig };

    enum SunSign { Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces };
    [Serializable]
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }

        private Person(string name, string surname)
        {
            if (IsValidName(name))
            {
                Name = name;
            }
            else
            {
                throw new ArgumentException("Invalid name!");
            }

            if (IsValidName(surname))
            {
                Surname = surname;
            }
            else
            {
                throw new ArgumentException("Invalid surname!");
            }

        }

        public Person(string name, string surname, string email) : this(name, surname)
        {
            if (IsValidEmail(email))
            {
                Email = email;
            }
            else
            {
                throw new InvalidEmailException(email);
            }
        }

        public Person(string name, string surname, DateTime birthDate) : this(name, surname)
        {
            if (IsDeadPersonBirthDate(birthDate))
            {
                throw new DeadPersonBirthDateException(birthDate);
            }
            else if (IsFutureBirthDate(birthDate))
            {
                throw new FutureBirthDateException(birthDate);
            }
            else
            {
                BirthDate = birthDate;
            }
        }

        public Person(string name, string surname, DateTime birthDate, string email) : this(name, surname, email)
        {
            if (IsDeadPersonBirthDate(birthDate))
            {
                throw new DeadPersonBirthDateException(birthDate);
            }
            else if (IsFutureBirthDate(birthDate))
            {
                throw new FutureBirthDateException(birthDate);
            }
            else
            {
                BirthDate = birthDate;
            }
        }

        public bool IsAdult
        {
            get
            {
                var age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate > DateTime.Today.AddYears(-age)) age--;
                if (age >= 18) return true;
                return false;
            }
        }

        public string SunSign
        {
            get
            {
                int month = BirthDate.Month;
                int day = BirthDate.Day;
                switch (month)
                {
                    case 1:
                        if (day <= 19)
                            return "Capricorn";
                        else
                            return "Aquarius";

                    case 2:
                        if (day <= 18)
                            return "Aquarius";
                        else
                            return "Pisces";
                    case 3:
                        if (day <= 20)
                            return "Pisces";
                        else
                            return "Aries";
                    case 4:
                        if (day <= 19)
                            return "Aries";
                        else
                            return "Taurus";
                    case 5:
                        if (day <= 20)
                            return "Taurus";
                        else
                            return "Gemini";
                    case 6:
                        if (day <= 20)
                            return "Gemini";
                        else
                            return "Cancer";
                    case 7:
                        if (day <= 22)
                            return "Cancer";
                        else
                            return "Leo";
                    case 8:
                        if (day <= 22)
                            return "Leo";
                        else
                            return "Virgo";
                    case 9:
                        if (day <= 22)
                            return "Virgo";
                        else
                            return "Libra";
                    case 10:
                        if (day <= 22)
                            return "Libra";
                        else
                            return "Scorpio";
                    case 11:
                        if (day <= 21)
                            return "Scorpio";
                        else
                            return "Sagittarius";
                    case 12:
                        if (day <= 21)
                            return "Sagittarius";
                        else
                            return "Capricorn";
                }
                return "Error";
            }
        }

        public string ChineseSign
        {
            get
            {
                return ((ChineseZodiac)(BirthDate.Year % 12)).ToString();
            }
        }

        public bool IsBirthday
        {
            get
            {
                return (BirthDate.Day == DateTime.Today.Day) && (BirthDate.Month == DateTime.Today.Month);
            }
        }

        //applies to name and surname
        //no numbers and punctuation signs except , . ' -
        private bool IsValidName(String name)
        {
            name = name.Trim();

            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) return false;

            if (name[0] == '\'' || name[0] == ',' || name[0] == '.' || name[0] == '-') return false;
            if (name[name.Length - 1] == '\'' || name[name.Length - 1] == ',' || name[name.Length - 1] == '.' || name[name.Length - 1] == '-') return false;

            bool allPunct = true;



            foreach (char c in name)
            {
                if (Char.IsDigit(c)) return false;
                if (Char.IsPunctuation(c) && c != '\'' && c != ',' && c != '.' && c != '-') return false;
                if (c != '\'' && c != ',' && c != '.' && c != '-')
                {
                    allPunct = false;
                }
            }

            if (allPunct) return false;

            return true;
        }

        private bool IsValidEmail(String email)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email)) return false;
            if (email.Count('@') != 1) return false; //must be 1

            String name = email.Split('@')[0];
            String domain = email.Split('@')[1];

            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) return false;
            if (String.IsNullOrEmpty(domain) || String.IsNullOrWhiteSpace(domain)) return false;

            if (name[0] == '.' || name[0] == '@' || name[0] == ',') return false;
            if (name[name.Length - 1] == '.' || name[name.Length - 1] == ',' || name[name.Length - 1] == '@') return false;

            if (domain[0] == '.' || domain[0] == '@' || domain[0] == ',') return false;
            if (domain[domain.Length - 1] == '.' || domain[domain.Length - 1] == ',' || domain[domain.Length - 1] == '@') return false;

            if (!domain.Contains(".")) return false;
            if (domain.Contains(",")) return false;

            return true;
        }

        private bool IsFutureBirthDate(DateTime birthDate)
        {
            int result = DateTime.Compare(DateTime.Today, birthDate);
            if (result < 0)
            {
                return true;
            }
            return false;
        }

        private bool IsDeadPersonBirthDate(DateTime birthDate)
        {
            if (DateTime.Today.Year - birthDate.Year > 135)
            {
                return true;
            }
            return false;
        }
    }
}
