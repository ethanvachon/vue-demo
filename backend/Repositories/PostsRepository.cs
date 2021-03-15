using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using backend.Models;
using Dapper;

namespace backend.Repositories
{
  public class PostsRepository
  {
    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Post> GetAll()
    {
      string sql = @"
      SELECT 
      p.*,
      pr.*
      FROM posts p
      JOIN profiles pr ON p.creatorid = pr.id;";
      return _db.Query<Post, Profile, Post>(sql, (post, profile) => { post.Creator = profile; return post; }, splitOn: "id");
    }

    internal Post GetById(int id)
    {
      string sql = @"
      SELECT
      p.*,
      pr.*
      FROM posts p 
      JOIN profiles pr ON p.creatorid = pr.id
      WHERE p.id = @id;";
      return _db.Query<Post, Profile, Post>(sql, (post, profile) => { post.Creator = profile; return post; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Post newPost)
    {
      string sql = @"
      INSERT INTO posts
      (creatorId, body)
      VALUES
      (@CreatorId, @Body);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newPost);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM posts WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Post> GetByProfile(string id)
    {
      string sql = @"
      SELECT
      p.*,
      pr.*
      FROM posts p
      JOIN profiles pr ON p.creatorid = pr.id
      WHERE p.creatorid = @id;";
      return _db.Query<Post, Profile, Post>(sql, (post, profile) => { post.Creator = profile; return post; }, new { id }, splitOn: "id");
    }
  }
}