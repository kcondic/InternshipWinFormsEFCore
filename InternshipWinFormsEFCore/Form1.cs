using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipWinFormsEFCore.Domain.Repositories;

namespace InternshipWinFormsEFCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _repository = new PostRepository();
        }
        private readonly PostRepository _repository;
        private void getPostButton_Click(object sender, EventArgs e)
        {
            var post = _repository.GetPost(1);
            postLabel.Text = $@"Naslov: {post.Title}, Sadržaj: {post.Content}";
        }
    }
}
