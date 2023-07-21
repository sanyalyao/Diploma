using Allure.Net.Commons;
using BussinesObject.API.Models.TaskData;
using BussinesObject.API.Models.TaskObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace TestCases.API
{
    public class TasksTests : TestBase
    {
        [Test]
        [Description("Create a task")]
        [Category("API"), Category("Task")]
        [Order(1)]
        [AllureSeverity(SeverityLevel.critical)]        

        public void CreateTask()
        {
            TaskModel newTask = new TaskModel()
            {
                Subject = taskService.GetSubject(Subject.SendLetter),
            };

            taskServiceSteps.CreateNewTaskSteps(newTask);
        }

        [Test]
        [Description("Delete a task")]
        [Category("API"), Category("Task")]
        [Order(3)]
        [AllureSeverity(SeverityLevel.critical)]

        public void DeleteTask() 
        {
            taskServiceSteps.DeleteTaskSteps(taskService.GetTasks()[0]);
        }

        [Test]
        [Description("Edit a task")]
        [Category("API"), Category("Task")]
        [Order(2)]
        [AllureSeverity(SeverityLevel.critical)]

        public void EditTask()
        {
            TaskModel newTask = new TaskModel()
            {
                Subject = taskService.GetSubject(Subject.SendLetter),
                Status = taskService.GetStatus(BussinesObject.API.Models.TaskObjects.Status.Completed),
            };
            RecentItem oldTask = taskService.GetTasks()[0];

            taskServiceSteps.EditTaskSteps(oldTask, newTask);
        }
    }
}
