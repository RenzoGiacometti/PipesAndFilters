using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            
            PipeNull pipeNull = new PipeNull();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterSave filterSaveIntermedio = new FilterSave("ImagenIntermedia.jpg");
            FilterSave filterSave = new FilterSave("BeerB&W.jpg");
            PipeSerial pipeSerialGuardado2 = new PipeSerial(filterSave, pipeNull);
            PipeSerial pipeSerial1 = new PipeSerial(filterNegative, pipeSerialGuardado2);
            PipeSerial pipeSerialGuardado = new PipeSerial(filterSaveIntermedio, pipeSerial1);
            PipeSerial pipeSerial2 = new PipeSerial(filterGreyscale, pipeSerialGuardado);
            
            pipeSerial2.Send(picture);
        }
    }
}
