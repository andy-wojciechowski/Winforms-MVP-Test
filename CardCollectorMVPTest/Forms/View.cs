namespace CardCollectorMVPTest.Forms
{
    public class View : System.Windows.Forms.Form
    {
        public View()
        {
            foreach(var property in this.GetType().GetProperties())
            {
                //If we have a property with a setter and we don't have a winforms property then try and inject the property
                if(property.GetSetMethod() != null && !property.PropertyType.Namespace.StartsWith("System"))
                {
                    property.SetValue(this, Program.DependencyResolver.GetService(property.PropertyType));
                }
            }
        }
    }
}
