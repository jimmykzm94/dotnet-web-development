using System;
using System.ComponentModel.DataAnnotations;

namespace api1.Students
{
    public record CreateStudentDTO
    {
        // Name of student, required
        [Required]
        public string Name { get; init; }

        // Age of student, required, change every year
        [Required]
        public int Age { get; set; }

        // Class of student, change every year
        [Required]
        public ClassEnum ClassName { get; set; }
    }

    public record UpdateStudentDTO
    {
        // Age of student, required, change every year
        [Required]
        public int Age { get; init; }

        // Class of student, change every year
        [Required]
        public ClassEnum ClassName { get; init; }
    }

    public record Student
	{
        // Student ID
        public Guid StudentId { get; init; }

        // Name of student, required
        public string Name { get; init; }

        // Age of student, required, change every year
        public int Age { get; set; }

        // Class of student, change every year
        public ClassEnum ClassName { get; set; }
    }

    // 4 class available
    public enum ClassEnum
    {
        A1,
        A2,
        B1,
        B2
    }
}

