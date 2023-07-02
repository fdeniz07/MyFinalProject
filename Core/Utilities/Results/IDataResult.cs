namespace Core.Utilities.Results
{
    //Void olmayan, deger döndüren yapilar icinde DataResult yapisi kullaniliyor
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}