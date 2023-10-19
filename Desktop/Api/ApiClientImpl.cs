using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Desktop.Annotations;
using Entities.Models;
using Newtonsoft.Json;

namespace Desktop.Api
{
    public class ApiClientImpl : IApiClient
    {

        private readonly HttpClient _httpClient;

        public ApiClientImpl()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("http://45.144.64.179/api/");
        }

        [CanBeNull]
        [ItemCanBeNull]
        public async Task<TokenModel> LoginUserAsync(UserModel userModel)
        {
            var authData = new {Email = userModel.Email, Password = userModel.Password};

            var json = JsonConvert.SerializeObject(authData);

            var response = await _httpClient.PostAsync("auth/login",
                    new StringContent(json, System.Text.Encoding.UTF8, "application/json-patch+json"))
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode) return null;

            var jsonResult = await response.Content.ReadAsStringAsync();
            var authResult = JsonConvert.DeserializeObject<DataModel>(jsonResult);
            return authResult?.Data;
        }

        [CanBeNull]
        [ItemCanBeNull]
        public async Task<TokenModel> RegistrationUserAsync(UserModel userModel)
        {
            var authData = new {Name = userModel.Name, Email = userModel.Email, Password = userModel.Password};

            var json = JsonConvert.SerializeObject(authData);

            var response = await _httpClient.PostAsync("auth/registration",
                    new StringContent(json, System.Text.Encoding.UTF8, "application/json-patch+json"))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var authResult = JsonConvert.DeserializeObject<DataModel>(jsonResult);
                return authResult?.Data;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserModel> GetUserInformation()
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.Token);

            HttpResponseMessage response = await _httpClient.GetAsync("user").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<UserModelResponse>(json);
                return items.Data;
            }
            else
            {
                return null;
            }
        }

        [ItemCanBeNull]
        [CanBeNull]
        public async Task<ObservableCollection<TaskModel>> GetTasksAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.Token);

            HttpResponseMessage response = await _httpClient.GetAsync("todos").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<TaskListResponse>(json);
                return items.Data;
            }
            else
            {
                return null;
            }
        }

        [CanBeNull]
        [ItemCanBeNull]
        public async Task<TaskModel> CreateTaskAsync(TaskModel taskModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.Token);
            
            var json = JsonConvert.SerializeObject(taskModel);

            var response = await _httpClient.PostAsync("todos",
                    new StringContent(json, System.Text.Encoding.UTF8, "application/json-patch+json"))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<DataModel>(jsonResult);
                return items.TaskModel;
            }
            else
            {
                return null;
            }
        }

        [CanBeNull]
        public async Task DeleteTaskAsync(Guid id)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.Token);

            await _httpClient.DeleteAsync($"todos/{id}").ConfigureAwait(false);
        }
        
        [CanBeNull]
        public async Task MarkTaskAsync(Guid id)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.Token);
            
            await _httpClient.PutAsync($"todos/mark/{id}", null).ConfigureAwait(false);
        }
    }
}