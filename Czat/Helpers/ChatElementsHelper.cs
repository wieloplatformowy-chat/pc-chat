using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace Czat.Helpers {
    internal static class ChatElementsHelper {

        /// <summary>
        /// Returns MessageControl containing Panel with message row
        /// </summary>
        /// <param name="isLocalUser">true if panel is for current logged in user</param>
        public static MessageControl GetMessageControl(bool isLocalUser = true) {
            // Awatar
            var avatarImage = new Image {
                Width = 50,
                Margin = new Thickness(8),
                VerticalAlignment = VerticalAlignment.Top
            };
            DockPanel.SetDock(avatarImage, isLocalUser ? Dock.Right : Dock.Left);

            // Message content
            var message = new TextBlock {
                TextWrapping = TextWrapping.WrapWithOverflow,
                Foreground = isLocalUser ? Brushes.White : Brushes.Black
            };

            // Sent time
            var dateTime = new Label {
                HorizontalAlignment = isLocalUser ? HorizontalAlignment.Right : HorizontalAlignment.Left
            };

            // Controls
            var outerPanel = new DockPanel {
                Width = double.NaN,
                HorizontalAlignment = isLocalUser ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                Margin = new Thickness(8, 0, 8, 8)
            };
            var innerPanel = new StackPanel();
            var card = new Card {
                Margin = new Thickness(4),
                Padding = new Thickness(8, 4, 8, 4),
                Background = isLocalUser ? Brushes.DarkCyan : Brushes.LightGray,
                Content = message,
                UniformCornerRadius = 8
            };
            innerPanel.Children.Add(card);
            innerPanel.Children.Add(dateTime);
            outerPanel.Children.Add(avatarImage);
            outerPanel.Children.Add(innerPanel);

            return new MessageControl(outerPanel, message, dateTime, avatarImage);
        }
    }
}
