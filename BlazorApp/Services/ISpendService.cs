using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ISpendService
    {
        Task<List<Spend>> GetSpends();

        Task SaveSpends(List<Spend> spends);
    }
}
