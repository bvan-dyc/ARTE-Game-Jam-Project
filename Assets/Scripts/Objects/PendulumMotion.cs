using UnityEngine;

public class PendulumMotion : MonoBehaviour
{
	[SerializeField] protected Quaternion RotateFrom = Quaternion.identity;
	[SerializeField] protected Quaternion RotateTo = Quaternion.identity;
	[SerializeField] protected float Speed = 0.0f;
	[SerializeField] protected bool launchOnStart = false;
	[SerializeField] protected bool moveOnlyOnce = false;
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

		transform.rotation = Quaternion.Slerp(RotateFrom, RotateTo, currentTime);
	}

	public void LaunchPendulum()
	{
		launch = true;
	}
}
