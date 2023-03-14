using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Prism.Ioc;
using LoginRoleApp.Views;
using LoginRoleApp.Common;

namespace LoginRoleApp.ViewModels
{
    public class ShellViewModel:BindableBase
    {
        private IEventAggregator _eventAggregator;
        IContainerExtension _container;
        private IRegionManager _regionManager;
        private IRegion _region;
        private Login loginView;
        private Main mainView;



        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private DelegateCommand _loadDataCommand;
        public DelegateCommand LoadDataCommand =>
            _loadDataCommand ?? (_loadDataCommand = new DelegateCommand(ExecuteLoadDataCommand ));

       
        public ShellViewModel(IRegionManager regionManager, IContainerExtension container,IEventAggregator aggregator)
        {
            _regionManager = regionManager;
            _container = container;
            _eventAggregator = aggregator;
            _eventAggregator.GetEvent<LoginSentEvent>().Subscribe(MessageReceived);
        }

        void MessageReceived(bool loginState)
        {
            if (loginState)
            {
                _region.Deactivate(loginView);
                mainView = _container.Resolve<Main>();
                _region.Add(mainView);
                Title = "Now is the main form of the program";
            }
            else
            {
                _region.Deactivate(mainView);
                Title = "User Login";
                _region.Activate(loginView);
            }

        }
        void ExecuteLoadDataCommand()
        {
            _region = _regionManager.Regions["MainRegion"];
            loginView = _container.Resolve<Login>();

            Title = "User Login";
            _region.Add(loginView);
        }
    }
}
