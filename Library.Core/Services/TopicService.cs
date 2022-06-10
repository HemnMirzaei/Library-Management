using Library.Core.Interfaces;
using Library.Core.ViewModels;
using Library.Data.Context;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class TopicService : ITopic
    {
        private readonly LibDbContext _context;
        public TopicService(LibDbContext context)
        {
            _context = context;
        }

        public void AddNewTopic(Topic topic)
        {
            _context.Topics.Add(topic); 
            _context.SaveChanges();
        }

        public bool IsExistTopic(string topicName)
        {
            return _context.Topics.Any(t => t.Name.ToLower() == topicName.ToLower());
        }

        public void DeleteTopic(int? id)
        {
            var topic = _context.Topics.Find(id);
            List<Book> books = _context.Books.Where(t => t.TopicId == id).ToList();
            foreach (Book book in books)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            _context.Topics.Remove(topic);
            _context.SaveChanges();
        }

        public List<Topic> GetAllTopics()
        {
            return _context.Topics.OrderBy(t => t.Name).ToList();
        }

        public Topic GetTopicById(int id)
        {
            return _context.Topics.Find(id);
        }


        public void EditTopic(int id, TopicViewModel modal)
        {
            Topic topic = _context.Topics.Find(id);

            topic.Name = modal.Title;
            _context.SaveChanges();
        }
    }
}
