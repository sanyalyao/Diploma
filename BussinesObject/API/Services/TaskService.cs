using BussinesObject.API.Models.TaskData;
using Core.RestCore;
using Newtonsoft.Json;
using RestSharp;
using BussinesObject.API.Models.SuccessResponses;
using BussinesObject.API.Models.TaskObjects;
using NUnit.Allure.Attributes;

namespace BussinesObject.API.Services
{
    public class TaskService : BaseService
    {
        private string SpecialTaskEndpoint = BaseTaskEndpoint + "/{id}";
        private string GetTaskEndpoint = BaseTaskEndpoint;

        public TaskService(BaseAPIClient apiClient) : base(apiClient) { }

        [AllureStep("Get list of tasks")]
        public List<RecentItem> GetTasks()
        {
            var request = new RestRequest(GetTaskEndpoint);
            var response = apiClient.Execute(request).Content;

            logger.Info("Get list of tasks");

            return JsonConvert.DeserializeObject<Items<List<RecentItem>>>(response).RecentItems;
        }

        [AllureStep("Get special task")]
        public TaskModel GetTask(RecentItem task)
        {
            var request = new RestRequest(SpecialTaskEndpoint).AddUrlSegment("id", task.Id);
            var response = apiClient.Execute(request).Content;

            logger.Info($"Get special task. Task ID - {task.Id}");

            return JsonConvert.DeserializeObject<TaskModel>(response);
        }

        [AllureStep("Create new task")]
        public SuccessTaskCreation CreateNewTask(TaskModel newTask)
        {
            var request = new RestRequest(GetTaskEndpoint, Method.Post);
            var body = JsonConvert.SerializeObject(newTask);
            request.AddBody(body);

            SuccessTaskCreation response = JsonConvert.DeserializeObject<SuccessTaskCreation>(apiClient.Execute(request).Content);

            logger.Info($"Create new task");

            return response;
        }

        [AllureStep("Delete special task")]
        public RestResponse DeleteTask(RecentItem task)
        {
            logger.Info($"Delete special task with ID - {task.Id}");

            return apiClient.Execute(new RestRequest(SpecialTaskEndpoint, Method.Delete).AddUrlSegment("id", task.Id));
        }

        [AllureStep("Edit special task")]
        public RestResponse EditTask(RecentItem oldTask, TaskModel newTask)
        {
            var request = new RestRequest(SpecialTaskEndpoint, Method.Patch).AddUrlSegment("id", oldTask.Id);
            var body = JsonConvert.SerializeObject(newTask);
            request.AddBody(body);

            logger.Info($"Edit Task with ID - {oldTask.Id}");

            return apiClient.Execute(request);
        }

        public string GetSubject(Subject subject)
        {
            string subjectString = Enum.GetName(typeof(Subject), subject);
            return subjectString ?? "Other";
        }

        public string GetStatus(Status status)
        {
            string statusString = Enum.GetName(typeof(Status), status);
            return statusString ?? "Deferred";
        }
    }
}
