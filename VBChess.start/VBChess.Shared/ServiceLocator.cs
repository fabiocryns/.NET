using Microsoft.Practices.Unity;

namespace VBChess.Shared {
    public class ServiceLocator {
        static ServiceLocator() {
            _container = new UnityContainer();
            _container.RegisterInstance<IUnityContainer>(_container);
        }

        public static TProxyType Resolve<TProxyType>() {
            return _container.Resolve<TProxyType>();
        }

        private static UnityContainer _container;
    }

}
