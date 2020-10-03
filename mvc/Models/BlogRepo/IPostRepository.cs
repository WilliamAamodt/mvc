﻿using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.BlogRepo
{
    public interface IPostRepository
    {

        IEnumerable<Post> GetAll();

        void Save(PostViewModel post);

        PostViewModel getPrstViewModel(int id);

        void Delete(PostViewModel post);

        void Edit(PostViewModel post);

    }
}