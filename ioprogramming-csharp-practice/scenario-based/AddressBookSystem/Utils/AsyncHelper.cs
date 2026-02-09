using System;
using System.Threading;

namespace AddressBookSystem.Utils
{
    public static class AsyncHelper
    {
        public static void RunAsync(Action task)
        {
            Thread t = new Thread(new ThreadStart(task));
            t.IsBackground = true;
            t.Start();
        }
    }
}
