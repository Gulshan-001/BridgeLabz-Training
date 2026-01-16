interface IBrowser
{
    void VisitPage(string url);
    void GoBack();
    void GoForward();
    void CloseTab();
    void RestoreTab();
}
