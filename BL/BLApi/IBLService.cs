
namespace BL.BLApi
{
    public interface IBLService<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<bool> CreateAsync(T data);
        public Task<bool> UpdateAsync(T data);
        public Task<bool> DeleteAsync(params string[] list);

    }
}
