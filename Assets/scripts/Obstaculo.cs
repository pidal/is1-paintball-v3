using UnityEngine;
using System.Collections;

public class Obstaculo : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Color transparente;
	public Color visible;

	// Use this for initialization
	void Start () 
	{
		transparente = new Color (255, 255, 255, 0);
		visible = new Color (255, 255, 255, 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
			spriteRenderer = col.GetComponent<SpriteRenderer> ();
			spriteRenderer.color = transparente;
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
			spriteRenderer = col.GetComponent<SpriteRenderer> ();
			spriteRenderer.color = visible;

		}
	}
}
