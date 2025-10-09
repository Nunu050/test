namespace PutApi.DTOs
{
    public class PaginationDto<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Items { get; set; }
    }
}
