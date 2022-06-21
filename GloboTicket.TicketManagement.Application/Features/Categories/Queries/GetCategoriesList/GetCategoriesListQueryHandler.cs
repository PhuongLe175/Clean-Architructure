using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryResRepository;

        public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryResRepository)
        {
            _mapper = mapper;
            _categoryResRepository = categoryResRepository;
        }
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categoriesList = (await _categoryResRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<CategoryListVm>>(categoriesList);
        }
    }
}