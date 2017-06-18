using CacheManager.Core;

namespace CacheManagerPractice
{
    public class CacheManagers
    {
        private static CacheManagers customer = null;
        private static ICacheManager<object> manager = null;

        public static CacheManagers Cache
        {
            get
            {
                if (customer == null)
                {
                    customer = new CacheManagers();
                    manager = CacheFactory.Build("firstCache", settings =>
                    {
                        settings.WithSystemRuntimeCacheHandle("runtimeCache");
                    });
                }

                return customer;
            }
        }

        public bool Insert(string key, object value) => manager.Add(key, value);

        public object Get(string key) => manager.Get(key);

        public void Update(string key, object value) => manager.Update(key, m => value);

        public void Delete(string key) => manager.Remove(key);
    }
}