﻿using System.Data.Entity;
using Domain.Entities;
using Domain.Entities.User;
using Infrastructure.Interfaces.Users;

namespace Infrastructure.Repository.Users
{
    public class PhotoRepository :
     BaseRepository<Photo>,
     IPhotoRepository
    {
        public PhotoRepository(DbContext context)
            : base(context)
        {

        }
    }
}
