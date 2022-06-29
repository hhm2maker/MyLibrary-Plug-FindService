using MyLibraryBase.Model.Article;
using MyLibraryBase.View.UserControlView;
using System;
using System.Collections.Generic;
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

namespace FindServicePlugin
{
    /// <summary>
    /// FindServiceUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class FindServiceUserControl : UserControl
    {
        StyleFindPluginModel findPluginStyleModels;
        BaseWindow window;
        public FindServiceUserControl(ArticleAllModel articleAllModel, BaseWindow window)
        {
            InitializeComponent();

            this.window = window;
            findPluginStyleModels = new StyleFindPluginModel();

            List<BaseArticleModel> data = articleAllModel.Content;
            if (data.Count > 0)
            {
                if (!(data[0] is ArticleTableModel))
                {
                    return;
                }

                if ((data[0] as ArticleTableModel).Texts.Count == 0)
                {
                    return;
                }

                if ((data[0] as ArticleTableModel).Texts[0].Count < 5)
                {
                    return;
                }

                foreach (var item in (data[0] as ArticleTableModel).Texts)
                {
                    StyleFindPluginModel.StyleFindPluginChildModel child = new StyleFindPluginModel.StyleFindPluginChildModel();

                    child.Name = item[0];
                    string[] tags = item[1].Split('#');
                    foreach (var tag in tags)
                    {
                        if (!string.IsNullOrEmpty(tag))
                        {
                            child.Tag.Add(tag);
                        }
                    }
                    child.Link = item[2];
                    child.Describe = item[3];
                    child.Cover = item[4];

                    findPluginStyleModels.Child.Add(child);
                }
            }
        }

        bool isFirst = true;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (isFirst)
            {
                foreach (var item in findPluginStyleModels.Child)
                {
                    wpMain.Children.Add(new FindPluginItemUserControl(item, window)
                    {
                        Width = wpMain.ActualWidth / 4
                    });
                }
                isFirst = false;
            }
        }
    }
}
