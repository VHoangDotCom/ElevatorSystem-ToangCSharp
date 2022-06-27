using ElevatorSystem.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElevatorSystem.Admin.Models.Entity;
using ElevatorSystem.Admin.Models;
using System.IO;

namespace ElevatorSystem.Admin.Repositories
{
    public class BlogRepository
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public int UploadImageInDataBase(HttpPostedFileBase file, BlogViewModel blogViewModel)
        {
            blogViewModel.Thumbnail = ConvertToBytes(file);
            var Blog = new Blog
            {
                Title = blogViewModel.Title,
                Summary = blogViewModel.Summary,
                IsPublished = blogViewModel.IsPublished,
                PostContent = blogViewModel.PostContent,
               // Thumbnail = blogViewModel.Thumbnail,
                Slug = blogViewModel.Slug,
                CreatedAt = blogViewModel.CreatedAt,
                ModifiedAt = blogViewModel.ModifiedAt,
                PublishedAt = blogViewModel.PublishedAt,
                Tag = blogViewModel.Tag,
                TagID = blogViewModel.TagID,
                
            };
            db.Blogs.Add(Blog);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}