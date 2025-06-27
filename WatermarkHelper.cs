using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp1.WatermarkHelper
{
    public static class WatermarkHelper
    {
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark", typeof(string), typeof(WatermarkHelper), new PropertyMetadata(string.Empty, OnWatermarkChanged));

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.Loaded += (s, ev) => ToggleAdorner(textBox);
                textBox.TextChanged += (s, ev) => ToggleAdorner(textBox);
            }
        }

        private static void ToggleAdorner(TextBox textBox)
        {
            var layer = AdornerLayer.GetAdornerLayer(textBox);
            if (layer == null) return;

            var existing = layer.GetAdorners(textBox);
            if (existing != null)
            {
                foreach (var adorner in existing.OfType<WatermarkAdorner>())
                    layer.Remove(adorner);
            }

            if (string.IsNullOrEmpty(textBox.Text))
            {
                var watermarkText = GetWatermark(textBox);
                var adorner = new WatermarkAdorner(textBox, watermarkText);
                layer.Add(adorner);
            }
        }
    }

    public class WatermarkAdorner : Adorner
    {
        private readonly TextBlock _textBlock;

        public WatermarkAdorner(UIElement adornedElement, string watermarkText)
            : base(adornedElement)
        {
            _textBlock = new TextBlock
            {
                Text = watermarkText,
                Foreground = Brushes.Gray,
                Margin = new Thickness(4, 2, 0, 0),
                IsHitTestVisible = false
            };

            AddVisualChild(_textBlock);
        }

        protected override int VisualChildrenCount => 1;
        protected override Visual GetVisualChild(int index) => _textBlock;

        protected override Size MeasureOverride(Size constraint)
        {
            _textBlock.Measure(constraint);
            return constraint;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _textBlock.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }

}
