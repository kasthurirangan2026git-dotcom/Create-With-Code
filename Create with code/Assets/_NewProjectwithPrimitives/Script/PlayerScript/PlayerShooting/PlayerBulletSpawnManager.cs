using UnityEngine;

public class PlayerBulletSpawnManager : MonoBehaviour
{
    [SerializeField]
   private GameObject _BulletPrefvab;
   public void BulletSpawn()
    {
       GameObject bulletGameObject = Instantiate(_BulletPrefvab,this.transform.position,this.transform.rotation);
       bulletGameObject.tag = "PlayerBullet";
    }
}
