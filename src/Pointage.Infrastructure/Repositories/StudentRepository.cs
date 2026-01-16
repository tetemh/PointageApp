using System;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<StudentDto>> GetAllStudents()
    {
        return await _context.Students.Select(entity => new StudentDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsPresent = entity.IsPresent
        }).ToListAsync();
    }

    public async Task<StudentDto> GetStudent(int id)
    {
        StudentEntity? student = await _context.Students.FindAsync(id);

        if(student == null) throw new Exception("Student not found");

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            IsPresent = student.IsPresent
        };
    }

    public Task SetPresenceStudent(int id, bool IsPresent)
    {
        var entity = new StudentEntity
        {
            Id = id,
            IsPresent = IsPresent
        };

        _context.Students.Update(entity);
        return _context.SaveChangesAsync();
    }
}
