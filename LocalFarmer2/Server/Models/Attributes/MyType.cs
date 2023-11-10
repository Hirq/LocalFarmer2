namespace LocalFarmer2.Server.Models
{
    public class MyType
    {
        [AttributeUsage(AttributeTargets.Class)]
        public class TypeNameAttribute : Attribute
        {
            public string TypeName { get; }

            public TypeNameAttribute(string typeName)
            {
                TypeName = typeName;
            }
        }
    }
}
