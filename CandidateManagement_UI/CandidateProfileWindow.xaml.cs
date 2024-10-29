﻿using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using MessageBox = System.Windows.MessageBox;

namespace CandidateManagement_UI
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private CandidateProfile selectedCandidate = null!;
        private ICandidateProfileService candidateProfileService;
        private IJobPostingService jobPostingService;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            candidateProfileService = new CandidateProfileService();
            jobPostingService = new JobPostingService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            this.dtgCandidateProfile.ItemsSource = candidateProfileService.GetCandidateProfiles();
            cboJobPostingID.ItemsSource = jobPostingService.GetJobPostings();
            cboJobPostingID.DisplayMemberPath = "JobPostingTitle";
            cboJobPostingID.SelectedValuePath = "PostingId";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd);
            if (txtCandidateID.Text.Equals(string.Empty) || txtFullname.Text.Equals(string.Empty) || dtpBirthday.Text.Equals(string.Empty) || textRange.Text.Equals(string.Empty) || txtProfileURL.Equals(string.Empty) || cboJobPostingID.SelectedValue.Equals(string.Empty))
            {
                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin!");
            }
            else if(candidateProfileService.GetCandidateProfileById(txtCandidateID.Text) != null)
            {
                MessageBox.Show("CandidateId đã tồn tại!");
            }
            else 
            {
                CandidateProfile candidateProfile = new CandidateProfile()
                {
                    CandidateId = txtCandidateID.Text,
                    Fullname = txtFullname.Text,
                    ProfileShortDescription = textRange.Text.Trim(),
                    Birthday = DateTime.Parse(dtpBirthday.Text),
                    ProfileUrl = txtProfileURL.Text,
                    PostingId = cboJobPostingID.SelectedValue.ToString()
                };
                bool check = candidateProfileService.AddCandidateProfile(candidateProfile);
                if (check)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin!");
                }
                LoadData();
            }
            
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd);
            if (selectedCandidate == null)
            {
                MessageBox.Show("Hãy chọn 1 dòng");
            }
            else if (txtFullname.Text.Equals(string.Empty) || dtpBirthday.Text.Equals(string.Empty) || textRange.Text.Equals(string.Empty) || txtProfileURL.Equals(string.Empty) || cboJobPostingID.SelectedValue.Equals(string.Empty))
            {
                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin!");
            }
            else
            {
                selectedCandidate.Fullname = txtFullname.Text;
                selectedCandidate.ProfileShortDescription = textRange.Text.Trim();
                selectedCandidate.Birthday = DateTime.Parse(dtpBirthday.Text);
                selectedCandidate.ProfileUrl = txtProfileURL.Text;
                selectedCandidate.PostingId = cboJobPostingID.SelectedValue.ToString();
                bool check = candidateProfileService.UpdateCandidateProfile(selectedCandidate);
                if (check)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại, vui lòng kiểm tra lại thông tin!!");
                }
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCandidate != null)
            {
                // Display a confirmation dialog
                MessageBoxResult result = MessageBox.Show("Bạn có thực sự muốn xóa", "Xác nhận", MessageBoxButton.YesNo);

                // If the user confirms, proceed with the deletion
                if (result == MessageBoxResult.Yes)
                {
                    // Call the delete method from the service
                    bool check = candidateProfileService.DeleteCandidateProfile(selectedCandidate);
                    if (check)
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại thông tin!!");
                    }
                }
                else
                {
                    LoadData();
                }
            }
            else
            {
                // If no candidate is selected, notify the user
                MessageBox.Show("Chọn 1 dòng");
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCandidate = (CandidateProfile)dtgCandidateProfile.SelectedItem;

            if (selectedCandidate != null)
            {
                txtCandidateID.Text = selectedCandidate.CandidateId;
                txtFullname.Text = selectedCandidate.Fullname;
                txtDescription.Document.Blocks.Clear();
                txtDescription.Document.Blocks.Add(new Paragraph(new Run(selectedCandidate.ProfileShortDescription)));
                dtpBirthday.Text = selectedCandidate.Birthday.ToString();
                txtProfileURL.Text = selectedCandidate.ProfileUrl;
                cboJobPostingID.SelectedValue = selectedCandidate.PostingId;
            }
        }
    }
}