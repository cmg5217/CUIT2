using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CUITAdmin
{
    class PasswordHash
    {
        //this method returns a SHA512 Hash string
        public string getHashSha512(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA512Managed hashstring = new SHA512Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

     }
}
