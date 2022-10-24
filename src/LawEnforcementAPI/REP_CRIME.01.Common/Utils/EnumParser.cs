namespace REP_CRIME._01.Common.Utils
{
    public static class EnumParser
    {
        public static T ParseEnum<T>(int value)
        {
            if (!Enum.IsDefined(typeof(T), value))
                return default;
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}