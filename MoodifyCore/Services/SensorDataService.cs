using MoodifyCore.Data;

namespace MoodifyCore.Services
{
    public interface ISensorDataService
    {
        SensorData GetSensorDataById(int id);
        List<SensorData> GetListOfSensorDataByUser(int userId);
        void CreateSensorData(SensorData data);
        void DeleteSensorData(int id);
    }
    public class SensorDataService : ISensorDataService
    {
        private readonly MoodifyDataContext dbContext;

        public SensorDataService(MoodifyDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateSensorData(SensorData entity)
        {
            dbContext.SensorDatas.Add(entity);
            dbContext.SaveChanges();
        }

        public void DeleteSensorData(int id)
        {
            var entity = dbContext.SensorDatas.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dbContext.SensorDatas.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public SensorData GetSensorDataById(int id)
        {
            var sensorDataById = dbContext.SensorDatas.FirstOrDefault(x => x.Id == id);
            if (sensorDataById == null)
                return null;

            return sensorDataById;
        }

        public List<SensorData> GetListOfSensorDataByUser(int userId)
        {
            var sensorDataList = dbContext.SensorDatas
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Timestamp)
                .ToList();

            if (sensorDataList == null)
                return null;

            return sensorDataList;
        }
    }
}
