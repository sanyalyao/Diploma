using BussinesObject.API.Models;
using BussinesObject.API.Models.TaskData;
using DiplomaAPI.Tests;
using NUnit.Framework;

namespace TestCases.API
{
    public class TasksTests : TestBase
    {
        [Test]
        public void CreateTask()
        {
            TaskModel newTask = new TaskModel()
            {
                Subject = taskService.GetSubject(subject.SendLetter),
            };

            taskService.CreateNewTask(newTask);
        }

        [Test]
        public void DeleteTask() 
        {
            taskServiceSteps.DeleteTaskSteps(taskService.GetTasks()[0]);
        }

        [Test]
        public void EditTask()
        {

        }
    }
}
