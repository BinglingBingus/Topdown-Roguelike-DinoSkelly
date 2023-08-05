using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]public  Rigidbody    PlayerRigid;
    [SerializeField]public  Camera       PlayerCamera;
    [SerializeField]public  GameObject   Bullet;
    [SerializeField]public  GameObject   BulletSpawnPoint;
    [SerializeField]public  GameObject   PlayerGO;
    [SerializeField]public  LayerMask    groundmask;
    [SerializeField]public  Transform    PlayerTransform;

                    public  float        AttackSpeed;
                    public  float        AttackCooldown;
                    public  Vector3      DinoYPos;
                    Transform           SpawnedBulletPos;
                    Vector3             FacingDirectionRotation;
                    public  bool         isfiring = false;
                    //public Vector3      BulletSpawn;
                    

    // Start is called before the first frame updat
    // Update is called once per frame

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
        PlayerControllerMovement();
        PlayerControllerAttack();
        PlayerControllerAerialMovement();
        
        AttackCooldown -= Time.deltaTime;
        
    }


    void PlayerControllerMovement()
    {
        if(Physics.Raycast(PlayerCamera.ScreenPointToRay(Input.mousePosition),out RaycastHit FacingDirection, float.MaxValue, groundmask))
        {
            FacingDirectionRotation = FacingDirection.point;
            FacingDirectionRotation.y += 0.5f;
            //FacingDirectionRotation.x = 0
            //FacingDirectionRotation.z = ;

            PlayerTransform.LookAt(FacingDirectionRotation);
        }
    }
    
    void PlayerControllerAerialMovement()
    {
                if(Input.GetAxis("Mouse ScrollWheel") > 0f && transform.position.y !> -10.1 )
        {
            //Make dino go down
            print("down");
            transform.position -= DinoYPos;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f && transform.position.y !< -8.214 )
        {
            //Make dino go up
            print("up");
            transform.position += DinoYPos;
        }
    }

        void PlayerControllerAttack()
        {
            if(Input.GetMouseButton(0) && AttackCooldown <=0)
            {
            Instantiate(Bullet,BulletSpawnPoint.transform.position,Quaternion.identity);
            AttackCooldown = 1f/AttackSpeed;
            
            Debug.Log("Firing");
            }

        }
        

   //     IEnumerator PlayerControllerAttack()
    //{
      //  if(Input.GetMouseButtonDown(0))
       // {
            

         //   Instantiate(Bullet,BulletSpawnPoint.transform.position,Quaternion.identity);
          //  yield return new WaitForSeconds (AttackSpeed);
            //Loop
       // }

    //}
    
}
        

        
    

