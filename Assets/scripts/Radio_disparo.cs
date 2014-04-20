using UnityEngine;
using System.Collections;

public class Radio_disparo : MonoBehaviour {

	public float def_distancia;
	public float distancia;

	private Jugador jugador;

	// Use this for initialization
	void Start () {
		def_distancia = 6;
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
		if (col.tag == "Player") 
		{
			Jugador jugador_enemigo = col.gameObject.GetComponent<Jugador> ();

			if(!jugador.equipo.Equals(jugador_enemigo.equipo))
			{
				jugador.enemigo_combatiendo = jugador_enemigo;

				// Si un jugador entra en combate con otro, este otro detecta y combate tambien con el primero.	
				jugador_enemigo.enemigo_combatiendo = jugador;
				jugador_enemigo.enemigo_detectado = jugador;
			}
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
			//Jugador jugador_enemigo = col.gameObject.GetComponent<Jugador> ();

			// En un principio este metodo no seria necesario, ya que en la clase de combate, eliminamos un jugador
			// y al otro se le reestablecen las propiedades necesarias.

		}
	}

}
