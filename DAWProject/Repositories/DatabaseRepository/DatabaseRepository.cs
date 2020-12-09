using System;
using System.Collections.Generic;
using System.Linq;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;
using DAWProject.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace DAWProject.Repositories.DatabaseRepository
{
    public class DatabaseRepository: GenericRepository<Model1>, IDatabaseRepository
    {
        public DatabaseRepository (DawAppContext context) : base(context)
        {

        }

        public List<Model1> GetAllWithInclude()
        {
            return _table.Include(x => x.Models2).ToList();

            // Model1 model1-a
            //    Model2 model2-a
            // Model1 model1-b
            //   Model2 model2-b

            // {... Model1 a, {...Model2 a}} , {...Model1 b, {...Model2 b}}}
        }

        public List<Model1> GetAllWithJoin()
        {
            var result = _table.Join(_context.Models2, model1 => model1.Id, model2 => model2.Model1Id,
                (model1, model2) => new { model1, model2 }).Select(obj => obj.model1).ToList();

            // model1 ........ model2..
            // {Model1 a, Model2 a }, {Model1 b, Model2 b}

            return result;
        }

        public Model1 GetByTitle(string title)
        {
            return _table.FirstOrDefault(x => x.Title.Contains(title));
        }
    }
}
