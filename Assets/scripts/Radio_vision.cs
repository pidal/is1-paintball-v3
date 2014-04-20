using UnityEngine;
using System.Collections;

public class Radio_vision : MonoBehaviour {
	
	public float def_distancia;
	public float distancia;

	private Jugador jugador;

	// Use this for initialization
	void Start () {
		def_distancia = 12;
		distancia = def_distancia;
		jugador = transform.parent.GetComponent<Jugador> ();
	}
	
	// Update is called once per frame
	public void Update () 
	{
		CircleCollider2D planetCollider = this.GetComponent<CircleCollider2D>();
		planetCollider.radius = distancia;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//Debug.Log ("Aqui hay algo");
		// Solo si detecto un radio de deteccion de otro enemigo
		if (col.tag == "radio_deteccion") 
		{
			//Debug.Log ("Un radio de deteccion enemigo!!");
			Jugador jugador_enemigo = col.gameObject.transform.parent.GetComponent<Jugador>();

			if(!jugador.equipo.Equals(jugador_enemigo.equipo))
			{
				//Debug.Log("Si se imprime esto malo!");
				jugador.enemigo_detectado = jugador_enemigo;
				// El jugador enemigo detectado no tiene porque detectar al primero.
				//jugador_enemigo.enemigo_detectado = jugador;
			}
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		// Solo si detecto un radio de deteccion de otro enemigo
		if (col.tag == "radio_deteccion") 
		{
			Jugador jugador_enemigo = col.gameObject.transform.parent.GetComponent<Jugador>();

			if(jugador.enemigo_detectado != null && jugador.enemigo_detectado.Equals(jugador_enemigo))
			{
				jugador.enemigo_detectado = null;
				// Ver el trigger de arriba
				//jugador_enemigo.enemigo_detectado = null;
			}

		}
	}
}