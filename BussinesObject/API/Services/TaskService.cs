using BussinesObject.API.Models.TaskData;
using Core.RestCore;
using Newtonsoft.Json;
using RestSharp;
using BussinesObject.API.Models.SuccessResponses;
using BussinesObject.API.Models.TaskObjects;

namespace BussinesObject.API.Services
{
    public class TaskService : BaseService
    {
        private string SpecialTaskEndpoint = "/services/data/v58.0/sobjects/Task/{id}";
        private string GetTaskEndpoint = "/services/data/v58.0/sobjects/Task";

        public TaskService(BaseAPIClient apiClient) : base(apiClient) { }

        public List<RecentItem> GetTasks()
        {
            var request = new RestRequest(GetTaskEndpoint);

            var response = apiClient.Execute(request).Content;

            return JsonConvert.DeserializeObject<Items<List<RecentItem>>>(response).RecentItems;
        }

        public TaskModel GetTask(RecentItem task)
        {
            var request = new RestRequest(SpecialTaskEndpoint).AddUrlSegment("id", task.Id);
            var response = apiClient.Execute(request).Content;

            return JsonConvert.DeserializeObject<TaskModel>(response);
        }

        public SuccessTaskCreation CreateNewTask(TaskModel newTask)
        {
            var request = new RestRequest(GetTaskEndpoint, Method.Post);
            var body = JsonConvert.SerializeObject(newTask);
            request.AddBody(body);

            SuccessTaskCreation response = JsonConvert.DeserializeObject<SuccessTaskCreation>(apiClient.Execute(request).Content);

            return response;
        }

        public RestResponse DeleteTask(RecentItem task)
        {
            return apiClient.Execute(new RestRequest(SpecialTaskEndpoint, Method.Delete).AddUrlSegment("id", task.Id));
        }

        public RestResponse EditTask(RecentItem oldTask, TaskModel newTask)
        {
            var request = new RestRequest(SpecialTaskEndpoint, Method.Patch).AddUrlSegment("id", oldTask.Id);
            var body = JsonConvert.SerializeObject(newTask);
            request.AddBody(body);

            return apiClient.Execute(request);
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

        public string GetStatus(status status)
        {
            switch (status)
            {
                case status.NotStarted:
                    {
                        return "Not Started";
                    }
                case status.InProgress:
                    {
                        return "In Progress";
                    }
                case status.Completed:
                    {
                        return "Completed";
                    }
                case status.WaitingOnSomeoneElse:
                    {
                        return "Waiting on someone else";
                    }
                default:
                    {
                        return "Deferred";
                    }
            }
        }
    }
}
