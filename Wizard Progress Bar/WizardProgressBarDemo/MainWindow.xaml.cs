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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WizardProgressBarDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            Steps = new ObservableCollection<string>();
            Steps.Add("WELCOME");
            Steps.Add("PROFILE");
            Steps.Add("CREDENTIALS");
            Steps.Add("GROUPS");
            Steps.Add("FINISHED");
            this.DataContext = this;
        }
        private int m_progress;
        public int Progress
        {
            get { return m_progress; }
            set
            {
                m_progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public ObservableCollection<string> Steps
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Progress += 1;
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Progress -= 1;
        }
    }
}
