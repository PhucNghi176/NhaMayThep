using NhaMayThep.Application.LoaiCongTac;

namespace NhaMapThep.Api.Controllers.ResponseTypes
{
    /// <summary>
    /// Implicit wrapping of types that serialize to non-complex values.
    /// </summary>
    /// <typeparam name="T">Types such as string, Guid, int, long, etc.</typeparam>
    public class JsonResponse<T>
    {
        public JsonResponse(T value)
        {
            Value = value;
        }

        public JsonResponse(List<LoaiCongTacDto> result)
        {
        }

        public T Value { get; set; }
    }
}
