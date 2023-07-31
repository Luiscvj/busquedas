public class Book
{
    public string  Title  { get; set; }
    public int PageCount { get; set; }
    public DateTime   PublishedDate { get; set; }
    public string Status { get; set; }
    public List<string>  Authors { get; set; }
    public List<string>  Categories { get; set; }
}