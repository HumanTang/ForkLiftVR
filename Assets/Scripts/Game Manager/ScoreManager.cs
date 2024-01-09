using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
	public Text[] Result;
	public Text[] Grade;
	public Text Score;
	public Text Score_Grade;
	public Text Passed;
	public int score;
	public Color A = Color.green;
	public Color B = Color.yellow;
	public Color C = new Color(255, 255, 0, 255);
	public Color D = new Color(255, 0, 255, 255);
	public Color E = new Color(100, 100, 100, 255);
	public Color F = new Color(255, 0, 0, 255);
	public Text AvgSpeed;
	private void Awake()
	{



	}
	// Start is called before the first frame update
	void Start()
	{
		score = 0;
		GameManager.instance.ChangeGameStage(GameManager.GameStage.Result);

		var col = GameRule.collision;
		var wr = System.Math.Round(GameRule.WrongDirection, 1);
		var adj = System.Math.Round(GameRule.DriveAdjustForkLR, 1);
		var over = System.Math.Round(GameRule.OverSpeed, 1);
		var max = System.Math.Round(GameRule.MaxSpeed, 1);
		var raise = System.Math.Round(GameRule.DriveRaiseLowFork, 1);
		var tilt = System.Math.Round(GameRule.DriveTiltFork, 1);
		var turn = System.Math.Round(GameRule.TurningRamp, 1);
		var face = GameRule.GoDownRamp;
		var finish = System.Math.Round(GameRule.GameTimer, 1);
		var high = System.Math.Round(GameRule.RaiseForkTooHigh, 1);
		
		var OverAllSpeed = GameRule.OverAllSpeed;
		var avgSpeed = System.Math.Round(OverAllSpeed / finish,1);
		AvgSpeed.text = avgSpeed.ToString() + " km/h";
		Result[0].text = col.ToString() + " time";
		Result[1].text = wr.ToString() + " s";
		Result[2].text = adj.ToString() + " s";
		Result[3].text = over.ToString() + " s";
		Result[4].text = max.ToString() + " km/h";
		Result[5].text = raise.ToString() + " s";
		Result[6].text = tilt.ToString() + " s";
		Result[7].text = turn.ToString() + " s";
		Result[8].text = face.ToString() + " s";
		Result[9].text = finish.ToString() + " s";

		
		//if (col > 5)
		//{
		//	Result[10].text = "Too many collision.";
		//	Result[12].text = "Try to turn slow to avoid obstacle.";

		//}
		//if (over != 0)
		//{
		//	Result[11].text = "Drive too fast.";
		//	Result[13].text = "Step on the gas pedal slowly, drive in a stable speed under 8 km/h.";
		//}

		Grade[0].text = ProcessGrade(col, Grade[0]);
		Grade[1].text = ProcessGrade(wr, Grade[1]);
		Grade[2].text = ProcessGrade(adj, Grade[2]);
		Grade[3].text = ProcessGrade(over, Grade[3]);
		Grade[4].text = ProcessGrade(max, Grade[4]);
		Grade[5].text = ProcessGrade(raise, Grade[5]);
		Grade[6].text = ProcessGrade(tilt, Grade[6]);
		Grade[7].text = ProcessGrade(turn, Grade[7]);
		Grade[8].text = ProcessGrade(face, Grade[8]);
		Grade[9].text = ProcessGrade_Time(finish, Grade[9]);
		
		Score.text = score.ToString() + "/50";
		if (score >= 40) {
			Score_Grade.text = "A";
			Score_Grade.color = A;
		} 
		else if (score >= 35)
		{
			Score_Grade.text = "B";
			Score_Grade.color = B;
		}
		else if (score >= 20)
		{
			Score_Grade.text = "C";
			Score_Grade.color = C;
		}
		else if (score >= 10)
		{
			Score_Grade.text = "D";
			Score_Grade.color = D;
		}
		else if (score >= 5)
		{
			Score_Grade.text = "E";
			Score_Grade.color = E;
		}
		else
		{
			Score_Grade.text = "F";
			Score_Grade.color = F;
		}

		if (score >= 35) {
			Passed.text = "Passed";
			Passed.color = Color.green;
		}
		else
		{
			Passed.text = "Failed";
			Passed.color = Color.red;
		}


		SqlHandler.instance.onCreateRecordLessonRecord_handler(score, col, over.ToString(), avgSpeed.ToString(), max.ToString(),
			wr.ToString(), adj.ToString(), raise.ToString(), tilt.ToString(), finish.ToString(), high.ToString(), turn.ToString(), face.ToString(), Passed.text);
	}

	// Update is called once per frame
	void Update()
	{
		var square = Input.GetButtonDown("square");
		if (square == true || Input.GetKeyDown("p") == true)
		{
			SceneManager.LoadScene("Start Screen");
		}



	}
	
	string ProcessGrade_Time(double time,Text txt)
	{
		if (time <= 60)
		{
			score += 5;
			txt.color = A;
			return "A";
		}
		else if (time <= 80)
		{
			score += 4;
			txt.color = B;
			return "B";
		}
		else if (time <= 100)
		{
			score += 3;
			txt.color = C;
			return "C";
		}
		else if (time <= 120)
		{
			score += 2;
			txt.color = D;
			return "D";
		}
		else if (time <= 150)
		{
			score += 1;
			txt.color = E;
			return "E";
		}
		else
		{
			score += 0;
			txt.color = F;
			return "F";
		}
	}
	string ProcessGrade(int time,Text txt) {
		if (time <= 3)
		{
			score += 5;
			txt.color = A;
			return "A";
		}
		else if (time <= 5)
		{
			score += 4;
			txt.color = B;
			return "B";
		}
		else if (time <= 10)
		{
			score += 3;
			txt.color = C;
			return "C";
		}
		else if (time <= 15)
		{
			score += 2;
			txt.color = D;
			return "D";
		}
		else if (time <= 20)
		{
			score += 1;
			txt.color = E;
			return "E";
		}
		else
		{
			score += 0;
			txt.color = F;
			return "F";
		}
	}

	// for Result1 to Result6
	string ProcessGrade(double time, Text txt) {
		if (time <= 3)
		{
			score += 5;
			txt.color = A;
			return "A";
		}
		else if (time <= 5)
		{
			score += 4;
			txt.color = B;
			return "B";
		}
		else if (time <= 10)
		{
			score += 3;
			txt.color = C;
			return "C";
		}
		else if (time <= 15)
		{
			score += 2;
			txt.color = D;
			return "D";
		}
		else if (time <= 20)
		{
			score += 1;
			txt.color = E;
			return "E";
		}
		else
		{
			score += 0;
			txt.color = F;
			return "F";
		}
	

	}


}
