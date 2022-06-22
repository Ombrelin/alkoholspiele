namespace Alkoholspiel.Core.Notifications;

public interface INotificationManager
{
    event EventHandler<JokeCreatedNotification> JokeCreated;
}