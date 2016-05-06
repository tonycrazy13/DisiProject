using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace DisiProject.Util
{
    public class RSAXml
    {
        //move paths to config
        public Tuple<string, string, string, string> FirmaRSA(string cadena, string certificado, string keyPath, string password, string SerialNumber)
        {
            var ArchivoCertificado = certificado;

            var strCadenaOriginal = cadena;

            var certEmisor = new X509Certificate2();
            var byteCertData = ReadFile(ArchivoCertificado);
            certEmisor.Import(byteCertData);
            var cer = Convert.ToBase64String(certEmisor.GetRawCertData());

            var objCert = new X509Certificate2(ArchivoCertificado, password);
            var serie = objCert.SerialNumber;
            var serie1 = serie.Replace("3", "");
            //var serie1 = SerialNumber;
            // Sha1
            var oSHA1 = SHA1CryptoServiceProvider.Create();
            var textOriginal = Encoding.UTF8.GetBytes(strCadenaOriginal);
            var hash = oSHA1.ComputeHash(textOriginal);
            var oSB = new StringBuilder();

            foreach (byte i in hash)
                oSB.AppendFormat("{0:x2}", i);
            var sha_valido = oSB.ToString();

            // leer KEY
            var lSecStr = new SecureString();
            lSecStr.Clear();
            foreach (char c in password)
                lSecStr.AppendChar(c);

            var pLlavePrivadaenBytes = File.ReadAllBytes(keyPath);

            // Uso opensslkey para Leer Certificado
            var lrsa = opensslkey.DecodeEncryptedPrivateKeyInfo(pLlavePrivadaenBytes, lSecStr);
            var hasher = new SHA1CryptoServiceProvider();
            var bytesFirmados = lrsa.SignData(Encoding.UTF8.GetBytes(strCadenaOriginal), hasher);
            var sellodigital = Convert.ToBase64String(bytesFirmados);

            return Tuple.Create(sellodigital, cer, sha_valido, serie1);
        }

        public static byte[] ReadFile(string stArchivossss)
        {
            var f = new FileStream(stArchivossss, FileMode.Open, FileAccess.Read);
            var size = (int)f.Length;
            var data = new byte[size];
            f.Read(data, 0, size);
            f.Close();
            return data;
        }
    }
}