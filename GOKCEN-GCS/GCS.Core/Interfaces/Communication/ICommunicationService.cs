using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Interfaces.Communication
{
    public interface ICommunicationService : IBaseInterface
    {



        public void Init();

        public void SendToTopic<T>(string topicName, T content);

        public void SendToService<T>(string topicName, T content);

        public void Shutdown();


    }
}
