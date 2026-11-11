using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // 적 프리팹
    [SerializeField]
	private	GameObject	enemyHPPrefab; // 적 체력을 출력하는 Slider UI 프리팹
    [SerializeField]
	private	Transform	hpUIParent;
    [SerializeField]
    private float spawnTime; // 적 생성 추가
    [SerializeField]
    private Transform[] wayPoints; // 현재 스테이지의 이동 경로

    private List<Enemy> enemyList; // 현재 맵에 존재하는 모든 적의 정보
    [SerializeField]
	private	PlayerHP playerHP;	//플레이어 체력	
	[SerializeField]
	private PlayerGold playerGold; //플레이어 골드 정보
    public	List<Enemy>	EnemyList => enemyList; 
    private void Awake()
    {
        // 적 리스트 메모리 할당
        enemyList = new List<Enemy>();
        // 적 생성 코루틴 메소드 호출
        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); //적 오브젝트 생성
            Enemy enemy = clone.GetComponent<Enemy>(); // 방금 생성한 적의 Enemy 컴포넌트
            
            //this는 나 자신(자신의 enemySpawner 정보)
            enemy.Setup(this, wayPoints); // wayPoints 정보를 매개변수로 Setup() 메소드 호출
            enemyList.Add(enemy); // 리스트에 방금 생성한 적 정보 저장

            SpawnEnemyHP(clone);

            yield return new WaitForSeconds(spawnTime); // spawnTime 시간 동안 대기
        }
    }
    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int gold)
    {

        if ( type == EnemyDestroyType.Arrive )
		{
			// �÷��̾� ü�� -1
			playerHP.TakeDamage(1);
		}
        else if ( type == EnemyDestroyType.Kill )
		{
			// ���� ������ ���� ��� �� ��� ȹ��
			playerGold.CurrentGold += gold;
		}

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
