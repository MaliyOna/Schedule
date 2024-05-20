using ScheduleAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Schedule.IntegrationTests;

[Collection("Sequential")]
public class MealGenericTests
{
    private readonly HttpClient _client;

    public MealGenericTests()
    {
        var factory = new TestingWebAppFactory();

        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedModel()
    {
        // Arrange
        var mealDto = new MealDTO { Id = "1", Time = new TimeOnly(12, 0) };
        var content = new StringContent(JsonSerializer.Serialize(mealDto), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/Meals", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var createdMeal = JsonSerializer.Deserialize<MealDTO>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.Equal(mealDto.Id, createdMeal.Id);
        Assert.Equal(mealDto.Time, createdMeal.Time);
    }

    [Fact]
    public async Task Delete_NotShouldReturnNotFound()
    {
        // Arrange
        var id = "2";
        await _client.DeleteAsync($"/api/Meals/{id}");

        // Act
        var response = await _client.DeleteAsync($"/api/Meals/{id}");

        // Assert
        Assert.NotEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllModels()
    {
        // Act
        var response = await _client.GetAsync("/api/Meals");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var meals = JsonSerializer.Deserialize<List<MealDTO>>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(meals);
        Assert.IsType<List<MealDTO>>(meals);
    }

    [Fact]
    public async Task GetById_ShouldReturnModel()
    {
        // Arrange
        var id = "3";
        var mealDto = new MealDTO { Id = id, Time = new TimeOnly(12, 0) };
        var content = new StringContent(JsonSerializer.Serialize(mealDto), Encoding.UTF8, "application/json");
        await _client.PostAsync("/api/Meals", content);

        // Act
        var response = await _client.GetAsync($"/api/Meals/{id}");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var meal = JsonSerializer.Deserialize<MealDTO>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.Equal(mealDto.Id, meal.Id);
        Assert.Equal(mealDto.Time, meal.Time);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedModel()
    {
        // Arrange
        var id = "4";
        var mealDto = new MealDTO { Id = id, Time = new TimeOnly(12, 0) };
        var content = new StringContent(JsonSerializer.Serialize(mealDto), Encoding.UTF8, "application/json");
        await _client.PostAsync("/api/Meals", content);

        var updatedMealDto = new MealDTO { Id = id, Time = new TimeOnly(14, 0) };
        var updatedContent = new StringContent(JsonSerializer.Serialize(updatedMealDto), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("/api/Meals", updatedContent);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var updatedMeal = JsonSerializer.Deserialize<MealDTO>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.Equal(updatedMealDto.Id, updatedMeal.Id);
        Assert.Equal(updatedMealDto.Time, updatedMeal.Time);
    }
}
