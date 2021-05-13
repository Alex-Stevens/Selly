using System;
using Windows.UI.Notifications;

namespace Selly.Agent.Windows
{
    public class ToastHelper
    {
        public static void PopToast(string message)
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);

            var textFields = toastXml.GetElementsByTagName("text");
            textFields[0].AppendChild(toastXml.CreateTextNode(message));
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(20.0);

            ToastNotificationManager.CreateToastNotifier("Microsoft.Samples.DesktopToasts").Show(toast);
        }
    }
}
