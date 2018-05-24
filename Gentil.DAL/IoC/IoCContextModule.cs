using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Gentil.DAL.Contexts;
using SimpleInjector;

namespace Gentil.DAL.IoC
{
    public class IoCContextModule
    {
        public static void Inject(Container container)
        {
            container.Register(typeof(DbContext), typeof(GentilContext), Lifestyle.Scoped);
        }
    }
}
