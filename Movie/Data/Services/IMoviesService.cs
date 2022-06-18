using Movie_Ecommerce.Data.Base;
using Movie_Ecommerce.ViewModels;
using Movie_Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie_Ecommerce.Data;
using Movie.Models;
using Movie_Ecommerce.Data.ViewModels;


namespace eTickets.Data.Services
{
    public interface IMoviesService:IBaseRepository<Moviee>
    {
        Task<Moviee> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
