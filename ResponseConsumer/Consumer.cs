using ResponseConsumer.Models;
using ResponseConsumer.Processors;
using ResponseConsumer.Receivers;
using System.Collections.Generic;

namespace ResponseConsumer
{
    public class Consumer
    {
        private readonly IReceiver<ResponseModel> _receiver;

        private const int DefaultProcessInParallelCount = 5;


        public Consumer(            
            IReceiver<ResponseModel> receiver,
            IProcessor<ICollection<ResponseModel>> processor)
        {
            _receiver = receiver;
            _receiver.OnAllReceived = processor.Process;
        }

        public void Start()
        {
            int processInParallelCount = DefaultProcessInParallelCount;

            if (_receiver?.Options?.ProcessInParallelCount > 0)
                processInParallelCount = _receiver.Options.ProcessInParallelCount;
            _receiver.ReceiveMultiple(processInParallelCount);
        }
    }
}
