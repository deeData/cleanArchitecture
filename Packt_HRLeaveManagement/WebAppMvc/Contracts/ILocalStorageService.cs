using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMvc.Contracts
{
    //authentication using jwot- storing jwot
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        bool Exists(string key);
        T GetStorageValue<T>(string key);
        void SetStorageValue<T>(string key, T value);
    }
}
