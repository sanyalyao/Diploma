namespace Core.RestCore
{
    public class BaseService
    {
        protected BaseAPIClient apiClient;
        protected static string BaseTaskEndpoint = "/services/data/v58.0/sobjects/Task";

        public BaseService(BaseAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }
    }
}