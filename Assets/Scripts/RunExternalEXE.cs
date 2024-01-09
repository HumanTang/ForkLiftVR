using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
public class RunExternalEXE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
		Process p = new Process();
		//p.StartInfo.UseShellExecute = true;
		//p.StartInfo.FileName = "D:\\VR ForkLift\\Detect\\KinectBackgroundRemoval.exe";
		//p.StartInfo.FileName = "D:\\kinect-2-background-removal\\KinectBackgroundRemoval\\bin\\x64\\Release\\KinectBackgroundRemoval.exe";
		p.StartInfo.FileName = "D:\\VR ForkLift\\Assets\\Bat\\run.bat";
		p.Start();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
