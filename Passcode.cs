using System;
using System.Security.Cryptography;
using System.Text;


namespace RandomPasscode.Models.Home
{
    public class Passcode
    {
        public string randPass {get; set; }

        public int? timesVisited {get; set; }
    }
}
