﻿using KudryavtsevAlexey.Forum.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IListingService
    {
        public Task<List<ListingDto>> GetPublishedListings();

        public Task<List<ListingDto>> SortListingsByDate();

        public Task<ListingDto> GetPublishedListingById(int id);

        public Task<ListingDto> GetListingById(int id);

        public Task<List<ListingDto>> GetListingsByUserId(int id);

        public Task<List<ListingDto>> GetPublishedListingsByCategory(string category);

        public Task<List<ListingDto>> GetPublishedListingsByUserId(int id);

        public Task<List<ListingDto>> GetUnpublishedListingsByUserId(int id);

        public Task CreateListing(CreateListingDto listingDto);

        public Task UpdateListing(int id, UpdateListingDto listingDto);

        public Task DeleteListing(int id);
    }
}
