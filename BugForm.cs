using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace FlightRecorder
{
    public partial class BugForm : Form
    {
        public BugForm(string callsign,List<string> data)
        {
            InitializeComponent();
            tbTitle.Text = callsign + " problem : ";
            tbDesc.Text = "Describe the problem:\r\n\r\n\r\n==================\r\nLog starts here \r\n================\r\n";
            foreach (string l in data)
            {
                tbDesc.Text += l+"\r\n";
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            // Replace these with your GitHub credentials and repository details
            var owner = "Skall34";
            var repoName = "FlightRecorder";
            var personalAccessToken = "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";

            // Initialize the GitHub client
            var client = new GitHubClient(new ProductHeaderValue("FlightRecorder"))
            {
                Credentials = new Credentials(personalAccessToken)
            };

            // Create a new issue
            var newIssue = new NewIssue(tbTitle.Text)
            {
                Body = tbDesc.Text
            };
            try
            {
                var issue = await client.Issue.Create(owner, repoName, newIssue);
                Console.WriteLine($"Issue created: {issue.HtmlUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating issue: {ex.Message}");
            }
            this.Close();
        }
    }
}
