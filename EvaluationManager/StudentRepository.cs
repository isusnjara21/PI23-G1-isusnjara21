﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;

namespace EvaluationManager {
    public class StudentRepository {
        private Student CreateObject(SqlDataReader reader) {
            Student student = new Student();

            student.Id = Convert.ToInt32(reader["Id"].ToString());
            student.FirstName = reader["FirstName"].ToString();
            student.LastName = reader["LastName"].ToString();
            int.TryParse(reader["Grade"].ToString(), out int grade);
            student.Grade = grade;

            return student;
        }

        public Student GetStudent(int id) {
            Student student = null;
            DB.OpenConnection();
            SqlDataReader reader = DB.GetDataReader($"SELECT * FROM Students WHERE id = {id}");
            if (reader.HasRows) {
                reader.Read();
                student = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return student;
        }

        public List<Student> GetStudents() {
            List<Student> students = new List<Student>();
            DB.OpenConnection();
            SqlDataReader reader = DB.GetDataReader("SELECT * FROM Students");
            while(reader.Read()) {
                if (reader.HasRows) {
                    Student student = CreateObject(reader);
                    students.Add(student);
                }
            }
            reader.Close();
            DB.CloseConnection();
            return students;
        }
    }
}
