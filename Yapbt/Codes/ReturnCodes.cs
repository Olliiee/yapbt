namespace Org.Strausshome.Yapbt.Codes
{
    public class ReturnCodes
    {
        public enum Codes
        {
            Ok,
            Error,
            ImportError,
            ImportOk,
            ResetError,
            ResetOk,
            XmlError,
            ConvertNoFileExistsError,
            ConvertError,
            ConvertOk
        };

        public enum FsVersion
        {
            Fs9,
            FsX,
            None
        };
    }
}
