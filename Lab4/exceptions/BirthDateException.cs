using System;

namespace Lab4.exceptions
{
    abstract class BirthDateException : Exception
    {
        public BirthDateException(String message, DateTime birthDate) : base(message)
        {
            InvalidBirthDate = birthDate;
        }

        private DateTime _invalidBirthDate;

        public DateTime InvalidBirthDate { get => _invalidBirthDate; set => _invalidBirthDate = value; }
    }
}
