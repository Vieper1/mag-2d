using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPull : MonoBehaviour
{
	public float ForceMultiplier = 1f;

	void Start()
	{

	}

	void Update()
	{
		RaycastHit2D[] _hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		foreach (RaycastHit2D _hit in _hits)
		{
			if (_hit.collider.gameObject == gameObject)
			{
				GameController._instance.AddPullFrom(this);
				break;
			}
		}
	}
}
