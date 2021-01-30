using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        private readonly Member[] Members = GetMembers().ToArray();

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == typeof(T) && Members.All(m =>
            {
                var otherValue = m.GetValue(obj);
                var thisValue = m.GetValue(this);
                return m.IsNonStringEnumerable
                    ? GetEnumerableValues(otherValue).SequenceEqual(GetEnumerableValues(thisValue))
                    : otherValue?.Equals(thisValue) ?? thisValue == null;
            });
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(
                Members.Select(m => m.IsNonStringEnumerable
                    ? CombineHashCodes(GetEnumerableValues(m.GetValue(this)))
                    : m.GetValue(this)));
        }


        public override string ToString()
        {
            if (Members.Length == 1)
            {
                var m = Members[0];
                var value = m.GetValue(this);
                return m.IsNonStringEnumerable
                    ? $"{string.Join("|", GetEnumerableValues(value))}"
                    : value.ToString();
            }

            var values = Members.Select(m =>
            {
                var value = m.GetValue(this);
                return GetString(m, value);
            });
            return $"{typeof(T).Name}[{string.Join("|", values)}]";
        }

        private static string GetString(Member m, object value)
        {
            if (m.IsNonStringEnumerable)
            {
                return $"{m.Name}:{string.Join("|", GetEnumerableValues(value))}";
            }

            return m.Type != typeof(string)
                ? $"{m.Name}:{value}"
                : NotNullValueAsString(m, value);
        }

        private static string NotNullValueAsString(Member m, object value)
        {
            return value == null
                ? $"{m.Name}:null"
                : $"{m.Name}:\"{value}\"";
        }

        private static IEnumerable<Member> GetMembers()
        {
            var t = typeof(T);
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
            while (t != typeof(object))
            {
                if (t == null)
                {
                    continue;
                }

                foreach (var p in t.GetProperties(flags))
                {
                    yield return new Member(p);
                }

                foreach (var f in t.GetFields(flags))
                {
                    yield return new Member(f);
                }

                t = t.BaseType;
            }
        }

        private static IEnumerable<object> GetEnumerableValues(object obj)
        {
            var enumerator = ((IEnumerable)obj).GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        private static int CombineHashCodes(IEnumerable<object> objs)
        {
            unchecked
            {
                return objs.Aggregate(17, (current, obj) => current * 59 + (obj?.GetHashCode() ?? 0));
            }
        }

        private struct Member
        {
            public readonly string Name;
            public readonly Func<object, object> GetValue;
            public readonly bool IsNonStringEnumerable;
            public readonly Type Type;

            public Member(MemberInfo info)
            {
                switch (info)
                {
                    case FieldInfo field:
                        Name = field.Name;
                        GetValue = obj => field.GetValue(obj);
                        IsNonStringEnumerable = typeof(IEnumerable).IsAssignableFrom(field.FieldType) &&
                                                field.FieldType != typeof(string);
                        Type = field.FieldType;
                        break;
                    case PropertyInfo prop:
                        Name = prop.Name;
                        GetValue = obj => prop.GetValue(obj);
                        IsNonStringEnumerable = typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) &&
                                                prop.PropertyType != typeof(string);
                        Type = prop.PropertyType;
                        break;
                    default:
                        throw new ArgumentException("Member is not a field or property?!?!", info.Name);
                }
            }
        }
    }
}