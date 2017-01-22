﻿namespace WinDbgDebug.WinDbg
{
    public static class ErrorCodes
    {
        #region Fields

        public static readonly int PlatformNotSupported = 1;
        public static readonly int TargetDoesNotExist = 2;
        public static readonly int FailedToLaunch = 3;
        public static readonly int MissingVariablesReference = 4;
        public static readonly int FailedToAttach = 5;

        #endregion
    }
}
