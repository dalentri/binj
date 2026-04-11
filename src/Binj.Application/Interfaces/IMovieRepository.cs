using Binj.Domain.Entities;

namespace Binj.Application.Interfaces;

// Inherit from IMediaRepository generic
public interface IMovieRepository : IMediaRepository<Movie> { }
