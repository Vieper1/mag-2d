using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Sand"))
		{
			GameController._instance.CollectSandUnit(collision.gameObject);
		}
	}
}
