using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    float time = 0;
    float timer = 0;
    [SerializeField] float duration = 1;
    Vector3 down;
    float reset = 1;

    private void Start()
    {
        duration *= 100;
    }
  
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            time += Time.deltaTime;
            if (time >= 1 && time < 5)
            {
                timer = time - reset;
                reset = 0;
                down = new Vector3(this.transform.position.x, -1.5f, this.transform.position.z);
                transform.position = Vector3.Lerp(transform.position, down, timer / duration);

            }
            if (time >= 5f)
            {
                time = 0;
                SaveFrog(collision.collider);
            }
        }
    }

    void SaveFrog(Collider collider)
    {
        if (Frog.currentShield >= 1)
        {
            down = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
            transform.position = down;
            SalvavidasController.spawnPos.transform.position = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z); ;
            GetComponent<Respawn>().ShieldProtection(collider);
        }
        else
        {
            GetComponent<Respawn>().GameOver();
        }
    }
}
