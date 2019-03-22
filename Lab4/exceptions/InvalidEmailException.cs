using System;

namespace Lab4.exceptions
{
    class InvalidEmailException : Exception
    {
        public InvalidEmailException(String email) : base("The email specified is invalid: " + email)
        {

        }
    }
}
