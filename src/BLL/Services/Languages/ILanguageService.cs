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
        Task<List<LanguageEntity>> GetAvailableLanguagesAsync();
        Task<LanguageEntity> GetLanguageByIdAsync(int id);
        Task UpdateLanguageAsync(LanguageEntity language);
    }
}
