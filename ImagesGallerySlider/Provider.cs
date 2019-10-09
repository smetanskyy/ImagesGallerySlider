using ImagesGallerySlider.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImagesGallerySlider
{
    public class ConnectionProvider
    {
        public delegate void ConnectionDelegate(EFContext eFContext);
        public event ConnectionDelegate ConectedEvent;
        public ConnectionProvider()
        {
            Debug.WriteLine("ConnectionProvider CurrentThread: {0} - {1}",
                Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
        public Task ConnectRun()
        {
            Debug.WriteLine("ConnectRun CurrentThread: {0} - {1}",
                Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            return Task.Run(
                () =>
                {
                    Debug.WriteLine("Task.Run: {0} {1}",
                        Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                    EFContext context = new EFContext();
                    context.Configuration.AutoDetectChangesEnabled = false;
                    var c = context.Photos.Count();
                    ConectedEvent?.Invoke(context);
                    Debug.WriteLine("Task.Run end: {0} {1}",
                        Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                });
        }

    }
}
