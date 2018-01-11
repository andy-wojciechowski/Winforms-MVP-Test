using StructureMap;
using System.Reflection;

namespace CardCollectorMVPTest.DependencyResolution
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
                scan.Assembly("CardCollectorStandard.Domain");
                scan.Assembly("CardCollectorStandard.Data");
                scan.WithDefaultConventions();
            });

            e.Policies.SetAllProperties(x =>
            {
                x.Matching(y =>
                {
                    return y.PropertyType.Assembly == Assembly.GetExecutingAssembly() ||
                           y.PropertyType.Assembly == Assembly.Load("CardCollectorStandard.Domain") ||
                           y.PropertyType.Assembly == Assembly.Load("CardCollectorStandard.Data");
                });
            });
        }
    }
}
