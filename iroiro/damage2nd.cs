using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damage2nd : MonoBehaviour
{ 
 public int currentHp;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Sword") == true)
            {
                Debug.Log("Sword entered!");
                other.GetComponent<EnemyS>().Damage();
            }
        }

}
