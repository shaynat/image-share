using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_59.CL
{
    public class ImagesManager
    {
        private string _connectionString;

        public ImagesManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Images> GetAllImages()
        {
            using (var context = new Images3DataContext(_connectionString))
            {
                return context.Images.OrderByDescending(i=>i.Id).ToList();
            }
        }

        public void AddImage(Images image)
        {
            using (var context = new Images3DataContext(_connectionString))
            {
                context.Images.InsertOnSubmit(image);
                context.SubmitChanges();
            }
        }

        public void AddLikeForId(int id)
        {
            using (var context = new Images3DataContext(_connectionString))
            {
                Images image = context.Images.FirstOrDefault(i => i.Id == id);
                image.LikeCount++;
                context.SubmitChanges();
            }
        }

        public Images GetImageForId(int id)
        {
            using(var context = new Images3DataContext(_connectionString))
            {
                return context.Images.FirstOrDefault(i => i.Id == id);
            }
        }

        public int GetLikesForId(int id)
        {
            using(var context=new Images3DataContext(_connectionString))
            {
                Images image = context.Images.FirstOrDefault(i => i.Id == id);
                return image.LikeCount;
            }
        }

        public int GetHighestId()
        {
            using (var context = new Images3DataContext(_connectionString))
            {
                return context.Images.OrderByDescending(i => i.Id).FirstOrDefault().Id;
            }
        }
    }
}
