//SqlHandler

using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

public class SqlHandler : MonoBehaviour
{

	// reference to our database manager object in the scene
	public SimpleSQL.SimpleSQLManager dbManager;
	public static SqlHandler instance;
	public Text Username;
	public Text Password;
	public Text TableName;
	public Text lesson_input;
	public string username;
	public string password;
	public bool userMatched = false;
	// reference to the gui text object in our scene that will be used for output
	public Text outputText;

	public void onCreateTable() {
		string sql;
		sql = "CREATE TABLE \"User\" " +
		"(\"UserID\" INTEGER PRIMARY KEY NOT NULL, " +
		"\"UserName\" varchar(30), " +
		"\"Password\" varchar(20) )";
		dbManager.Execute(sql);
	}

	public void onCreateRecord()
	{
		byte[] salt;
		new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
		var pbkdf2 = new Rfc2898DeriveBytes(Password.text,salt,10000);
		byte[] hash = pbkdf2.GetBytes(20);
		byte[] hashBytes = new byte[36];
		Array.Copy(salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);
		string savedPasswordHash = Convert.ToBase64String(hashBytes);
		User user = new User
		{
			UserName = Username.text,
			Password = savedPasswordHash,
			CreateDate = System.DateTime.UtcNow.ToString(),
			LastLogin = System.DateTime.UtcNow.ToString()
		};
		dbManager.Insert(user);

	}

	public void onCreateRecordLesson()
	{
		Lesson lesson = new Lesson
		{
			LessonName = lesson_input.text,
			
		};
		dbManager.Insert(lesson);

	}

	public void onCreateRecordLessonRecord()
	{
		LessonRecord lesson_record = new LessonRecord
		{
			LessonID = 0,
			UserID = 0,
			Score = 1,
			Collision_count = 1,
			Overspeed = "1",
			AvgSpeed = "1",
			MaxSpeed = "1",
			WrongFaceDirection = "1",
			AdjustDrive = "1",
			RaiseDrive = "1",
			TiltDrive = "1",
			FinishTime = "1",
			ForkTooHigh = "1",
			RampTurning = "1",
			RampFaceDown = "1",
			Result = "passed",
			Create_Date = System.DateTime.UtcNow.ToString()
		};
		dbManager.Insert(lesson_record);

	}


	public void CreateDatabase() {

	}
	
	public void ReadTable() {
		List<User> Userlist = dbManager.Query<User>(
														"SELECT *" +

														"FROM " +
															"User"
														);
		outputText.text = "Users:\n\n";
		foreach (User user in Userlist)
		{
			outputText.text += "<color=#1abc9c>UserID</color>: '" + user.UserID + "' " +
									  "<color=#1abc9c>UserName</color>:" + user.UserName.ToString() + " " +
									  "<color=#1abc9c>Password</color>:" + user.Password.ToString() + " " +
									 "\n";
		}

	}

	public void ReadTableLessonRecord()
	{
		List<LessonRecord> LessonRecordlist = dbManager.Query<LessonRecord>(
														"SELECT *" +

														"FROM " +
															"LessonRecord"
														);
		outputText.text = "LessonRecords:\n\n";
		if (LessonRecordlist != null)
		{
			foreach (LessonRecord lessonrecord in LessonRecordlist)
			{
				outputText.text += "<color=#1abc9c>LessonRecordID</color>: '" + lessonrecord.LessonRecordID.ToString() + "' " +
										  "<color=#1abc9c>LessonID</color>: " + lessonrecord.LessonID.ToString() + " " +
										 "<color=#1abc9c>UserID</color>: " + lessonrecord.UserID.ToString() + " " +
										 "<color=#1abc9c>Score</color>:" + lessonrecord.Score.ToString() + " " +
										 "<color=#1abc9c>Collision_count</color>:" + lessonrecord.Collision_count.ToString() + " " +
										 "<color=#1abc9c>Overspeed</color>:" + lessonrecord.Overspeed.ToString() + " " +
										 "<color=#1abc9c>AvgSpeed</color>:" + lessonrecord.AvgSpeed.ToString() + " " +
										 "<color=#1abc9c>MaxSpeed</color>:" + lessonrecord.MaxSpeed.ToString() + " " +
										 "<color=#1abc9c>WrongFaceDirection</color>:" + lessonrecord.WrongFaceDirection.ToString() + " " +
										 "<color=#1abc9c>AdjustDrive</color>:" + lessonrecord.AdjustDrive.ToString() + " " +
										 "<color=#1abc9c>RaiseDrive</color>:" + lessonrecord.RaiseDrive.ToString() + " " +
										 "<color=#1abc9c>TiltDrive</color>:" + lessonrecord.TiltDrive.ToString() + " " +
										 "<color=#1abc9c>FinishTime</color>:" + lessonrecord.FinishTime.ToString() + " " +
										 "<color=#1abc9c>ForkTooHigh</color>:" + lessonrecord.ForkTooHigh.ToString() + " " +
										 "<color=#1abc9c>RampTurning</color>:" + lessonrecord.RampTurning.ToString() + " " +
										 "<color=#1abc9c>RampFaceDown</color>:" + lessonrecord.RampFaceDown.ToString() + " " +
										 "<color=#1abc9c>Result</color>:" + lessonrecord.Result.ToString() + " " +
										 "<color=#1abc9c>Create_Date</color>:" + lessonrecord.Create_Date.ToString() + " " +
										 "\n";
			}
		}
		else
		{
			outputText.text = "NULL";
		}
		

	}


	public void ReadTableLessonRecord_CurrentUser()
	{
		List<LessonRecord> LessonRecordlist = dbManager.Query<LessonRecord>(
														"SELECT *" +

														"FROM " +
															"LessonRecord  Where UserID = ?", LoginUser.UserID
														);
		outputText.text = "LessonRecords:\n\n";
		if (LessonRecordlist != null)
		{
			foreach (LessonRecord lessonrecord in LessonRecordlist)
			{
				outputText.text += "<color=#1abc9c>LessonRecordID</color>: '" + lessonrecord.LessonRecordID.ToString() + "' " +
										  "<color=#1abc9c>LessonID</color>: " + lessonrecord.LessonID.ToString() + " " +
										 "<color=#1abc9c>UserID</color>: " + lessonrecord.UserID.ToString() + " " +
										 "<color=#1abc9c>Score</color>:" + lessonrecord.Score.ToString() + " " +
										 "<color=#1abc9c>Collision_count</color>:" + lessonrecord.Collision_count.ToString() + " " +
										 "<color=#1abc9c>Overspeed</color>:" + lessonrecord.Overspeed.ToString() + " " +
										 "<color=#1abc9c>AvgSpeed</color>:" + lessonrecord.AvgSpeed.ToString() + " " +
										 "<color=#1abc9c>MaxSpeed</color>:" + lessonrecord.MaxSpeed.ToString() + " " +
										 "<color=#1abc9c>WrongFaceDirection</color>:" + lessonrecord.WrongFaceDirection.ToString() + " " +
										 "<color=#1abc9c>AdjustDrive</color>:" + lessonrecord.AdjustDrive.ToString() + " " +
										 "<color=#1abc9c>RaiseDrive</color>:" + lessonrecord.RaiseDrive.ToString() + " " +
										 "<color=#1abc9c>TiltDrive</color>:" + lessonrecord.TiltDrive.ToString() + " " +
										 "<color=#1abc9c>FinishTime</color>:" + lessonrecord.FinishTime.ToString() + " " +
										 "<color=#1abc9c>ForkTooHigh</color>:" + lessonrecord.ForkTooHigh.ToString() + " " +
										 "<color=#1abc9c>RampTurning</color>:" + lessonrecord.RampTurning.ToString() + " " +
										 "<color=#1abc9c>RampFaceDown</color>:" + lessonrecord.RampFaceDown.ToString() + " " +
										 "<color=#1abc9c>Result</color>:" + lessonrecord.Result.ToString() + " " +
										 "<color=#1abc9c>Create_Date</color>:" + lessonrecord.Create_Date.ToString() + " " +
										 "\n";
			}
		}
		else
		{
			outputText.text = "NULL";
		}


	}

	public void ReadTableLessonRecord_CurrentUserLessonCode(int LessonID = 6)
	{
		List<LessonRecord> LessonRecordlist = dbManager.Query<LessonRecord>(
														"SELECT *" +

														"FROM " +
															"LessonRecord  Where UserID = ? AND LessonID =?", LoginUser.UserID, LessonID
														);
		outputText.text = "LessonRecords:\n\n";
		//outputText.text += LoginUser.UserID + " \n";
		//outputText.text += LessonID + " \n"  ;
		if (LessonRecordlist != null)
		{
			foreach (LessonRecord lessonrecord in LessonRecordlist)
			{
				outputText.text += "<color=#1abc9c>LessonRecordID</color>: " + lessonrecord.LessonRecordID.ToString() + " \t" +
										 // "<color=#1abc9c>LessonID</color>: " + lessonrecord.LessonID.ToString() + " " +
										 //"<color=#1abc9c>UserID</color>: " + lessonrecord.UserID.ToString() + " " +
										 "<color=#1abc9c>Score</color>:" + lessonrecord.Score.ToString() + " \t" +
										 "<color=#1abc9c>Collision_count</color>:" + lessonrecord.Collision_count.ToString() + " \t" +
										 "<color=#1abc9c>Overspeed</color>:" + lessonrecord.Overspeed.ToString() + " \t" +
										 "<color=#1abc9c>AvgSpeed</color>:" + lessonrecord.AvgSpeed.ToString() + " \t" +
										 "<color=#1abc9c>MaxSpeed</color>:" + lessonrecord.MaxSpeed.ToString() + " \t" +
										 "<color=#1abc9c>WrongFaceDirection</color>:" + lessonrecord.WrongFaceDirection.ToString() + " \t" +
										 "<color=#1abc9c>AdjustDrive</color>:" + lessonrecord.AdjustDrive.ToString() + " \t" +
										 "<color=#1abc9c>RaiseDrive</color>:" + lessonrecord.RaiseDrive.ToString() + " \t" +
										 "<color=#1abc9c>TiltDrive</color>:" + lessonrecord.TiltDrive.ToString() + " \t" +
										 "<color=#1abc9c>FinishTime</color>:" + lessonrecord.FinishTime.ToString() + " \t" +
										 //"<color=#1abc9c>ForkTooHigh</color>:" + lessonrecord.ForkTooHigh.ToString() + " " +
										 "<color=#1abc9c>RampTurning</color>:" + lessonrecord.RampTurning.ToString() + " \t" +
										 "<color=#1abc9c>RampFaceDown</color>:" + lessonrecord.RampFaceDown.ToString() + " \t" +
										 "<color=#1abc9c>Result</color>:" + lessonrecord.Result.ToString() + " \t" +
										 "<color=#1abc9c>Create_Date</color>:" + lessonrecord.Create_Date.ToString() + " \t" +
										 "\n\n\n";
			}
		}
		else
		{
			outputText.text = "NULL";
		}


	}


	public void ReadTableLesson_CurrentLesson(int lesson_code)
	{
		List<Lesson> Lessonlist = dbManager.Query<Lesson>(
														"SELECT *" +

														"FROM " +
															"Lesson  = ?", lesson_code
														);
		outputText.text = "LessonRecords:\n\n";
		if (Lessonlist != null)
		{
			foreach (Lesson lesson in Lessonlist)
			{
				outputText.text += "<color=#1abc9c>LessonRecordID</color>: '" + lesson.LessonID.ToString() + "' " +
										  "<color=#1abc9c>LessonID</color>: " + lesson.LessonName.ToString() + " " +
										 "\n";
			}
		}
		else
		{
			outputText.text = "NULL";
		}


	}






	public void ReadTableLesson()
	{
		List<Lesson> Lessonlist = dbManager.Query<Lesson>(
														"SELECT *" +

														"FROM " +
															"Lesson"
														);
		outputText.text = "Users:\n\n";
		foreach (Lesson lesson in Lessonlist)
		{
			outputText.text += "<color=#1abc9c>LessonID</color>: '" + lesson.LessonID + "' " +
									  "<color=#1abc9c>LessonName</color>:" + lesson.LessonName.ToString() + " " +									  
									 "\n";
		}

	}
	public void UserLogin() {
		
		bool recordExists;
		User firstUserRecord = dbManager.QueryFirstRecord<User>(out recordExists, "SELECT UserID,UserName,Password FROM User WHERE UserName = ?", Username.text);
		if (recordExists)
		{
			outputText.text += firstUserRecord.UserName + "\n";
			outputText.text += firstUserRecord.Password + "\n";
			byte[] hashBytes = Convert.FromBase64String(firstUserRecord.Password);
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);			
			var pbkdf2 = new Rfc2898DeriveBytes(Password.text, salt, 10000);
			byte[] hash = pbkdf2.GetBytes(20);
			
			
			string savedPasswordHash = Convert.ToBase64String(hashBytes);

			int ok = 1;
			for (int i = 0; i < 20; i++)
			{
				if (hashBytes[i + 16] != hash[i])
					ok = 0;
			}
			if (ok == 1)
			{
				outputText.text += "Matched record found\n";
				LoginUser.UserID = firstUserRecord.UserID;
				dbManager.Execute("UPDATE User SET LastLogin = ? WHERE UserID = ?", System.DateTime.UtcNow.ToString(), firstUserRecord.UserID);
			}
		}
		else
			outputText.text += "No record found\n";
	}
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//LoginUser.ResetValues();
		username = LoginUser.UserName;
		password = LoginUser.Password;
	}
	void GetLoginInfo() {
		username = LoginUser.UserName;
		password = LoginUser.Password;
	}

	public void UserLogin_handler(string user,string password)
	{

		bool recordExists;
		User firstUserRecord = dbManager.QueryFirstRecord<User>(out recordExists, "SELECT UserID,UserName,Password FROM User WHERE UserName = ?", user);
		if (recordExists)
		{			
			byte[] hashBytes = Convert.FromBase64String(firstUserRecord.Password);
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
			byte[] hash = pbkdf2.GetBytes(20);


			string savedPasswordHash = Convert.ToBase64String(hashBytes);

			int ok = 1;
			for (int i = 0; i < 20; i++)
			{
				if (hashBytes[i + 16] != hash[i])
					ok = 0;
			}
			if (ok == 1)
			{
				userMatched = true;				
				dbManager.Execute("UPDATE User SET LastLogin = ? WHERE UserID = ?", System.DateTime.UtcNow.ToString(), firstUserRecord.UserID);
				LoginUser.UserID = firstUserRecord.UserID;
				LoginUser.UserName = firstUserRecord.UserName;
				LoginUser.LessonFinished = firstUserRecord.LessonFinished;
				LoginUser.LessonPassed = firstUserRecord.LessonPassed;
				LoginUser.CreateDate = firstUserRecord.CreateDate;
				
				username = LoginUser.UserName;
				
			}
		}
		else
		{
			userMatched = false;
			
		}
			
	}


	void Logout()
	{
		LoginUser.ResetValues();
	}

	public void onCreateRecordLessonRecord_handler(int score,int collision,string overspeed, string avgspeed,string maxspeed,
		string wrongfacedirection,string adjustdrive, string raisedrive,string tiltdrive, string finishtime,string forktoohigh,
		string rampturning,string rampfacedown, string result)
	{
		LessonRecord lesson_record = new LessonRecord
		{
			LessonID = (int)GameManager.instance.current_lesson,
			UserID = LoginUser.UserID,
			Score = score,
			Collision_count = collision,
			Overspeed = overspeed,
			AvgSpeed = avgspeed,
			MaxSpeed = maxspeed,
			WrongFaceDirection = wrongfacedirection,
			AdjustDrive = adjustdrive,
			RaiseDrive = raisedrive,
			TiltDrive = tiltdrive,
			FinishTime = finishtime,
			ForkTooHigh = forktoohigh,
			RampTurning = rampturning,
			RampFaceDown = rampfacedown,
			Result = result,
			Create_Date = System.DateTime.UtcNow.ToString()
		};
		dbManager.Insert(lesson_record);

	}

	private void Update()
	{
		
		var active_scene = SceneManager.GetActiveScene();
		if (active_scene.name == "Scoreboard")
		{
			var output = GameObject.Find("Ouput");
			outputText = output.gameObject.GetComponent<Text>();
			ReadTableLessonRecord_CurrentUserLessonCode(6);
		}
	}
	void Start()
	{
		
		//string sql;
		//sql = "CREATE TABLE \"StarShip\" " +
		//"(\"StarShipID\" INTEGER PRIMARY KEY NOT NULL, " +
		//"\"StarShipName\" varchar(60), " +
		//"\"HomePlanet\" varchar(100), " +
		//"\"Range\" FLOAT, " +
		//"\"Armor\" FLOAT, " +
		//"\"Firepower\" FLOAT)";
		//dbManager.Execute(sql);





		//      // get the first weapon record that has a WeaponID > 4
		//outputText.text += "\nFirst weapon record where the WeaponID > 4: ";
		//bool recordExists;
		//StarShip firstWeaponRecord = dbManager.QueryFirstRecord<StarShip>(out recordExists, "SELECT HomePlanet FROM StarShip");
		//if (recordExists)
		//	outputText.text += firstWeaponRecord.StarShipName + "\n";
		//else
		//	outputText.text += "No record found\n";

	}
}

