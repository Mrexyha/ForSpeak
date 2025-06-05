using DAL.Entities.Modules;
using DAL.Entities.Tasks;

namespace DAL.Entities.Tasks
{
    public class SpeakingPhraseAttemptEntity
    {
        public int Id { get; set; }
        public int SpeakingPhraseId { get; set; }
        public SpeakingPhraseEntity Phrase { get; set; }

        public double Accuracy { get; set; }
        public DateTime AttemptedAt { get; set; }

    }
}