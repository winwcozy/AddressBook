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

namespace AddressBook.Forms.UI.Views
{
    public class AddrBook_Window : Window
    {
        static AddrBook_Window()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddrBook_Window), new FrameworkPropertyMetadata(typeof(AddrBook_Window)));
        }
    }
}
