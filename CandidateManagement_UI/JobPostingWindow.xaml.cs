using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using System.Windows;
using System.Windows.Documents;

namespace CandidateManagement_UI
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService jobPostingService;
        private JobPosting selectedJobPosting = null!;

        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
            LoadData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescription.Text.Equals(string.Empty) || txtTitle.Text.Equals(string.Empty) || txtPostID.Text.Equals(string.Empty) || dtpPostDate.Text.Equals(string.Empty) )
            {
                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin!", "Thất bại!", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else if(jobPostingService.GetJobPostingById(txtPostID.Text) != null)
            {
                MessageBox.Show("PostID đã tồn tại!", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                JobPosting job = new()
                {
                    PostingId = txtPostID.Text,
                    JobPostingTitle = txtTitle.Text,
                    Description = txtDescription.Text,
                    PostedDate = DateTime.Parse(dtpPostDate.Text)
                };

                if (jobPostingService.AddJobPosting(job))
                {
                    LoadData();
                    ResetForm();
                    MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }     
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtDescription.Text.Equals(string.Empty) || txtTitle.Text.Equals(string.Empty) || txtPostID.Text.Equals(string.Empty) || dtpPostDate.Text.Equals(string.Empty))
            {
                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin!", "Thất bại!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                JobPosting job = jobPostingService.GetJobPostingById(txtPostID.Text);
                if (job != null)
                {
                    job.Description = txtDescription.Text;
                    job.JobPostingTitle = txtTitle.Text;
                    job.PostedDate = DateTime.Parse(dtpPostDate.Text);
                    if (jobPostingService.UpdateJobPosting(job))
                    {
                        LoadData();
                        ResetForm();
                        MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 dòng", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }         
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có thực sự muốn xóa", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                JobPosting job = jobPostingService.GetJobPostingById(txtPostID.Text);
                if (job != null)
                {
                    if (jobPostingService.DeleteJobPosting(job))
                    {
                        LoadData();
                        ResetForm();
                        MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 dòng", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có thực sự muốn thoát ", "Thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
        private void LoadData()
        {
            dtgJobPost.ItemsSource = jobPostingService.GetJobPostings();
        }

        private void ResetForm()
        {
            txtPostID.Clear();
            txtTitle.Clear();
            txtDescription.Clear();
            dtpPostDate.Text = string.Empty;
        }

        private void dtgJobPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedJobPosting = (JobPosting)dtgJobPost.SelectedItem;

            if (selectedJobPosting != null)
            {
                txtPostID.Text = selectedJobPosting.PostingId;
                txtTitle.Text = selectedJobPosting.JobPostingTitle;
                txtDescription.Text = selectedJobPosting.PostingId;
                dtpPostDate.Text = selectedJobPosting.PostedDate.ToString();
            }
        }
    }
}
