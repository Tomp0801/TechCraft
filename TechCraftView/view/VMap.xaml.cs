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
using TechCraft.model;

namespace TechCraftView.view
{
    /// <summary>
    /// Interaction logic for VMap.xaml
    /// </summary>
    public partial class VMap : UserControl
    {
        private VField[,] vFields;
        public VMap(IMap world)
        {
            InitializeComponent();
            InitFields(world.Fields);
        }

        private void InitFields(IField[,] fields)
        {
            vFields = new VField[fields.GetLength(0), fields.GetLength(1)];
            for (uint i  = 0; i < fields.GetLength(0); i++)
            {
                for (uint j = 0; j < fields.GetLength(1); j++)
                {
                    VField vField = new (fields[i, j]);
                    Canvas.SetLeft(vField, VField.SIZE * i);
                    Canvas.SetTop(vField, VField.SIZE * j);
                    root.Children.Add(vField);
                    vFields[i, j] = vField;
                }
            }
        }

        public void SetPlayer(uint x, uint y, IPlayer player)
        {
            vFields[x, y].SetPlayer(player);
        }

        public void RemovePlayer(uint x, uint y)
        {
            vFields[x, y].RemovePlayer();
        }
    }
}
