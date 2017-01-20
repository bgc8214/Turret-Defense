using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    Rigidbody rigidbody;
    GameObject[] followers;
    float velocity = 3.0f;
    int followerIndex = 1;

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        //settings 값 초기화
    }

	void Start () {
        
	}

    public void Init(GameObject[] followers) 
    {
        this.followers = followers;
    }

    void Update () {
        // this.rigidbody.AddForce(this.transform.forward * 200
        //     , ForceMode.VelocityChange);
        var targetPosition = followers[followerIndex].transform.position; // 이동할 곳의 포지션

        this.transform.forward = (targetPosition - this.transform.position).normalized; // 이동할 곳을 보는 벡터로 forward 지정

        if(Vector3.Distance(this.transform.position, targetPosition) < 0.1f) // 0.1f 이내로 오면 다음 녀석으로 이동
        {
            followerIndex++;
            if(followerIndex == followers.Length) // 마지막에 오면 지우겠다
            {
                CharacterManager.Instance.removeEnemy(this.gameObject); //리스트에서 빼기 위함
                followerIndex = 1;
                velocity = 0f; // 속도가 중첩되는 이유는 ???
                gameObject.SetActive(false);
            }   
        }

        this.transform.position = this.transform.position + transform.forward * velocity * Time.deltaTime;
    }
}
