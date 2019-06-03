        public int StudentId { get; set; }
        public string NCESId { get; set; }
        public DateTime Birthday { get; set; }
        public string Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public bool Active { get; set; }
		
		
		                            BoatID = reader.GetString(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Capacity = reader.GetInt32(3),
                            Date = reader.GetDateTime(4),
                            Slip = reader.GetInt32(5),
                            BoatTypeID = reader.GetString(6),
                            StatusID = reader.GetString(7),
                            Active = reader.GetBoolean(8)
		

		
							
							
	[IEPID]					[int]IDENTITY(100000,1)	NOT NULL,
	[StudentID]				[int] 					NOT NULL,
	[SLPID]					[int] 					NOT NULL,
	[IEPType]				[nvarchar](50)  		NOT NULL,
	[IEPDate]				[date]					NOT NULL DEFAULT
	'1950-01-01',
	[IEPLeaderFirstName]	[nvarchar](50)			NOT NULL,
	[IEPLeaderLastName]		[nvarchar](50)			NOT NULL,
	[IEPNotes]				[nvarchar](4000)		NULL,
	
	
	print '' print '*** Creating sp_retrieve_student_iep'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_student_iep]
	(
		@StudentID			[int]
	)
AS
	BEGIN
		SELECT	[School].[Name], [Student].[Birthday], [Student].[Grade], [Student].[FirstName], [Student].[LastName], [IEP].[IEPType], [IEP].[IEPDate], [IEP].[IEPLeaderFirstName], [IEP].[IEPLeaderLastName], [IEP].[IEPNotes]
		FROM	[School] INNER JOIN [Student] ON [School].[NCESID] = [Student].[NCESID]
				INNER JOIN [IEP] ON [Student].[StudentID] = [IEP].[StudentID]
				INNER JOIN [IEPGoals] ON [IEPGoals].[IEPID] = [IEP].[IEPID]
				INNER JOIN [GoalType] ON [IEPGoals].[GoalType] = [GoalType].[GoalType]
		WHERE	[IEP].[StudentID] = @StudentID
	END
GO




        public string SchoolName { get; set; }
        public DateTime Birthday { get; set; }
        public string Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IEPType { get; set; }
        public DateTime IEPdate { get; set; }
        public string IEPLeaderFirstName { get; set; }
        public string IEPLeaderLastName { get; set; }
        public string IEPNotes { get; set; }
		
		
		
		
		
		
		
		
		
		
		
        public static IEP SelectStudentIEP(int studentId)
        {
            IEP studentIEP = null;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_retrieve_student_iep", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StudentID", SqlDbType.Int);

            cmd.Parameters["@StudentID"].Value = studentId;

            try
            {
                int slpId = 0;
                string schoolName = null;
                DateTime birthday;
                string grade = null;
                string firstName = null;
                string lastName = null;
                string iepType = null;
                DateTime iepDate;
                string iepLeaderFirstName = null;
                string iepLeaderLastName = null;
                string iepNotes = null;

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    slpId = reader.GetInt32(0);
                    schoolName = reader.GetString(1);
                    birthday = reader.GetDateTime(2);
                    grade = reader.GetString(3);
                    firstName = reader.GetString(4);
                    lastName = reader.GetString(5);
                    iepType = reader.GetString(6);
                    iepDate = reader.GetDateTime(7);
                    iepLeaderFirstName = reader.GetString(8);
                    iepLeaderLastName = reader.GetString(9);
                    iepNotes = reader.GetString(10);
                }
                else
                {
                    throw new ApplicationException("Student not found.");
                }
                reader.Close();

                studentIEP = new IEP(slpId, schoolName, birthday, grade, firstName, lastName, iepType, iepDate, iepLeaderFirstName, iepLeaderLastName, iepNotes);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return studentIEP;
        }
    }
}


            List<Students> students = new List<Students>();

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_retrive_student_by_slpid";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SLPID", SLPId);

            try
            {
                int studentID = 0;
                string NCESID = null;
                DateTime birthday;
                string grade = null;
                string firstName = null;
                string lastName = null;
                string address = null;
                string city;
                string state = null;
                string zipcode = null;
                bool active = false;

                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        studentID = reader.GetInt32(0);
                        NCESID = reader.GetString(1);
                        birthday = reader.GetDateTime(2);
                        grade = reader.GetString(3);
                        firstName = reader.GetString(4);
                        lastName = reader.GetString(5);
                        address = reader.GetString(6);
                        city = reader.GetString(7);
                        state = reader.GetString(8);
                        zipcode = reader.GetInt32(9).ToString();
                        active = reader.GetBoolean(10);
                    }
