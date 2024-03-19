using System.Security.Cryptography;

namespace Client
{
    internal class IdentificatoinKey
    {
        public string CreateKey()
        {
            using (var provider = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[16];
                provider.GetBytes(bytes);

                return new Guid(bytes).ToString();
            }
        }
    }
}
