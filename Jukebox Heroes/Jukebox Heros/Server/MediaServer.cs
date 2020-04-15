using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jukebox_Heroes.Server
{
    class MediaServer
    {

        private readonly HttpListener _listener = new HttpListener();

        public MediaServer(string prefix) {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            if (prefix == null)
                throw new ArgumentException("prefix");


            _listener.Prefixes.Add(prefix);

            _listener.Start();
        }

        private byte[] getCurrentSongByteArray(HttpListenerRequest r) {
            return File.ReadAllBytes(r.RawUrl.Substring(1));
        }

        public void Run() {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try {
                    while (_listener.IsListening) {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try {
                                Console.WriteLine("Got request for " + ctx.Request.RawUrl.Substring(1));
                                byte[] buf = getCurrentSongByteArray(ctx.Request);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.ContentType = "audio/mpeg";
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            } catch { } finally {
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                } catch { }
            });
        }

        public void Stop() {
            _listener.Stop();
            _listener.Close();
        }
    }
}
