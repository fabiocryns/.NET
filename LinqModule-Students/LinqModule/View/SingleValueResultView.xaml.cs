﻿using System;
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
using LinqModule.ServiceLocation;

namespace LinqModule.View {
    /// <summary>
    /// Interaction logic for SingleValueResultView.xaml
    /// </summary>
    public partial class SingleValueResultView : UserControl, IView {
        public SingleValueResultView() {
            InitializeComponent();
        }
    }
}