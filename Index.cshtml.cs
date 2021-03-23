using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesFirst.Models;

namespace RazorPagesFirst.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFirst.Data.RazorPagesFirstContext _context;

        public IndexModel(RazorPagesFirst.Data.RazorPagesFirstContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Type { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookType { get; set; }

        public async Task OnGetAsync()
        {
            
            IQueryable<string> genreQuery = from b in _context.Book
                                            orderby b.Type
                                            select b.Type;

            var movies = from m in _context.Book
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookType))
            {
                movies = movies.Where(x => x.Type == BookType);
            }
            Type = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await movies.ToListAsync();
        }

        private DbSet<Book> GetBook()
        {
            return _context.Book;
        }
    }
}
