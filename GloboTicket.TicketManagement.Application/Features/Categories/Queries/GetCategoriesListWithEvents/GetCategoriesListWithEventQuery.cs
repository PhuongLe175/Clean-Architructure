using System.Collections.Generic;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventQuery: IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}