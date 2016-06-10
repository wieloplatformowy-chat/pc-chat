using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Czat.Helpers;

namespace Czat.Controls {
    /// <summary>
    /// Interaction logic for MessageRow.xaml
    /// </summary>
    public partial class MessageRow : UserControl {

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageRow), new PropertyMetadata());

        public string AdditionalInfo
        {
            get { return (string)GetValue(AdditionalInfoProperty); }
            set { SetValue(AdditionalInfoProperty, value); }
        }
        public static readonly DependencyProperty AdditionalInfoProperty = DependencyProperty.Register("AdditionalInfo", typeof(string), typeof(MessageRow), new PropertyMetadata());

        public ImageSource AvatarSource
        {
            get { return (ImageSource)GetValue(AvatarSourceProperty); }
            set { SetValue(AvatarSourceProperty, value); }
        }
        public static readonly DependencyProperty AvatarSourceProperty = DependencyProperty.Register("AvatarSource", typeof(ImageSource), typeof(MessageRow), new PropertyMetadata());

        protected Brush MessageBackground
        {
            get { return (Brush)GetValue(MessageBackgroundProperty); }
            set { SetValue(MessageBackgroundProperty, value); }
        }
        protected static readonly DependencyProperty MessageBackgroundProperty = DependencyProperty.Register("MessageBackground", typeof(Brush), typeof(MessageRow), new PropertyMetadata());

        protected Brush MessageForeground
        {
            get { return (Brush)GetValue(MessageForegroundProperty); }
            set { SetValue(MessageForegroundProperty, value); }
        }
        protected static readonly DependencyProperty MessageForegroundProperty = DependencyProperty.Register("MessageForeground", typeof(Brush), typeof(MessageRow), new PropertyMetadata());

        protected HorizontalAlignment HorizontalRowAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalRowAlignmentProperty); }
            set { SetValue(HorizontalRowAlignmentProperty, value); }
        }
        protected static readonly DependencyProperty HorizontalRowAlignmentProperty = DependencyProperty.Register("HorizontalRowAlignment", typeof(HorizontalAlignment), typeof(MessageRow), new PropertyMetadata());

        protected Dock HorizontalAvatarAlignment
        {
            get { return (Dock)GetValue(HorizontalAvatarAlignmentProperty); }
            set { SetValue(HorizontalAvatarAlignmentProperty, value); }
        }
        protected static readonly DependencyProperty HorizontalAvatarAlignmentProperty = DependencyProperty.Register("HorizontalAvatarAlignment", typeof(Dock), typeof(MessageRow), new PropertyMetadata());

        /// <summary>
        /// Adds message to control
        /// </summary>
        /// <param name="message">text to display</param>
        public void AppendMessage(string message) {
            MessagesTextBlock.Inlines.Add(message);
        }

        /// <summary>
        /// Adds message to control
        /// </summary>
        /// <param name="message">inline to display</param>
        public void AppendMessage(Inline message) {
            MessagesTextBlock.Inlines.Add(message);
        }

        /// <summary>
        /// Adds message to control
        /// </summary>
        /// <param name="message">ui element to display</param>
        public void AppendMessage(UIElement message) {
            MessagesTextBlock.Inlines.Add(message);
        }

        public MessageRow() : this(true) { }

        public MessageRow(bool isLocal = true) {
            InitializeComponent();
            DataContext = this;
            MessageBackground = isLocal ? ColorsHelper.GetSecondaryColorBrush() : ColorsHelper.GetBackgroundColorBrush();
            MessageForeground = isLocal ? ColorsHelper.GetLightForegroundColorBrush() : ColorsHelper.GetDarkForegroundColorBrush();
            HorizontalRowAlignment = isLocal ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            HorizontalAvatarAlignment = isLocal ? Dock.Right : Dock.Left;
        }
    }
}
