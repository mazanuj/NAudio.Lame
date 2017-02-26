using LameDLLWrap;

namespace NAudio.Lame
{
    /// <summary>LAME DLL version information</summary>
    public class LameVersion
    {
        /* generic LAME version */

        /// <summary>LAME library major version</summary>
        public int Major { get; private set; }

        /// <summary>LAME library minor version</summary>
        public int Minor { get; private set; }

        /// <summary>LAME library 'Alpha' version flag</summary>
        public bool Alpha { get; private set; }

        /// <summary>LAME library 'Beta' version flag</summary>
        public bool Beta { get; private set; }

        /// <summary>Psychoacoustic code major version</summary>
        public int PsychoAcoustic_Major { get; private set; }

        /// <summary>Psychoacoustic code minor version</summary>
        public int PsychoAcoustic_Minor { get; private set; }

        /// <summary>Psychoacoustic code 'Alpha' version flag</summary>
        public bool PsychoAcoustic_Alpha { get; private set; }

        /// <summary>Psychoacoustic code 'Beta' version flag</summary>
        public bool PsychoAcoustic_Beta { get; private set; }

        /// <summary>Compile-time features string</summary>
        public string Features { get; private set; }

        /// <summary>Constructor, library-local, converts <see cref="LameDLLWrap.LAMEVersion"/></summary>
        /// <param name="source"></param>
        internal LameVersion(LameDLLWrap.LAMEVersion source)
        {
            Major = source.major;
            Minor = source.minor;
            Alpha = source.alpha;
            Beta = source.beta;

            PsychoAcoustic_Major = source.psy_major;
            PsychoAcoustic_Minor = source.psy_minor;
            PsychoAcoustic_Alpha = source.psy_alpha;
            PsychoAcoustic_Beta = source.psy_beta;

            Features = source.features;
        }

        // Prevent default construction
        private LameVersion()
        {
        }
    }

    /// <summary>
    /// Static class providing access to context-free LAME entry points
    /// </summary>
    public static class LameDll
    {
        static LameDll()
        {
            Loader.Init();
        }

        #region DLL version data

        /// <summary>Lame Version</summary>
        public static string LameVersion => LibMp3Lame.LameVersion;

        /// <summary>Lame Short Version</summary>
        public static string LameShortVersion => LibMp3Lame.LameShortVersion;

        /// <summary>Lame Very Short Version</summary>
        public static string LameVeryShortVersion => LibMp3Lame.LameVeryShortVersion;

        /// <summary>Lame Psychoacoustic Version</summary>
        public static string LamePsychoacousticVersion => LibMp3Lame.LamePsychoacousticVersion;

        /// <summary>Lame URL</summary>
        public static string LameURL => LibMp3Lame.LameURL;

        /// <summary>Lame library bit width - 32 or 64 bit</summary>
        public static string LameOSBitness => LibMp3Lame.LameOSBitness;

        /// <summary>Get LAME version information</summary>
        /// <returns>LAME version structure</returns>
        public static LameVersion GetLameVersion()
        {
            return new LameVersion(LibMp3Lame.GetLameVersion());
        }

        #endregion
    }
}