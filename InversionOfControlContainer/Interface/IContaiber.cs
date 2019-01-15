using System;

namespace InversionOfControlContainer
{
    public interface IContainerBuilder
    {
        IRegistrationInfo Register<TInterface, TImplemention>();

        IRegistrationInfo RegisterSingltone<TInterface, TImplemention>();

        TInterface GetService<TInterface>();
    }

}
