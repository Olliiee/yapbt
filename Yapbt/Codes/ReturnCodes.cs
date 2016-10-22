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
            ImportTaxiwayOk,
            ImportParkingPosOk,
            ImportPointOk,
            ResetError,
            ResetOk,
            XmlError,
            ConvertNoFileExistsError,
            ConvertError,
            ConvertOk,
            IdontKnowWhatHappenedError
        };

        public enum FsVersion
        {
            Fs9,
            FsX,
            None
        };
    }
}
