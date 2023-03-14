using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using LoginRoleApp.Services;
using System.Windows.Controls;
using System.Threading;
using LoginRoleApp.Common;

namespace LoginRoleApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private IAuthenticationService _authentication;

        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        private string message = "";
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        public LoginViewModel(IEventAggregator aggregator,IAuthenticationService authentication)
        {
            _eventAggregator = aggregator;
            _authentication = authentication;
        }
        private DelegateCommand<PasswordBox> _loginCommand;
        public DelegateCommand<PasswordBox> LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand<PasswordBox>(ExecuteLoginCommand));
        

        void ExecuteLoginCommand(PasswordBox password)
        {
            try
            {
                var user = _authentication.AuthenticateUser(Login, password.Password);
                UserPrincipial userPrincipial = Thread.CurrentPrincipal as UserPrincipial;
                if (userPrincipial == null)
                    throw new ArgumentException("Не зарегистрирован пользователь по умолчанию!");
                userPrincipial.UserIdentity = new UserIdentity(user.Login,user.FIO,user.Role.ToString());
                Login = "";
                password.Password = "";
                _eventAggregator.GetEvent<LoginSentEvent>().Publish(true);

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            
        }
    }
}
