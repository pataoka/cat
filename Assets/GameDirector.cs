/* UI를 갱신하는 감독
 *   - 플레이어가 화살에 맞으면 화면 오른쪽 위에 표시되는 HP 게이지를 줄이는 기능
 *   - 플레이어가 화살에 맞는 시점에 화살 컨트롤러는 감독에게 HP가 감소되었다고 알림 -> 감독은 HP 게이지의 UI를 갱신
 *   - 플레이어와 화살 충돌을 감지하고 UI를 갱신하는 스크립트 작성
 */
using UnityEngine;

using UnityEngine.UI; // UI 오브젝트를 스크립트에서 조작하기 위해서 임포트

public class GameDirector : MonoBehaviour
{
    // HP 게이지 게임오브젝트를 저장하는 변수
    // GameObject.Find()를 이용하여 씬에서 HP 게이지 검색
    GameObject hpGauge = null;

    // 게임 시작 시 한 번 실행
    void Start()
    {
        // 1. 씬에서 HP 게이지 게임오브젝트 검색
        // GameObject.Find(): 이름으로 게임오브젝트 검색
        // "hpGauge": Unity Hierarchy 창의 게임오브젝트 이름
        hpGauge = GameObject.Find("hpGauge");
    }

    // 매 프레임 실행
    void Update()
    {
        
    }

    // 2. HP 게이지를 10% 감소시키는 메서드
    // public: 다른 스크립트에서 호출할 수 있도록 공개
    // ArrowController에서 화살과 플레이어가 충돌하면 호출
    public void DecreaseHP()
    {
        // 3. HP 게이지의 Image 컴퍼넌트 가져오기
        // GetComponent<Image>(): Image 컴퍼넌트 반환

        // 4. Image의 fillAmount 값을 0.1만큼 감소
        // fillAmount: 이미지가 채워지는 비율 (0.0 ~ 1.0)
        // 1.0: HP 100%
        // 0.5: HP 50%
        // 0.0: HP 0%
        hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
