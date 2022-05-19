using System.Collections;
using Blazor.Data.Models;

namespace Blazor.Services;

public class CommentComparer : IComparer<Comment>
{
    public int Compare(Comment? x, Comment? y)
    {
        return -x.Date.CompareTo(y.Date);
    }
}