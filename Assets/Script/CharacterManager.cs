using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public ArrayList enemies; // 적 리스트로 터렛에게 타겟 넘기기 위함
    public GameObject Character;
    public static CharacterManager Instance; // 싱글톤으로 쓰고 싶으나 private 생성자가 안되니 그냥 static으로
    public GameObject[] followers; // 길의 위치를 매니저만 가지고 있고, 이것을 만들때마다 적에게 부여하는 방식이 좋다

    void Awake() // processing 의 setting과 같음. 값을 초기화 할 때 사용
    {
        Instance = this;
        enemies = new ArrayList();
    }

    void Start()
    {
        StartCoroutine(CreateCharacter());
    }

    public void removeEnemy(GameObject gameObject)
    {
        enemies.Remove(gameObject);
    }

    public GameObject nearestCharacter(Vector3 position, float range)
    {
        var min = 100000f;
        GameObject nearObject = null;
        foreach (GameObject gameObject in enemies)
        {
            var dist = Vector3.Distance(position, gameObject.transform.position);
            if (min > dist)
            {
                min = dist;
                nearObject = gameObject;
            }
        }
        if (min < range)
            return nearObject;
        else
            return null;
    }

    IEnumerator CreateCharacter()
    {
        for (;;)
        {
            yield return new WaitForSeconds(2.0f);
            var enemy = GameObject.Instantiate(Character);
            enemy.transform.position = followers[0].transform.position; // 0번 위치에서 시작하기 위함
            var script = enemy.AddComponent<CharacterMovement>();  // 스크립트도 직접 붙이지 말고 만들어서 넣자
            enemies.Add(enemy); // 리스트에 추가
            script.Init(followers); // 스크립트의 함수를 부르겠다.
        }
    }

    void Update()
    {

    }
}
