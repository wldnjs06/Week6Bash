using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class ObjectDetector : MonoBehaviour
{
    [SerializeField]    
    private TowerSpawner towerSpawner;
    [SerializeField]
	private	UIPopupTower uiPopupTower;

    private Camera mainCamera;
    private Vector2 screanPoint;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        screanPoint = context.ReadValue<Vector2>();
    }

public void Onclick(InputAction.CallbackContext context)
{
        //버튼을 누르거나 땔 때 호출
        if(!context.performed) return;

        //버튼을 눌렀을 때만 true 변환(땔 떄 호출하지 않도록 처리)
        if(!context.ReadValueAsButton()) return;

        //카메라 위치에서 화면의 터치 위치를 관통하는 레이 생성
        Ray ray = mainCamera.ScreenPointToRay(screanPoint);

        //2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택하는 방법
        //레이와 충돌하는 오브젝트를 검증해 hit에 저장
        if(Physics.Raycast(ray, out var hit, Mathf.Infinity))
        {
            //광선에 충돌한 오브젝트의 태그가 "Tile"이면
            if(hit.transform.CompareTag("Tile"))
            {
                //타워를 생성하는 TrySpawnTower() 메소드 호춯
                towerSpawner.TrySpawnTower(hit.transform);
            }

            //타워를 선택하면 해당 타워 정보를 출력
            else if ( hit.transform.CompareTag("Tower") )
			{
				uiPopupTower.OnPopup(hit.transform);
			}
        }
    }
}
