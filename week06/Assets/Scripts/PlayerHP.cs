using UnityEngine;

public class PlayerHP : MonoBehaviour
{
	[SerializeField]
    private UIScreanRed screanUI;

    [SerializeField]
	private	float maxHP;			

	private	float currentHP;	

	public	float MaxHP => maxHP;
	public	float CurrentHP => currentHP;

	private void Awake()
	{
		currentHP = maxHP;
	}

	public void TakeDamage(float damage)
	{

		currentHP -= damage;

        screanUI.OnHitAnimation();


		if ( currentHP <= 0 )
		{
		}
	}
}
