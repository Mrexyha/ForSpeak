using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Languages
{
    public interface ILanguageRepository
    {
        Task<List<LanguageEntity>> GetAllLanguagesAsync();
        Task<LanguageEntity?> GetByIdAsync(int id);
        Task UpdateLanguageAsync(LanguageEntity language);
    }
}
