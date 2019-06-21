using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public static class KriptoEntity
    {
        private static string sKey = "dSuUdFih";
        public static string EncryptString(string data)
        {
            MemoryStream msOutput = new MemoryStream();

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(msOutput,
               desencrypt,
               CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cryptostream);
            sw.WriteLine(data);
            sw.Close();
            cryptostream.Close();

            return Convert.ToBase64String(msOutput.ToArray());
        }

        public static string DecryptString(string data)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            MemoryStream ms = new MemoryStream(Convert.FromBase64String(data));
            CryptoStream encStream = new CryptoStream(ms, DES.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(encStream);

            string val = sr.ReadLine();

            sr.Close();
            encStream.Close();
            ms.Close();

            return val;
        }
    }
}
