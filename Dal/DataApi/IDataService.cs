


namespace Dal.DataApi
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<bool> CreateAsync(T data);
        Task<bool> UpdateAsync(T data);
        Task<bool> DeleteAsync(params string[] list);

    }
}
