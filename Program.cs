using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = "MySourceData";
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            Console.WriteLine(ByteArrayToString(tmpHash));

            sSourceData = "NotMySourceData";
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            byte[] tmpNewHash;

            tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            bool bEqual = false;
            if (tmpNewHash.Length == tmpHash.Length)
            {
                int i = 0;
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
                {
                    i += 1;
                }
                if (i == tmpNewHash.Length)
                {
                    bEqual = true;
                }
            }

            if (bEqual)
                Console.WriteLine("The two hash values are the same");
            else
                Console.WriteLine("The two hash values are not the same");
            Console.ReadLine();
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
