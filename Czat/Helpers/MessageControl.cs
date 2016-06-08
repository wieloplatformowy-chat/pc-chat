using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Czat.Helpers {
    internal class MessageControl {
        
        /// <summary>
        /// Panel containing message row
        /// </summary>
        public Panel Control { get; private set; }

        private readonly TextBlock _messageBlock;
        private readonly ContentControl _dateTimeContent;
        private readonly Image _avatarImage;

        /// <summary>
        /// Creates message row controller for specified elements
        /// </summary>
        public MessageControl(Panel control, TextBlock messageBlock, ContentControl dateTimeContent, Image avatarImage) {
            Control = control;
            _messageBlock = messageBlock;
            _dateTimeContent = dateTimeContent;
            _avatarImage = avatarImage;
        }

        /// <summary>
        /// Adds message to control
        /// </summary>
        /// <param name="message">text to display</param>
        public void AddMessage(string message) {
            _messageBlock.Inlines.Add(message);
        }
        
        /// <summary>
        /// Adds message to control
        /// </summary>
        /// <param name="message">inline to display</param>
        public void AddMessage(Inline message) {
            _messageBlock.Inlines.Add(message);
        }
        
        /// <summary>
        /// Adds message to control
        /// </summary>
        /// <param name="message">ui element to display</param>
        public void AddMessage(UIElement message) {
            _messageBlock.Inlines.Add(message);
        }

        /// <summary>
        /// Changes avatar's image
        /// </summary>
        /// <param name="imageSource">source of image</param>
        public void ChangeAvatarImage(ImageSource imageSource) {
            _avatarImage.Source = imageSource;
        }

        /// <summary>
        /// Changes date time label of this message
        /// </summary>
        /// <param name="dateTime">date/time to display</param>
        public void ChangeDateTimeContent(string dateTime) {
            _dateTimeContent.Content = dateTime;
        }
    }
}