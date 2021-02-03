namespace ResponseConsumer.Processors
{
    public interface IProcessor<TObject>
    {
        /// <summary>
        /// Processes an argument and returns true iff process succeeded
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        bool Process(TObject arg);
    }
}
