using System.Text.Json;

namespace XOLIT.ShoppingCart.Domain.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class DetalleErrorDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
