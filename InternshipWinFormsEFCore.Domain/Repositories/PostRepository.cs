using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipWinFormsEFCore.Data.Entities;
using InternshipWinFormsEFCore.Data.Entities.Models;

namespace InternshipWinFormsEFCore.Domain.Repositories
{
    public class PostRepository
    {
        public PostRepository()
        {
            _context = new BloggingContext();   
        }
        private readonly BloggingContext _context;

        public Post GetPost(int id)
        {
            return _context.Posts.Find(id);
        }
    }
}
