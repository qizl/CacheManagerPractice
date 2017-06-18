using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CacheManagerPractice
{
    [TestClass]
    public class CacheManagersTests
    {
        private static string key = "GetAll";

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            var v = new List<string>() { "apple", "pen" };
            CacheManagers.Cache.Insert(key, v);
        }

        [TestMethod]
        public void Insert()
        {
            var v = new List<string>() { "apple", "123" };
            var r = CacheManagers.Cache.Insert(key, v);
            Assert.IsFalse(r);
        }

        [TestMethod]
        public void Get()
        {
            var r = CacheManagers.Cache.Get(key) as List<string>;
            Assert.IsTrue(r != null);
        }

        [TestMethod]
        public void Update()
        {
            var v = "ahaha...";
            var r = CacheManagers.Cache.Get(key) as List<string>;
            r.Add(v);

            CacheManagers.Cache.Update(key, r);

            var r1 = CacheManagers.Cache.Get(key) as List<string>;
            Assert.IsTrue(r != null && r.Contains(v));
        }

        [TestMethod]
        public void Delete()
        {
            CacheManagers.Cache.Delete(key);

            var r = CacheManagers.Cache.Get(key);
            Assert.IsTrue(r == null);
        }
    }
}