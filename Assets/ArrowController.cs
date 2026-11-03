/* 화살을 화면 위에서 아래로 떨어트리는 스크립트
 *   - 화살이 위에서 아래로 1ㅊ에 떨어지는 기능 --> transform.Translate()
 *   - 화살이 게임화면 밖으로 나오면 화살 오브젝트를 소멸시키는 기능 --> Destroy()
 *     
 */

using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // 화살 이동 속도 (초당 Unity 단위)
    float arrowSpeed = 6.0f;

    //플레이어 오브젝트
    GameObject player = null;

    Vector2 arrowCirclePoint = Vector2.zero;     // 화살 원의 중심 좌표
    Vector2 playerCirclePoint = Vector2.zero;    // 플레이어 언의 중심 좌표
    Vector2 arrowPlayerDirection = Vector2.zero; // 두 원의 중심을 연결하는 벡터

    //충돌 판정에 사용할 거리 및 반지름
    float arrowPlayerDistance = 0.0f; // 두 원의 중심 사이 거리
    float arrowRadius = 0.5f;         // 화살 원의 반지름
    float playerRadius = 1.0f;        // 플레이어 원의 반지름  

    // 게임 시작 시 한번 수행
    void Start()
    {
        // 씬에서 player 오브젝트 검색
        player = GameObject.Find("player");
    }

    // 매 프레임 실행
    void Update()
    {
        // 1. 화살을 아래 방향으로 이동
        //     - Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
        //     - Y 좌표에 (-arrowSpeed * Time.deltaTime)를 지정하면 오브젝트를 조금씩 위에서 아래로 움직인다
        //     - 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -arrowSpeed * Time.deltaTime, 0);

        // 2. 화면 밖으로 나온 화살 소멸시키기
        //    - 화살을 내버려 두면 화면 밖으로 나가게 되고, 눈에 보이지는 않지만 계속 떨어짐
        //    - 화살이 보이지 않는 곳에서 계속 떨어지면 컴퓨터 역시 계산을 해야함으로 메모리 낭비
        //    - 메모리가 낭비되지 않도록 화살이 화면 밖으로 나가면 오브젝트를 소멸시켜야 함
        // 3. Destroy 메서드 : 매개변수로 전달한 오브젝트를 삭제
        //    - 매개변수로 자신(화살 오브젝트)을 가르키는 gameObject 변수를 전달하므로 화살이
        //    - 화면 밖으로 나갈 때 자기 자신을 소멸시킴
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);

            return;
        }

        // 플레이어 오브젝트가 없으면 충돌 판정 생략
        if (player == null)
        {
            return;
        }

        // 4. 화살과 플레이어의 중심 좌표 구하기
        arrowCirclePoint = transform.position;
        playerCirclePoint = player.transform.position;

        // 5. 두 원의 중심을 연결하는 벡터 계산
        arrowPlayerDirection = playerCirclePoint - arrowCirclePoint;

        // 6. 두 원의 중심 사이 거리 계산
        //    - 두 벡터간의 길이를 구하는 메서드 : magnitude
        arrowPlayerDistance = arrowPlayerDirection.magnitude;

        // 7. 두 원의 충돌 판정
        if ( arrowPlayerDistance <= arrowRadius + playerRadius)
        {
            // GameDirector 오브젝트 검색
            GameObject gameDirector = GameObject.Find("GameDirector");

            // 게임 감독 스크립트의 HP 감소 메서드 호출
            gameDirector.GetComponent<GameDirector>().DecreaseHP();
            // 충돌한 화살 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
