namespace FootballManager.Bll.Helpers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class ToPasswordRepository
    {
        public static byte[] ByteDonustur(string value)
        {

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetBytes(value);

        }

        public static byte[] Byte8(string value)
        {
            char[] arrayChar = value.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
        }
        public static string Md5(string incomestring)
        {
            if (string.IsNullOrEmpty(incomestring))
            {
                throw new ArgumentNullException(@"Şifrelenecek veri yok");
            }
            else
            {
                MD5CryptoServiceProvider password = new MD5CryptoServiceProvider();
                byte[] passwordByte = password.ComputeHash(Encoding.UTF8.GetBytes(incomestring));
                var sb = new StringBuilder();
                foreach (byte b in passwordByte)
                    sb.Append(b.ToString("x2").ToLower());

                return sb.ToString();
            }
        }
        public static string Sha1(string incomestring)
        {
            if (string.IsNullOrEmpty(incomestring))
            {
                throw new ArgumentNullException(@"Şifrelenecek veri yok.");
            }
            else
            {
                SHA1CryptoServiceProvider sifre = new SHA1CryptoServiceProvider();
                 byte[] sifrebytes = sifre.ComputeHash(Encoding.UTF8.GetBytes(incomestring));
                 var sb = new StringBuilder();
                 foreach (byte b in sifrebytes)
                     sb.Append(b.ToString("x2").ToLower());

                 return sb.ToString();
            }
        }
        public static string Sha256(string strGiris)
        {
            if (string.IsNullOrEmpty(strGiris))
            {
                throw new ArgumentNullException(@"Şifrelenecek Veri Yok");
            }
            else
            {
                SHA256Managed sifre = new SHA256Managed();
                byte[] arySifre = ByteDonustur(strGiris);
                byte[] aryHash = sifre.ComputeHash(arySifre);
                return BitConverter.ToString(aryHash);
            }
        }
        public static string Sha384(string strGiris)
        {
            if (string.IsNullOrEmpty(strGiris))
            {
                throw new ArgumentNullException(@"Şifrelenecek veri bulunamadı.");
            }
            else
            {
                SHA384Managed sifre = new SHA384Managed();
                byte[] arySifre = ByteDonustur(strGiris);
                byte[] aryHash = sifre.ComputeHash(arySifre);
                return BitConverter.ToString(aryHash);
            }
        }
        public static string Sha512(string strGiris)
        {
            if (string.IsNullOrEmpty(strGiris))
            {
                throw new ArgumentNullException(@"Şifrelenecek veri yok.");
            }
            else
            {
                SHA512Managed sifre = new SHA512Managed();
                byte[] arySifre = ByteDonustur(strGiris);
                byte[] aryHash = sifre.ComputeHash(arySifre);
                return BitConverter.ToString(aryHash);
            }
        }

        public static string PasswordCryptographyCombine(string pass)
        {
            return (Md5(Sha384(Sha256(pass))));
        }
    }
}
