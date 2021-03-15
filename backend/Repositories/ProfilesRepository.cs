using System;
using System.Data;
using backend.Models;
using Dapper;

namespace backend.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = @"SELECT * FROM profiles WHERE id = @id;";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
      (name, picture, email, id)
      VALUES
      (@Name, @Picture, @Email, @Id)
      ;";
      _db.Execute(sql, userInfo);
      return userInfo;
    }

    internal object GetAll()
    {
      string sql = "SELECT * FROM profiles";
      return _db.Query<Profile>(sql);
    }
  }
}