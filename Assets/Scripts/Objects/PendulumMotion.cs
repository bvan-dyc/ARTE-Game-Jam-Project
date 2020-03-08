using UnityEngine;

public class PendulumMotion : MonoBehaviour
{
	[SerializeField] protected Quaternion RotateFrom = Quaternion.identity;
	[SerializeField] protected Quaternion RotateTo = Quaternion.identity;
	[SerializeField] protected float Speed = 0.0f;
	[SerializeField] protected bool launchOnStart = false;
	[SerializeField] protected bool stopAfterOneSlash = false;
	[SerializeField] protected bool destroyAfterTime = false;
	[SerializeField] protected float timeBeforeDestruction_s = 4f;

	protected bool launch = false;

	// Use this for initialization
	void Start()
	{
		launch = launchOnStart;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!launch)
			return;
		var currentTime = Mathf.SmoothStep(0.0f, 1.0f, Mathf.PingPong(Time.time * Speed, 1.0f));

		if (destroyAfterTime)
		{
			timeBeforeDestruction_s -= Time.deltaTime;
			if (timeBeforeDestruction_s < 0)
			{
				Destroy(gameObject);
			}
		}
		if (stopAfterOneSlash && currentTime >= 0.9)
		{
			Speed = 0;
		}
		else
		{
			transform.rotation = Quaternion.Slerp(RotateFrom, RotateTo, currentTime);
		}
	}

	public void LaunchPendulum()
	{
		launch = true;
	}
}
