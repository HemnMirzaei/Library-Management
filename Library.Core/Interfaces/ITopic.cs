using Library.Core.ViewModels;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface ITopic
    {
        void AddNewTopic(Topic topic);

        bool IsExistTopic(string topicName);

        void DeleteTopic(int? id);

        List<Topic> GetAllTopics();

        Topic GetTopicById(int id);

        void EditTopic(int topicId, TopicViewModel modal);
    }
}
