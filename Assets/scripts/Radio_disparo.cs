using UnityEngine;
using System.Collections;

public class Radio_disparo : MonoBehaviour {

	public float def_distancia;
	public float distancia;

	private Jugador jugador;

	// Use this for initialization
	void Start () {
		def_distancia = 18;
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
				int layerMask = 1 << LayerMask.NameToLayer("Obstaculos");
				if(!Physics2D.Linecast(jugador.transform.position, jugador_enemigo.transform.position, layerMask))
				{
					jugador.enemigo_combatiendo = jugador_enemigo;
					
					// Si un jugador entra en combate con otro, este otro detecta y combate tambien con el primero.	
//					jugador_enemigo.enemigo_combatiendo = jugador;
//					jugador_enemigo.enemigo_detectado = jugador;
				}
			}
		}
	}


	void OnTriggerStay2D (Collider2D col)
	{
		OnTriggerEnter2D (col);
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
		
			Jugador jugador_enemigo = col.gameObject.GetComponent<Jugador> ();

			if(jugador.enemigo_combatiendo != null && jugador.enemigo_combatiendo.Equals(jugador_enemigo))
			{
				jugador.enemigo_combatiendo = null;
			}

			// En un principio este metodo no seria necesario, ya que en la clase de combate, eliminamos un jugador
			// y al otro se le reestablecen las propiedades necesarias.

		}
	}

}
