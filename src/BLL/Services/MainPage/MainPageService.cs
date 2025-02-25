using DAL.Entities.Languages;
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

        public async Task<List<LanguageEntity>> GetAvailableLanguagesAsync()
        {
            return await _languageRepository.GetAllLanguagesAsync();
        }

        public async Task<LanguageEntity> GetLanguageByIdAsync(int id)
        {
            return await _languageRepository.GetByIdAsync(id);
        }

    }
}
