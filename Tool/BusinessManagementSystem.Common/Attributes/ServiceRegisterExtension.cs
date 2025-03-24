using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Common.Attributes
{
    public static class ServiceRegisterExtension
    {
        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// <para>
        /// 需要注意的是，这里有如下约定：
        /// IUserService --> UserService, IUserRepository --> UserRepository.
        /// </para>
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection RegisterAssembly(this IServiceCollection service, string[] IocAssemblyNames)
        {
            foreach (var name in IocAssemblyNames)
            {
                RegisterType(name, service);
            }
            return service;
        }

        public static IServiceCollection RegisterAssembly(this IServiceCollection service, string[] IocAssemblyNames, Type checkType)
        {
            foreach (var name in IocAssemblyNames)
            {
                RegisterType(name, service, checkType);
            }
            return service;
        }

        public static void RegisterType(string assemblyName, IServiceCollection service, Type checkType)
        {
            Type[] types = Assembly.Load(assemblyName).GetTypes();
            try
            {
                foreach (Type type in types)
                {
                    System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
                    foreach (System.Attribute attr in attrs)
                    {
                        if (attr.GetType() == checkType)
                        {
                            var attribute = attr as IocRegisterAttribute;
                            var baseTypes = new List<Type>();
                            if (attribute.RegisterType != null)
                            {
                                baseTypes.Add(attribute.RegisterType);
                            }
                            else if (type.GetInterfaces().Any())
                            {
                                var ifs = type.GetInterfaces();
                                baseTypes.AddRange(type.GetInterfaces());
                            }
                            if (type.BaseType != null && type.BaseType != typeof(Object))
                            {
                                Type bt = type.BaseType;
                                while (bt.BaseType != null && bt.BaseType != typeof(Object))
                                    bt = bt.BaseType;
                                baseTypes.Add(bt);
                            }

                            if (baseTypes.Count <= 0)
                            {
                                try
                                {
                                    service.AddTransient(type, type);
                                }
                                catch (Exception e)
                                {
                                    throw new Exception($"类型\"{type}\"注入失败:{e.Message}");

                                }
                            }
                            else
                            {
                                foreach (Type baseType in baseTypes)
                                {
                                    service.AddTransient(baseType, type);
                                }
                                service.AddTransient(type, type);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        public static void RegisterType(string assemblyName, IServiceCollection service)
        {
            Type[] types = Assembly.Load(assemblyName).GetTypes();
            foreach (Type type in types)
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
                foreach (System.Attribute attr in attrs)
                {
                    if (attr is IocRegisterAttribute)
                    {
                        var attribute = attr as IocRegisterAttribute;
                        var baseTypes = new List<Type>();
                        if (attribute.RegisterType != null)
                        {
                            baseTypes.Add(attribute.RegisterType);
                        }
                        else if (type.GetInterfaces().Any())
                        {
                            baseTypes.AddRange(type.GetInterfaces());
                        }
                        if (type.BaseType != null && type.BaseType != typeof(Object))
                        {
                            Type bt = type.BaseType;
                            while (bt.BaseType != null && bt.BaseType != typeof(Object))
                                bt = bt.BaseType;
                            baseTypes.Add(bt);
                        }

                        if (baseTypes.Count <= 0)
                        {
                            try
                            {
                                service.AddTransient(type, type);
                            }
                            catch (Exception e)
                            {
                                throw new Exception($"类型\"{type}\"注入失败:{e.Message}");

                            }
                        }
                        else
                        {
                            foreach (Type baseType in baseTypes)
                            {
                                service.AddTransient(baseType, type);
                            }
                        }

                    }
                }
            }
        }
    }
}
