using Rosidl.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Models.RosMessages
{
    public class Message : IMessage
    {
        public static string TypeSupportName => throw new NotImplementedException();

        public static IMessage CreateFrom(nint data, Encoding textEncoding)
        {
            throw new NotImplementedException();
        }

        public static TypeSupportHandle GetTypeSupportHandle()
        {
            throw new NotImplementedException();
        }

        public static nint UnsafeCreate()
        {
            throw new NotImplementedException();
        }

        public static void UnsafeDestroy(nint data)
        {
            throw new NotImplementedException();
        }

        public static void UnsafeFinalize(nint data)
        {
            throw new NotImplementedException();
        }

        public static void UnsafeFinalizeSequence(nint data)
        {
            throw new NotImplementedException();
        }

        public static bool UnsafeInitialize(nint data)
        {
            throw new NotImplementedException();
        }

        public static bool UnsafeInitializeSequence(int size, nint data)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(nint data, Encoding textEncoding)
        {
            throw new NotImplementedException();
        }
    }
}
