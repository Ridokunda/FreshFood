using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHelper
{
    // Generate a random salt
    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    // Hash the password with the salt
    public static string HashPassword(string password, byte[] salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000)) // 10000 iterations
        {
            byte[] hash = pbkdf2.GetBytes(20); // Generate a 20-byte hash
            byte[] hashBytes = new byte[36]; // Salt (16 bytes) + Hash (20 bytes)
            Array.Copy(salt, 0, hashBytes, 0, 16); // Copy salt
            Array.Copy(hash, 0, hashBytes, 16, 20); // Copy hash
            return Convert.ToBase64String(hashBytes); // Convert to base64 string for storage
        }
    }

    // Verify the password by comparing the hash
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
        using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
        {
            byte[] enteredHash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != enteredHash[i])
                    return false;
            }
        }
        return true;
    }
}
