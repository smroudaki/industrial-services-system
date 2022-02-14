using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Common.Interfaces
{
    public interface IChatRoomService
    {
        Task<bool> OrderRequestExistsAsync(Guid orderRequestGuid);

        Task<bool> IsOrderRequestAccessibleAsync(OrderRequest orderRequest);

        Task<OrderRequest> GetOrderRequestAsync(Guid orderRequestGuid);

        Task<Document> GetDocumentAsync(Guid documentGuid);

        Task<ChatMessage> CreateMessageAsync(int orderRequestId, string message, int userId, int? documentId);
    }
}
