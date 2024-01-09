using SimpleSQL;

public class LessonRecord
{
	

	[NotNull,PrimaryKey,AutoIncrement]
	public int LessonRecordID { get; set; }

	[NotNull]
	public int LessonID { get; set; }

	[NotNull]
	public int UserID { get; set; }
	
	[MaxLength(30), NotNull]
	public int Score { get; set; }	

	[MaxLength(20), NotNull]
	public int Collision_count { get; set; }

	[MaxLength(20), NotNull]
	public string Overspeed { get; set; }

	[MaxLength(20), NotNull]
	public string AvgSpeed { get; set; }

	[MaxLength(20), NotNull]
	public string MaxSpeed { get; set; }

	[MaxLength(20), NotNull]
	public string WrongFaceDirection { get; set; }

	[MaxLength(20), NotNull]
	public string AdjustDrive { get; set; }

	[MaxLength(20), NotNull]
	public string RaiseDrive { get; set; }

	[MaxLength(20), NotNull]
	public string TiltDrive { get; set; }

	[MaxLength(20), NotNull]
	public string FinishTime { get; set; }

	[MaxLength(20), NotNull]
	public string ForkTooHigh { get; set; }

	[MaxLength(20), NotNull]
	public string RampTurning { get; set; }

	[MaxLength(20), NotNull]
	public string RampFaceDown { get; set; }

	[MaxLength(20), NotNull]
	public string Result { get; set; }

	[MaxLength(20), NotNull]
	public string Create_Date  { get; set; }
}
