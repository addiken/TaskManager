using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Manager.db_context;
using Task_Manager.Entity;
using Task_Manager.request;

namespace Task_Manager.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        public TaskController(ILogger<TaskController> logger)=> _logger = logger;
        [HttpGet]
        [Route("api/GetAllTask")]
        public IEnumerable<Task> Get()
        {
            using (TaskContext db = new TaskContext())
            {
                return db.Task.ToList();
            }
        }

        [HttpGet]
        [Route("api/GetTaskById")]
        public Task Get(int id)
        {
            using (TaskContext db = new TaskContext())
            {
                return db.Task.Find(id);
            }
        }

        [HttpPost]
        [Route("api/CreateTask")]
        public void CreateTask(CreateTaskRequest request)
        {
            Task task = new Task
            {
                Heading = request.Heading,
                Description = request.Description,
                CreateDate = DateTime.Now,
                Deadline = request.Deadline
            };
            using (TaskContext db = new TaskContext())
            {
                db.Task.Add(task);
                db.SaveChanges();
            }
        }
        [HttpPost]
        [Route("api/EditTask")]
        public void EditTask(EditTaskRequest request)
        {
            Task task = new Task
            {
                Id = request.Id,
                Heading = request.Heading,
                Description = request.Description,
                CreateDate = DateTime.Now,
                Deadline = request.Deadline,
                IsDone = request.IsDone
            };
            using (TaskContext db = new TaskContext())
            {
                db.Task.Update(task);
                db.SaveChanges();
            }
        }
        [HttpDelete]
        [Route("api/DeleteTask")]
        public void DeleteTask(int id)
        {
            using (TaskContext db = new TaskContext())
            {
                Task task = db.Task.Find(id);
                if (task != null){ db.Task.Remove(task); }
                db.SaveChanges();
            }
        }
    }
}
