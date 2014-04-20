using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {
	
	public enum Equipos
	{
		Azul,
		Rosa
	}

	public enum Postura
	{
		DePie,
		Agachado,
		Tumbado
	}

	public bool activo;
	public float def_velocidad = 1;
	public float velocidad;
	public bool selected = false;

	public Radio_vision radio_vision = null;
	public Radio_deteccion radio_deteccion = null;
	public Radio_disparo radio_disparo = null;

	public Terreno tipo_terreno;

	public Jugador enemigo_detectado;
	public Jugador enemigo_combatiendo; 

	public Equipos equipo;
	public Postura postura;

	private Vector3 direccion;
	
	// Update is called once per frame
	void Update () {

		// CalcularVelocidad ();

		if (this.selected) 
		{
			direccion = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			transform.position += direccion * velocidad;
		}

		if (this.enemigo_combatiendo != null) 
		{
			Debug.Log("COMBATE!");
			Combate.Combatir(this, enemigo_combatiendo);
		}

		if (this.activo == false)
			Destroy (gameObject, 2f);

	}

	void CalcularVelocidad()
	{
		switch (postura) {
			case Postura.Agachado:
				this.velocidad = def_velocidad * 0.5f;
				break;
			case Postura.Tumbado:
				this.velocidad = def_velocidad * 0.1f;
				break;
			default:
				this.velocidad = def_velocidad * 1;
				break;
		}
	}

	void OnMouseDown()
	{
		if (this.selected)
			this.selected = false;
		else
			this.selected = true;
	}
}
