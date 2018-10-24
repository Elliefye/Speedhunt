using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerInfoTest : MonoBehaviour {
	public string name = "Justin";
	public bool isNight = false;
	public int heat = 0;
	public int cash = 0;
	public int dayNr = 1;
	public int mainQuest = 1;
	public int sideQuest1 = 0;
	public int carId = 0;
	public int wheelId = 0;
	public float wheelScale = 0.7f;
	public string licensePlate = "NFS";
	public int upgrade1 = 0;
	public int upgrade2 = 0;
	public int upgrade3 = 0;
	public int arrestedCount = 0;
	public int racedCount = 0;
	public bool lastArrested = false;
	
	void Awake () {
		Game.current = new Game();
		Game.current.checking = false;
        Game.current.isNight = isNight;
        Game.current.name = name;
        Game.current.heat = heat;
        Game.current.cash = cash;
        Game.current.dayNr = dayNr;

        Game.current.mainQuest = mainQuest;
		Game.current.sideQuest1 = sideQuest1;

        Game.current.carId = carId;
        Game.current.wheelId = wheelId;

        Game.current.upgrade1 = upgrade1;
        Game.current.upgrade2 = upgrade2;
        Game.current.upgrade3 = upgrade3;

        Game.current.arrestedCount = arrestedCount;
        Game.current.racedCount = racedCount;
        Game.current.lastArrested = lastArrested;
	}
}
