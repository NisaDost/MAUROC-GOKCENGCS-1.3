using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rcl;
using Rosidl.Runtime;

namespace GCS.Core.Interfaces.ROS
{
    public interface IRosNodeService : IBaseInterface
    {
        public void Init();

        RclContext CreateContext();

        IRclNode CreateNode(string nodeName);

        IRclPublisher CreatePublisher<T>(string topicName) where T : IMessage;

        IRclSubscription CreateSubscription<T>(string topicName) where T : IMessage;

        public void SendToTopic<T>(string topicName, T messageContent) where T : IMessage;

        public void SendToService<T>(string topicName, T messageContent) where T : IMessage;



    }
}
