namespace Dynamic
{
    
    public interface ICopiable
    {
        object ShallowCopy();
        object DeepCopy();
    }
}