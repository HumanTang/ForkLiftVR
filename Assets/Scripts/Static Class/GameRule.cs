using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameRule
{

		public static float WrongDirection { get; set; }
		public static float OverSpeed { get; set; }
		public static float OverAllSpeed { get; set; }
		public static float MaxSpeed { get; set; }
		public static float GoDownRamp { get; set; }
		public static float RaiseForkHeightWithLoad { get; set; }
		public static float RaiseForkTooHigh { get; set; }
		public static float DriveAdjustForkLR { get; set; }
		public static float DriveRaiseLowFork { get; set; }
		public static float DriveTiltFork { get; set; }
		public static float GameTimer { get; set; }
		public static int collision { get; set; }
		public static int score { get; set; }
		public static int result { get; set; }
		public static float TurningRamp { get; set; }
		public static void ResetValues() {
			WrongDirection = 0;
			OverSpeed = 0;		
			OverAllSpeed = 0;
			MaxSpeed = 0;
			GoDownRamp = 0;
			RaiseForkHeightWithLoad = 0;
			RaiseForkTooHigh = 0;
			DriveAdjustForkLR = 0;
			DriveRaiseLowFork = 0;
			DriveTiltFork = 0;
			GameTimer = 0;
			collision = 0;
			score = 0;
			result = 0;
			TurningRamp = 0;
		}
}
