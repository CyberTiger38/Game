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

namespace GameArt
{

    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tehnsecond;
        int math;


        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;

            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tehnsecond++;
            TiemTextBlok.Text = (tehnsecond / 10F).ToString("0.0s");
            if (math == 8)
            {
                timer.Stop();
                TiemTextBlok.Text = TiemTextBlok.Text + " - Play again?";

            }
        }
        private void SetUpGame()

        {
            List<string> WordTxt = new List<string>
            {
                "yam", "yam",
                "addition", "addition",
                "picture", "picture",
                "probable", "probable",
                "painstaking", "painstaking",
                "doctor", "doctor",
                "diligent", "diligent",
                "cynical", "cynical",
                "trade", "trade",
                "half", "half",
                "burn", "burn",
                "comparison", "comparison",
                "grade", "grade",
                "few", "few",
                "productive", "productive",
                "jelly", "jelly",
                "shaky", "shaky",
                "sort", "sort",
                "action", "action",
                "materialistic", "materialistic",
                "skin", "skin",
                "little", "little",

            };
            Random random = new Random();


            foreach (TextBlock textBloc in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBloc.Name != "timeTextBloc")
                {
                    textBloc.Visibility = Visibility.Visible;
                    int index = random.Next(WordTxt.Count);
                    string wordss = WordTxt[index];
                    textBloc.Text = wordss;
                    WordTxt.RemoveAt(index);
                }
            }

            timer.Start();
            tehnsecond = 0;
            math = 0;
        }

        TextBlock lastTextBloc;
        bool clik = false;



        private void TextBlock_MouseDown(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (clik == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBloc = textBlock;
                clik = true;
            }
            else if (textBlock.Text == lastTextBloc.Text)
            {
                math++;
                textBlock.Visibility = Visibility.Hidden;
                clik = false;
            }

            else
            {
                textBlock.Visibility = Visibility.Visible;
                clik = false;
            }
        }

        private void TimeTextBloc_Mouse(object sender, MouseButtonEventArgs e)
        {
            if (math == 8)
            {
                SetUpGame();
            }
        }
    }
}
