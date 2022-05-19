namespace Blazor.Services;

using System.Collections;
using Blazor.Data.Models;

public class PostComparer : IComparer<Post>
{
    public int Compare(Post? x, Post? y)
    {
        return -x.Date.CompareTo(y.Date);
    }
}