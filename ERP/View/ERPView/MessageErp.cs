
namespace ERP.View
{
    public class MessageErp
    {
        public static void ErrorMessage(string message)
        {
            new MessageWindowErp(message, MessageWindowErp.MessageType.Error).Show();
        }

        public static void InfoMessage(string message)
        {
            new MessageWindowErp(message, MessageWindowErp.MessageType.Info).Show();
        }

        public static MessageWindowErp ConfirmMessage(string message)
        {
            return new MessageWindowErp(message, MessageWindowErp.MessageType.Confirm);
        }
    }
}
