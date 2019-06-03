using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess
{
    public class StudentAccessor : IStudentAccessor
    {
        public StudentAccessor()
        {

        }

        public List<Students> SelectStudents()
        {
            List<Students> students = new List<Students>();

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_retrieve_student_info";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students.Add(new Students()
                        {
                            StudentId = reader.GetString(0),
                            SchoolName = reader.GetString(1),
                            NCESId = reader.GetString(2),
                            Birthday = reader.GetDateTime(3),
                            Grade = reader.GetString(4),
                            FirstName = reader.GetString(5),
                            LastName = reader.GetString(6),
                            IEPType = reader.GetString(7),
                            IEPdate = reader.GetDateTime(8),
                            IEPLeaderFirstName = reader.GetString(9),
                            IEPLeaderLastName = reader.GetString(10),
                            IEPNotes = reader.GetString(11),
                            Address = reader.GetString(12),
                            City = reader.GetString(13),
                            State = reader.GetString(14),
                            ZipCode = reader.GetString(15),
                            GoalType = reader.GetString(16),
                            Active = reader.GetBoolean(17),
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return students;
        }

        public List<Students> SelectStudentsByTeacherID(string teacherID)
        {
            List<Students> students = new List<Students>();

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_retrieve_student_info_by_teacherID";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeacherID", teacherID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students.Add(new Students()
                        {
                            StudentId = reader.GetString(0),
                            SchoolName = reader.GetString(1),
                            NCESId = reader.GetString(2),
                            Birthday = reader.GetDateTime(3),
                            TeacherID = reader.GetString(4),
                            Grade = reader.GetString(5),
                            FirstName = reader.GetString(6),
                            LastName = reader.GetString(7),
                            IEPType = reader.GetString(8),
                            IEPdate = reader.GetDateTime(9),
                            IEPLeaderFirstName = reader.GetString(10),
                            IEPLeaderLastName = reader.GetString(11),
                            IEPNotes = reader.GetString(12),
                            Address = reader.GetString(13),
                            City = reader.GetString(14),
                            State = reader.GetString(15),
                            ZipCode = reader.GetString(16),
                            GoalType = reader.GetString(17),
                            Active = reader.GetBoolean(18),
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return students;
        }


        public List<Students> SelectStudentsBySLPID(string slpID)
        {
            List<Students> students = new List<Students>();

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_retrieve_student_info_by_slpID";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SLPID", slpID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students.Add(new Students()
                        {
                            StudentId = reader.GetString(0),
                            SchoolName = reader.GetString(1),
                            NCESId = reader.GetString(2),
                            Birthday = reader.GetDateTime(3),
                            TeacherID = reader.GetString(4),
                            Grade = reader.GetString(5),
                            FirstName = reader.GetString(6),
                            LastName = reader.GetString(7),
                            IEPType = reader.GetString(8),
                            IEPdate = reader.GetDateTime(9),
                            IEPLeaderFirstName = reader.GetString(10),
                            IEPLeaderLastName = reader.GetString(11),
                            IEPNotes = reader.GetString(12),
                            Address = reader.GetString(13),
                            City = reader.GetString(14),
                            State = reader.GetString(15),
                            ZipCode = reader.GetString(16),
                            GoalType = reader.GetString(17),
                            Active = reader.GetBoolean(18),
                            SLPID = reader.GetString(19)
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return students;
        }


        public Students SelectStudentIEP(string studentId)
        {
            Students student = null;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_student_info_by_id", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentID", studentId);

            try
            {

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        student = new Students();

                        student.StudentId = reader.GetString(0);
                        student.SchoolName = reader.GetString(1);
                        student.NCESId = reader.GetString(2);
                        student.Birthday = reader.GetDateTime(3);
                        student.Grade = reader.GetString(4);
                        student.FirstName = reader.GetString(5);
                        student.LastName = reader.GetString(6);
                        student.IEPID = reader.GetInt32(7);
                        student.IEPType = reader.GetString(8);
                        student.IEPdate = reader.GetDateTime(9);
                        student.IEPLeaderFirstName = reader.GetString(10);
                        student.IEPLeaderLastName = reader.GetString(11);
                        student.IEPNotes = reader.GetString(12);
                        student.Address = reader.GetString(13);
                        student.City = reader.GetString(14);
                        student.State = reader.GetString(15);
                        student.ZipCode = reader.GetString(16);
                        student.GoalType = reader.GetString(17);
                        student.Active = reader.GetBoolean(18);
                        
                    }

                }
                else
                {
                    throw new ApplicationException("Student not found.");
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return student;
        }

        public List<string> SelectAllStudentIEPTypes()
        {
            var studentIds = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_all_iep_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        studentIds.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return studentIds;
        }

        public List<string> SelectAllGrades()
        {
            var grades = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_all_grade", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        grades.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return grades;
        }

        public List<string> SelectSchools()
        {
            var schools = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_all_schools", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        schools.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return schools;
        }

        public List<string> SelectGoalTypes()
        {
            var goaltypes = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_all_goaltypes", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        goaltypes.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return goaltypes;
        }

        public List<string> SelectTeacherName()
        {
            var teacher = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_teacher_names", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        teacher.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return teacher;
        }

        public List<States> RetrieveStates()
        {
            List<States> stateList = new List<States>();

            char[] separator = { ',' };
            
            string filename = Directory.GetCurrentDirectory() + @"\states.csv";
            //System.Diagnostics.Process.Start(filename);
            try
            {
                StreamReader fileReader = new StreamReader(filename); 
                while (fileReader.EndOfStream == false)
                {
                    string line = fileReader.ReadLine();
                    string[] parts;
                    if (line.Length == 2)
                    {
                        parts = line.Split(separator);
                        if (parts.Count() == 1)
                        {
                            States newState = new States();

                            newState.UnitedStates = parts[0].ToString();

                            stateList.Add(newState);
                        }
                    }
                }
                fileReader.Close();
            }
            catch(Exception)
            {
                throw;
            }
            return stateList;
        }

        public bool CreateNewStudent(Students student, SLPUser slp, TeacherUser teacher)
        {

            bool result = false;
            
            var cmdText1 = @"sp_insert_student";
            var cmdText2 = @"sp_insert_new_iep";

            int newStudentId;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand(cmdText1, conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@FirstName", student.FirstName);
                        cmd1.Parameters.AddWithValue("@LastName", student.LastName);
                        cmd1.Parameters.AddWithValue("@Birthday", student.Birthday);
                        cmd1.Parameters.AddWithValue("@TeacherID", student.TeacherID);
                        cmd1.Parameters.AddWithValue("@Grade", student.Grade);
                        cmd1.Parameters.AddWithValue("@Address", student.Address);
                        cmd1.Parameters.AddWithValue("@City", student.City);
                        cmd1.Parameters.AddWithValue("@State", student.State);
                        cmd1.Parameters.AddWithValue("@ZipCode", student.ZipCode);
                        cmd1.Parameters.AddWithValue("@NCESID", student.NCESId);
                        

                        var temp = cmd1.ExecuteScalar();
                        newStudentId = Convert.ToInt32(temp);

                        SqlCommand cmd2 = new SqlCommand(cmdText2, conn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@IEPDate", SqlDbType.Date);
                        cmd2.Parameters.AddWithValue("@StudentID", newStudentId);
                        cmd2.Parameters.AddWithValue("@SLPID", slp.SLPID);
                        cmd2.Parameters.AddWithValue("@IEPType", student.IEPType);
                        cmd2.Parameters["@IEPDate"].Value = student.IEPdate;
                        cmd2.Parameters.AddWithValue("@IEPLeaderFirstName", student.IEPLeaderFirstName);
                        cmd2.Parameters.AddWithValue("@IEPLeaderLastName", student.IEPLeaderLastName);
                        cmd2.Parameters.AddWithValue("@GoalType", student.GoalType);
                        cmd2.Parameters.AddWithValue("@IEPNotes", student.IEPNotes);
                        cmd2.Parameters.AddWithValue("@Active", student.Active);

                        int returnValue = cmd2.ExecuteNonQuery();

                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;

        }

        public int DeleteStudent(Students student, Students iep)
        {
            int result = 0;

            int delete1 = 0;
            int delete2 = 0;

            var conn = DBConnection.GetConnection();

            var cmdText1 = @"sp_delete_student_iep_by_id";
            var cmdText2 = @"sp_delete_student_by_id";

            var cmd1 = new SqlCommand(cmdText1, conn);
            var cmd2 = new SqlCommand(cmdText2, conn);

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@StudentID", iep.StudentId);
            cmd2.Parameters.AddWithValue("@StudentID", student.StudentId);


            try
            {
                conn.Open();

                delete2 = cmd1.ExecuteNonQuery();
                delete1 = cmd2.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            if (delete1 == 1 && delete2 == 1)
            {
                result = 1;
            }

            return result;
        }

        public int DeactivateIEP(Students iep)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"deactivate_iep_by_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IEPID", iep.IEPID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int ActivateIEP(Students iep)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"activate_iep_by_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IEPID", iep.IEPID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int CreateNewStudentIEP(Students student, SLPUser slp)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            string cmdText = @"sp_insert_new_iep";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@IEPDate", SqlDbType.Date);
            //cmd.Parameters.Add("@StudentID", SqlDbType.Int);

            //cmd.Parameters.["@StudentID"].Value = student.StudentId;
            cmd.Parameters.AddWithValue("@StudentID", student.StudentId);
            cmd.Parameters.AddWithValue("@SLPID", slp.SLPID);
            cmd.Parameters.AddWithValue("@IEPType", student.IEPType);
            //cmd.Parameters.AddWithValue("@IEPDate", student.IEPdate);
            cmd.Parameters["@IEPDate"].Value = student.IEPdate;
            cmd.Parameters.AddWithValue("@IEPLeaderFirstName", student.IEPLeaderFirstName);
            cmd.Parameters.AddWithValue("@IEPLeaderLastName", student.IEPLeaderLastName);
            cmd.Parameters.AddWithValue("@IEPNotes", student.IEPNotes);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int UpdateIEP(Students oldIEP, Students newIEP)
        {
            int rows = 0;

            

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_update_iep_by_studentid";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentID", oldIEP.StudentId);

            cmd.Parameters.AddWithValue("@IEPType", newIEP.IEPType);
            cmd.Parameters.AddWithValue("@IEPDate", newIEP.IEPdate);
            cmd.Parameters.AddWithValue("@IEPLeaderFirstName", newIEP.IEPLeaderFirstName);
            cmd.Parameters.AddWithValue("@IEPLeaderLastName", newIEP.IEPLeaderLastName);
            cmd.Parameters.AddWithValue("@GoalType", newIEP.GoalType);
            cmd.Parameters.AddWithValue("@IEPNotes", newIEP.IEPNotes);

            cmd.Parameters.AddWithValue("@OldIEPType", oldIEP.IEPType);
            cmd.Parameters.AddWithValue("@OldIEPDate", oldIEP.IEPdate);
            cmd.Parameters.AddWithValue("@OldIEPLeaderFirstName", oldIEP.IEPLeaderFirstName);
            cmd.Parameters.AddWithValue("@OldIEPLeaderLastName", oldIEP.IEPLeaderLastName);
            cmd.Parameters.AddWithValue("@OldGoalType", oldIEP.GoalType);
            cmd.Parameters.AddWithValue("@OldIEPNotes", oldIEP.IEPNotes);


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        public List<string> SelectAllStates()
        {
            var states = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_all_stateID", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        states.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return states;
        }
    }
}
