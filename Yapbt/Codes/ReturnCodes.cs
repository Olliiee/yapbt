﻿namespace Org.Strausshome.Yapbt.Codes
{
    public class ReturnCodes
    {
        public enum Codes
        {
            Ok,
            Error,
            ImportError,
            ResetError,
            ResetOk,
            ErrorXml
        };

        public enum FsVersion
        {
            Fs9,
            FsX,
            None
        };
    }
}
