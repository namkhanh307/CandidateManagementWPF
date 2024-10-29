using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using System.Windows;

namespace CandidateManagement_UI
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService jobPostingService;
        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                JobPosting job = jobPostingService.GetJobPostingById(txtPostID.Text);
                if (job != null)
                {
                    if (jobPostingService.DeleteJobPosting(job))
                    {
                        this.LoadData();
                        this.ResetForm();
                        MessageBox.Show("Delete Successful!", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something wrong!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Something wrong, please select a certain Job Posting to delete!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void LoadData()
        {
            this.dtgJobPost.ItemsSource = null;
            this.dtgJobPost.ItemsSource = jobPostingService.GetJobPostings().Select(x => new
            {
                x.PostingId,
                x.Description,
                x.PostedDate,
                x.JobPostingTitle,
            });
        }

        private void ResetForm()
        {
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtPostID.Text = string.Empty;
            dtpPostDate.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = new JobPosting();
            job.PostingId = txtPostID.Text;
            job.JobPostingTitle = txtTitle.Text;
            job.Description = txtDescription.Text;
            job.PostedDate = DateTime.Parse(dtpPostDate.Text);

            if (jobPostingService.AddJobPosting(job))
            {
                this.LoadData();
                this.ResetForm();
                MessageBox.Show("Add Successful!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something wrong!", "Add", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            JobPosting job = jobPostingService.GetJobPostingById(txtPostID.Text);
            if (job != null)
            {
                job.Description = txtDescription.Text;
                job.JobPostingTitle = txtTitle.Text;
                job.PostedDate = DateTime.Parse(dtpPostDate.Text);
                if (jobPostingService.UpdateJobPosting(job))
                {
                    this.LoadData();
                    this.ResetForm();
                    MessageBox.Show("Update Successful!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something wrong!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Something wrong, please select a certain Job Postings to edit!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
