using BussinesObject.API.Models.TaskData;
using Core.RestCore;
using Newtonsoft.Json;
using RestSharp;
using BussinesObject.API.Models.SuccessResponses;
using BussinesObject.API.Models;

namespace BussinesObject.API.Services
{
    public class TaskService : BaseService
    {
        public string SpecialTaskEndpoint = "/services/data/v58.0/sobjects/Task/{id}";
        public string GetTaskEndpoint = "/services/data/v58.0/sobjects/Task";

        public TaskService(BaseAPIClient apiClient) : base(apiClient) { }

        public List<RecentItem> GetTasks()
        {
            var request = new RestRequest(GetTaskEndpoint);

            var response = apiClient.Execute(request).Content;

            return JsonConvert.DeserializeObject<Items<List<RecentItem>>>(response).RecentItems;
        }

        public SuccessTaskCreation CreateNewTask(TaskModel newTask)
        {
            var request = new RestRequest(GetTaskEndpoint, Method.Post);
            var body = JsonConvert.SerializeObject(newTask);
            request.AddBody(body);

            SuccessTaskCreation response = JsonConvert.DeserializeObject<SuccessTaskCreation>(apiClient.Execute(request).Content);

            return response;
        }

        public void DeleteTask(RecentItem task)
        {
            apiClient.Execute(new RestRequest(SpecialTaskEndpoint, Method.Delete).AddUrlSegment("id", task.Id));
        }

        public string GetSubject(subject subject)
        {
            switch (subject)
            {
                case subject.Call:
                    {
                        return "Call";
                    }
                case subject.Email:
                    {
                        return "Email";
                    }
                case subject.SendLetter:
                    {
                        return "Send Letter";
                    }
                case subject.SendQuote:
                    {
                        return "Send Quote";
                    }
                default:
                    {
                        return "Other";
                    }
            }
        }
    }
}
