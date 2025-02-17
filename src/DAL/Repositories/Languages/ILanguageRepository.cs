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
        //Language GetById(int id);
        //List<Language> GetAll();
        //void Add(Language language);
        //void Update(Language language);
        //void Delete(int id);

        Task<List<LanguageEntity>> GetAllLanguagesAsync();
        Task<LanguageEntity> GetByIdAsync(int id);
        Task AddLanguageAsync(LanguageEntity language);
    }
}
