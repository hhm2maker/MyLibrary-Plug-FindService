using MyLibraryBase.View.UserControlView;
using MyLibraryPlugin;
using System.Collections.Generic;
using System.Windows.Media;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MyLibraryBase.Model.Article;

namespace FindServicePlugin
{
    class BaseFindServicePlugin : IBasePlugin
    {
        private BaseWindow window;
        public ImageSource GetIcon()
        {
            // 获取当前程序集
            Assembly assembly = Assembly.GetAssembly(GetType());
            // 获取程序集中资源名称
            string resourceName = assembly.GetName().Name + ".g";
            // 资源管理器
            ResourceManager rm = new ResourceManager(resourceName, assembly);
            BitmapImage bitmap = new BitmapImage();
            using (ResourceSet set = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                UnmanagedMemoryStream s;
                s = (UnmanagedMemoryStream)set.GetObject("Image/logo.png", true);

                // img在XAML声明的空间      
                return BitmapFrame.Create(s, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        public string GetName()
        {
            return "寻找服务";
        }

        public List<int> GetPermission()
        {
            return new List<int>() { 0 };
        }

        public UserControl GetUserControl(ArticleAllModel articleAllModel)
        {
            return new FindServiceUserControl(articleAllModel, window);
        }

        public void SetWindow(BaseWindow baseWindow)
        {
            this.window = baseWindow;
        }
    }
}
