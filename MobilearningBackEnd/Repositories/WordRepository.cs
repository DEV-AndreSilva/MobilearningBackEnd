using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IWordRepository
    {
        List<Word> Read();
        void Create(Word word);
        void Delete(Guid id);
        void Update(Guid id, Word word);
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
                word.ID = Guid.NewGuid();

                _context.Words.Add(word);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
          if(_context.Words != null)
            {
                var word = _context.Words.Find(id);
                if(word != null)
                {
                    _context.Entry(word).State = EntityState.Deleted;
                    _context.SaveChanges();
                }

                
            }
        }

        public List<Word> Read()
        {
            if(_context.Words != null)
            return _context.Words.ToList();

            return new List<Word>();
        }

        public void Update(Guid id, Word word)
        {
            Console.WriteLine(id);
            if(_context.Words != null)
            {
                var wordFind = _context.Words.Find(word.ID);
                
                if(wordFind != null)
                {
                    wordFind.EnglishWord = word.EnglishWord;
                    wordFind.EnglishDefinition = word.EnglishDefinition;
                    wordFind.PortugueseWord = word.PortugueseWord;
                    wordFind.PortugueseDefinition = word.PortugueseDefinition;

                    _context.Entry(wordFind).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                
            }
        }
    }
}