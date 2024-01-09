using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoginUser
{

	public static int UserID { get; set; }		
	public static string UserName { get; set; }
	public static string Password { get; set; }
	public static int LessonFinished { get; set; }
	public static int LessonPassed { get; set; }
	public static string CreateDate { get; set; }
	public static string LastLogin { get; set; }
	public static void ResetValues()
	{
		UserID = 0;
		UserName = "Username";
		Password = "Password";
		LessonFinished = 0;
		LessonPassed = 0;
		CreateDate = "";
		LastLogin = "";
		
	}
}
