using System;
using Forum.Data.Models;

public class DataSource
{
    private static DataSource instance;
    private DataSource()
    {
    }
    public static DataSource GetInstance()
    {
        if (instance == null)
        {
            instance = new DataSource();
        }
        return instance;
    }
    public List<User> _users = new List<User>();
    public List<Post> _posts = new List<Post>();
    public List<Comment> _comments = new List<Comment>();
}
