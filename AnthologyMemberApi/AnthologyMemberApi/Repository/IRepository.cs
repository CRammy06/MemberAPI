namespace AnthologyMemberApi.Repository
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public Task Update(T _object);

        public Task<List<T>> GetAll();

        public Task<T> GetById(int Id);

        public Task<int> Delete(T _object);

    }
}
