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

namespace WizardProgressBarLibrary
{
    public class WizardProgressBar : ItemsControl
    {
        #region Dependency Properties

        public static DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress",
                                        typeof(int),
                                        typeof(WizardProgressBar),
                                        new FrameworkPropertyMetadata(0, null, CoerceProgress));

        private static object CoerceProgress(DependencyObject target, object value)
        {
            WizardProgressBar wizardProgressBar = (WizardProgressBar)target;
            int progress = (int)value;
            if (progress < 0)
            {
                progress = 0;
            }
            else if (progress > 100)
            {
                progress = 100;
            }
            return progress;
        }

        #endregion // Dependency Properties

        static WizardProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WizardProgressBar), new FrameworkPropertyMetadata(typeof(WizardProgressBar)));
        }

        public WizardProgressBar()
        {
        }

        #region Properties

        public int Progress
        {
            get { return (int)base.GetValue(ProgressProperty); }
            set { base.SetValue(ProgressProperty, value); }
        }

        #endregion // Properties
    }
}
