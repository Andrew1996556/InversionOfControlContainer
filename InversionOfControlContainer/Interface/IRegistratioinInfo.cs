using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlContainer
{
    public interface IRegistrationInfo
    {
        IRegistrationInfo AddConstructionArgument(string name, object value);
    }
}
