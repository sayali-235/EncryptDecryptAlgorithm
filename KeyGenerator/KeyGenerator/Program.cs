using System;
using System.Security.Cryptography;

public static class RSAKeyGenerator
{
    public static (string PublicKey, string PrivateKey) GenerateKeys()
    {
        using var rsa = RSA.Create(2048);

        string publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
        string privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

        return (publicKey, privateKey);
    }
}

public static class ECCKeyGenerator
{
    public static (string PublicKey, string PrivateKey) GenerateKeys()
    {
        using var ecdh = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);

        string publicKey = Convert.ToBase64String(ecdh.PublicKey.ExportSubjectPublicKeyInfo());
        string privateKey = Convert.ToBase64String(ecdh.ExportPkcs8PrivateKey());

        return (publicKey, privateKey);
    }
}

class Program
{
    static void Main()
    {
        // RSA KEYS
        var rsaKeys = RSAKeyGenerator.GenerateKeys();
        Console.WriteLine("=== RSA PUBLIC KEY ===");
        Console.WriteLine(rsaKeys.PublicKey);

        Console.WriteLine("\n=== RSA PRIVATE KEY ===");
        Console.WriteLine(rsaKeys.PrivateKey);

        // ECC KEYS
        var eccKeys = ECCKeyGenerator.GenerateKeys();
        Console.WriteLine("\n=== ECC PUBLIC KEY ===");
        Console.WriteLine(eccKeys.PublicKey);

        Console.WriteLine("\n=== ECC PRIVATE KEY ===");
        Console.WriteLine(eccKeys.PrivateKey);
    }
}
