namespace dotnet_rpg.Models
{
    public class ServiceResponse<T>
    {
        //Wraps the api response
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;

    }
}
