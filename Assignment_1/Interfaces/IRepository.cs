﻿using Assignment_1.Data;

namespace Assignment_1.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public List<T> Search(string searchString);
        public T Create(T entity);
        public T Update(T entity);
        public T Delete(int id);
        public T GetById(int id);
        public T GetById(string id);

    }
}
