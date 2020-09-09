namespace Template.SharedKernel.Domain
{
    public class ValueObject
    {
    }

    public abstract class ValueObject<T> : ValueObject
        where T : class
    {
    }
}
