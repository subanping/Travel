namespace WebApiStartup.DataSeeds
{
    /// <summary>
    /// 种子数据接口
    /// </summary>
    public interface IDataSeed
    {
        Task Initial();
    }
}
