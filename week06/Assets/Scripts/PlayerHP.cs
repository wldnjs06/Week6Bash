using UnityEngine;
using System.Collections;
//using UnityEditor.Search;

public class PlayerHP : MonoBehaviour
{
	[SerializeField]
    private UIScreanRed screanUI;

    [SerializeField]
	private	float maxHP;			

	private	float currentHP;		
	//private	bool isDie = false;	
	//private	Enemy enemy;
	//private	SpriteRenderer	spriteRenderer;

	public	float MaxHP => maxHP;
	public	float CurrentHP => currentHP;

	private void Awake()
	{
		//enemy			= GetComponent<Enemy>();
		//spriteRenderer	= GetComponentInChildren<SpriteRenderer>();
		currentHP		= maxHP;
	}

	public void TakeDamage(float damage)
	{
		//if ( isDie == true ) return;


		currentHP -= damage;

        screanUI.OnHitAnimation();

		// StopCoroutine(nameof(HitAlphaAnimation));
		// StartCoroutine(nameof(HitAlphaAnimation));

		if ( currentHP <= 0 )
		{
			// isDie = true;
			// enemy.OnDie(EnemyDestroyType.Kill);
		}
	}

	// private IEnumerator HitAlphaAnimation()
	// {
	// 	Color color = spriteRenderer.color;

	// 	color.a = 0.4f;
	// 	spriteRenderer.color = color;

	// 	yield return new WaitForSeconds(0.05f);

	// 	color.a = 1.0f;
	// 	spriteRenderer.color = color;
	// }
}
