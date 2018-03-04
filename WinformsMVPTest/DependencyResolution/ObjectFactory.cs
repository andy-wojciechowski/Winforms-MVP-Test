using StructureMap;
using System.Reflection;
using WinformsMVPTest.Data.Interfaces;
using WinformsMVPTest.Data;

namespace WinformsMVPTest.DependencyResolution
{
    public class ObjectFactory
    {
        public static IContainer GetContainer()
        {
            return new Container(Configure);
        }

        private static void Configure(ConfigurationExpression e)
        {
            e.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.Assembly("WinformsMVPTest.Domain");
                scan.Assembly("WinformsMVPTest.Data");
                scan.WithDefaultConventions();
            });

			e.For<ICardRepository>().Use<CardRepository>();

            e.Policies.SetAllProperties(x =>
            {
                x.Matching(y =>
                {
                    return y.PropertyType.Assembly == Assembly.GetExecutingAssembly() ||
                           y.PropertyType.Assembly == Assembly.Load("WinformsMVPTest.Domain") ||
                           y.PropertyType.Assembly == Assembly.Load("WinformsMVPTest.Data");
                });
            });
        }
    }
}
