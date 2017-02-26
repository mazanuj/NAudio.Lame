using NAudio.Lame;
using NAudio.Wave;

namespace TestConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var tag = new Id3TagData
            {
                Title = "A Test File",
                Artist = "Microsoft",
                Album = "Windows 7",
                Year = "2009",
                Comment = "Test only.",
                Genre = LameMp3FileWriter.Genres[1],
                Subtitle = "From the Calligraphy theme",
                AlbumArt = System.IO.File.ReadAllBytes(@"disco.png")
            };

            using (var reader = new AudioFileReader(@"test.wav"))
            using (var writer = new LameMp3FileWriter(@"test.mp3", reader.WaveFormat, 128, tag))
            {
                reader.CopyTo(writer);
            }
        }
    }
}