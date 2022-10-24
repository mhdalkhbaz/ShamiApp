using Domain.Material;
using SharedProject.Dtos;
using SharedProject.Dtos.Common;
using System.Diagnostics;
using System.Net.Http.Json;

namespace BlazorServer.Services
{
    public class ServiceGeneric<TDto, T, TCreateDto> : IServiceGeneric<TDto, T, TCreateDto>
    {
        private readonly HttpClient _httpClient;

        public ServiceGeneric(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddAsync(TCreateDto category)
        {
            var url = String.Format("api/{0}", typeof(T).Name);
            try
            {
                var httpResponseMessage = await _httpClient.PostAsJsonAsync<TCreateDto>(url, category);
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
        }
        public async Task UpdateAsync(TDto category)
        {
            var url = String.Format("api/{0}", typeof(T).Name);
            try 
            {
                var httpResponseMessage = await _httpClient.PutAsJsonAsync<TDto>(url, category);
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
        }


        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var url = String.Format("api/{0}/get-all", typeof(T).Name);
            IEnumerable<TDto> categories;
            try
            {
                var categorylist = await _httpClient.GetFromJsonAsync<PagingResultDto<TDto>>(url);
                categories = categorylist.Data;
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
            return categories;
        }

        public Task<TDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(int ssada)
        {
            var url = String.Format("api/{0}/delete-id", typeof(T).Name);
            var tt = await _httpClient.PutAsJsonAsync<int>(url, ssada);
        }
    }
}
