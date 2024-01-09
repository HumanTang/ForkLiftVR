using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
	public SqlHandler sqlHandler;
    // Start is called before the first frame update
    void Start()
    {
		sqlHandler.ReadTableLessonRecord_CurrentUserLessonCode(6);

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
