namespace Core.RestCore
{
    public class BaseService
    {
        protected BaseAPIClient apiClient;

        public BaseService(BaseAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }
    }
}