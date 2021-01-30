using Common.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Services.BlobStorage.Adapters
{
    public class RestClientAdapter : IBlobStorageClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiName;

        private readonly string _apiBasePath;

        public RestClientAdapter(IHttpClientFactory httpClientFactory, string apiName, string apiBasePath)
        {
            _httpClientFactory = httpClientFactory;
            _apiName = apiName;
            _apiBasePath = apiBasePath;
        }

        public async Task<byte[]> Get(Guid id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(_apiName))
            {
                var data = await httpClient.GetByteArrayAsync($"{_apiBasePath}/{id}").ConfigureAwait(false);

                return data;
            }
        }

        public async Task Delete(Guid id, string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_apiBasePath}/{id}");

            await SendRequest(request, accessToken);
        }

        public async Task Post(Guid id, byte[] content, string accessToken)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiBasePath}"))

            using (var httpContent = CreateHttpContent(new
            {
                Id = id,
                Blob = content
            }))
            {
                request.Content = httpContent;
                await SendRequest(request, accessToken);
            }
        }

        public async Task Put(Guid id, byte[] content, string accessToken)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, $"{_apiBasePath}/{id}"))

            using (var httpContent = CreateHttpContent(new
            {
                Blob = content
            }))
            {
                request.Content = httpContent;
                await SendRequest(request, accessToken);
            }
        }

        private async Task SendRequest(HttpRequestMessage request, string accessToken)
        {
            var httpClient = _httpClientFactory.CreateClient(_apiName);
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", accessToken);
            }

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                    response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException();
                }

                throw new AppException();
            }
        }

        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        private static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }
    }
}
