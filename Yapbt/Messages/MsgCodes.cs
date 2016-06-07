using Org.Strausshome.Yapbt.Codes;

namespace Org.Strausshome.Yapbt.Messages
{
    public class MsgCodes
    {
        public string CreateMessage(ReturnCodes.Codes code)
        {
            string result = string.Empty;

            switch (code)
            {
                case ReturnCodes.Codes.Ok:
                    break;
                case ReturnCodes.Codes.Error:
                    break;
                case ReturnCodes.Codes.ImportError:
                    return "Error while importing the data.";
                    break;
                case ReturnCodes.Codes.ImportOk:
                    return "Import complete.";
                    break;
                case ReturnCodes.Codes.ImportParkingPosOk:
                    return "Import parking position complete.";
                    break;
                case ReturnCodes.Codes.ImportPointOk:
                    return "Import single point complete.";
                    break;
                case ReturnCodes.Codes.ImportTaxiwayOk:
                    return "Import taxiway complete.";
                    break;
                case ReturnCodes.Codes.ResetError:
                    break;
                case ReturnCodes.Codes.ResetOk:
                    break;
                case ReturnCodes.Codes.XmlError:
                    break;
                case ReturnCodes.Codes.ConvertNoFileExistsError:
                    break;
                case ReturnCodes.Codes.ConvertError:
                    break;
                case ReturnCodes.Codes.ConvertOk:
                    break;
                default:
                    break;
            }

            return result;

        }
    }
}
