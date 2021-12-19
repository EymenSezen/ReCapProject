using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);//cachede var mı
        void Remove(string key);//cacheden uçur
        void RemoveByPattern(string pattern);//başı ve sonu önemli değil içinde mesela "get,category" gibi patterna göre
    }
}
