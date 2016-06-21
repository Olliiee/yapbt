using Org.Strausshome.Yapbt.Codes;

namespace Org.Strausshome.Yapbt.Messages
{
    public class MsgCodes
    {
        public MessageBoxData CreateMessage(ReturnCodes.Codes code)
        {
            string result = string.Empty;
            MessageBoxData boxData = new MessageBoxData();

            switch (code)
            {
                case ReturnCodes.Codes.Ok:
                    break;
                case ReturnCodes.Codes.Error:
                    break;
                case ReturnCodes.Codes.ImportError:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Error while importing";
                    boxData.Message = "Error while importing the data.";
                    return boxData;
                case ReturnCodes.Codes.ImportOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import complete.";
                    return boxData;
                case ReturnCodes.Codes.ImportParkingPosOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import parking position complete.";
                    return boxData;
                case ReturnCodes.Codes.ImportPointOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import single point complete.";
                    return boxData;
                case ReturnCodes.Codes.ImportTaxiwayOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import taxiway complete.";
                    return boxData;
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
