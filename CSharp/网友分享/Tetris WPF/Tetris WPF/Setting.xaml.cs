using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Miko.WPF.Tetris
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        MainWindow owner;
        MainWindow.cubeColor newColor;

        Color tempColor;

        public Setting()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int tick;
            int.TryParse(this.textBox.Text, out tick);

            if (tick > 999 || tick < 1)
            {
                tick = 400;
            }

            owner.timer.Interval = TimeSpan.FromMilliseconds(tick);
            owner.nowColor = this.newColor;

            owner.Preview= (bool)this.checkBox.IsChecked;
            owner.CheatMode = (bool)this.checkBox1.IsChecked;
            owner.autoPause = (bool)this.checkBox2.IsChecked;

            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 所有者类型转换不能放在构造函数中
            if ((owner = (MainWindow)this.Owner) == null)
            {
                throw new Exception("所有者无效 !");
            }

            newColor = owner.nowColor;
            slider.Value = owner.Opacity * 10;

            this.textBox.Text = owner.timer.Interval.Milliseconds.ToString();
            this.comboBox.ItemsSource = Enum.GetNames(typeof(MainWindow.cubeType)).ToList<string>();
            this.comboBox.SelectedIndex = 0;

            this.checkBox.IsChecked = owner.Preview;
            this.checkBox1.IsChecked = owner.CheatMode;
            this.checkBox2.IsChecked = owner.autoPause;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (owner == null) return;

            double d = slider.Value * 0.1;
            this.Opacity = d;
            owner.Opacity = d;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush tempBrush;
            switch (this.comboBox.SelectedItem.ToString())   // 不能用 this.comboBox.Text 因为是选中前的值
            {
                case "I":
                    tempBrush = newColor.I;
                    break;
                case "J":
                    tempBrush = newColor.J;
                    break;
                case "L":
                    tempBrush = newColor.L;
                    break;
                case "O":
                    tempBrush = newColor.O;
                    break;
                case "S":
                    tempBrush = newColor.S;
                    break;
                case "T":
                    tempBrush = newColor.T;
                    break;
                case "Z":
                    tempBrush = newColor.Z;
                    break;
                default:
                    this.label3.Background = Brushes.Transparent;
                    groupBox.IsEnabled = false;
                    return;
            }

            groupBox.IsEnabled = true;
            this.label3.Background = tempBrush;

            Color c = ((SolidColorBrush)tempBrush).Color;
            sliderA.Value = c.A;
            sliderR.Value = c.R;
            sliderG.Value = c.G;
            sliderB.Value = c.B;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Brush tempBrush = new SolidColorBrush(tempColor);

            switch (comboBox.Text)
            {
                case "I":
                    newColor.I = tempBrush;
                    break;
                case "J":
                    newColor.J = tempBrush;
                    break;
                case "L":
                    newColor.L = tempBrush;
                    break;
                case "O":
                    newColor.O = tempBrush;
                    break;
                case "S":
                    newColor.S = tempBrush;
                    break;
                case "T":
                    newColor.T = tempBrush;
                    break;
                case "Z":
                    newColor.Z = tempBrush;
                    break;
                default:
                    return;
            }

            label3.Background = tempBrush;
        }
        private void sliderA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempColor.A = (byte)sliderA.Value;
            labelColor.Background = new SolidColorBrush(tempColor);
        }

        private void sliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempColor.R = (byte)sliderR.Value;
            labelColor.Background = new SolidColorBrush(tempColor);
        }

        private void sliderG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempColor.G = (byte)sliderG.Value;
            labelColor.Background = new SolidColorBrush(tempColor);
        }

        private void sliderB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempColor.B = (byte)sliderB.Value;
            labelColor.Background = new SolidColorBrush(tempColor);
        }
    }
}
