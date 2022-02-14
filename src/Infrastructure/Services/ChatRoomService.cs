using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Exceptions;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Infrastructure.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IIndustrialServicesSystemContext _context;

        public ChatRoomService(IIndustrialServicesSystemContext context)
        {
            _context = context;
        }

        #region OrderRequest

        public async Task<bool> OrderRequestExistsAsync(Guid orderRequestGuid)
        {
            return await _context.OrderRequest
                .AnyAsync(x => x.OrderRequestGuid == orderRequestGuid);
        }

        public Task<bool> IsOrderRequestAccessibleAsync(OrderRequest orderRequest)
        {
            return Task.FromResult((orderRequest.Order.StateCodeId == 9
                && orderRequest.IsAllow) ||
                orderRequest.StateCodeId == 18);
        }

        public async Task<OrderRequest> GetOrderRequestAsync(Guid orderRequestGuid)
        {
            OrderRequest orderRequest = await _context.OrderRequest
                .Include(x => x.Order)
                .SingleOrDefaultAsync(x => x.OrderRequestGuid == orderRequestGuid);

            if (orderRequest == null)
                throw new ArgumentException("Invalid Order Request GUID");

            return orderRequest;
        }

        #endregion

        #region Document

        public async Task<Document> GetDocumentAsync(Guid documentGuid)
        {
            Document document = await _context.Document
                .Include(x => x.TypeCode)
                .SingleOrDefaultAsync(x => x.DocumentGuid == documentGuid);

            if (document == null)
                throw new ArgumentException("Invalid Document GUID");

            return document;
        }

        #endregion

        public async Task<ChatMessage> CreateMessageAsync(int orderRequestId, string text, int userId, int? documentId)
        {
            ChatMessage chatMessage = new ChatMessage
            {
                OrderRequestId = orderRequestId,
                UserId = userId,
                Text = text,
                DocumentId = documentId
            };

            _context.ChatMessage.Add(chatMessage);
            await _context.SaveChangesAsync(CancellationToken.None);

            return chatMessage;
        }
    }
}
