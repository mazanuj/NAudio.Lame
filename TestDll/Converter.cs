using NAudio.Lame;
using NAudio.Wave;

namespace TestDll
{
    public class Converter
    {
        public static void ConvertToMp3()
        {
            using (var reader = new AudioFileReader(@"test.wav"))
            using (var writer = new LameMp3FileWriter(@"test.mp3", reader.WaveFormat, 128))
                reader.CopyTo(writer);
        }
    }
}