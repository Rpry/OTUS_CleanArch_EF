using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using StateMachine.Compose;
using Xunit;

namespace Tests
{
    public class RepositoryTests 
    {
        private CourseRepository _courseRepository;
        
        public RepositoryTests()
        {
            var builder = new ConfigurationBuilder();
            var configuration = builder.Build();
            var serviceCollection = ServiceCollectionExtensions.PopulateServiceCollection(new ServiceCollection(), configuration, "Tests");
            serviceCollection.ConfigureInMemoryContext();
            var serviceProvider =  serviceCollection.BuildServiceProvider();
            _courseRepository = serviceProvider.GetService<CourseRepository>();
        }

        [Fact]
        public async Task CreatingCourses()
        {
            //Arrange
            var course1Entity = new Course
            {
                Name = "Course1",
                Price = 1
            };
            var course2Entity = new Course
            {
                Name = "Course1",
                Price = 1
            };
            
            //Act
            var course1 = await _courseRepository.AddAsync(course1Entity);
            var course2 = await _courseRepository.AddAsync(course2Entity);
            await _courseRepository.SaveChangesAsync();

            //Assert
            var courses=_courseRepository.GetAll().ToList();
            courses.Count.ShouldBe(2);
            courses.Contains(course1);
            courses.Contains(course2);
        }
    }
}