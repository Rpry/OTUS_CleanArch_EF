using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// UOW.
    /// </summary>
    public interface IUnitOfWork
    {
        ILessonRepository LessonRepository { get; }

        ICourseRepository CourseRepository { get; }

        Task SaveChangesAsync();
    }
}
