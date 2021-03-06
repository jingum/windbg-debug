﻿using System.Text;
using log4net;
using Microsoft.Diagnostics.Runtime.Interop;

namespace WinDbgDebug.WinDbg
{
    public class OutputCallbacks : IDebugOutputCallbacks2
    {
        private readonly ILog _logger = LogManager.GetLogger(nameof(OutputCallbacks));
        private readonly StringBuilder _buffer = new StringBuilder();
        private bool _isCatching = false;

        public int GetInterestMask(out DEBUG_OUTCBI Mask)
        {
            Mask = DEBUG_OUTCBI.ANY_FORMAT;
            return HResult.Ok;
        }

        public int Output(DEBUG_OUTPUT mask, string text)
        {
            _buffer.Append(text);
            DoOutput(text);
            return HResult.Ok;
        }

        public int Output2(DEBUG_OUTCB Which, DEBUG_OUTCBF Flags, ulong Arg, string Text)
        {
            _buffer.Append(Text);
            DoOutput(Text);

            return HResult.Ok;
        }

        public void Catch()
        {
            _isCatching = true;
        }

        public string StopCatching()
        {
            var result = _buffer.ToString();
            _buffer.Clear();
            _isCatching = false;

            return result;
        }

        private void DoOutput(string text)
        {
            if (_isCatching)
                return;

            if (text.Contains("\n"))
            {
                string message = _buffer.ToString();
                _logger.Debug(message);
                _buffer.Clear();
            }
        }
    }
}
