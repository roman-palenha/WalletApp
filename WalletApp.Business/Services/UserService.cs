using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WalletApp.Business.Dto;
using WalletApp.Business.Services.Interfaces;
using WalletApp.Data;
using WalletApp.Data.Entities;

namespace WalletApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            if (id <= 0) 
                throw new ArgumentOutOfRangeException(nameof(id));

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                throw new InvalidOperationException(nameof(user));

            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task<int> CalculatePointsAsync(int id)
        {
            var currentDate = DateTime.UtcNow;
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) 
                throw new InvalidOperationException(nameof(user));

            if (user.PointsDate?.Date == currentDate.Date)
            {
                return user.Points;
            }

            var points = CalculatePointsForCurrentDate(currentDate, user.PointsDate ?? currentDate.AddDays(-1));
            user.Points += Convert.ToInt32(points);
            user.PointsDate = currentDate;

            await _dbContext.SaveChangesAsync();
            return user.Points;
        }

        public async Task<User> CreateUserAsync(UserDto user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var result = _mapper.Map<User>(user) ?? throw new InvalidOperationException();
            await _dbContext.Users.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        private double CalculatePointsForCurrentDate(DateTime currentDate, DateTime? lastPointsDate)
        {
            if (IsFirstOrSecondDayOfSeason(currentDate))
            {
                return currentDate.Day == 1 ? 2 : 3;
            }

            return CalculateDynamicPoints(currentDate, lastPointsDate ?? currentDate);
        }

        private double CalculateDynamicPoints(DateTime currentDate, DateTime lastPointsDate)
        {
            var daysPassed = (currentDate - lastPointsDate).Days;
            double basePoints = daysPassed switch
            {
                1 => 2,
                2 => 3,
                _ => CalculateDynamicPoints(currentDate.AddDays(-1), lastPointsDate)
            };
            return basePoints * 1.6;
        }

        private bool IsFirstOrSecondDayOfSeason(DateTime date)
        {
            return date.Month % 3 == 1 && (date.Day == 1 || date.Day == 2);
        }
    }
}
