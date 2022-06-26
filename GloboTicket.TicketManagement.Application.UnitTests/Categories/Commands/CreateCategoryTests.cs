using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMock.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);
            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            
            allCategories.Count.ShouldBe(6);
        } 
    }
}