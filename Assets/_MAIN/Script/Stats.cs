using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	public int coin;
	public float joy;
	public float hunger;
	public float energy;
	//public long timeInSeconds;
	public long secondsOff;

	public Image joyBar;
	public Image hungerBar;
	public Image energyBar;
	public Text coinText;

	void Start () {
		coin = PlayerPrefs.GetInt ("Coin", 0);
		joy = PlayerPrefs.GetFloat ("Joy", 100);
		hunger = PlayerPrefs.GetFloat ("Hunger", 100);
		energy = PlayerPrefs.GetFloat ("Energy", 100);
		long timeInSeconds = Convert.ToInt64 (PlayerPrefs.GetString ("Seconds", SecondStamp().ToString() ));
		secondsOff = SecondStamp () - timeInSeconds;

		//Gain Energy when sleeping: 50% per hour.
		energy += 50.0f*(secondsOff/3600.0f);

		//Drain Hunger when sleeping: 6% per hour.
		hunger -= 4*(secondsOff/3600.0f);

		//Decrease Joy while away: 6% per hour but only after 9 hour, but can not fall below 10%.
		joy -= Math.Min(90, Math.Max(0, 6.0f * ( (secondsOff/3600.0f)-9) ) );

		StartCoroutine(SecondUpdate());
	}

	void Update () {
		AnimCheck ();
		StatsLimit ();

		joyBar.fillAmount = joy/100.0f;
		hungerBar.fillAmount = hunger/100.0f;
		energyBar.fillAmount = energy/100.0f;
		coinText.text = coin.ToString();

		PlayerPrefs.SetInt ("Coin", coin);
		PlayerPrefs.SetFloat ("Joy", joy);
		PlayerPrefs.SetFloat ("Hunger", hunger);
		PlayerPrefs.SetFloat ("Energy", energy);
		PlayerPrefs.SetString ("Seconds", SecondStamp().ToString());
	}   
        
	IEnumerator SecondUpdate () {
		//Drain Energy when awake: 12.5% per hour.
		energy -= 12.5f*(1/3600.0f);

		//Drain Hunger when awake: 7.5% per hour.
		hunger -= 5*(1/3600.0f);

		yield return new WaitForSeconds(1);

		StartCoroutine(SecondUpdate());
	}

	/*void OnApplicationQuit() {
		//To be replaced with actual values
		PlayerPrefs.SetInt ("Coin", coin);
		PlayerPrefs.SetFloat ("Joy", joy);
		PlayerPrefs.SetFloat ("Hunger", hunger);
		PlayerPrefs.SetFloat ("Energy", energy);
		//string longTimeToStr = SecondStamp().ToString();
		PlayerPrefs.SetString ("Seconds", SecondStamp().ToString());
		//Debug.Log("Application closed at " + SecondStamp() + " local seconds");
	}*/

	long SecondStamp () {
		long ticksToSeconds = Convert.ToInt64(Mathf.Pow(10, 7));
		long localSeconds = System.DateTime.Now.Ticks / ticksToSeconds;
		//print (localSeconds);
		return (localSeconds);
	}

	void StatsLimit () {
		if (joy > 100)
			joy = 100;

		if (hunger > 100)
			hunger = 100;

		if (energy > 100)
			energy = 100;

		if (joy < 0)
			joy = 0;

		if (hunger < 0)
			hunger = 0;

		if (energy < 0)
			energy = 0;

		if (coin < 0)
			coin = 0;
	}

	void AnimCheck (){
		GameObject objWithAnim = GameObject.Find("Russ");
		Anim scrAnim = objWithAnim.GetComponent<Anim>();
		if(joy < 50 || hunger < 50 || energy < 50)
		{
			scrAnim.tired = 1;
		}
		else scrAnim.tired = 0;
	}

}
