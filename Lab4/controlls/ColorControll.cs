using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab4.controlls
{
    abstract class ColorControll : TextBox
    {
        public ColorControll()
        {
            SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(80, 90, 90, 200)));
            IsValid = false;
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(bool), typeof(ColorControll));

        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }

        protected abstract bool ValidText(string text);

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            if (ValidText(GetValue(TextProperty).ToString()))
            {
                SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 90, 200, 90)));
                IsValid = true;
            }
            else
            {
                SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 200, 90, 90)));
                IsValid = false;
            }
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            
            if (ValidText(GetValue(TextProperty).ToString()))
            {
                SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 90, 200, 90)));
                IsValid = true;
            }
            else
            {
                SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 200, 90, 90)));
                IsValid = false;
            }
        }
    }
}
