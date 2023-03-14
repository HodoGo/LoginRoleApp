using Prism.Commands;
using Prism.Mvvm;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using LoginRoleApp.Common;

namespace LoginRoleApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string userAuth;
        public string UserAuth
        {
            get { return userAuth; }
            set { SetProperty(ref userAuth, value); }
        }
        private string userRole;
        public string UserRole
        {
            get { return userRole; }
            set { SetProperty(ref userRole, value); }
        }
        IEventAggregator _eventAggregator;
        private DelegateCommand _logoutcmd;
        public DelegateCommand LogoutCmd =>
            _logoutcmd ?? (_logoutcmd = new DelegateCommand(ExecuteLogoutCommand));

        private void ExecuteLogoutCommand()
        {
            bool loginState = false;
            if (_eventAggregator != null)
                _eventAggregator.GetEvent<LoginSentEvent>().Publish(loginState);
        }

        public MainViewModel(IEventAggregator aggregator)
        {
            _eventAggregator = aggregator;
            UserAuth = Thread.CurrentPrincipal.Identity.Name;
            UserRole = Thread.CurrentPrincipal.IsInRole("Admin")?"Администратор":"Пользователь";
        }
    }
}
