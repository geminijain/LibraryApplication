using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public static class Library
    {/// <summary>
    /// Library creates an account for user
    /// </summary>
    /// <param name="emailAddress">Email address of the account</param> 
    /// <returns>return new account</returns>
        public static Account CreateAccount(string emailAddress)
        {
            var account = new Account
            { EmailAddress = emailAddress
            };          
           
            return account;           
        }
    }
}
