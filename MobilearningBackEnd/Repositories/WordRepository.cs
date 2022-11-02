using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IWordRepository
    {
        List<Word> Read(int id);
        void Create(Word word);
        void Delete(int id);
        void Update(int id, Word word);
    }

    public class WordRepository : IWordRepository
    {
        //necessário injetar a depedência de datacontex
        private readonly DataContext _context;

        public WordRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Word word)
        {
            if(_context.Words != null)
            {
                _context.Words.Add(word);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
          if(_context.Words != null)
            {
                 var wordFind = _context.Words.FirstOrDefault(word=>word.id==id);

                if(wordFind != null)
                {
                    _context.Entry(wordFind).State = EntityState.Deleted;
                    _context.SaveChanges();
                }

                
            }
        }

        public List<Word> Read(int id)
        {
            if(_context.Words != null)
            {
                var results = _context.Words.Where(Word => Word.userId == id).ToList();
                return results;
            }
            

            return new List<Word>();
        }

        public void Update(int id, Word word)
        {  
            if(_context.Words != null)
            {
                var wordFind = _context.Words.FirstOrDefault(word=>word.id==id);
                
                if(wordFind != null)
                {
                    wordFind.englishWord = word.englishWord;
                    wordFind.englishDefinition = word.englishDefinition;
                    wordFind.portugueseWord = word.portugueseWord;
                    wordFind.portugueseDefinition = word.portugueseDefinition;

                    _context.Entry(wordFind).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }
    }
}