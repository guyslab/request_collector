using ResponseConsumer.Options;
using System;
using System.Collections.Generic;

namespace ResponseConsumer.Receivers
{
    public interface IReceiver<TObject>
    {
        ReceiverOptions Options { get; }

        /// <summary>
        /// Handler to be called when all objects recieved
        /// </summary>
        /// <returns>True iff handling succeeded</returns>
        Func<ICollection<TObject>, bool> OnAllReceived { get; set; }

        /// <summary>
        /// Receives multiple objects
        /// </summary>
        /// <param name="count">defaults to 1 object</param>
        void ReceiveMultiple(int count = 1);
    }
}
