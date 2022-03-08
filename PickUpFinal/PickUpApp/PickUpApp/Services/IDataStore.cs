using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickUpApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);

        Task<T> GetSendingAsync(string id);
        // Task<bool> AddItemByStringAsync(string id);
        // Task<IEnumerable<T>> GetItemsSelectedAsync();
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetSendingsAsync(bool forceRefresh = false);

        //for returnBox
        Task<IEnumerable<T>> GetDeliveriesAsync();
    }
}
