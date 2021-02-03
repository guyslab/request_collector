namespace RequestGenerator.Factories
{
    public interface IFactory<TModel>
    {
        TModel Create();
    }
}
