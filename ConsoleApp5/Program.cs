using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {

        static void Main(string[] args)
        {
            var messenger= new Messenger();
            var video = new Video {Title = "ojioij"};
            var VideoEncoder = new VideoEncoder(video);
            VideoEncoder.OnVideoEncoded += messenger.OnVideoEncoded;
            VideoEncoder.Encode();

        }

        class Messenger
        {
            public void OnVideoEncoded(object sender, EventArgs e)
            {
                Console.WriteLine("Sending message...");
            }
        }

        class VideoEncoder
        {
            public Video video { get; set; }
            public event EventHandler OnVideoEncoded;

            public VideoEncoder(Video video)
            {
                this.video = video;
            }

            public void Encode()
            {
                Console.WriteLine("Encoding...Video");
                Thread.Sleep(2000);
                OnVideoEncoded?.Invoke(this,EventArgs.Empty);
                
            }   
        }
    }

    internal class Video
    {
        public string Title { get; set; }
    }
}
