using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;

public class DependencyResolver
{
    private IContainer container;

    public DependencyResolver(IContainer container)
    {
        this.container = container;
    }

    public object GetService(Type serviceType)
    {
        return serviceType.IsAbstract || serviceType.IsInterface
                ? container.TryGetInstance(serviceType)
                : container.GetInstance(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        return container.GetAllInstances(serviceType).Cast<object>();
    }
}
