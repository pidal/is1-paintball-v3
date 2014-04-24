using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Simulador : MonoBehaviour {
	
	private List<Jugador> jugadores = new List<Jugador>();

	void start()
	{
		Time.timeScale = 0;
		Application.LoadLevel ("Menu");
	}
}
