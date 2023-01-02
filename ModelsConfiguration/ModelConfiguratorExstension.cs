using System.Linq;

namespace FlightREST.ModelsConfiguration
{
    public static class ModelConfiguratorExstension
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((char x, int i) => (i <= 0 || !char.IsUpper(x)) ? x.ToString() : ("_" + x))).ToLower();
        }
    }
}
