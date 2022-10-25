using System;
using System.Threading.Tasks;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public string Path {get; set;}
        public string Info {get; set;}

        public FilterTwitter(string path)
        {
            this.Path = path;
            this.Info = Info;
        }

        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(this.Info,this.Path));
            return image;
        }
    }
}