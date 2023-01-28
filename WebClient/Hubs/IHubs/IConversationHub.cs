public interface IConversationHub{
    Task ReceiveMessage(Message message);
}