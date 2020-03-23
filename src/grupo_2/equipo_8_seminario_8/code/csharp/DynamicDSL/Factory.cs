namespace CSharp.DynamicDSL
{
    class Factory
    {
        private static InstanceCreator creator = new InstanceCreator();
        public static InstanceCreator New
        {
            get
            {
                return creator;
            }
        }
    }
}