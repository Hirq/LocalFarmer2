using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class AESHelper
{
    public static (byte[] EncryptedMessage, byte[] IV) Encrypt(string plainText, byte[] key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.GenerateIV(); // Generujemy nowy IV dla każdej wiadomości

            using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return (encryptedBytes, aesAlg.IV); // Zwracamy zaszyfrowaną wiadomość i IV
            }
        }
    }

    public static string Decrypt(byte[] cipherText, byte[] iv, byte[] key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
            {
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}