using System;
using System.Collections.Generic;
using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.repository.Context;
using Microsoft.EntityFrameworkCore;
using eaton.agir.domain.Entities;

namespace eaton.agir.repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AgirContext _dbContext;
        public BaseRepository(AgirContext agirContext){
            _dbContext=agirContext;
        }

         public int Atualizar(T dados)
        {
            try
            {
                _dbContext.Set<T>().Update(dados);
                return _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T BuscarPorId(int id, string[] includes = null)
        {
            try
            {
                var chavePrimaria = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];

                var query = _dbContext.Set<T>().AsQueryable();
            
                if(includes == null) return query.FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
                
                return query.FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public int Deletar(T dados)
        {
            try
            {
                _dbContext.Set<T>().Remove(dados);
                return _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(T dados)
        {
            try
            {
                _dbContext.Set<T>().Add(dados);
                return _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> Listar(string[] includes = null)
        {
            try
            {
                var query = _dbContext.Set<T>().AsQueryable();

                if(includes == null) return query.ToList();

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                return query.ToList();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
}
}