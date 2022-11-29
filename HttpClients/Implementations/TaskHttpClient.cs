using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Domain.DTOs.Task;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class TaskHttpClient:ITaskService
{
    private readonly HttpClient client;
    public TaskHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<TaskEntity> CreateAsync(TaskCreateDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/api/tasks", dto);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TaskEntity task = JsonSerializer.Deserialize<TaskEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return task;
    }

    public async Task UpdateAsync(TaskUpdateDTO dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/api/tasks", body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"/api/tasks/{id}");

        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<TaskEntity> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/api/tasks/{id}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TaskEntity task = JsonSerializer.Deserialize<TaskEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return task;
    }

    public async Task<IEnumerable<BasicTaskDTO>> GetByProjectIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/api/tasks/?projectId={id}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<BasicTaskDTO> task = JsonSerializer.Deserialize<IEnumerable<BasicTaskDTO>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return task;
    }
}