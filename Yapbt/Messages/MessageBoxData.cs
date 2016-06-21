using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.Strausshome.Yapbt.Codes;

namespace Org.Strausshome.Yapbt.Messages
{
    /// <summary>
    /// This class handles the messagebox data.
    /// </summary>
    public class MessageBoxData
    {
        public MessageBoxButtons Buttons { get; set; }

        public MessageBoxIcon Icon { get; set; }

        public string Message { get; set; }

        public string Caption { get; set; }

        public ReturnCodes.Codes ReturnCode { get; set; }
    }
}
