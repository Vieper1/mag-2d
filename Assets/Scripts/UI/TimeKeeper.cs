using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
	[Header("References")]
	public GameController _gameController;

	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
    {
		text.text = Mathf.RoundToInt(GameController._instance.GameTime).ToString();
    }
}
