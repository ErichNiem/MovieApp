using AutoMapper;
using Moq;
using MovieApp.Data.DataModels;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Commands.Movies;
using MovieApp.Domain.Queries.Movies;

namespace MoviesApp.Unit.Tests
{
    [TestClass]
    public class MovieTests
    {
        private AddMovieHandler _addSubject = default!;
        private UpdateMovieHandler _updateSubject = default!;
        private DeleteMovieHandler _deleteSubject = default!;
        private GetMovieHandler _getSubject = default!;

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<IMovieRespository> _mockMovieRepository = new Mock<IMovieRespository>();

        [TestInitialize]
        public void Init()
        {

            _addSubject = new AddMovieHandler(_mockMovieRepository.Object, _mockMapper.Object);

            _updateSubject = new UpdateMovieHandler(_mockMovieRepository.Object, _mockMapper.Object);
            _deleteSubject = new DeleteMovieHandler(_mockMovieRepository.Object);
            _getSubject = new GetMovieHandler(_mockMovieRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task WhenAddMovieHandlerCalledWithValidAddMovieCommandObject_ReturnsInteger()
        {
            var addMovie = ArrangeNewAddMovieCommand();

            _mockMovieRepository.Setup(x => x.Add(It.IsAny<MovieDto>())).ReturnsAsync(1);
            _mockMapper.Setup(x => x.Map<AddMovieCommand, MovieDto>(It.IsAny<AddMovieCommand>())).Returns(
                new MovieDto { Id = 1 });

            var newMovieId = await _addSubject.Handle(addMovie);

            _mockMovieRepository.Verify(d => d.Add(It.IsAny<MovieDto>()), Times.Once);
            Assert.IsNotNull(newMovieId);
            Assert.IsInstanceOfType(newMovieId, typeof(int));
        }

        [TestMethod]
        public async Task WhenUpdateMovieHandlerCalled_WithValidUpdateMovieCommandObject_Update_MovieInDb()
        {
            var updateMovie = ArrangeNewUpdateMovieCommand();

            _mockMapper.Setup(x => x.Map<UpdateMovieCommand, MovieDto>(It.IsAny<UpdateMovieCommand>())).Returns(
                new MovieDto { Id = 1 });

            await _updateSubject.Handle(updateMovie);

            _mockMovieRepository.Verify(d => d.Update(It.IsAny<MovieDto>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenDeleteMovieHandlerCalled_WithValidNewMovieCommandObject_Delete_MovieAccordingToSoftDeleteBoolDb()
        {
            var deleteMovie = ArrangeNewDeleteMovieCommand();

            _mockMapper.Setup(x => x.Map<DeleteMovieCommand, MovieDto>(It.IsAny<DeleteMovieCommand>())).Returns(
                new MovieDto { Id = 1 });

            await _deleteSubject.Handle(deleteMovie);

            _mockMovieRepository.Verify(d => d.Delete(It.IsAny<int>()), Times.Once);
        }

        private AddMovieCommand ArrangeNewAddMovieCommand()
        {
            return new AddMovieCommand
            {
                Title = "Die Hard (A christmas movie)",
                DateTimeAdded = DateTime.Now,
                Rating = 3.5M,
                Category = "Action",
                Description = "Cool action movie about dude breaking stuff"
            };
        }

        private UpdateMovieCommand ArrangeNewUpdateMovieCommand()
        {
            return new UpdateMovieCommand
            {
                Id = 1,
                DateTimeUpdated = DateTime.Now,
                Rating = 4,
                Category = "Christmas",
                Description = "Correction Cool Christmas movie about dude breaking stuff"
            };
        }

        private DeleteMovieCommand ArrangeNewDeleteMovieCommand()
        {
            return new DeleteMovieCommand
            {
                Id = 1,
                SoftDelete = false,
            };
        }
    }
}