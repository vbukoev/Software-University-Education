using ChatApp.Models.Chat;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static readonly List<KeyValuePair<string, string>> messages =
            new List<KeyValuePair<string, string>>();
        

        public IActionResult Show()
        {
            if(messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatViewModel = new ChatViewModel()
            {
                AllMessages = messages.Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value,
                }).ToList()
                
            };
            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chatViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Show");
            }
            KeyValuePair<string, string> currentMessage = new KeyValuePair<string, string>(chatViewModel.CurrentMessage.Sender, chatViewModel.CurrentMessage.MessageText);
            messages
                .Add(currentMessage);

            return RedirectToAction("Show");
        }
    }
}
