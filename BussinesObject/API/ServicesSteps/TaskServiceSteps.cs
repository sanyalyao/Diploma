using Core.RestCore;
using BusinessObject.API.Services;
using BussinesObject.API.Models;
using BussinesObject.API.Models.SuccessResponses;
using NUnit.Framework;
using BussinesObject.API.Models.TaskData;
using BussinesObject.API.Services;

namespace BussinesObject.API.ServicesSteps
{
    public class TaskServiceSteps : BaseService
    {
        protected TaskService TaskService;

        public TaskServiceSteps(BaseAPIClient apiClient, TaskService taskService) : base(apiClient)
        {
            TaskService = taskService;
        }

        public void CreateNewTaskSteps(TaskModel newTask)
        {
            SuccessTaskCreation response = TaskService.CreateNewTask(newTask);
            List<string> tasks = TaskService.GetTasks().Select(task => task.Id).ToList();

            Assert.Contains(response.Id, tasks);
            Assert.IsTrue(Boolean.Parse(response.Success));
        }

        public void DeleteTaskSteps(RecentItem task)
        {
            List<string> oldTasks = TaskService.GetTasks().Select(task => task.Id).ToList();

            TaskService.DeleteTask(task);

            List<string> newTasks = TaskService.GetTasks().Select(task => task.Id).ToList();

            Assert.AreEqual(oldTasks.Count - 1, newTasks.Count);
        }
    }
}
