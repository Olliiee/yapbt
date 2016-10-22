using Org.Strausshome.Yapbt.Codes;

namespace Org.Strausshome.Yapbt.Messages
{
    public class MsgCodes
    {
        public MessageBoxData CreateMessage(ReturnCodes.Codes code)
        {
            MessageBoxData boxData = new MessageBoxData();
            boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
            boxData.Icon = System.Windows.Forms.MessageBoxIcon.Exclamation;
            boxData.ReturnCode = ReturnCodes.Codes.IdontKnowWhatHappenedError;
            boxData.Caption = "Something went wrong ..";
            boxData.Message = ".. and I don't knwo why.";

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
                    break;
                case ReturnCodes.Codes.ImportOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import complete.";
                    break;
                case ReturnCodes.Codes.ImportParkingPosOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import parking position complete.";
                    break;
                case ReturnCodes.Codes.ImportPointOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import single point complete.";
                    break;
                case ReturnCodes.Codes.ImportTaxiwayOk:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Import complete";
                    boxData.Message = "Import taxiway complete.";
                    break;
                case ReturnCodes.Codes.ResetError:
                    break;
                case ReturnCodes.Codes.ResetOk:
                    break;
                case ReturnCodes.Codes.XmlError:
                    break;
                case ReturnCodes.Codes.ConvertNoFileExistsError:
                    boxData.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    boxData.Icon = System.Windows.Forms.MessageBoxIcon.Error;
                    boxData.ReturnCode = code;
                    boxData.Caption = "Unable to convert";
                    boxData.Message = "Unable to convert the BGL file.";
                    break;
                case ReturnCodes.Codes.ConvertError:
                    break;
                case ReturnCodes.Codes.ConvertOk:
                    break;
                default:
                    break;
            }

            return boxData;

        }
    }
}
