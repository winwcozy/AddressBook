using AddressBook.Forms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AddressBook.Forms.UI.Views
{
    /// <summary>
    /// Frm_AddrBook.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Frm_AddrBook : Window
    {
        /// <summary>
        /// Frm_AddrBook Controller
        /// </summary>
        private Controller_AddrBook _ControllerAddrBook = null;

        /// <summary>
        /// 생성자
        /// </summary>
        public Frm_AddrBook(Controller_AddrBook _ControllerAddrBook)
        {
            InitializeComponent();

            _ControllerAddrBook = new Controller_AddrBook(this);
        }

        private Point startPos;

        private System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;

        #region EVENT

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void window_StateChanged(object sender, EventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                main.BorderThickness = new Thickness(0);
                rectMax.Visibility = Visibility.Hidden;
                rectMin.Visibility = Visibility.Visible;
            }
            else
            {
                main.BorderThickness = new Thickness(1);
                rectMax.Visibility = Visibility.Visible;
                rectMin.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// 3. 마우스로 잡고 윈도우를 드래그 할 수 있는 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void System_MouseMove(object sender, MouseEventArgs e)
        {
            #region 설명
            /*
             * startPos는 MouseDown에서 사용하게 되는 변수이지만, Drag의 부가 기능을 위해서는 이 변수가 필요합니다.
             * startPos를 사용하는 내용은 다음 4번 코드에 같이 쓰겠습니다.
             * 기본적으로 Window는 DragMove()라는 함수를 제공합니다.
             * 하지만 최대화 되어 있을 때 DragMove는 최대화를 풀어주지 못하고 Drag 되지 않습니다.
             * 그래서 최대화 되었을 때 최대화를 풀어주고, 마우스 위치를 기준으로 Drag를 시작하도록 해주는 코드 입니다.
             * 처음 마우스를 눌렀을 때 바로 풀리는 것이 아닌, 조금 움직인 뒤 Drag를 시작하도록 합니다(startPos).
            */
            #endregion

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if(this.WindowState == WindowState.Maximized && Math.Abs(startPos.Y - e.GetPosition(null).Y) > 2)
                {
                    Point point = PointToScreen(e.GetPosition(null));

                    this.WindowState = WindowState.Normal;

                    this.Left = point.X - this.ActualWidth / 2;
                    this.Top = point.Y - border.ActualHeight / 2;
                }
                DragMove();
            }

        }

        /// <summary>
        /// 4. 더블 클릭 시 최대화, 최소화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void System_MouseDown(object sender, MouseButtonEventArgs e)
        {
            #region 설명
            /*
             * 이 기능은 간단한 기능처럼 보이지만, WindowStyle이 None인 경우에는 윈도우가 최대화 되었을 때 
             * 화면 아래 작업 표시줄까지 가려버리는 문제가 발생합니다.
             * 그래서 이 문제를 막기 위해 추가적인 내용이 필요하게 됩니다.
            */
            #endregion

            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount >= 2)
                {
                    this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
                }
                else
                {
                    startPos = e.GetPosition(null);
                }
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                Point pos = PointToScreen(e.GetPosition(this));
                IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
                IntPtr hMenu = GetSystemMenu(hWnd, false);
                int cmd = TrackPopupMenu(hMenu, 0x100, (int)pos.X, (int)pos.Y, 0, hWnd, IntPtr.Zero);
                if (cmd > 0)
                    SendMessage(hWnd, 0x112, (IntPtr)cmd, IntPtr.Zero);
            }

        }

        #region Dll Import

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);

        [DllImport("user32.dll")]
        static extern bool SetProcessDPIAware();

        #endregion

        /// <summary>
        /// 4.1 여러개의 모니터를 사용할 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_LocationChanged(object sender, EventArgs e)
        {
            #region 설명
            /*
             * 그리고 작업 표시줄을 가리지 않도록 해주어야 하는데, 이를 Window의 MaxHeight를 통해 처리합니다.
             * 그리고 여러개의 모니터를 쓸 경우를 위해 Windows.Forms를 통해 Screen 클래스를 사용하게 됩니다.
             * 우선 어셈블리 참조가 필요합니다.
             * ※참조 추가 -> 어셈블리 -> System.Drawing , System.Windows.Forms 
            */
            #endregion

            #region 기존
            //int sum = 0;
            //foreach(System.Windows.Forms.Screen item in screens)
            //{
            //    sum += item.WorkingArea.Width;
            //    if (sum >= this.Left + this.Width / 2)
            //    {
            //        this.MaxHeight = item.WorkingArea.Height;
            //        break;
            //    }
            //}
            #endregion


            int sum = 0;
            foreach (System.Windows.Forms.Screen item in screens)
            {
                sum += item.WorkingArea.Width;
                if (sum >= this.Left + this.Width / 2)
                {
                    this.MaxHeight = item.WorkingArea.Height;
                    break;
                }
            }

        }


        #endregion


    }






}
