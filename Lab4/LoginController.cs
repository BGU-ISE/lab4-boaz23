using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class LoginController
    {
        private int _failedAttemptsCount;

        public LoginController()
        {
            this._failedAttemptsCount = 0;
        }

        public LoginResponse Login(string userid, string password)
        {
            if (this._failedAttemptsCount == 3)
            {
                return LoginResponse.TooManyAttempts;
            }
            if (userid == "myuser" && password == "1234")
            {
                return LoginResponse.Succeeded;
            }

            this._failedAttemptsCount++;
            return LoginResponse.Failed;
        }
    }
}