using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
	private	TowerTemplateSO towerTemplate;	
    [SerializeField]
	private	EnemySpawner enemySpawner;	// 현재 맵에 존재하는 적 리스트 정보를 얻기 위해

    [SerializeField]
	private	PlayerGold playerGold;
    [SerializeField]
	private	SystemTextViewer systemTextViewer;

    public void TrySpawnTower(Transform tileTransform)
    {
        //타워 건설 가능 여부 확인
        //1. 골드가 부족하면 타워 건설 불가능 할 때 출력
        if (towerTemplate.weapon[0].cost > playerGold.CurrentGold)
        {
            systemTextViewer.PrintText(MESSAGE.MONEY);
            return;
        }
		// 타워가 건설되어 있음으로 설정
		Tile tile = tileTransform.GetComponent<Tile>();


        if ( tile.IsbuildTower == true )
		{	
			systemTextViewer.PrintText(MESSAGE.BUILD);
			return;
		}

		tile.IsbuildTower = true;

		playerGold.CurrentGold -= towerTemplate.weapon[0].cost;

		Vector3 position = tileTransform.position + Vector3.back;
		var clone = Instantiate(towerTemplate.towerPrefab, position, Quaternion.identity);

		clone.GetComponent<TowerWeapon>().Setup(enemySpawner, playerGold, tile);
    }
}
