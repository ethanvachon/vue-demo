using System;
using System.Collections.Generic;
using System.Data;
using backend.Models;
using Dapper;

namespace backend.Repositories
{
  public class FollowingRepository
  {
    private readonly IDbConnection _db;

    public FollowingRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void Delete(object id)
    {
      throw new NotImplementedException();
    }

    internal Following GetById(int id)
    {
      string sql = "SELECT * FROM following WHERE id = @id;";
      return _db.QueryFirstOrDefault<Following>(sql, new { id });
    }

    internal int Create(Following newFollowing)
    {
      string sql = @"
      INSERT INTO following
      (followingId, followerId, creatorId)
      VALUES
      (@FollowingId, @FollowerId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newFollowing);
    }
    // internal IEnumerable<Following> GetByProfile(string id)
    // {
    //   string sql = @"
    //   SELECT 
    //   f.*,
    //   pr.*
    //   FROM following f
    //   JOIN profiles pr ON f.creatorId
    //   WHERE followingId = @id;";
    //   return _db.Query<Following, Profile, Following>(sql, (following, profile) => { following.Creator = profile; return following; }, splitOn: "id");
    // }

    internal IEnumerable<Following> GetByProfile(string id)
    {
      string sql = @"
      SELECT * FROM following WHERE followerId = @id";
      return _db.Query<Following>(sql, new { id });
    }
  }
}