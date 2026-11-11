using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
	private	GameObject	enemyHPPrefab; // 적 체력을 출력하는 Slider UI 프리팹
    [SerializeField]
	private	Transform	hpUIParent;
    [SerializeField]
    private Transform[] wayPoints; // 현재 스테이지의 이동 경로
    [SerializeField]
	private	PlayerHP playerHP;	//플레이어 체력	
	[SerializeField]
	private PlayerGold playerGold; //플레이어 골드 정보
    private	Wave currentWave; //현재 웨이브 정보
    private List<Enemy> enemyList; // 현재 맵에 존재하는 모든 적의 정보
    private	int	currentEnemyCount; 
    public	List<Enemy>	EnemyList => enemyList; 
    public	int	CurrentEnemyCount => currentEnemyCount;
	public	int	MaxEnemyCount => currentWave.maxEnemyCount;
    private void Awake()
    {
        // 적 리스트 메모리 할당
        enemyList = new List<Enemy>();
    }

    	public void StartWave(Wave wave)
	{
		currentWave = wave;
		currentEnemyCount = currentWave.maxEnemyCount;
		StartCoroutine(nameof(SpawnEnemy));
	}


    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;

        while (spawnEnemyCount < currentWave.maxEnemyCount)
        {
            int	enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
			var	clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
			Enemy enemy = clone.GetComponent<Enemy>();
            
            //this는 나 자신(자신의 enemySpawner 정보)
            enemy.Setup(this, wayPoints); // wayPoints 정보를 매개변수로 Setup() 메소드 호출
            enemyList.Add(enemy); // 리스트에 방금 생성한 적 정보 저장

            SpawnEnemyHP(clone);

            spawnEnemyCount ++;

            yield return new WaitForSeconds(currentWave.spawnTime); // spawnTime 시간 동안 대기
        }
    }
    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int gold)
    {

        if ( type == EnemyDestroyType.Arrive )
		{
			playerHP.TakeDamage(1);
		}
        else if ( type == EnemyDestroyType.Kill )
		{
			playerGold.CurrentGold += gold;
		}

        currentEnemyCount --;
        //리스트에서 사망하는 적 정보 삭제
        enemyList.Remove(enemy);
        // 적 오브젝트 삭제
        Destroy(enemy.gameObject);
    }

    private void SpawnEnemyHP(GameObject enemy)
	{
		var clone = Instantiate(enemyHPPrefab);
		
		clone.transform.SetParent(hpUIParent);
		clone.transform.localScale = Vector3.one;

		clone.GetComponent<FollowTargetUI>().SetTarget(enemy.GetComponent<Enemy>().HUDPoint);
		clone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
	}
    
}
