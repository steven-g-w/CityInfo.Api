namespace CityInfo.Api.Common
{
    public interface IMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom input);
    }
}
