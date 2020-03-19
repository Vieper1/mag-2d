using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController _instance;

	[Header("Game")]
	public GameObject BagOfSand;
	public int NumberOfSandUnits = 1;
	public GameObject SandUnitPrefab;
	

	[Header("Other")]
	public float GameTime = 0f;

	private List<Rigidbody2D> _sandUnits;
	private int _sandUnitsCollected = 0;


    void Start()
    {
        if (_instance != this)
		{
			Destroy(_instance);
			_instance = this;
		}

		_sandUnits = new List<Rigidbody2D>(NumberOfSandUnits);
		Vector3 _position = BagOfSand.transform.position;
		for (int i = 0; i < NumberOfSandUnits; i++)
		{
			Vector3 _offset = new Vector3(Random.value, Random.value, 0f);
			Vector3 _spawnPosition = _position + _offset;

			GameObject obj = Instantiate(SandUnitPrefab, _spawnPosition, Quaternion.identity, BagOfSand.transform);
			_sandUnits.Add(obj.GetComponent<Rigidbody2D>());
		}
    }

    void Update()
    {
		GameTime += Time.deltaTime;
    }

	public void CollectSandUnit(GameObject sandUnit)
	{
		_sandUnits.Remove(sandUnit.GetComponent<Rigidbody2D>());
		//Destroy(sandUnit);
		_sandUnitsCollected++;
	}

	

	// Force
	public void AddPullFrom(MagnetPull _magnet)
	{
		foreach (Rigidbody2D _rb2d in _sandUnits)
		{
			Vector3 distance = _rb2d.transform.position - _magnet.transform.position;
			_rb2d.AddForce(distance.normalized * -1f * _magnet.ForceMultiplier / distance.magnitude);
		}
	}

	public void AddPushFrom(MagnetPush _magnet)
	{
		foreach (Rigidbody2D _rb2d in _sandUnits)
		{
			Vector3 distance = _rb2d.transform.position - _magnet.transform.position;
			_rb2d.AddForce(distance.normalized * _magnet.ForceMultiplier / distance.magnitude);
		}
	}
}
