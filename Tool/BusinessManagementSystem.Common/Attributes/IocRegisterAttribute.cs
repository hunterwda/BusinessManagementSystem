using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Common.Attributes
{
    public class IocRegisterAttribute : Attribute
    {
        public Type RegisterType { get; protected set; }

        public string Name { get; protected set; }

        public IocRegisterAttribute() : this(null, null)
        {
        }

        public IocRegisterAttribute(Type register_type) : this(register_type, null)
        {
        }

        public IocRegisterAttribute(string name) : this(null, name)
        {
        }

        public IocRegisterAttribute(Type registerType, string name)
        {
            RegisterType = registerType;
            Name = name;
        }
    }
}
