using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour {

	protected PlayerController representedPlayerController;	
	[SerializeField] private GameObject lifeIconPrefab = null;
	[SerializeField] private float heartIconAnchorWidth = 0.041f;
	[SerializeField] private float heartIconAnchorHeight = -0.02f;

	protected Animator[] lifeIconAnimators;

	protected readonly int hashActivePara = Animator.StringToHash("Active");

	IEnumerator Start()
	{
		representedPlayerController = PlayerController.instance;
		if (representedPlayerController == null)
			yield break;

		yield return null;

		lifeIconAnimators = new Animator[representedPlayerController.MaxLives];

		for (int i = 0; i < representedPlayerController.MaxLives; i++)
		{
			GameObject lifeIcon = Instantiate(lifeIconPrefab);
			lifeIcon.transform.SetParent(transform);
			RectTransform lifeIconRect = lifeIcon.transform as RectTransform;
			lifeIconRect.anchoredPosition = Vector2.zero;
			//lifeIconRect.sizeDelta = Vector2.zero;
			lifeIconRect.anchorMin = new Vector2(lifeIconRect.anchorMin.x, lifeIconRect.anchorMin.y + heartIconAnchorHeight);
			lifeIconRect.anchorMax = new Vector2(lifeIconRect.anchorMax.x, lifeIconRect.anchorMax.y + heartIconAnchorHeight);
			lifeIconRect.anchorMin += new Vector2(heartIconAnchorWidth, 0f) * (i + 1);
			lifeIconRect.anchorMax += new Vector2(heartIconAnchorWidth, 0f) * (i + 1);
			lifeIconAnimators[i] = lifeIcon.GetComponent<Animator>();

			if (representedPlayerController.LivesLeft < i + 1)
			{
				lifeIconAnimators[i].SetBool(hashActivePara, false);
			}
		}
	}

	public void RefreshLivesUI(PlayerController PlayerController)
	{
		if (lifeIconAnimators == null)
			return;

		for (int i = 0; i < lifeIconAnimators.Length; i++)
		{
			lifeIconAnimators[i].SetBool(hashActivePara, PlayerController.LivesLeft >= i + 1);
		}
	}
}
