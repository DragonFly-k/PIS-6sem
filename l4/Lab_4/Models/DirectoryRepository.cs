using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class DirectoryRepository : IRepository<Directory>
    {
        private DBContext db;
        public DirectoryRepository()
        {
            this.db = new DBContext();
        }
        public void Create(Directory item)
        {
            db.Directory.Add(item);
        }

        public void Delete(Directory item)
        {
            db.Entry(item).State = EntityState.Deleted;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Directory GetDirectory(int id)
        {
            return db.Directory.Find(id);
        }

        public IEnumerable<Directory> GetDirectoryList()
        {
            return db.Directory;
        }

        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void Update(Directory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}