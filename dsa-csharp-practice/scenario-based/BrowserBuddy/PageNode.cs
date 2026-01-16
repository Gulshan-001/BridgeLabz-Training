class PageNode
{
    public string Url { get; private set; }
    public PageNode Prev { get; set; }
    public PageNode Next { get; set; }

    public PageNode(string url)
    {
        Url = url;
        Prev = null;
        Next = null;
    }
}
