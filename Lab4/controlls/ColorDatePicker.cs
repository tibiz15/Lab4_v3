using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab4.controlls
{
    class ColorDatePicker : DatePicker
    {
        public ColorDatePicker()
        {
            SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(80, 90, 90, 200)));
            IsValidDate = false;
        }

        public static readonly DependencyProperty IsValidDateProperty =
            DependencyProperty.Register("IsValidDate", typeof(bool), typeof(ColorDatePicker));

        public bool IsValidDate
        {
            get
            {
                return (bool)GetValue(IsValidDateProperty);
            }
            set
            {
                SetValue(IsValidDateProperty, value);
            }
        }

        protected override void OnCalendarClosed(RoutedEventArgs e)
        {
            base.OnCalendarClosed(e);
            UpdateValues();

        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            UpdateValues();
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            UpdateValues();
        }

        protected override void OnSelectedDateChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectedDateChanged(e);
            UpdateValues();
        }

        private void UpdateValues()
        {
            if (GetValue(SelectedDateProperty) == null || string.IsNullOrEmpty(GetValue(SelectedDateProperty).ToString()) || string.IsNullOrWhiteSpace(GetValue(SelectedDateProperty).ToString()))
            {
                SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 200, 90, 90)));
                IsValidDate = false;
            }
            else
            {
                SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 90, 200, 90)));
                IsValidDate = true;
            }
        }
    }
}
