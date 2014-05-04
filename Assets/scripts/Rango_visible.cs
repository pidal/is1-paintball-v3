using UnityEngine;
using System.Collections;

public class vision : MonoBehaviour {
	private Jugador jugador;
	
	// Use this for initialization
	void Start () {
		jugador = transform.light.GetComponent<Jugador> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
