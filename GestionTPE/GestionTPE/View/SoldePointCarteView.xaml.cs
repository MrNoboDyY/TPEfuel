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

namespace GestionTPE.View
{
    /// <summary>
    /// Interaction logic for SoldePointCarteView.xaml
    /// </summary>
    public partial class SoldePointCarteView : Window
    {
        public SoldePointCarteView(int? TpeToken)
        {
            InitializeComponent();
            ((dynamic)this.DataContext).TpeToken = TpeToken;
        }
    }
}
