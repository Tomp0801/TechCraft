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
using TechCraft.model;

namespace TechCraftView.view
{
    /// <summary>
    /// Interaction logic for VField.xaml
    /// </summary>
    public partial class VField : UserControl
    {


        private readonly Field field;
        public static uint SIZE { get; } = 100;

        public VField(Field field)
        {
            this.field = field;
            InitializeComponent();
            this.Width = SIZE;
            this.Height = SIZE;
            this.MaxWidth = SIZE;
            this.MaxHeight = SIZE;
            InitItem(field.Item);
        }

        private void InitItem(FieldItem item)
        {
            if (item != null)
            {
                itemLabel.Content = "default item";
            }
        }

        public void SetPlayer(Player player)
        {
            playerLabel.Content = player.Name;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit(); //TODO
            bitmap.UriSource = new Uri(@"image/player.png", UriKind.Relative);
            bitmap.EndInit();
            playerImage.Source = bitmap;
        }

        public void RemovePlayer()
        {
            playerLabel.Content = "";
            playerImage.Source = null;
        }
    }
}
