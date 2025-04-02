using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GCS.Core.Interfaces.ROS;
using Rcl;
using Rosidl.Runtime;

namespace GCS.Service.ROS
{
    public class RosNodeService : IRosNodeService
    {

        public RclContext RclContext { get; set; }
        public IRclNode RclNode { get; set; }

        public Dictionary<string, IRclPublisher> Publishers { get; set; }
        public Dictionary<string, IRclSubscription> Subscribers { get; set; }

        public RclContext CreateContext()
        {
            using var context = new RclContext();
            return context;
        }

        public IRclNode CreateNode(string nodeName)
        {
            using var node = RclContext.CreateNode(nodeName);
            return node;
        }

        public IRclPublisher CreatePublisher<T>(string topicName) where T : Rosidl.Runtime.IMessage
        {
            using var pub = RclNode.CreatePublisher<T>(topicName);
            Publishers.Add(topicName, pub);
            return pub;
        }

        public IRclSubscription CreateSubscription<T>(IRclNode rclNode, string topicName) where T : IMessage
        {
            using var sub = rclNode.CreateSubscription<T>(topicName);
            Subscribers.Add(topicName, sub);
            return sub;
        }

        public void Init()
        {

            RclContext = CreateContext();
            RclNode = CreateNode("GCS");

            //string yerine std gelmeli
            CreatePublisher<string>("/gcs/deneme");
            

            /*
             * Context yarat
             * Node yarat
             * Publisher / Subscriberlarını yarat
             * Service Server ve clientlarını yarat
             */
        }

        public void SendToTopic<T>(string topicName, T messageContent)
        {
            throw new NotImplementedException();
        }

        public void SendToService<T>(string topicName, T messageContent)
        {
            throw new NotImplementedException();
        }

        

        public void 



    }
}
