using System;
using System.Collections.Generic;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
  public class FollowingService
  {

    private readonly FollowingRepository _repo;

    private readonly ProfilesRepository _prepo;

    public FollowingService(FollowingRepository repo, ProfilesRepository prepo)
    {
      _repo = repo;
      _prepo = prepo;
    }

    internal Following Create(Following newFollowing, Profile userinfo)
    {
      Profile follower = _prepo.GetById(newFollowing.FollowerId);
      Profile following = _prepo.GetById(newFollowing.FollowingId);
      if (follower == null)
      {
        throw new Exception("Invalid follower Id");
      }
      if (following == null)
      {
        throw new Exception("invalid folllowing Id");
      }
      newFollowing.CreatorId = userinfo.Id;
      _repo.Create(newFollowing);
      return newFollowing;

    }

    internal void delete(int FollowingId, string UserId)
    {
      Following toDelete = _repo.GetById(FollowingId);
      if (toDelete.CreatorId != UserId)
      {
        throw new Exception("this account is not the creator of this object");
      }
      _repo.Delete(UserId);
    }

    internal IEnumerable<Following> GetByProfile(string id)
    {
      return _repo.GetByProfile(id);
    }
  }
}