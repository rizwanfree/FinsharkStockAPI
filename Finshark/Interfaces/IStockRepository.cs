﻿using Finshark.DTOs.Stocks;
using Finshark.Models;

namespace Finshark.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(UpdateStockRequestDTO dto, int id);
        Task<Stock?> DeleteAsync(int id);
    }
}
