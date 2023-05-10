using CSL.Encryption;
using BCrypt.Net;

namespace DaceloApi.Handlers;

public static class Hashing
{
    public static string GenerateHash(string plaintext)
    {
        return BCrypt.Net.BCrypt.HashPassword(plaintext, 13);
    }

    public static bool IsValid(string email, string plaintext)
    {
        //do some database magic!
        return true;
    }
}