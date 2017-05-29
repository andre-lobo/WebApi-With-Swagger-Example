using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Utils
{
    public static class Encryption
    {
        #region Variables

        private static string _key = Settings.EncryptionKey;
        private static SymmetricAlgorithm _algorithm;

        #endregion

        #region Public Method

        public static string Encrypt(string value)
        {
            _algorithm = new RijndaelManaged();
            _algorithm.Mode = CipherMode.CBC;

            var plainByte = Encoding.UTF8.GetBytes(value);
            var keyByte = GetKey();

            _algorithm.Key = keyByte;
            _algorithm.IV = new byte[]
            {0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc};

            var cryptoTransform = _algorithm.CreateEncryptor();
            var _memoryStream = new MemoryStream();
            var _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Write);

            _cryptoStream.Write(plainByte, 0, plainByte.Length);
            _cryptoStream.FlushFinalBlock();
            byte[] cryptoByte = _memoryStream.ToArray();

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
        }

        public static string Decrypt(string valueEncrypt)
        {
            var cryptoByte = Convert.FromBase64String(valueEncrypt);
            var keyByte = GetKey();
            _algorithm.Key = keyByte;
            _algorithm.IV = new byte[]
            {0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc};
            var cryptoTransform = _algorithm.CreateDecryptor();

            try
            {
                var _memoryStream = new MemoryStream(cryptoByte, 0, cryptoByte.Length);
                var _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Read);
                var _streamReader = new StreamReader(_cryptoStream);
                return _streamReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Privates Methods

        private static byte[] GetKey()
        {
            string salt = string.Empty;

            if (_algorithm.LegalKeySizes.Length > 0)
            {
                int keySize = _key.Length * 8;
                int minSize = _algorithm.LegalKeySizes[0].MinSize;
                int maxSize = _algorithm.LegalKeySizes[0].MaxSize;
                int skipSize = _algorithm.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                    _key = _key.Substring(0, maxSize / 8);
                else if (keySize < maxSize)
                {
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;

                    if (keySize < validSize)
                        _key = _key.PadRight(validSize / 8, '*');
                }
            }
            var key = new PasswordDeriveBytes(_key, Encoding.ASCII.GetBytes(salt));
            return key.GetBytes(_key.Length);
        }

        #endregion
    }
}
