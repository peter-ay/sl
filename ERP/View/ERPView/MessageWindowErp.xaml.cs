using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ERP.View
{
    public partial class MessageWindowErp : ChildWindowErp
    {
        /// <summary>
        /// Types of message boxes that can be displayed.
        /// </summary>
        public enum MessageType { Info, Error, Confirm, TextInput, ComboInput };

        /// <summary>
        /// The string result of any input taking message box (i.e. TextInput and ComboInput).
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// The path to the icons. Note the name of the namespace inside the path.
        /// </summary>
        private const string ICONS_PATH = "/ERP;component/Images/CWin/";

        public MessageWindowErp(string message, MessageType type = MessageType.Info, String[] inputOptions = null)
        {
            InitializeComponent();
            switch (type)
            {
                case MessageType.Info:
                    //The message is already set up as an info message box.
                    //No need for change.
                    break;

                case MessageType.TextInput:
                case MessageType.ComboInput:

                    //Put the text part of the message on the top so it won't 
                    //interfere with the input box.
                    this.TextBlock.VerticalAlignment = VerticalAlignment.Top;

                    //Modify the margin around the textblock to make it more suitable.
                    Thickness newBorderMargin = this.TextBlockBorder.Margin;
                    newBorderMargin.Top += 20;
                    this.TextBlockBorder.Margin = newBorderMargin;

                    //Depending on the type of input, make either the textbox or
                    //the combobox visible. 
                    if (type == MessageType.ComboInput)
                    {
                        this.InputComboBox.ItemsSource = inputOptions;

                        //This is optional; Selects the first item in the combo box,
                        //if the combo options are not empty.
                        /**
                        if (inputOptions != null && inputOptions.Length != 0)
                            this.InputComboBox.SelectedIndex = 0;
                        */

                        this.InputComboBox.Visibility = Visibility.Visible;
                    }
                    else //TextBox input.
                    {
                        this.InputTextBox.Visibility = Visibility.Visible;
                    }
                    break;

                case MessageType.Error:
                    setMessageIcon("warning.png");
                    this.MessageBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case MessageType.Confirm:
                    setMessageIcon("question.png");
                    //this.MessageBorder.BorderBrush = new SolidColorBrush((Color)App.Current.Resources["DisabledBackgroundBrush"]);
                    this.MessageBorder.BorderBrush = App.Current.Resources["DisabledBackgroundBrush"] as Brush;
                    this.Btn_Cancel.Visibility = Visibility.Visible;
                    break;
            }

            //Set the message.
            this.TextBlock.Text = message;
        }
        /// <summary>
        /// Sets the image of the custom message button given the name of the image.
        /// </summary>
        /// <param name="imagePath">The name of the image to set.</param>
        private void setMessageIcon(string imagePath)
        {
            MessageIcon.Source = new BitmapImage(new Uri(ICONS_PATH + imagePath, UriKind.RelativeOrAbsolute));
        }

        protected override void InitTitle()
        {
            var bindingTitle = new System.Windows.Data.Binding("UIText[ERP_Title]");
            this.SetBinding(System.Windows.Controls.ChildWindow.TitleProperty, bindingTitle);
        }

        protected override void OnChildWindowClosed(bool msg)
        {
            Messenger.Default.Send<bool>(false, USysMessages.MessageWindow);
        }
    }
}

