using StructureMap;
using System.Reflection;

public class MVPRegistry : Registry
{
    public MVPRegistry()
    {
        Scan(scanner =>
        {
            scanner.TheCallingAssembly();
            scanner.Assembly("CardCollectorStandard.Domain");
            scanner.Assembly("CardCollectorStandard.Data");
            scanner.WithDefaultConventions();
        });

        Policies.SetAllProperties(policy =>
        {
            policy.Matching(x =>
            {
                return  x.PropertyType.Assembly == Assembly.GetExecutingAssembly() ||
                        x.PropertyType.Assembly == Assembly.Load("CardCollectorStandard.Domain") ||
                        x.PropertyType.Assembly == Assembly.Load("CardCollectorStandard.Data");

            });
        });
    }
}
