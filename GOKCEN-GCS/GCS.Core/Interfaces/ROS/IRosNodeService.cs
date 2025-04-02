using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rcl;

namespace GCS.Core.Interfaces.ROS
{
    public interface IRosNodeService : IBaseInterface
    {
        public void Init();

        RclContext CreateContext();

        IRclNode CreateNode(RclContext ctx, string nodeName);

        IRclPublisher CreatePublisher<T>(IRclNode rclNode, string topicName) where T : Rosidl.Runtime.IMessage;

        IRclSubscription CreateSubscription<T>(IRclNode rclNode, string topicName) where T : Rosidl.Runtime.IMessage;

        public void SendToTopic<T>(string topicName, T messageContent);

        public void SendToService<T>(string topicName, T messageContent);



    }
}
