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

		ActualizarVariables ();

		if (this.selected) 
		{
			direccion = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			transform.position += direccion * velocidad;

			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				CambiarPostura();
			}
		}

		if (this.enemigo_combatiendo != null) 
		{
			Debug.Log("COMBATE!");
			Combate.Combatir(this, enemigo_combatiendo);
		}

		if (this.activo == false) 
		{
			Destroy (gameObject); //, 2f
		}
	}

	void ActualizarVariables()
	{
		switch (postura) {
			case Postura.Agachado:
				this.velocidad = def_velocidad * 0.5f;
				this.radio_vision.distancia = this.radio_vision.def_distancia * 0.5f;
				this.radio_deteccion.distancia = this.radio_deteccion.def_distancia * 0.5f;
				this.radio_disparo.distancia = this.radio_disparo.def_distancia * 0.5f;
				break;
			case Postura.Tumbado:
				this.velocidad = def_velocidad * 0.1f;
				this.radio_vision.distancia = this.radio_vision.def_distancia * 0.3f;
				this.radio_deteccion.distancia = this.radio_deteccion.def_distancia * 0.3f;
				this.radio_disparo.distancia = this.radio_disparo.def_distancia * 0.3f;
				break;
			default:
				this.velocidad = def_velocidad * 1;
				this.radio_vision.distancia = this.radio_vision.def_distancia * 1;
				this.radio_deteccion.distancia = this.radio_deteccion.def_distancia * 1;
				this.radio_disparo.distancia = this.radio_disparo.def_distancia * 1;
				break;
		}

		if (this.tipo_terreno != null) 
		{
			this.velocidad *= tipo_terreno.cambio_velocidad;
			this.radio_vision.distancia *= tipo_terreno.cambio_radio_vision;
			this.radio_disparo.distancia *= tipo_terreno.cambio_radio_deteccion;
			this.radio_deteccion.distancia *= tipo_terreno.cambio_radio_disparo;
		}
	}

	void CambiarPostura()
	{
		if (postura == Postura.DePie)
			postura = Postura.Agachado;
		else if (postura == Postura.Agachado)
			postura = Postura.Tumbado;
		else
			postura = Postura.DePie;
	}

	void OnMouseDown()
	{
		if (this.selected)
			this.selected = false;
		else
			this.selected = true;
	}
}
