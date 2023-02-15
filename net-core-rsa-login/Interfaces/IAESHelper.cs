using System;
namespace Interfaces
{
    public interface IAESHelper
    {
        string Decrypt(string value, string aesKey);
    }
}
