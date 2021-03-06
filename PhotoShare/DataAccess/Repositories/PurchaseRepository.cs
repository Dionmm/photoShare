﻿using System.Linq;
using PhotoShare.DataAccess.DataContext;
using PhotoShare.DataAccess.Entities;
using PhotoShare.DataAccess.Repositories.Interfaces;

namespace PhotoShare.DataAccess.Repositories
{
    public class PurchaseRepository: Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(PhotoShareDbContext context) : base(context)
        {
        }

        public int GetNumberOfSalesByPhotoId(int photoId)
        {
            return Context.Purchases.Count(c => c.Photo.Id == photoId);
        }
    }
}