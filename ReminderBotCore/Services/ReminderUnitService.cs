using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    public class ReminderUnitService
    {
        private IBotRepo dBRepo;

        public ReminderUnitService(IBotRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
    }
}
