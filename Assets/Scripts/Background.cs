using UnityEngine;

public class Background : MonoBehaviour {
    bool flag = true;

	void Start () {
        transform.position = new Vector3(0, 15.8f, 0);
	}
	
	void Update () {
        transform.position = new Vector3(0, transform.position.y - .075f, 0);

        if (transform.position.y <= -5.6f && flag)
        {
            GameManager.Instance.NextBackground();
            flag = false;
        }
            

        if (transform.position.y < -15.8f)
            Destroy(gameObject);
	}
}
