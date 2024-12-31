using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.NotifyClass
{
    public static class NotifyManagement
    {
        public static void ShowNotifyMessage(string BalloonTitle, string Message, int Duration, ToolTipIcon Style)
        {
            string _iconPath = "3986701-online-shop-store-store-icon_112278.ico";
            var notifyIcon = new NotifyIcon
            {
                Icon = new Icon(_iconPath),
                Visible = true                
            };

            notifyIcon.BalloonTipIcon = Style;
            notifyIcon.BalloonTipTitle = BalloonTitle;
            notifyIcon.BalloonTipText = Message;
            notifyIcon.ShowBalloonTip(Duration);
            notifyIcon.Dispose();
        }
    }
}
