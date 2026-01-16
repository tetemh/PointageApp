using System;
using Pointage.Core.Dtos;
using Pointage.Core.IRepositories;
using Pointage.Infrastructure.Contexts;
using Pointage.Infrastructure.Entities;

namespace Pointage.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{

    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<StudentDto>> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public Task<StudentDto> GetStudent(int id)
    {
        throw new NotImplementedException();
    }

    public Task SetPresenceStudent(int id, bool IsPresent)
    {
        throw new NotImplementedException();
    }

    public Task TogglePresenceStudent(int id)
    {
        throw new NotImplementedException();
    }
}
