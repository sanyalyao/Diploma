using BussinesObject.API.Models.TaskData;
using BussinesObject.API.Models.TaskObjects;
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

            taskServiceSteps.CreateNewTaskSteps(newTask);
        }

        [Test]
        public void DeleteTask() 
        {
            taskServiceSteps.DeleteTaskSteps(taskService.GetTasks()[0]);
        }

        [Test]
        public void EditTask()
        {
            TaskModel newTask = new TaskModel()
            {
                Subject = taskService.GetSubject(subject.SendLetter),
                Status = taskService.GetStatus(status.Completed),
            };
            RecentItem oldTask = taskService.GetTasks()[0];

            taskServiceSteps.EditTaskSteps(oldTask, newTask);
        }
    }
}
