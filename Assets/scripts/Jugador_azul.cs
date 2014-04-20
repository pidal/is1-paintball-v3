using UnityEngine;
using System.Collections;

public class Jugador_azul : Jugador {


	// Use this for initialization
	void Start () {

		activo = true;
		equipo = Equipos.Azul;
		postura = Postura.DePie;
		this.velocidad = def_velocidad;

	}
	

}
