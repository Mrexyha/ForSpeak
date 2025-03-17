using DAL.Entities.Languages;
using DAL.Repositories.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Languages
{
    public class LanguageService:ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
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
