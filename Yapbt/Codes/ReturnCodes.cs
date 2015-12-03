namespace Org.Strausshome.Yapbt.Codes
{
    public class ReturnCodes
    {
        public enum Codes
        {
            Ok,
            Error,
            ImportError,
            ResetError,
            ResetOk
        };

        public enum FsVersion
        {
            Fs9,
            FsX,
            None
        };
    }
}
