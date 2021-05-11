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

        public int RegularCheckPassword(string password)
        {
            int errorCode = 0;


            if (CreateReg(@"^$").IsMatch(password)) //проверка на нулевую строку
            {
                errorCode = 4;
            }
            else
            {

                if (CreateReg(@"[^A-z0-9]{1,}").IsMatch(password)) // проверка на ввод только цифр и букв латинского алфавита
                {
                    errorCode = 3;
                }
                else if (CreateReg(@"^[0-9]+[A-z0-9]{1,}$").IsMatch(password)) //проверка на цифру в первом символе
                {
                    errorCode = 1;
                }
                else if (!CreateReg(@"^.{2,10}$").IsMatch(password)) //проверка на количество символов
                {
                    errorCode = 2;
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