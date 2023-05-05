using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationManager {
    public partial class frmStudents : Form {
        public frmStudents() {
            InitializeComponent();
        }
        private void ShowStudents() {
            StudentRepository repository = new StudentRepository();
            List<Student> students = repository.GetStudents();
            dataGridView1.DataSource = students;
        }
        private void frmStudents_Load(object sender, EventArgs e) {
            ShowStudents();
        }
    }
}
