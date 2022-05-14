using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class LoginValidation
    {
        public static string CurrentUserUsername { get; private set; }
        public static UserRoles CurrentUserRole { get; private set; }

        public delegate void ActionOnError(string errorMsg);

        private string _username;
        
        private string _password;
        
        private string _errorLog;
        
        private ActionOnError _errorfunc;

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this._username = username;
            this._password = password;
            this._errorfunc = actionOnError;
        }

        public bool ValidateUserInput(out User user)
        {
            user = null;
            if (_username.Equals(string.Empty))
            {
                _errorLog = "Не е посочено потребителско име";
            }
            if (_username.Length < 5)
            {
                _errorLog = "Потребителско име не може да е по-малко от 5 символа";
            }
            if (_password.Equals(string.Empty))
            {
                _errorLog = "Не е посочена парола";
            }
            if (_password.Length < 5)
            {
                _errorLog = "Паролата не може да е по-малко от 5 символа";
            }
            user = UserData.IsUserPassCorrect(_username, _password);
            if (user == null) _errorLog = "Потребителя не е намерен";

            if (!string.IsNullOrEmpty(_errorLog))
            {
                _errorfunc(_errorLog);
                Logger.LogActivity(_errorLog);
                CurrentUserUsername = string.IsNullOrEmpty(_username) ? _username : "Unknown";
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            CurrentUserUsername = _username;
            CurrentUserRole = (UserRoles)user.Role;
            Logger.LogActivity("Успешен login");
            return true;    
        }
    }
}
