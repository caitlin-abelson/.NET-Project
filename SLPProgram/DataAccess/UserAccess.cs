using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserAccess : IUserAccess
    {
        public UserAccess()
        {

        }

        public int VerifyUsernamePasswordSLP(string username, string password)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            string cmdText = @"sp_authenticate_slp";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = password;

            try
            {
                conn.Open();

                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception up)
            {

                throw up;
            }

            return result;
        }

        public int VerifyUsernamePasswordManager(string username, string password)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            string cmdText = @"sp_authenticate_manager";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = password;

            try
            {
                conn.Open();

                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception up)
            {

                throw up;
            }

            return result;
        }

        public int VerifyUsernamePasswordTeacher(string username, string password)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            string cmdText = @"sp_authenticate_teacher";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = password;

            try
            {
                conn.Open();

                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception up)
            {

                throw up;
            }

            return result;
        }

        public SLPUser GetSLPByEmail(string email)
        {
            SLPUser slpUser = null;

            var conn = DBConnection.GetConnection();

            string cmdText = "sp_get_slp_username_by_email";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);

            cmd.Parameters["@Email"].Value = email;

            try
            {
                string firstName = null;
                string lastName = null;
                string slpID = null;
                string managerId = null;
                List<string> users = new List<string>();


                conn.Open();

                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        slpID = reader1.GetString(0);
                        firstName = reader1.GetString(1);
                        lastName = reader1.GetString(2);
                        managerId = reader1.GetString(3);
                    }
                }
                else
                {
                    throw new ApplicationException("This SLP was not not found.");
                }

                reader1.Close();

                slpUser = new SLPUser(slpID, firstName, lastName, managerId, users);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return slpUser;
        }

        public ManagerUser GetManagerByEmail(string email)
        {
            ManagerUser managerUser = null;

            var conn = DBConnection.GetConnection();

            string cmdText = "sp_get_manager_username_by_email";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);

            cmd.Parameters["@Email"].Value = email;

            try
            {
                string firstName = null;
                string lastName = null;
                string managerID = null;
                List<string> users = new List<string>();


                conn.Open();

                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        managerID = reader1.GetString(0);
                        firstName = reader1.GetString(1);
                        lastName = reader1.GetString(2);
                    }
                }
                else
                {
                    throw new ApplicationException("This Manager was not not found.");
                }

                reader1.Close();

                managerUser = new ManagerUser(managerID, firstName, lastName, users);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return managerUser;
        }
        public TeacherUser GetTeacherByEmail(string email)
        {
            TeacherUser teacherUser = null;

            var conn = DBConnection.GetConnection();

            string cmdText = "sp_get_teacher_username_by_email";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);

            cmd.Parameters["@Email"].Value = email;

            try
            {
                string firstName = null;
                string lastName = null;
                string teacherID = null;
                string ncesID = null;
                List<string> users = new List<string>();


                conn.Open();

                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        teacherID = reader1.GetString(0);
                        ncesID = reader1.GetString(1);
                        firstName = reader1.GetString(2);
                        lastName = reader1.GetString(3);
                    }
                }
                else
                {
                    throw new ApplicationException("This Teacher was not not found.");
                }

                reader1.Close();

                teacherUser = new TeacherUser(teacherID, ncesID, firstName, lastName, users);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return teacherUser;
        }

        public List<string> SelectSLPIds()
        {
            var slpids = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_slpid", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        slpids.Add(reader.GetString(0));
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

            return slpids;
        }



        public int UpdatePasswordHashSLP(string email, string oldPassword, string newPassword)
        {
            int result = 0;

            // get a connect
            var conn = DBConnection.GetConnection();

            //command text

            string cmdText = "sp_update_passwordhash_slp";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@NewPasswordHash"].Value = newPassword;
            cmd.Parameters["@OldPasswordhash"].Value = oldPassword;

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

        public int UpdatePasswordHashManager(string email, string oldPassword, string newPassword)
        {
            int result = 0;

            // get a connect
            var conn = DBConnection.GetConnection();

            //command text

            string cmdText = "sp_update_password_hash_manager";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@NewPasswordHash"].Value = newPassword;
            cmd.Parameters["@OldPasswordhash"].Value = oldPassword;

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

        public int UpdatePasswordHashTeacher(string email, string oldPassword, string newPassword)
        {
            int result = 0;

            // get a connect
            var conn = DBConnection.GetConnection();

            //command text

            string cmdText = "sp_update_passwordhash_teacher";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@NewPasswordHash"].Value = newPassword;
            cmd.Parameters["@OldPasswordhash"].Value = oldPassword;

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


        public SLPUser RetrieveSLPByEmail(string email)
        {
            SLPUser slp = null;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_retrieve_all_slp_emails";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", email);

            try
            {
                string slpID = null;
                string firstName = null;
                string lastName = null;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        slpID = reader.GetString(0);
                        firstName = reader.GetString(1);
                        lastName = reader.GetString(2);
                    }
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }

                slp = new SLPUser(slpID, firstName, lastName);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return slp;
        }

        public TeacherUser RetrieveTeacherByEmail(string email)
        {
            TeacherUser teacher = null;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_retrieve_all_teacher_emails";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", email);

            try
            {
                string teacherID = null;
                string firstName = null;
                string lastName = null;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        teacherID = reader.GetString(0);
                        firstName = reader.GetString(1);
                        lastName = reader.GetString(2);
                    }
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }

                teacher = new TeacherUser(teacherID, firstName, lastName);
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

        public ManagerUser RetrieveManagerByEmail(string email)
        {
            ManagerUser manager = null;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_retrieve_all_manager_emails";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", email);

            try
            {
                string managerID = null;
                string firstName = null;
                string lastName = null;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        managerID = reader.GetString(0);
                        firstName = reader.GetString(1);
                        lastName = reader.GetString(2);
                    }
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }

                manager = new ManagerUser(managerID, firstName, lastName);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return manager;
        }

        public List<SLPUser> RetrieveSLPs()
        {
            List<SLPUser> slps = new List<SLPUser>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_retrieve_slp_info";
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
                        SLPUser slp = new SLPUser();
                        slp.SLPID = reader.GetString(0);
                        slp.FirstName = reader.GetString(1);
                        slp.LastName = reader.GetString(2);
                        slp.Email = reader.GetString(3);
                        slps.Add(slp);
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

            return slps;
        }

        public List<TeacherUser> RetrieveTeachers()
        {
            List<TeacherUser> teachers = new List<TeacherUser>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_retrieve_teacher_info";
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
                        TeacherUser teacher = new TeacherUser();
                        teacher.TeacherID = reader.GetString(0);
                        teacher.FirstName = reader.GetString(1);
                        teacher.LastName = reader.GetString(2);
                        teacher.Email = reader.GetString(3);
                        teachers.Add(teacher);
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

            return teachers;
        }
    }
}
