using DAL.Repositories.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.MainPage
{
    public class MainPageService : IMainPageService
    {
        private readonly ILanguageRepository _languageRepository;

        public MainPageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<List<string>> GetAllLanguagesAsync()
        {
            return await _languageRepository.GetAllLanguagesAsync();
        }
    }
}
