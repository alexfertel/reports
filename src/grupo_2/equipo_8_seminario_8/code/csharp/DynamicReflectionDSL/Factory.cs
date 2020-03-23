namespace CSharp.DynamicReflectionDSL
{
    class Factory
    {
        private static InstanceCreator creator = new InstanceCreator();
        public static dynamic New
        {
            get
            {
                return creator;
            }
        }
    }
}