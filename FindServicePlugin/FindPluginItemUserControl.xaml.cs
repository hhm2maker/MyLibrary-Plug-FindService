using MyLibraryBase.View.UserControlView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FindServicePlugin.StyleFindPluginModel;

namespace FindServicePlugin
{
    /// <summary>
    /// FindPluginItemUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class FindPluginItemUserControl : UserControl
    {
        private StyleFindPluginChildModel child;
        private BaseWindow window;
        public FindPluginItemUserControl(StyleFindPluginChildModel child, BaseWindow window)
        {
            InitializeComponent();

            this.window = window;
            this.child = child;

            tbName.Text = child.Name;
            StringBuilder sb = new StringBuilder();
            foreach (var item in child.Tag)
            {
                sb.Append("#").Append(item).Append(" ");
            }
            tbTag.Text = sb.ToString();

            if (!string.IsNullOrEmpty(child.Cover))
            {
                if (child.Cover.StartsWith("http"))
                {
                    ImageUtils.SetImageSource(iCover, child.Cover);
                }
                else if (File.Exists(child.Cover))
                {
                    ImageUtils.SetLocalImageSource(iCover, child.Cover);
                }
            }
            tbDescribe.Text = child.Describe;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            gVisit.Visibility = Visibility.Visible;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            gVisit.Visibility = Visibility.Hidden;
        }

        private void tbVisit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (child.Link.StartsWith("http"))
            {
                window.OpenFile(child.Link);
                //MyStaticResource.mw.AddUserControl(child.Name, ProcessUtils.GetWebView(child.Link));
            }
        }
    }
}
