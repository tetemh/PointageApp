using System;
using Pointage.Core.Dtos;

namespace Pointage.Core.IRepositories;

public interface IStudentRepository
{

    Task<IEnumerable<StudentDto>> GetAllStudents();
    Task<StudentDto> GetStudent(int id);
    Task TogglePresenceStudent(int id);
    Task SetPresenceStudent(int id, bool IsPresent);

}
