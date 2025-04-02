using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GCS.Core.Interfaces.ROS;
using GCS.Core.Models.RosMessages;
using GCS.Service.Logging;
using Rcl;
using Rosidl.Runtime;

namespace GCS.Service.ROS
{
    public class RosNodeService : IRosNodeService
    {

        public RclContext RclContext { get; set; }
        public IRclNode RclNode { get; set; }


        #region Publishers
        public IRclPublisher<ROSNode.Std.String> DenemePublisher { get; set; }
        #endregion


        #region Subscribers
        public IRclSubscription<ROSNode.Std.String> DenemeSubscription { get; set; }
        #endregion

        public RclContext CreateContext()
        {
            RclContext context = new RclContext();
            RclContext = context;
            return context;
        }

        public IRclNode CreateNode(string nodeName)
        {
            IRclNode node = RclContext.CreateNode(nodeName);
            RclNode = node;
            return node;
        }

        public void Init()
        {

            CreateContext();
            CreateNode("GCS");

            #region Create Publishers
            DenemePublisher = RclNode.CreatePublisher<ROSNode.Std.String>("gcs/deneme");
            #endregion



            #region Create Subscribers
            DenemeSubscription = RclNode.CreateSubscription<ROSNode.Std.String>("gcs/deneme");

            #endregion


            #region Hook Subscribers
            HookDenemeSubscription();
            #endregion


            // DEBUG

            PublishDeneme();

            /*
             * 
             * Subscription Thread
             * 
             */





            //string yerine std gelmeli
            // TODO CreatePublisher<string>("/gcs/deneme");


            /*
             * Context yarat
             * Node yarat
             * Publisher / Subscriberlarını yarat
             * Service Server ve clientlarını yarat
             */
        }

        private void HookDenemeSubscription()
        {
            
            Thread denemeSubscriptionHook = new Thread(async () =>
            {
                
                await foreach (var message in DenemeSubscription.ReadAllAsync())
                {
                    LoggingService.Info($"Received message: {message.Data}");
                }

            });

            denemeSubscriptionHook.Start();

        }

        public void PublishDeneme()
        {
            ROSNode.Std.String denemeMessage = new ROSNode.Std.String();

            int i = 0;

            while(i < 100)
            {
                denemeMessage.Data = i.ToString();
                DenemePublisher.Publish(denemeMessage);
            }

            
        }
    }
}
