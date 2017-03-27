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
using System.Windows.Shapes;

namespace GestionTPE.View
{
    /// <summary>
    /// Interaction logic for LoyaltyView.xaml
    /// </summary>
    public partial class LoyaltyView : Window
    {
        private int? tpeToken;

        public LoyaltyView()
        {
            InitializeComponent();
        }

        public LoyaltyView(int? tpeToken)
        {
            this.tpeToken = tpeToken;
        }
    }
}
