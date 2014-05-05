using UnityEngine;
using System.Collections;

public class Terreno : MonoBehaviour {

	public float cambio_velocidad;
	public float cambio_radio_deteccion;
	public float cambio_radio_vision;
	public float cambio_radio_disparo;
	public float cambio_transparencia;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
			Jugador jugador = col.gameObject.GetComponent<Jugador> ();
			jugador.tipo_terreno = this;

//			Esto no es necesario ya que se ejecuta en el update del jugador continuamente.

//			jugador.velocidad *= cambio_velocidad;
//			jugador.radio_vision.distancia *= cambio_radio_vision;
//			jugador.radio_disparo.distancia *= cambio_radio_disparo;
//			jugador.radio_deteccion.distancia *= cambio_radio_deteccion;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
			Jugador jugador = col.gameObject.GetComponent<Jugador> ();
			jugador.tipo_terreno = null;
		
//			jugador.velocidad = jugador.def_velocidad;
//			jugador.radio_vision.distancia = jugador.radio_vision.def_distancia;
//			jugador.radio_disparo.distancia = jugador.radio_disparo.def_distancia;
//			jugador.radio_deteccion.distancia = jugador.radio_deteccion.def_distancia;
		}
	}

}
