using System;
using api1.Students;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    [Route("students")]
	public class StudentController : ControllerBase
    {
        private StudentRepository repository;

		public StudentController(StudentRepository repository)
		{
            this.repository = repository;
        }

        // GET /students
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return repository.GetStudents();
        }

        // GET /students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            var student = repository.GetStudent(id);
            if (student == null)
            {
                return new NotFoundResult();
            }
            return student;
        }

        // POST /students
        [HttpPost]
        public ActionResult AddStudent(CreateStudentDTO student)
        {
            repository.AddNewStudent(new()
            {
                StudentId = Guid.NewGuid(),
                Name = student.Name,
                Age = student.Age,
                ClassName = (ClassEnum)student.ClassName
            });
            return new CreatedResult(nameof(AddStudent), student);
        }

        // PUT /students/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEveryYear(Guid id, UpdateStudentDTO s)
        {
            var student = repository.GetStudent(id);
            if (student is null) return new NotFoundResult();
            student.Age = s.Age;
            student.ClassName = s.ClassName;
            repository.UpdateEveryYear(id, student);
            return new AcceptedResult();
        }

        // DELETE /students/{id}
        [HttpDelete("{id}")]
        public ActionResult UpdateClass(Guid id)
        {
            var student = repository.GetStudent(id);
            if (student is null) return new NotFoundResult();
            repository.DeleteStudent(id);
            return new AcceptedResult();
        }
    }
}

