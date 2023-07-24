using Core.RestCore;
using BussinesObject.API.Models.SuccessResponses;
using NUnit.Framework;
using BussinesObject.API.Models.TaskData;
using BussinesObject.API.Services;
using BussinesObject.API.Models.TaskObjects;

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

            logger.Info($"Create new Task [Steps]. New Task ID - {response.Id}");
            logger.Info($"Is success status code - {response.Success}");

            Assert.Contains(response.Id, tasks);
            Assert.IsTrue(Boolean.Parse(response.Success));
        }

        public void DeleteTaskSteps(RecentItem task)
        {
            List<string> oldTasks = TaskService.GetTasks().Select(task => task.Id).ToList();

            var response = TaskService.DeleteTask(task);

            List<string> newTasks = TaskService.GetTasks().Select(task => task.Id).ToList();

            logger.Info($"Delete Task [Steps]. Is success status code - {response.IsSuccessStatusCode}");

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual(oldTasks.Count - 1, newTasks.Count);
        }

        public void EditTaskSteps(RecentItem oldTask, TaskModel newTask)
        {
            var response = TaskService.EditTask(oldTask, newTask);

            logger.Info($"Edit Task [Steps]" +
                $"\nCurrent Task:" +
                $"\nSubject - {oldTask.Subject}" +
                $"\nID - {oldTask.Id}");

            logger.Info($"\nNew Task:" +
                $"\nSubject - {newTask.Subject}" +
                $"\nStatus - {newTask.Status}");

            logger.Info($"Is success status code - {response.IsSuccessStatusCode}");

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
