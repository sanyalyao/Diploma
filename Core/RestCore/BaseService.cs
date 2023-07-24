using NLog;

namespace Core.RestCore
{
    public class BaseService
    {
        protected BaseAPIClient apiClient;
        protected static string BaseTaskEndpoint = "/services/data/v58.0/sobjects/Task";
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public BaseService(BaseAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }
    }
}