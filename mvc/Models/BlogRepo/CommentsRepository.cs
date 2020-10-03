using mvc.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.BlogRepo
{
    public class CommentsRepository : ICommentsRepository
    {
        public void Delete(Comments comment)
        {
            throw new NotImplementedException();
        }

        public void Edit(Comments comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comments> getAll()
        {
            throw new NotImplementedException();
        }

        public Comments GetComment(int id)
        {
            throw new NotImplementedException();
        }

        public Comments GetComments()
        {
            throw new NotImplementedException();
        }

        public void Save(Comments comment)
        {
            throw new NotImplementedException();
        }
    }
}
