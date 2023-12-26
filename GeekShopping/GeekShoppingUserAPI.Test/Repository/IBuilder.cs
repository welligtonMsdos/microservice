namespace GeekShoppingUserAPI.Test.Repository;

internal interface IBuilder<T>
{
    T Post();
    T Put();
    Task<T> Get();
    Task<ICollection<T>> GetAll();
    int Delete();
    void Build();
    public int Id { get; }
}
