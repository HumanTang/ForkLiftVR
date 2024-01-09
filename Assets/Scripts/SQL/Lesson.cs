using SimpleSQL;

public class Lesson
{
	

	[NotNull,PrimaryKey, AutoIncrement]
	public int LessonID { get; set; }	

	[MaxLength(20), NotNull]
	public string LessonName { get; set; }


}
