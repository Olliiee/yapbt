﻿using System;
using System.Diagnostics;
using System.IO;
using Org.Strausshome.Yapbt.Codes;

namespace Org.Strausshome.Yapbt.BglFileHandle
{
    /// <summary>
    /// This class handles the bgl converting part.
    /// </summary>
    public class BglFile
    {
        #region Public Methods

        /// <summary>
        /// Starts the bgl converter.
        /// </summary>
        /// <param name="bglTool">Where is the bgl converter exe.</param>
        /// <param name="bglFile">Where is the bgl file to convert.</param>
        /// <param name="xmlFile">Where to write the output xml file.</param>
        /// <returns>True ok; False something went wrong no xml file created.</returns>
        public ReturnCodes.Codes ConevertBglFile(string bglTool, string bglFile, string xmlFile)
        {
            try
            {
                // If xml file already exists delete it.
                if (File.Exists(xmlFile))
                {
                    File.Delete(xmlFile);
                }

                Process P = new Process();
                P.StartInfo.FileName = bglTool;

                string BglArguments = String.Empty;

                // Depending on the tool, set the parameters.
                if (bglTool.ToLower().Contains("bgl2xml.exe"))
                {
                    BglArguments = "/s \"" + bglFile + "\" /d \"" + xmlFile + "\"";
                }
                else if (bglTool.ToLower().Contains("bglxml.exe"))
                {
                    BglArguments = "\"" + bglFile + "\" \"" + xmlFile + "\"";
                }

                // Starting parameters are set? Let's got.
                if (BglArguments != String.Empty)
                {
                    P.StartInfo.Arguments = BglArguments;
                    P.Start();
                    P.WaitForExit();

                    if (File.Exists(xmlFile))
                    {
                        return ReturnCodes.Codes.Ok;
                    }
                }

                return ReturnCodes.Codes.ConvertNoFileExistsError;
            }
            catch
            {
                return ReturnCodes.Codes.ConvertError;
            }
        }

        #endregion Public Methods
    }
}