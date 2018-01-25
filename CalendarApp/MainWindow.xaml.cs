using CalendarApp.Models;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace CalendarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private RenderWindow _renderWindow;
        private readonly DispatcherTimer _timer;
        private  DispatcherTimer _dispatcherTimer;
        private readonly IDayModel _dayModel;
        private readonly IMetonicYearModel _metonicYearModel;
        private readonly IMonthModel _monthModel;
        private readonly IMoonModel _moonModel;
        private readonly INodesModel _nodesModel;
        private readonly ISunCountModel _sunCountModel;
        private readonly ISunModel _sunModel;
        private DateTime _gregorianDate;
        private Label _gregorianLabel;
        private Label _metonicLabel;
        private bool _playing = false;

        public MainWindow()
        {
            _metonicYearModel = new MetonicYearModel();  
            _moonModel = new MoonModel();
            _nodesModel = new NodesModel();
            _sunModel = new SunModel(_nodesModel);
            _sunCountModel = new SunCountModel(_sunModel); 
            _monthModel = new MonthModel(_metonicYearModel,_sunModel,_moonModel);
            _dayModel = new DayModel(_monthModel, _metonicYearModel);


            InitializeComponent();
            SetYearZero();
            

            CreateRenderWindow();

            var refreshRate = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            this._timer = new DispatcherTimer { Interval = refreshRate };
            this._timer.Tick += Timer_Tick;
            this._timer.Start();

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,500);


        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            
            _dispatcherTimer.Start();

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
        }

        private void GregorianLabel_Loaded(object sender, RoutedEventArgs e)
        {
            _gregorianLabel = sender as Label;

            _gregorianLabel.Content = "Gregorian Date: " + _gregorianDate.ToLongDateString();
        }

        private void MetonicLabel_Loaded(object sender, RoutedEventArgs e)
        {
            _metonicLabel = sender as Label;

            _metonicLabel.Content = "Metonic Date: " + GetMetonicDate();
        }
        private void CreateRenderWindow()
        {
            if (_renderWindow != null)
            {
                _renderWindow.SetActive(false);
                _renderWindow.Dispose();
            }

            var context = new ContextSettings { DepthBits = 24 };
            _renderWindow = new RenderWindow(DrawSurface.Handle, context);
            _renderWindow.SetActive(true);
        }

        private void DrawSurface_SizeChanged(object sender, EventArgs e)
        {
            CreateRenderWindow();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _renderWindow.DispatchEvents();
            _renderWindow.Clear(new SFML.Graphics.Color(255, 255, 255));
            Calendar.DrawCalendar(_renderWindow,_nodesModel,_sunModel,_moonModel, _metonicYearModel, _monthModel, _dayModel, _sunCountModel);
            _renderWindow.Display();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            AddDay();
            _gregorianDate = Convert.ToDateTime(_gregorianLabel.Content.ToString().Split(':')[1]);
            _renderWindow.DispatchEvents();
            _renderWindow.Clear(new SFML.Graphics.Color(255, 255, 255));
            Calendar.DrawCalendar(_renderWindow, _nodesModel, _sunModel, _moonModel, _metonicYearModel, _monthModel, _dayModel, _sunCountModel);
            _renderWindow.Display();
            _gregorianDate = _gregorianDate.AddDays(1);
            _gregorianLabel.Content = "Gregorian Date: " + _gregorianDate.ToLongDateString();
            _metonicLabel.Content = "Metonic Date: " + GetMetonicDate();
        }

        private string GetMetonicDate()
        {
            string date = _dayModel.Get() + " " + _monthModel.GetMonthName() + ", year " + _metonicYearModel.GetMetonicYear();
            return date;
        }

        public string GetMetonicDate(DateTime date)
        {
            SetYearZero();
            TimeSpan diff = date - _gregorianDate;
            AddDays(diff.Days);
            return GetMetonicDate();
        }

        public void AddDay()
        {
            
            _dayModel.Incriment();
            _moonModel.Incriment();
            _sunCountModel.Incriment(_gregorianDate);

            _gregorianDate.AddDays(1);



        }

        private void Date_Changed(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime date = (DateTime)picker.SelectedDate;
            if (date == null)
            {
                this.Title = "No date";
            }
            else
            {
                SetYearZero();
                var diff = (date - _gregorianDate).TotalDays;
                AddDays(Convert.ToInt32(diff));
                _renderWindow.DispatchEvents();
                _renderWindow.Clear(new SFML.Graphics.Color(255, 255, 255));
                Calendar.DrawCalendar(_renderWindow, _nodesModel, _sunModel, _moonModel, _metonicYearModel, _monthModel, _dayModel, _sunCountModel);
                _renderWindow.Display();
                _gregorianDate = _gregorianDate.AddDays(1);
                _gregorianLabel.Content = "Gregorian Date: " + date.ToLongDateString();
                _metonicLabel.Content = "Metonic Date: " + GetMetonicDate();
            }
        }

        public void AddDays(int daysToAdd)
        {
            for (int i = 1; i <= daysToAdd; i++)
            {
                AddDay();
            }
        }

        private void SetYearZero()
        {
            _dayModel.Set(1);
            _dayModel.SetLongMonth();
            _monthModel.Set(13);
            _metonicYearModel.SetMetonicYear(4);
            _moonModel.Set(1);
            _sunCountModel.Set(1);
            _sunModel.Set(1);
            _nodesModel.SetNode1Position(12);
            _nodesModel.SetNode2Position(40);
            _gregorianDate = new DateTime(1998, 12, 18);
        }
    }
}
