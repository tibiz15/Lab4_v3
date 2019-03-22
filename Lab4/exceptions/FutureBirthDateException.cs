using System;

namespace Lab4.exceptions
{
    class FutureBirthDateException : BirthDateException
    {
        public FutureBirthDateException(DateTime birthdate) 
            : base("Specified birth date is from the future!",birthdate)
        {

        }
    }
}
