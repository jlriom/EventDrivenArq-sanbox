namespace Common.Domain
{
    public class IdBase<T>
    {
        private readonly T _value;

        public IdBase(T value)
        {
            _value = value;
        }

        public static implicit operator T(IdBase<T> self)
        {
            return self._value;
        }

        public override bool Equals(object obj)
        {
            var other = (IdBase<T>)obj;
            if (other != null)
            {
                return _value.Equals(other._value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}