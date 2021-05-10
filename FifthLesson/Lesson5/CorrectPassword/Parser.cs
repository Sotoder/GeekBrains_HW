using System;
using System.Text.RegularExpressions;

namespace CorrectPassword
{
    class Parser
    {
        public int ParsAndCheckPassword(string password)
        {
            int errorCode = 0;

            if (String.IsNullOrEmpty(password))
            {
                errorCode = 4;
            }
            else
            {
                if (Char.IsNumber(password[0]))
                {
                    errorCode = 1;
                }
                else if (password.Length < 2 || password.Length > 10)
                {
                    errorCode = 2;
                }
                else
                {
                    foreach (char a in password)
                    {
                        if ((Convert.ToInt32(a) < 48) ||
                            (Convert.ToInt32(a) > 57 && Convert.ToInt32(a) < 90) ||
                            (Convert.ToInt32(a) > 90 && Convert.ToInt32(a) < 97) ||
                            (Convert.ToInt32(a) > 123))
                        {
                            errorCode = 3;
                        }
                    }
                }
            }

            return errorCode;
        }

        internal int RegularCheckPassword(string password)
        {
            int errorCode = 0;

            

            if (String.IsNullOrEmpty(password))
            {
                errorCode = 4;
            }
            else
            {

                if (CreateReg(@"^[0-9]+[A-z0-9]{1,}$").IsMatch(password))
                {
                    errorCode = 1;
                }
                else if (CreateReg(@"^[A-z0-9]{0,1}$").IsMatch(password) || CreateReg(@"^[A-z0-9]{10,}$").IsMatch(password))
                {
                    errorCode = 2;
                }
                else if (CreateReg(@"[^A-z0-9]{1,}").IsMatch(password))
                {
                    errorCode = 3;
                }
            }

            return errorCode;
        }

        private Regex CreateReg(string regStr)
        {
            Regex myReg = new Regex(regStr);
            return myReg;
        }
    }
}