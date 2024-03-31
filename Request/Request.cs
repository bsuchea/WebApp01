namespace WebApp01;

public class Request
{
    public string Text { get;  set; }

    public int Total { get; set; } = 0;

    public int Page { get; set; } = 0;

    public int PerPage { get; set; } = 5;

    public int Skip { get; set; } = 0;

    public int Take { get; set; } = 5;

}
