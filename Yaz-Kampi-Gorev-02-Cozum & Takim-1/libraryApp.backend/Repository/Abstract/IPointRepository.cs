using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface IPointRepository
    {


        IQueryable<Point> GetAllPoints { get; }
        IQueryable<Point> GetAllPointsOfPunish(Point point);
        Task<Point> GetByIdAsync(int id);
        Task CreatePointAsync(Point point);
        Task UpdatePointAsync(Point point);
        Task DeletePointAsync(int id);

    }
}
