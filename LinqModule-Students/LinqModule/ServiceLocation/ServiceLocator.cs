using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LinqModule.View;
using LinqModule.ViewModel;
using Microsoft.Practices.Unity;

namespace LinqModule.ServiceLocation {
    public static class ServiceLocator {
        private static UnityContainer _container;

        static ServiceLocator() {
            _container = new UnityContainer();
            _container.RegisterInstance<IUnityContainer>(_container);

            // register the views
            _container.RegisterType<Window, MainWindow>(ViewNames.MainWindow); // moet Window zijn (en geen IWindow) omdat dit doorgegeven wordt aan App.Run
            _container.RegisterType<IView, NoResultsView>(ViewNames.NoResultsView);
            _container.RegisterType<IView, EnumerableResultsView>(ViewNames.EnumerableResultsView);
            _container.RegisterType<IView, SingleResultView>(ViewNames.SingleResultView);
            _container.RegisterType<IView, ExceptionResultView>(ViewNames.ExceptionResultView);
            _container.RegisterType<IView, SingleValueResultView>(ViewNames.SingleValueResultView);

            // register the viewmodels
            _container.RegisterType<IMainWindowViewModel, MainViewModel>();
            _container.RegisterType<IQueryViewModel, QueryViewModel>();
        }

        public static TProxyType Resolve<TProxyType>() {
            return _container.Resolve<TProxyType>();
        }

        public static TProxyType Resolve<TProxyType>(string name) {
            return _container.Resolve<TProxyType>(name);
        }
    }
}
