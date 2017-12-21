﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject circle;
	public int quantity = 200;
	public float radius = 50;
	public float maxSpeed = 5;

	//proc gen sensor stuff
	public float sensorChance;
	public int avgSensorRange;
	public int sensorRangeRange;
	public int avgSensorTimeRange;
	public int sensorTimeRangeRange;



	// Use this for initialization
	void Awake (){
		for (int i = 0; i < quantity; i++) {
			Vector3 pos = Random.insideUnitCircle * radius;

			GameObject inst = Instantiate (circle, pos, Quaternion.identity) as GameObject;
			inst.name = "Asteroid" + i.ToString ();
			inst.GetComponent<Rigidbody2D> ().velocity = Random.insideUnitCircle * maxSpeed;
			if (Random.value <= sensorChance) {
				inst.GetComponent<AsteroidSensorInfo> ().hasSensors = true;
				inst.GetComponent<AsteroidSensorInfo> ().sensorRange = Random.Range (avgSensorRange - sensorRangeRange, avgSensorRange + sensorRangeRange);
				inst.GetComponent<AsteroidSensorInfo> ().sensorTimeRange = Random.Range (avgSensorTimeRange - sensorTimeRangeRange, avgSensorRange + sensorTimeRangeRange);
			} else {
				inst.GetComponent<AsteroidSensorInfo> ().hasSensors = false;
			}
		}
	}
}
