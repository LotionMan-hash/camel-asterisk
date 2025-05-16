using System.Numerics;
using System.Security.Cryptography;

namespace elgamal
{
    internal class Utils
    {
        static bool RabinMiller_test(BigInteger a, BigInteger n, BigInteger k, BigInteger m)
        {
            BigInteger mod = BigInteger.ModPow(a, m, n);
            if (mod == 1 || mod == n - 1)
                return true;
            for (int l = 1; l < k; ++l)
            {
                mod = (mod * mod) % n;
                if (mod == n - 1)
                    return true;
            }
            return false;
        }
        /// <summary>Kiểm tra số nguyên tố.</summary>
        public static bool IsPrimeNumber(BigInteger number)
        {
            if (number == 2 || number == 3 || number == 5 || number == 7)
                return true;
            if (number < 11)
                return false;
            BigInteger k = 0, m = number - 1;
            while (m % 2 == 0)
            {
                m /= 2;
                k++;
            }
            const int REPEAT = 3;
            for (int i = 0; i < REPEAT; ++i)
            {
                BigInteger a = RandomNumber(16, false, false) % (number - 3) + 2;
                if (!RabinMiller_test(a, number, k, m))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// <para>Euclid mở rộng: ax + by = GCD(a,b)</para> 
        /// </summary>
        /// <returns>x, y, GCD</returns>
        static (BigInteger x, BigInteger y, int gcd) ExtendedEuclid(BigInteger a, BigInteger b)
        {
            if (b == 0)
            {
                return (1, 0, (int)a);
            }
            else
            {
                var euc = ExtendedEuclid(b, a % b);
                BigInteger x = euc.y;
                BigInteger y = euc.x - ((a / b) * euc.y);
                return (x, y, euc.gcd);
            }
        }
        /// <summary>Nghịch đảo modulo (nghịch đảo của a trong vành Z_m).</summary>
        public static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(a, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(m, 2);
            var euc = ExtendedEuclid(a, m);      
            if (euc.gcd != 1)
            {
                Console.WriteLine("Khong the tinh nghich dao");
                return -1;
            }
            return (euc.x % m + m) % m;
        }
        ///<summary>Khởi tạo một số ngẫu nhiên.</summary>
        ///<param name="size">Kích cỡ của số ngẫu nhiên (theo byte)</param>
        ///<param name="isPrime">Có là số nguyên tố hay không.</param>
        ///<param name="showLog">Hiển thị lên console.</param>
        public static BigInteger RandomNumber(int size = 16, bool isPrime=false, bool showLog=true)
        {
            var randomBytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
                BigInteger rnd_number = new(randomBytes, true);
                if (isPrime) {
                    int i = 1;
                    while (!IsPrimeNumber(rnd_number))
                    {
                        Console.WriteLine(i + ": " + rnd_number.ToString());
                        rng.GetBytes(randomBytes);
                        rnd_number = new(randomBytes, true);
                        i++;
                    }
                    if (showLog)
                    {
                        if (IsPrimeNumber(rnd_number)) Console.WriteLine(i + ": " + rnd_number.ToString() + "(prime number)");
                        else Console.WriteLine(i + ": " + rnd_number.ToString());
                    }
                }
                else if(showLog) Console.WriteLine(rnd_number.ToString());
                rng.Dispose();
                return rnd_number;
            }
        }
        /// <summary>
        /// Chuyển một chuỗi thành số (theo ASCII)
        /// </summary>
        /// <param name="s">Input string.</param>
        public static BigInteger StringToNumber(string s)
        {
            BigInteger value = 0;
            foreach(char c in s)
            {
                BigInteger convert = (int)c;
                value = 256 * value + convert;
            }
            Console.WriteLine($"Convert: string '{s}' to number '{value}'");
            return value;
        }
        /// <summary>
        /// Chuyển một số thành chuỗi (theo ASCII)
        /// </summary>
        /// <param name="n">Input number.</param>
        public static string NumberToString(BigInteger n)
        {
            string result = string.Empty;
            BigInteger temp = n;
            while(n != 0)
            {
                BigInteger r = n % 256;
                n = n / 256;
                result += (char)r;
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result = new string(charArray);
            Console.WriteLine($"Convert: number '{temp}' to string '{result}'");
            return result;
        }
    }
}
