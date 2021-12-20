using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TechCraftView.view
{
    /// <summary>
    /// Interaction logic for VItem.xaml
    /// </summary>
    public partial class VItem : UserControl
    {
        private IItem item;
        public VItem(IItem item)
        {
            this.item = item;
            InitializeComponent();
            textBlock.Text = item.Name;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // TODO 
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            root.Background = Brushes.Red;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            root.Background = Brushes.LightGray;
        }
    }
}
