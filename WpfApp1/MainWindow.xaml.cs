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
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool[,] array_bool = new bool[40, 40];
        public MainWindow()
        {
            InitializeComponent();
            initiateGrid();
            //LayoutRoot.ShowGridLines = true; // чтобы сетку видеть
            

        }
        private void initiateGrid()
        {
            //Button[,] tb1 = new Button[40, 40];
            for (int i = 0; i < 40; i++)
            {
                
                ColumnDefinition col = new ColumnDefinition();
                LayoutRoot.ColumnDefinitions.Add(col);
                RowDefinition row = new RowDefinition();
                LayoutRoot.RowDefinitions.Add(row);
                for (int z = 0; z < 40; z++)
                {
                    Button tb = new Button();
                    tb.Name = "button" + i.ToString() + "_" + z.ToString();
                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, z);
                    tb.Click += Button_Click;
                    tb.Background = Brushes.White;
                    //Form.MainGrid.Children.Add(tb);
                    LayoutRoot.Children.Add(tb);
                    //tb1[i, z] = tb;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Event which will be triggerd on click of ya button
        {
            var button = (Button)sender;
            if (button != null && button.Background==Brushes.White)
            {
                button.Background = Brushes.Black;
                array_bool[(int)button.GetValue(Grid.RowProperty), (int)button.GetValue(Grid.ColumnProperty)] = true;
            }
            else if (button != null)
            {
                button.Background = Brushes.White;
                array_bool[(int)button.GetValue(Grid.RowProperty), (int)button.GetValue(Grid.ColumnProperty)] = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(SampleFunction);
            thread.Start();
        }

        void SampleFunction()
        {
            MessageBox.Show("Start");
            for (int i = 1; i < 39; i++)
            {
                for (int j = 1; j < 39; j++)
                {

                    int v_str = Convert.ToInt32(array_bool[i - 1, j - 1]) + Convert.ToInt32(array_bool[j, i - 1]) + Convert.ToInt32(array_bool[j+1, i]);
                    int s_str = Convert.ToInt32(array_bool[i - 1, j + 1]) + Convert.ToInt32(array_bool[j - 1, i]);
                    int n_str = Convert.ToInt32(array_bool[i + 1, j - 1]) + Convert.ToInt32(array_bool[j, i + 1]) + Convert.ToInt32(array_bool[j + 1, i + 1]);
                    //MessageBox.Show(v_str.ToString());
                    if (v_str > 0)
                    {
                        MessageBox.Show("loh");
                    }
                    
                    //if (array_bool[j,i] == true)
                    //{
                    //    
                    //}
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            StringBuilder sb = new StringBuilder(array_bool.Length);
            foreach (bool ch in array_bool)
            {
                sb.Append((Convert.ToInt32(ch)).ToString());
            }
            string value = sb.ToString();
            
        }
    }
}
