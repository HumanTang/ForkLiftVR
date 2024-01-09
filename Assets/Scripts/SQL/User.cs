using SimpleSQL;

public class User
{
	// User is the primary key, which automatically gets the NotNull attribute
	[PrimaryKey, AutoIncrement,NotNull]
	public int UserID { get; set; }

	// The User name will have an index created in the database.
	// It's max length is set to 30 characters.
	// The name cannot be null.
	[MaxLength(30), NotNull]
	public string UserName { get; set; }
		
	[MaxLength(100), NotNull]
	public string Password { get; set; }

	[NotNull, Default(0)]
	public int LessonFinished { get; set; }

	[NotNull, Default(0)]
	public int LessonPassed { get; set; }

	[MaxLength(20), NotNull]
	public string CreateDate { get; set; }

	[MaxLength(20), NotNull]
	public string LastLogin { get; set; }

	
}
