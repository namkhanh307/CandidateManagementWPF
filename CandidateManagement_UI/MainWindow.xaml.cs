﻿using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using System.Windows;

namespace CandidateManagement_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService _hRAccountService;
        public MainWindow()
        {
            InitializeComponent();
            _hRAccountService = new HRAccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = _hRAccountService.GetHraccountByEmail(txtEmail.Text);
            if (hraccount != null && txtPassword.Text.Equals(hraccount.Password) && hraccount.MemberRole == 1)
            {
                CandidateProfileWindow profileWindow = new CandidateProfileWindow();
                profileWindow.Show();
                Close();
                MessageBox.Show($"Xin chào {hraccount.FullName}", "Thành công");
            }
            else
            { 
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thất bại!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}