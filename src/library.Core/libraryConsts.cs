using library.Debugging;

namespace library
{
    public class libraryConsts
    {
        public const string LocalizationSourceName = "library";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6b0fdf4d9ae846d0ac4fbfaddd4ebcd8";
    }
}
