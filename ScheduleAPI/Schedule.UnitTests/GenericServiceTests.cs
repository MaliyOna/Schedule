using AutoMapper;
using Moq;
using ScheduleBLL.Models;
using ScheduleBLL.Services;
using ScheduleDAL.Entities;
using ScheduleDAL.Repositories;
using ScheduleDAL.Repositories.Abstractions;
using ScheduleDomain.Exceptions;

namespace Schedule.UnitTests;
public class GenericServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<MealEntity>> _mockGenericRepository;
    private readonly GenericService<MealModel, MealEntity> _genericService;

    public GenericServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockGenericRepository = new Mock<IGenericRepository<MealEntity>>();
        _genericService = new GenericService<MealModel, MealEntity>(_mockMapper.Object, _mockGenericRepository.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedModel()
    {
        // Arrange
        var mealModel = new MealModel { Id = "1", Time = new TimeOnly(12, 0) };
        var mealEntity = new MealEntity { Id = "1", Time = new TimeOnly(12, 0) };

        _mockMapper.Setup(m => m.Map<MealEntity>(It.IsAny<MealModel>())).Returns(mealEntity);
        _mockGenericRepository.Setup(r => r.Create(It.IsAny<MealEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(mealEntity);
        _mockMapper.Setup(m => m.Map<MealModel>(It.IsAny<MealEntity>())).Returns(mealModel);

        // Act
        var result = await _genericService.Create(mealModel, CancellationToken.None);

        // Assert
        Assert.Equal(mealModel, result);
    }

    [Fact]
    public async Task Delete_ShouldCallRepositoryDelete()
    {
        // Arrange
        var id = "1";

        _mockGenericRepository.Setup(r => r.Delete(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await _genericService.Delete(id, CancellationToken.None);

        // Assert
        _mockGenericRepository.Verify(r => r.Delete(id, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllModels()
    {
        // Arrange
        var mealEntities = new List<MealEntity>
            {
                new MealEntity { Id = "1", Time = new TimeOnly(12, 0) },
                new MealEntity { Id = "2", Time = new TimeOnly(13, 0) }
            };
        var mealModels = new List<MealModel>
            {
                new MealModel { Id = "1", Time = new TimeOnly(12, 0) },
                new MealModel { Id = "2", Time = new TimeOnly(13, 0) }
            };

        _mockGenericRepository.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(mealEntities);
        _mockMapper.Setup(m => m.Map<List<MealModel>>(It.IsAny<List<MealEntity>>())).Returns(mealModels);

        // Act
        var result = await _genericService.GetAll(CancellationToken.None);

        // Assert
        Assert.Equal(mealModels, result);
    }

    [Fact]
    public async Task GetById_ShouldReturnModel()
    {
        // Arrange
        var id = "1";
        var mealEntity = new MealEntity { Id = id, Time = new TimeOnly(12, 0) };
        var mealModel = new MealModel { Id = id, Time = new TimeOnly(12, 0) };

        _mockGenericRepository.Setup(r => r.GetById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(mealEntity);
        _mockMapper.Setup(m => m.Map<MealModel>(It.IsAny<MealEntity>())).Returns(mealModel);

        // Act
        var result = await _genericService.GetById(id, CancellationToken.None);

        // Assert
        Assert.Equal(mealModel, result);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedModel()
    {
        // Arrange
        var mealModel = new MealModel { Id = "1", Time = new TimeOnly(12, 0) };
        var mealEntity = new MealEntity { Id = "1", Time = new TimeOnly(12, 0) };

        _mockMapper.Setup(m => m.Map<MealEntity>(It.IsAny<MealModel>())).Returns(mealEntity);
        _mockGenericRepository.Setup(r => r.GetById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(mealEntity);
        _mockGenericRepository.Setup(r => r.Update(It.IsAny<MealEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(mealEntity);
        _mockMapper.Setup(m => m.Map<MealModel>(It.IsAny<MealEntity>())).Returns(mealModel);

        // Act
        var result = await _genericService.Update(mealModel, CancellationToken.None);

        // Assert
        Assert.Equal(mealModel, result);
    }

    [Fact]
    public async Task Update_ShouldThrowNotFoundException_WhenEntityNotFound()
    {
        // Arrange
        var mealModel = new MealModel { Id = "1", Time = new TimeOnly(12, 0) };
        var mealEntity = new MealEntity { Id = "1", Time = new TimeOnly(12, 0) };

        _mockMapper.Setup(m => m.Map<MealEntity>(It.IsAny<MealModel>())).Returns(mealEntity);
        _mockGenericRepository.Setup(r => r.GetById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((MealEntity)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _genericService.Update(mealModel, CancellationToken.None));
    }
}
