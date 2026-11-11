using UnityEngine;
using TMPro;

public class StageUIViewer : MonoBehaviour
{
	[SerializeField]
	private	TextMeshProUGUI	textPlayerHP;	 //플레이어 체력 출력 UI
	[SerializeField]
	private	TextMeshProUGUI	textPlayerGold;	
	[SerializeField]
	private	TextMeshProUGUI	textWave;		
	[SerializeField]
	private	TextMeshProUGUI	textEnemyCount;
	[SerializeField]
	private	PlayerHP playerHP;  //플레이어 체력 정보
	[SerializeField]
	private	PlayerGold playerGold;		
	[SerializeField]
	private	WaveSystem waveSystem;
	[SerializeField]
	private	EnemySpawner enemySpawner;

	private void Update()
	{
		textPlayerHP.text = $"{playerHP.CurrentHP}/{playerHP.MaxHP}";
		textPlayerGold.text	= $"{playerGold.CurrentGold}";
		textWave.text = $"{waveSystem.CurrentWave}/{waveSystem.MaxWave}";
		textEnemyCount.text	= $"{enemySpawner.CurrentEnemyCount}/{enemySpawner.MaxEnemyCount}";
	}
}
