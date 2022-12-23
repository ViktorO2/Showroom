using System.Text.Json;

namespace Showroom.ExtentionMethods
{
    public static class SessionExtentions
    {
        public static void Set<T> (this ISession instance,string key,T value)
            where T : class
        {
            if(value == null)
            {
                instance.Remove(key);
                return;
            }
            string jsonData = JsonSerializer.Serialize(value);
            instance.SetString(key, jsonData);

        }
        public static T Get<T>(this ISession instance, string key)
            where T : class
        {
            if (!instance.Keys.Contains(key))
                return null;

            string jsonData= instance.GetString(key);

            if(String.IsNullOrEmpty(instance.GetString(key)))
                return null;
            
            return JsonSerializer.Deserialize<T>(jsonData);
        
        }
    }
}
