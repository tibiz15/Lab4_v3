using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.models
{
    class ListOperationModel
    {
        public static List<Person> IsAdults(List<Person> persons, bool adult)
        {
            return persons.Where(person => person.IsAdult == adult).ToList();
        }

        public static List<Person> HasBirthday(List<Person> persons, bool bday)
        {
            return persons.Where(person => person.IsBirthday == bday).ToList();
        }

        //mb check < > signs
        public static List<Person> OlderThan(List<Person> persons, DateTime check)
        {
            return persons.Where(person => person.BirthDate.Equals(check) || person.BirthDate.CompareTo(check) > 0).ToList();
        }

        public static List<Person> YoungerThan(List<Person> persons, DateTime check)
        {
            return persons.Where(person => person.BirthDate.Equals(check) || person.BirthDate.CompareTo(check) < 0).ToList();
        }

        public static List<Person> IsSunSign(List<Person> persons, SunSign check ,bool not)
        {
            if (not)
            {
                return persons.Where(person => !person.SunSign.Equals(check.ToString())).ToList();
            }
            return persons.Where(person => person.SunSign.Equals(check.ToString())).ToList();
        }

        public static List<Person> IsChineseZodiac(List<Person> persons, ChineseZodiac check, bool not)
        {
            if (not)
            {
                return persons.Where(person => !person.ChineseSign.Equals(check.ToString())).ToList();
            }
            return persons.Where(person => person.ChineseSign.Equals(check.ToString())).ToList();
        }


        public static List<Person> StartsWith(List<Person> persons, String check, StrCheck type)
        {
            if (type == StrCheck.name)
            {
                return persons.Where(person => person.Name.StartsWith(check)).ToList();
            }
            else if (type == StrCheck.surname)
            {
                return persons.Where(person => person.Surname.StartsWith(check)).ToList();
            }
            else
            {
                return persons.Where(person => person.Email.StartsWith(check)).ToList();
            }
        }

        public static List<Person> EndsWith(List<Person> persons, String check, StrCheck type)
        {
            if (type == StrCheck.name)
            {
                return persons.Where(person => person.Name.EndsWith(check)).ToList();
            }
            else if (type == StrCheck.surname)
            {
                return persons.Where(person => person.Surname.EndsWith(check)).ToList();
            }
            else
            {
                return persons.Where(person => person.Email.EndsWith(check)).ToList();
            }
        }

        public static List<Person> Contains(List<Person> persons, String check, StrCheck type)
        {
            if (type == StrCheck.name)
            {
                return persons.Where(person => person.Name.Contains(check)).ToList();
            }
            else if (type == StrCheck.surname)
            {
                return persons.Where(person => person.Surname.Contains(check)).ToList();
            }
            else
            {
                return persons.Where(person => person.Email.Contains(check)).ToList();
            }
        }

        static public List<Person> Sort(List<Person> persons, SortType type, bool ascending)
        {

            switch (type)
            {
                case SortType.name:

                    return @ascending ? persons.OrderBy(person => person.Name).ToList() : persons.OrderByDescending(person => person.Name).ToList();

                case SortType.surname:
                    return @ascending ? persons.OrderBy(person => person.Surname).ToList() : persons.OrderByDescending(person => person.Surname).ToList();

                case SortType.birthDate:
                    return @ascending ? persons.OrderBy(person => person.BirthDate).ToList() : persons.OrderByDescending(person => person.BirthDate).ToList();

                case SortType.email:
                    return @ascending ? persons.OrderBy(person => person.Email).ToList() : persons.OrderByDescending(person => person.Email).ToList();

                case SortType.adult:
                    return @ascending ? persons.OrderBy(person => person.IsAdult).ToList() : persons.OrderByDescending(person => person.IsAdult).ToList();

                case SortType.birthday:
                    return @ascending ? persons.OrderBy(person => person.IsBirthday).ToList() : persons.OrderByDescending(person => person.IsBirthday).ToList();

                case SortType.zodiac:
                    return @ascending ? persons.OrderBy(person => ZodiacToInt(person.SunSign)).ToList() : persons.OrderByDescending(person => ZodiacToInt(person.SunSign)).ToList();


                case SortType.chinese:
                    return @ascending ? persons.OrderBy(person => ChinseToInt(person.ChineseSign)).ToList() : persons.OrderByDescending(person => ChinseToInt(person.ChineseSign)).ToList();

                default:
                    return persons;
            }
        }

        static private int ZodiacToInt(String str)
        {
            SunSign.TryParse(str, true, out SunSign z);
            int val = (int)z;
            return val;
        }

        static private int ChinseToInt(String str)
        {
            ChineseZodiac.TryParse(str, true, out ChineseZodiac z);
            int val = (int)z;
            if (val < 4) val += 15;
            return val;
        }
    }
}
