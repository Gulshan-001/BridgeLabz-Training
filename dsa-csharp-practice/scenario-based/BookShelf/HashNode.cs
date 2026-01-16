class HashNode
{
    public string Key { get; private set; }
    public BookLinkedList Value { get; set; }
    public HashNode Next { get; set; }

    public HashNode(string key, BookLinkedList value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}
