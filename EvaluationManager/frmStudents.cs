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
            List<Student> students = StudentRepository.GetStudents();
            dataGridView1.DataSource = students;
        }
        private void frmStudents_Load(object sender, EventArgs e) {
            ShowStudents();
        }

        private void btnEvaluateStudent_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0) {
                Student selectedStudent = dataGridView1.CurrentRow.DataBoundItem as Student;

                if (selectedStudent != null) {
                    frmEvaluation frmEvaluation = new frmEvaluation(selectedStudent);
                    frmEvaluation.ShowDialog();
                }
            }
        }
    }
}
