using System;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        public string Path {get; set;}
        public FilterSave(string path)
        {
            this.Path = path;
        }
        public IPicture Filter(IPicture image)
        {
            PictureProvider p = new PictureProvider();
            p.SavePicture(image, this.Path);
            return image;
        }
    }
}