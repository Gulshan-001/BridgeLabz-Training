using System;
using System.Collections.Generic;

class BrowserUtilityImpl : IBrowser
{
    private PageNode currentPage;
    private Stack<PageNode> closedTabs = new Stack<PageNode>();

    public BrowserUtilityImpl(string homePage)
    {
        currentPage = new PageNode(homePage);
        Console.WriteLine("Opened homepage: " + homePage);
    }

    public void VisitPage(string url)
    {
        PageNode newPage = new PageNode(url);
        currentPage.Next = newPage;
        newPage.Prev = currentPage;
        currentPage = newPage;

        Console.WriteLine("Visited: " + url);
    }

    public void GoBack()
    {
        if (currentPage.Prev != null)
        {
            currentPage = currentPage.Prev;
            Console.WriteLine("Back to: " + currentPage.Url);
        }
        else
        {
            Console.WriteLine("No previous page");
        }
    }

    public void GoForward()
    {
        if (currentPage.Next != null)
        {
            currentPage = currentPage.Next;
            Console.WriteLine("Forward to: " + currentPage.Url);
        }
        else
        {
            Console.WriteLine("No forward page");
        }
    }

    public void CloseTab()
    {
        closedTabs.Push(currentPage);
        Console.WriteLine("Tab closed");
    }

    public void RestoreTab()
    {
        if (closedTabs.Count > 0)
        {
            currentPage = closedTabs.Pop();
            Console.WriteLine("Restored tab at: " + currentPage.Url);
        }
        else
        {
            Console.WriteLine("No closed tabs to restore");
        }
    }
}
