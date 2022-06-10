using Library.Core.Classes;
using Library.Core.Interfaces;
using Library.Core.ViewModels;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Library.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopic _topic;
        public TopicController(ITopic topic)
        {
            _topic = topic;
        }

        public IActionResult Index()
        {
            List<Topic> topicList = _topic.GetAllTopics();
            return View(topicList);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(TopicViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_topic.IsExistTopic(model.Title))
                {
                    ModelState.AddModelError("Title", "This topic is already exist");
                    
                }
                else
                {

                    Topic topic = new Topic()
                    {
                        Name = model.Title
                    };

                    _topic.AddNewTopic(topic);

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }



        public IActionResult Delete(int id)
        {
            return View(_topic.GetTopicById(id));
        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _topic.DeleteTopic(id);
            return RedirectToAction(nameof(Index)); 
        }


        public IActionResult Edit(int id)
        {
            return View(_topic.GetTopicById(id));
        }


        [HttpPost]
        public IActionResult Edit(int id,TopicViewModel modal)
        {
            if (ModelState.IsValid)
            {
                if (_topic.IsExistTopic(modal.Title))
                {
                    ModelState.AddModelError("Name", "This topic is already exist");
                }
                else
                {
                    _topic.EditTopic(id, modal);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(modal);
        }

    }

}
