namespace JetLinkProject2.Models
{
    public class ChatGptReqModel
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }

        public ChatGptReqModel() 
        {
            model = "gpt-3.5-turbo";
        }
    }
    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
