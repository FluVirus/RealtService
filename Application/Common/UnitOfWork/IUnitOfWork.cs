﻿using Microsoft.AspNetCore.Identity;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Common.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Offer> Offers { get; }
    IRepository<ResidentialOffer> ResidentialOffers { get; }
    IRepository<CommercialOffer> CommercialOffers { get; }
    IRepository<User> Users { get; }
    IRepository<Shop> Shops { get; }
    IRepository<Office> Offices { get; }
    IRepository<Restaurant> Restaurants { get; }
    IRepository<Estate> Estates { get; }
    IRepository<CommercialEstate> CommercialEstates { get; }
    IRepository<ResidentialEstate> ResidentialEstates { get; }
    IRepository<Warehouse> Warehouses { get; }
    IRepository<House> Houses { get; }
    IRepository<Rooms> Rooms { get; }
    IRepository<Flat> Flats { get; }
    UserManager<User> UserManager { get; }
    RoleManager<UserRole> RoleManager { get; }
    SignInManager<User> SignInManager { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}