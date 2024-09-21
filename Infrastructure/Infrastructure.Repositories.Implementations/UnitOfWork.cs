using System.Threading.Tasks;
using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

/// <summary>
/// UOW.
/// </summary>
public class UnitOfWork: IUnitOfWork
{
    private ICourseRepository _courseRepository;
    private ILessonRepository _lessonRepository;
    private DatabaseContext _context;

    public ICourseRepository CourseRepository => _courseRepository;
    public ILessonRepository LessonRepository => _lessonRepository;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        _lessonRepository = new LessonRepository(context);
        _courseRepository = new CourseRepository(context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}