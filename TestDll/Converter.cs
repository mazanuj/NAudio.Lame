using System.IO;
using NAudio.Lame;
using NAudio.Wave;

namespace TestDll
{
    public static class Converter
    {
        public static void ConvertToMp3()
        {
            using (var reader = new AudioFileReader(@"test.wav"))
            using (var writer = new LameMp3FileWriter(@"test.mp3", reader.WaveFormat, 128))
                reader.CopyTo(writer);
        }

        public static void CopyTo(this Stream source, Stream target)
        {
            var buffer = new byte[16384];
            int rc;
            while ((rc = source.Read(buffer, 0, buffer.Length)) > 0)
                target.Write(buffer, 0, rc);
        }
    }
}