using mvc.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.BlogRepo
{
    interface ICommentsRepository
    {

        IEnumerable<Comments> getAll();

        void Save(Comments comment);

        Comments GetComment(int id);

        Comments GetComments();

        void Delete(Comments comment);

        void Edit(Comments comment);
    }
}
