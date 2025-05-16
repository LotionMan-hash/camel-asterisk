using System.Numerics;

namespace elgamal
{
    internal class ElGamal
    {
        public static Key GenerateKey(int keySize = 16, bool doX = true)
        {
            int count = 0;
            Console.WriteLine("Generating p:");
            BigInteger p = Utils.RandomNumber(keySize, true);
            while(p == 2) { Console.WriteLine("p = 2, generating new p:"); p = Utils.RandomNumber(keySize, true); }
            Console.Write("Generating a({0:D}): ", count);
            BigInteger a = Utils.RandomNumber(keySize);
            while (a >= p || a < 2)
            {
                count++;
                Console.Write("Generating a({0:D}): " , count);
                a = Utils.RandomNumber(keySize);

            }
            BigInteger x = 0;
            BigInteger y = 0;
            if (doX)
            {
                count = 0;
                Console.Write("Generating x({0:D}): ", count);
                x = Utils.RandomNumber(keySize);
                while (x > p)
                {
                    count++;
                    Console.Write("Generating x({0:D}): ", count);
                    x = Utils.RandomNumber(keySize);
                }
                y = BigInteger.ModPow(a, x, p);
            }
            Console.WriteLine("Key generated: p = {0:D}, a = {1:D}, x = {2:D}, y = {3:D}", p, a, x, y);
            return new Key(p,a,x,y);
        }
        public static (BigInteger c1, BigInteger c2) Encrypt(BigInteger plain, Key key, BigInteger k)
        {
            Console.WriteLine("Encrypting plain text({0:D})...", plain);
            int count = 0;
            //var key = GenerateKey();
            ArgumentOutOfRangeException.ThrowIfLessThan(key.P, plain);
            if(k <= 0)
            {
                Console.Write("Generating k({0:D}): ", count);
                int k_size = key.P.GetByteCount();
                if (k_size > 1) { k_size--; }
                k = Utils.RandomNumber(k_size);
                while (k > key.P)
                {
                    count++;
                    Console.Write("Generating k({0:D}): ", count);
                    k = Utils.RandomNumber(k_size);
                }
            }
            BigInteger K = BigInteger.ModPow(key.Y, k, key.P);
            Console.WriteLine("K = " + K.ToString());
            BigInteger c1 = BigInteger.ModPow(key.A, k, key.P);
            //Console.WriteLine(K * plain);
            BigInteger c2 = (K * plain) % key.P;
            Console.WriteLine("Encrypting completed with: ");
            Console.WriteLine("c1 = " + c1);
            Console.WriteLine("c2 = " + c2);
            return (c1, c2);
        }
        public static string Decrypt(BigInteger c1, BigInteger c2, BigInteger x, BigInteger p, bool isString = true)
        {
            Console.WriteLine("Decrypting...");
            BigInteger K = BigInteger.ModPow(c1, x, p);
            Console.WriteLine("K = " + K.ToString());
            BigInteger data = (c2 * Utils.ModInverse(K, p)) % p;
            string plain = string.Empty;
            if (isString) { plain = Utils.NumberToString(data); }
            else { plain = data.ToString(); }                
            Console.WriteLine("Decrypting completed: " + plain);
            return plain;
        }
    }
}
