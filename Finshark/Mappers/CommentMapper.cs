using Finshark.DTOs.Comments;
using Finshark.Models;

namespace Finshark.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment c)
        {
            return new CommentDTO
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn,
                StockId = c.StockId,
            };
        }
    }
}
