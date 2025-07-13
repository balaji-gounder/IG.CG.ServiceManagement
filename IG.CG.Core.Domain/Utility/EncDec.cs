using System.Security.Cryptography;
using System.Text;

namespace IG.CG.Core.Domain.Utility
{
    public class EncDec
    {

        public string Encrypt(string? clearText)
        {
            string password = "MAKV2SPBNI99212";
            byte[] bytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
                {
                73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
                100, 101, 118
                });
                aes.Key = rfc2898DeriveBytes.GetBytes(32);
                aes.IV = rfc2898DeriveBytes.GetBytes(16);
                using MemoryStream memoryStream = new MemoryStream();
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                    cryptoStream.Close();
                }

                clearText = Convert.ToBase64String(memoryStream.ToArray());
            }

            return clearText;
        }

        public string Decrypt(string? cipherText)
        {
            string password = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] array = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
                {
                73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
                100, 101, 118
                });
                aes.Key = rfc2898DeriveBytes.GetBytes(32);
                aes.IV = rfc2898DeriveBytes.GetBytes(16);
                using MemoryStream memoryStream = new MemoryStream();
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(array, 0, array.Length);
                    cryptoStream.Close();
                }

                cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
            }

            return cipherText;
        }

        public string URLEncode(string? str)
        {
            String strTemp;
            string strChar;
            strTemp = "";
            strChar = "";
            int nTemp;
            int nAsciiVal;

            for (nTemp = 1; (nTemp <= str.Length); nTemp++)
            {
                var v = System.Text.Encoding.GetEncoding(1252).GetBytes(str.Substring(nTemp - 1, 1));
                nAsciiVal = Convert.ToByte(v[0]);

                //nAsciiVal = asciiBytes[nTemp-1];
                if ((nAsciiVal < 123) && (nAsciiVal > 96))
                {
                    strTemp = strTemp + ((char)(nAsciiVal));
                }
                else if ((nAsciiVal < 91) && (nAsciiVal > 64))
                {
                    strTemp = strTemp + ((char)(nAsciiVal));
                }
                else if ((nAsciiVal < 58) && (nAsciiVal > 47))
                {
                    strTemp = strTemp + ((char)(nAsciiVal));
                }
                else
                {
                    //strChar = Hex(nAsciiVal).Trim(); 
                    strChar = String.Format("{0:X2}", nAsciiVal).Trim();
                    if ((nAsciiVal < 16))
                    {
                        strTemp = (strTemp + ("%0" + strChar));
                    }
                    else
                    {
                        strTemp = (strTemp + ("%" + strChar));
                    }
                }
            }

            return strTemp;
        }

    }
}
