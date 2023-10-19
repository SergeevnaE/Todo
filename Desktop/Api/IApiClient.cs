using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Entities.Models;

namespace Desktop.Api
{
    public interface IApiClient
    {
        public Task<TokenModel> LoginUserAsync(UserModel userModel);

        public Task<TokenModel> RegistrationUserAsync(UserModel userModel);

        public Task<UserModel> GetUserInformation();

        public Task<ObservableCollection<TaskModel>> GetTasksAsync();

        public Task<TaskModel> CreateTaskAsync(TaskModel taskModel);

        public Task DeleteTaskAsync(Guid id);
    }
}