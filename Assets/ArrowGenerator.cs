/* 화살 오브젝트를 1초에 한 개씩 생성하는 알고리즘
 *  - Instantiate 메서드
 *      - 게임을 실행하는 도중에 게임오브젝트를 생성할 수 있음
 *      - 화살 프리팹을 이용하여, 화살 인스턴스를 생성하는 메서드
 *  - Random.Range 메서드
 *      - Random 클래스는 흔히 요구되는 다양한 타입의 랜덤 값을 쉽게 생성할 수 있는 방법을 제공
 *      - 사용자가 제공한 최솟값과 최댓값 사이의 임의의 숫자를 제공함
 *      - 첫 번째 매개변수보다 크거나 같고, 두 번째 매개변수봐 작은 범위에서 무작위 수를 랜덤하게 반환
 * 
 */

using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    // 화살 프리팹을 저장하는 GameObject 변수
    // public으로 선언하면 Inspector 창엣 프리팹을 할당할 수 있음
    public GameObject arrowPrefab = null;
    
    // 생성된 화살 인스턴스를 저장하는 변수
    GameObject arrowInstance = null;

    // 화살이 생성될 x좌표를 저장하는 변수
    int arrowPositionX = 0;

    // 화살 생성 시간 간격 : 1초마다 화살 생성
    float arrowCreateInterval = 1.0f;

    // 프레임마다 경과한 시간을 누적하는 변수
    float elapsedTime = 0.0f;   //일랩, 경과시간, '경과된 시간'이라는 뜻으로. 게임이나 애니메이션 루프에서 가장 표준적으로 쓰이는 표현


    // 게임 시작 시 한 번 실행
    void Start()
    {
      
    }

    // 매 프레임 실행
    void Update()
    {
        // 1. 프레임 사이의 경과 시간을 누적
        //    Time.deltaTime : 이전 프레임과 현재 프레임 사이의 시간(초)
        elapsedTime += Time.deltaTime;

        // 2. 누적 시간이 화살 생성 간격(1초)을 초과하면 화살 생성
        if (elapsedTime > arrowCreateInterval)
        {
            // 누적 경과 시간 초기화
            elapsedTime = 0.0f;

            // 3. 화살 프리팹으로부터 화살 인스턴스 생성
            // Instantiate() : 프리팹을 복제하여 게임오브젝트 생성
            arrowInstance = Instantiate(arrowPrefab);

            // 4. 화살이 생성될 X 좌표를 무작위로 결정
            // Random.Range(-6, 7) : -6 이상 7 미만의 정수 반환
            // 실제 생성 범위 : -6 ~ 6
            arrowPositionX = Random.Range(-6, 7);

            // 5. 생성된 화살의 위치 설정
            // X : -6 ~ 6 사이의 무작위 좌표
            // Y : 7 (화면 위쪽)
            // Z : 0
            arrowInstance.transform.position = new Vector3(arrowPositionX, 7, 0);
        }

    }
}
