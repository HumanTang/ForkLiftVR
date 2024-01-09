using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// This script shows how to call a simple SQL query from a database using the class definition of the
/// database to format the results.
/// 
/// In this example we overwrite the working database since no data is being changed. This is set in the 
/// SimpleSQLManager gameobject in the scene.
/// </summary>
public class SimpleQuery : MonoBehaviour {

	// reference to our database manager object in the scene
	public SimpleSQL.SimpleSQLManager dbManager;
	
	// reference to the gui text object in our scene that will be used for output
	public Text outputText;

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

		//StarShip StarShip = new StarShip
		//{
		//	StarShipID = 3,
		//	StarShipName = "GOODShip",
		//	HomePlanet = "GG",
		//	Range = 1000,
		//	Armor = 10,
		//	Firepower = 0.5f
		//};
		//dbManager.Insert(StarShip);

		


		// Gather a list of weapons and their type names pulled from the weapontype table		
		List<StarShip> weaponList = dbManager.Query<StarShip>(
														"SELECT *" +														
															
														"FROM " +
															"StarShip"
														);

		//// output the list of weapons
		outputText.text = "Starship\n\n";
		foreach (StarShip weaponRecord in weaponList)
		{
			outputText.text += "<color=#1abc9c>Name</color>: '" + weaponRecord.StarShipID + "' " +
									  "<color=#1abc9c>Damage</color>:" + weaponRecord.StarShipName.ToString() + " " +
									  "<color=#1abc9c>Cost</color>:" + weaponRecord.HomePlanet.ToString() + " " +
									  "<color=#1abc9c>Weight</color>:" + weaponRecord.Range.ToString() + " " +
									  "<color=#1abc9c>Type</color>:" + weaponRecord.Armor + "\n";
		}


		//      // get the first weapon record that has a WeaponID > 4
		outputText.text += "\nFirst weapon record where the WeaponID > 4: ";
		bool recordExists;
		StarShip firstWeaponRecord = dbManager.QueryFirstRecord<StarShip>(out recordExists, "SELECT HomePlanet FROM StarShip");
		if (recordExists)
			outputText.text += firstWeaponRecord.StarShipName + "\n";
		else
			outputText.text += "No record found\n";

	}
}
