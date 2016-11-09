﻿using EmpyrionManagementSuite.ViewModel;
using EMS.Core.ViewModels;
using EMS.Core.Yaml;
using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Page
    {
        public StartupViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).Startup; }
        }

        public Startup()
        {
            InitializeComponent();

            Loaded += (s, f) =>
            {
                var sectors = YamlConverter.DeserializeFile<List<Sector>>("D:\\Sectors.yaml");

                ViewModel.Start();

                // check for updates
                if (((dynamic)Application.Current).Settings.CheckForUpdates)
                {
                    ViewModel.CheckForUpdates();
                }
            };
        }
    }
}