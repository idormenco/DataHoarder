using System.Threading.Tasks;

namespace DataHoarder.Modules.Air.Core.BackgroundJobs
{
    internal interface IAirQualityCacheUpdaterBackgrounJob
    {
        Task UpdateAirQualityCacheAsync();
    }
}
