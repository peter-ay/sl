using System;

namespace GalaSoft.MvvmLight.Messaging
{
    public static class ExMessengerExtension
    {
        public static void Send<T>(this IMessenger messenger, T body, object token)
        {
            Messenger.Default.Send<GenericMessage<T>>(new GenericMessage<T>(body), token);
        }

        public static void Register<T>(this Messenger messenger, object recipient, object token, Action<T> action)
        {
            Messenger.Default.Register<GenericMessage<T>>(recipient, token, msg =>
            {
                action(msg.Content);
            });
        }

    }
}
