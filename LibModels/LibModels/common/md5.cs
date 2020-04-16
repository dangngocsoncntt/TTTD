using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LibModels.common
{
    public class md5
    {
        public md5()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string getMd5(string pass)
        {
            if (pass != "")
            {
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] hashedBytes;
                UTF8Encoding encoder = new UTF8Encoding();
                hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(pass));


                string hashedpass = BitConverter.ToString(md5Hasher.ComputeHash(encoder.GetBytes(pass)));

                return hashedpass;
            }
            return "";
        }
    }
}
