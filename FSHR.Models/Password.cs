using System.Security.Cryptography;

namespace FSHR.Models
{
    public class Password
    {
        private const int DefaultSaltByteSize = 512;
        private const int DefaultHasingIterationCount = 5;
        private const int DefaultHashByteSize = 1024;
        private static byte[] GenerateSalt(int saltByteSize)
        {
            using (var generator = new RNGCryptoServiceProvider())
            {
                var salt = new byte[saltByteSize];
                generator.GetBytes(salt);
                return salt;
            }
        }
        internal static byte[] ComputeHash(string password, byte[] salt, int iterations, int hashByteSize)
        {
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt))
            {
                hashGenerator.IterationCount = iterations;
                return hashGenerator.GetBytes(hashByteSize);
            }
        }

        public Password(string password)
        {
            HasingIterationCount = DefaultHasingIterationCount;
            HashByteSize = DefaultHashByteSize;

            Salt = GenerateSalt(DefaultSaltByteSize);
            Hash = ComputeHash(password, Salt, HasingIterationCount, HashByteSize);

            GenerationTime = System.DateTime.Now;
        }

        public byte[] Hash { get; private set; }
        public byte[] Salt { get; private set; }
        public int HasingIterationCount { get; private set; }
        public int HashByteSize { get; private set; }
        public System.DateTime GenerationTime { get; private set; }

        public bool IsMatch(string password)
        {
            var hash = ComputeHash(password, Salt, HasingIterationCount, HashByteSize);

            return System.Convert.ToBase64String(hash) == System.Convert.ToBase64String(Hash);
        }
    }
}