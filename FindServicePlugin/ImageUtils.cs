using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FindServicePlugin
{
    public class ImageUtils
    {
        public static void SetClear(Image iv)
        {
            RenderOptions.SetBitmapScalingMode(iv, BitmapScalingMode.Fant);
        }

        public static void SetCornerImage(Image iv)
        {
            if (iv.OpacityMask == null)
            {
                Border border2 = new Border();
                border2.Background = Brushes.White;
                VisualBrush brush = new VisualBrush();
                brush.Visual = border2;
                iv.OpacityMask = brush;
                iv.SizeChanged += delegate
                {
                    border2.Width = iv.ActualWidth;
                    border2.Height = iv.ActualHeight;
                };
            }
            if (iv.OpacityMask is VisualBrush vb)
                if (vb.Visual is Border bd)
                    bd.CornerRadius = new CornerRadius(10);
        }

        public static void SetImageSource(Image iv, String uri)
        {
            iv.Source = new BitmapImage(new Uri(uri));
        }

        public static void SetLocalImageSource(Image iv, string path)
        {
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
            {
                BitmapImage imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.CacheOption = BitmapCacheOption.OnLoad;//设置缓存模式
                imageSource.StreamSource = ms;//通过StreamSource加载图片
                imageSource.EndInit();
                imageSource.Freeze();
                iv.Source = imageSource;
            }
        }

        public static void SetImageSource(Border border, string uri)
        {
            BitmapImage imageSource = new BitmapImage(new Uri(uri));

            ImageBrush imageBrush = new ImageBrush()
            {
                ImageSource = imageSource,
                Stretch = Stretch.UniformToFill
            };

            border.Background = imageBrush;
        }

        public static void SetBorderImageSource(Border border, string path)
        {
            ImageBrush imageBrush = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(path)),
                Stretch = Stretch.UniformToFill
            };

            border.Background = imageBrush;
        }
    }
}