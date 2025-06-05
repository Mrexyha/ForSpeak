using BLL.Models.Languages;
using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Languages
{
    public interface ILanguageService
    {
        Task<List<LanguageModel>> GetAvailableLanguagesAsync();
        Task<LanguageModel?> GetLanguageByIdAsync(int id);
        Task UpdateLanguageAsync(LanguageModel languageModel);
    }
}
