using System.Numerics;

namespace elgamal
{
    internal class Key
    {
        public BigInteger P { get; set; }
        public BigInteger A { get; set; }
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }
        public Key(BigInteger p, BigInteger a, BigInteger x, BigInteger y)
        {
            P = p;
            A = a; 
            X = x; 
            Y = y;
        }
        public override string ToString() => $"(p = {P}, a = {A}, x = {X}, y = {Y})";
        public void Free()
        {
            P = 0;
            A = 0;
            X = 0;
            Y = 0;
        }
    }
}
