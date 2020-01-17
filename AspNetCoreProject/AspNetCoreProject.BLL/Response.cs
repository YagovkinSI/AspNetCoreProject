using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreProject.BLL
{
    public class Response
    {
        public bool Success { get; }
        public string Error { get; }

        internal Response(bool success, string error = null)
        {
            Success = success;
            Error = error ?? string.Empty;
        }
    }
}
