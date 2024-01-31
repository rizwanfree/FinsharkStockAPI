using Finshark.ApplicationDBContextF;
using Finshark.DTOs.Stocks;
using Finshark.Interfaces;
using Finshark.Models;
using Microsoft.EntityFrameworkCore;

namespace Finshark.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> UpdateAsync(UpdateStockRequestDTO dto, int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x =>x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            stockModel.Symbol = dto.Symbol;
            stockModel.CompanyName = dto.CompanyName;
            stockModel.Purchase = dto.Purchase;
            stockModel.LastDiv = dto.LastDiv;
            stockModel.MarketCap = dto.MarketCap;
            stockModel.Industry = dto.Industry;

            await _context.SaveChangesAsync();
            return stockModel;
        }
    }
}
