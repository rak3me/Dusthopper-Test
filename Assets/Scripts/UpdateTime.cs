﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTime : MonoBehaviour {
	private bool weirdFrameHappened;
	//there's one frame at the beginning of opening the map where mapOpen has been set to true but Time.timeScale still hasn't been set to zero. 
	//I want to count the deltaTime from this frame but not the ones where fastforwarding is taking place

	void Start(){
		weirdFrameHappened = false;
		GameState.time = -Time.deltaTime;
	}

	void Update () {
		if (GameState.mapOpen) {
			if (!weirdFrameHappened) {
				GameState.time += Time.deltaTime;
				GetComponent<PathMaker> ().initialTime = GameState.time;
				weirdFrameHappened = true;
			}
		} else {
			GameState.time += Time.deltaTime;
			weirdFrameHappened = false;
		}
	}
}
