using Hanssens.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvc.Contracts;

namespace WebAppMvc.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "LEAVEMGMT.JWOT"
            };
            _storage = new LocalStorage(config);
        }

        //when someone logs out
        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist();
        }

    }
}
