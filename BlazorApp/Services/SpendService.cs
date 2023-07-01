using BlazorApp.Models;
using BlazorApp.Services;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorApp.Servoces
{
    public class SpendService : ISpendService
    {

        private readonly ILocalStorageService localStorageService;

        public SpendService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        private string spendsLocalStorageKey = "spendKey";

        public async Task<List<Spend>> GetSpends()
        {
            var spendJson = await localStorageService.GetItemAsync<string>(spendsLocalStorageKey);
            if (string.IsNullOrWhiteSpace(spendJson))
            {
                return new();
            }

            return JsonSerializer.Deserialize<List<Spend>>(spendJson);
        }

        public async Task SaveSpends(List<Spend> spends)
        {
            var spendsJson = JsonSerializer.Serialize(spends);

            await localStorageService.SetItemAsync(spendsLocalStorageKey, spendsJson);
        }
    }
}
