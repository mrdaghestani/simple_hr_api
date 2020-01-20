namespace FSHR.Models
{
    public class Password
    {
        public Password(string value, string salt)
        {
            Value = value;
            Salt = salt;
        }

        public string Value { get; private set; }
        public string Salt { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Password)) return false;
            var castedObj = (Password)obj;
            return this.Value.Equals(castedObj.Value) && this.Salt.Equals(castedObj.Salt);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() * 2 + Salt.GetHashCode() * 3;
        }

        public static bool operator ==(Password a, Password b)
        {
            return a?.Equals(b) ?? false;
        }
        public static bool operator !=(Password a, Password b)
        {
            return !(a == b);
        }
    }
}