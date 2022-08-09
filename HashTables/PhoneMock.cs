namespace HashTables
{
    public class PhoneMock
    {
        public string AreaCode { get; }
        public string Excange { get; }
        public string Number { get; }

        public PhoneMock(string areaCode, string excange, string number)
        {
            AreaCode = areaCode;
            Excange = excange;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            var number = obj as PhoneMock;
            if (number is null)
            {
                return false;
            }

            return string.Equals(AreaCode, number.AreaCode) && string.Equals(Excange, number.Excange) && string.Equals(Number, number.Number);
        }

        public static bool operator ==(PhoneMock left, PhoneMock right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(null, left))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(PhoneMock left, PhoneMock right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            // large prime numbers to avoid collisions
            // The unchecked keyword is used to suppress overflow-checking for integral-type arithmetic operations and conversions.
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Excange) ? Excange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Number) ? Number.GetHashCode() : 0);

                return hash;
            }

            return base.GetHashCode();
        }
    }
}
