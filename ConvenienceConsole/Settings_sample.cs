using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvenienceBackend
{
    class Settings
    {
        public static readonly String Server = "";
        public static readonly String ServerIP = "";
        public static readonly int Port = 0;
        public static readonly char MsgSeperator = ' ';
        public static readonly string MsgInvalid = "_MsGInvalid_";
        public static readonly string MsgACK = "_MsGACK";

        public static readonly String DBName = "";
        public static readonly String DBUser = "";
        public static readonly String DBPass = "";
        
        public static readonly String MailFrom = "";
        //public static readonly int MailPort = 465;
        public static readonly int MailPort = 587;
        /*public static readonly string MailSMTPHost = "";
        public static readonly String MailUser = "";
        public static readonly String MailPass = ""; */
        public static readonly string MailSMTPHost = "";
        public static readonly String MailUser = "";
        public static readonly String MailPass = "";
        
        public static readonly String Contactmail = "";

    }
}
