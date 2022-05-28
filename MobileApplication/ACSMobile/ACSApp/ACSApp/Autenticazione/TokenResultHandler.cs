using System;
using System.Collections.Generic;
using System.Text;

namespace ACSApp.Autenticazione
{
    static class TokenResultHandler
    {
        public static ErrorResults isInvalid { get; set; }
        public static bool isSuccess => isInvalid == ErrorResults.TOKEN_CORRECT;

        



    }

    enum ErrorResults { 
        SERVER_ERROR,
        TOKEN_NOT_CORRECT,
        TOKEN_CORRECT
    }
}
