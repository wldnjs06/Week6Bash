using UnityEngine;

public class FollowTargetUI : MonoBehaviour
{
	[SerializeField]
	private	Transform		target;

	private	RectTransform	rectTransform;
	private	Camera			mainCamera;

	private void Awake()
	{
		rectTransform	= GetComponent<RectTransform>();
		mainCamera		= Camera.main;
	}

	public void SetTarget(Transform target) => this.target = target;

	private void LateUpdate()
	{
		if ( target == null )
		{
			Destroy(gameObject);
			return;
		}

		rectTransform.position = mainCamera.WorldToScreenPoint(target.position);
	}




}
