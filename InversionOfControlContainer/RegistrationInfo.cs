using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InversionOfControlContainer
{
    internal class RegistrationInfo : IRegistrationInfo
    {
        public object Value { get; set; }
        public Type Type { get; private set; }

        public LifetimeScope LifetimeScope { get; private set; }
        public Dictionary<string, object> dictionaryRegistrationInfo { get; private set; }

        public RegistrationInfo(LifetimeScope lifetimescome, Type type)
        {
            dictionaryRegistrationInfo = new Dictionary<string, object>();
            LifetimeScope = lifetimescome;
            Type = type;
        }

        public IRegistrationInfo AddConstructionArgument(string name, object value)
        {
            dictionaryRegistrationInfo.Add(name, value);
            return this;
        }
    }
}
