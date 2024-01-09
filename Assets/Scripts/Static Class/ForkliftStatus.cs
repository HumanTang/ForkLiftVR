using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ForkliftStatus
{
	public static double Speed { get; set; }
	public static float HeightOfFork { get; set; }
	public static bool EngineIsOn { get; set; }
	public static bool Weighted { get; set; }
	public static bool isDriving { get; set; }
	public static bool isTurning { get; set; }
	public static int Direction { get; set; }
    public static float TiltAngle { get; set; }
    public static bool ParkingBrake { get; set; }
    public static void ResetValues() {
		Speed = 0;
		HeightOfFork = 0;
		EngineIsOn = false;
		Weighted = false;
		isDriving = false;
		isTurning = false;
		Direction = 0;
        TiltAngle = 0;
		ParkingBrake = false;
	}




}
