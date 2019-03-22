using System;

namespace Lab4.exceptions
{
    class DeadPersonBirthDateException : BirthDateException
    {
        public DeadPersonBirthDateException(DateTime birthDate) 
            : base("Specified birth date is of a dead person!",birthDate)
        {

        }
    }
}
