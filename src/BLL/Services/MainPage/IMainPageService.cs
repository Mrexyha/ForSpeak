using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.MainPage
{
    public interface IMainPageService
    {
        //Task<IEnumerable<LightSideAchievementModel>> GetAchievementsAsync();
        //Task<IEnumerable<FeedbackModel>> GetFeedbacksAsync();
        //Task<IEnumerable<FeedbackModel>> GetTopTenFeedbacksAsync();

        Task<List<LanguageEntity>> GetAvailableLanguagesAsync();
        Task<LanguageEntity> GetLanguageByIdAsync(int id);

    }
}
