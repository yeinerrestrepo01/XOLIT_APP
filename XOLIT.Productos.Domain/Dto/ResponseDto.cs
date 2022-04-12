using System.Net;

namespace XOLIT.Productos.Domain.Dto
{
    /// <summary>
    /// Response DTO
    /// </summary>
    /// <typeparam name="T">Propiedad de respuesta</typeparam>
    public class ResponseDto<T>
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string? Message { get; set; }
        public int? Count { get; set; }
        public T? Data { get; set; }
    }
}
