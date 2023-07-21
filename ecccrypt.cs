using System;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Encodings;

class Program
{
    static void Main(string[] args)
    {
        // Set up the ECC parameters
        X9ECParameters x9 = X9ECParametersFromNamedCurve("P-256");
        ECDomainParameters domainParameters = new ECDomainParameters(x9.Curve, x9.G, x9.N, x9.H, x9.GetSeed());

        // Generate key pair
        AsymmetricCipherKeyPair keyPair = GenerateKeyPair(domainParameters);

        // Encrypting and decrypting a message
        string originalMessage = "Hello, ECC!";
        byte[] encryptedMessage = Encrypt(originalMessage, keyPair.Public);
        string decryptedMessage = Decrypt(encryptedMessage, keyPair.Private);

        Console.WriteLine("Original Message: " + originalMessage);
        Console.WriteLine("Decrypted Message: " + decryptedMessage);
    }

    static AsymmetricCipherKeyPair GenerateKeyPair(ECDomainParameters domainParameters)
    {
        ECKeyPairGenerator generator = new ECKeyPairGenerator("ECDSA");
        generator.Init(new ECKeyGenerationParameters(domainParameters, new SecureRandom()));
        return generator.GenerateKeyPair();
    }

    static byte[] Encrypt(string plainText, AsymmetricKeyParameter publicKey)
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes(plainText);

        IAsymmetricBlockCipher ece = new OaepEncoding(new AesEngine());

        ece.Init(true, publicKey);

        return ece.ProcessBlock(message, 0, message.Length);
    }

    static string Decrypt(byte[] cipherText, AsymmetricKeyParameter privateKey)
    {
        IAsymmetricBlockCipher ece = new OaepEncoding(new AesEngine());

        ece.Init(false, privateKey);

        byte[] message = ece.ProcessBlock(cipherText, 0, cipherText.Length);

        return System.Text.Encoding.UTF8.GetString(message);
    }
}
