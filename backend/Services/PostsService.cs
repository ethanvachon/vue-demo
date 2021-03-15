using System;
using System.Collections.Generic;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
  public class PostsService
  {

    private readonly PostsRepository _repo;

    public PostsService(PostsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Post> Get()
    {
      return _repo.GetAll();
    }

    public Post Get(int id)
    {
      Post post = _repo.GetById(id);
      return post;
    }
    public Post Create(Post newPost)
    {
      _repo.Create(newPost);
      return newPost;
    }

    public string Delete(int id, string userId)
    {
      Post postToRemove = Get(id);
      if (postToRemove == null)
      {
        throw new Exception("invalid id");
      }
      _repo.Delete(id);
      return "deleted";
    }

    internal object GetByProfile(string id)
    {
      return _repo.GetByProfile(id);
    }
  }
}