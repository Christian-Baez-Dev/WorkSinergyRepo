using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.DTOs.Entities.Common
{
    public class GetManyResponse<T> : Response<List<T>>
        where T : class
    {
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
        public bool HasNext  { get; set; }
        public bool HasPrevious { get; set; }   
    }
}
