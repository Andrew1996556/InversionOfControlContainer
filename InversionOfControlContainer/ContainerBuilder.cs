using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InversionOfControlContainer
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly Dictionary<Type, RegistrationInfo> dictionaryService = new Dictionary<Type, RegistrationInfo>();

        public IRegistrationInfo Register<TInterface, TImplemention>()
        {
            return Register<TInterface, TImplemention>(LifetimeScope.Trancient);
        }

        public IRegistrationInfo RegisterSingltone<TInterface, TImplemention>()
        {
            return Register<TInterface, TImplemention>();
        }

        public TInterface GetService<TInterface>()
        {
            Type interfaceType = typeof(TInterface);
            Object instance = null;

            if (dictionaryService.TryGetValue(interfaceType, out RegistrationInfo registrationInfo))
            {
                switch (registrationInfo.LifetimeScope)
                {
                    case LifetimeScope.Singltone:
                        registrationInfo.Value = registrationInfo.Value ?? CreateInstance(registrationInfo);
                        instance = registrationInfo.Value;
                        break;
                    case LifetimeScope.Trancient:
                        instance = CreateInstance(registrationInfo);
                        break;
                }
                return (TInterface)instance;
            }
            throw new Exception($"Implementation for type {interfaceType.Name} already was't registered");
        }

        private object CreateInstance(RegistrationInfo info)
        {
            object instanse = null;
            if (info.dictionaryRegistrationInfo.Count == 0)
            {
                instanse = Activator.CreateInstance(info.Type);
            }
            else
            {
                IEnumerable<string> addedKeys = info.dictionaryRegistrationInfo.Keys;
                ConstructorInfo ctorInfo = info.Type.GetConstructors().FirstOrDefault(c => c.GetParameters()
                                                                      .Select(p => p.Name).SequenceEqualNotConsistently(addedKeys));


                ParameterInfo[] ctorParamsInfo = ctorInfo.GetParameters();
                object[] parameters = new object[ctorParamsInfo.Length];
                for (int i = 0; i < ctorParamsInfo.Length; i++)
                {
                    parameters[i] = info.dictionaryRegistrationInfo[ctorParamsInfo[i].Name];
                }

                instanse = ctorInfo.Invoke(parameters);
            }
            return instanse;
        }

        private IRegistrationInfo Register<TInterface, TImplemention>(LifetimeScope life)
        {
            Type interfaceType = typeof(TInterface);

            if (!dictionaryService.TryGetValue(interfaceType, out RegistrationInfo func))
            {
                RegistrationInfo info = new RegistrationInfo(life, typeof(TImplemention));
                dictionaryService.Add(interfaceType, info);
                return info;
            }
            else
            {
                throw new Exception($"Implementation for type {interfaceType.Name} already was registered");
            }
        }
    }
}
