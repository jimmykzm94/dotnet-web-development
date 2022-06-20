using System;
namespace api1.Students
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudents();
        public Student? GetStudent(Guid studentId);
        public void AddNewStudent(Student student);
        public void UpdateAge(Guid studentId, int age);
        public void UpdateClass(Guid studentId, ClassEnum className);
    }

    public class StudentRepository //: IStudentRepository
    {
		private List<Student> students;
		public StudentRepository()
		{
            // Create few examples
            students = new()
            {
                new(){StudentId=Guid.NewGuid(), Name="Ally", Age=11, ClassName=ClassEnum.A1},
                new(){StudentId=Guid.NewGuid(),Name="Belly", Age=11, ClassName=ClassEnum.A1},
                new(){StudentId=Guid.NewGuid(),Name="Cecil", Age=11, ClassName=ClassEnum.A2},
                new(){StudentId=Guid.NewGuid(),Name="Diggle", Age=12, ClassName=ClassEnum.B1},
                new(){StudentId=Guid.NewGuid(),Name="Elpine", Age=12, ClassName=ClassEnum.B1},
                new(){StudentId=Guid.NewGuid(),Name="Falin", Age=12, ClassName=ClassEnum.B2},
            };
		}

		public IEnumerable<Student> GetStudents()
        {
            return students;
        }

        public Student? GetStudent(Guid studentId)
        {
            return students.Where(s => s.StudentId == studentId).SingleOrDefault();
        }

        public void AddNewStudent(Student student)
        {
            students.Add(student);
        }

        public void UpdateEveryYear(Guid studentId, Student student)
        {
            int index = students.FindIndex(s => s.StudentId == studentId);
            students[index].Age = student.Age;
            students[index].ClassName = student.ClassName;
        }

        public void DeleteStudent(Guid studentId)
        {
            int index = students.FindIndex(s => s.StudentId == studentId);
            students.RemoveAt(index);
        }
    }
}

