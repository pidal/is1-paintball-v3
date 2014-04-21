using UnityEngine;
using System.Collections;

public static class Combate {


	public static void Combatir(Jugador jug1, Jugador jug2)
	{
		float num = Random.Range (0f, 10f);
		Debug.Log (num);
		if (num <= 5) 
		{
			//eliminar_jugador(jug1);
		} 
		else 
		{
			eliminar_jugador(jug2);
			jug1.enemigo_detectado = null;
			jug1.enemigo_combatiendo = null;
			jug2.enemigo_detectado = null;
			jug2.enemigo_combatiendo = null;
		}

	}

	private static void eliminar_jugador(Jugador jugador)
	{
		jugador.activo = false;
		jugador.selected = false;
		jugador.transform.rotation = Quaternion.Euler(0,0,180);
	}
	
}
