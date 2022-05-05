using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject DestroyEffect;
    [SerializeField] GameObject ChangeDirectionEffect2;

    [SerializeField] GameObject FireWallBounceEffect;
    [SerializeField] GameObject FireEffect;
    
    private Camera mainCamera;

    [SerializeField] private float rotationSpeed = 15f;
    private Vector3 Direction;
    private GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        Direction = new Vector3(0.3f,0f,0f);
        mainCamera = Camera.main;

        fire = Instantiate(FireEffect,transform.position,Quaternion.identity);
    }
    
    void Update()
    {
        transform.position += Direction;
        transform.Rotate( 750f * Time.deltaTime, 0f,0f);
        KeepPlayerOnScreen();
        fire.transform.position = transform.position ;
    }

    private void KeepPlayerOnScreen(){
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);
        Vector3 EffectLocation = transform.position;
        EffectLocation.x -= 0.35f;
        EffectLocation.y -= 1.5f;

        if(viewPortPosition.x>0.94){
            EffectLocation.x += 0.7f;
            MoveLeft();
            AudioManager.instance.Play("bounce");
        }
        if(viewPortPosition.x<0.06){
            MoveRight();
            AudioManager.instance.Play("bounce");
        }

    }
    public void ChangeDirection(){
        Direction.x *= -1;
        rotate();
    }

    public void MoveLeft(){
        Vector3 EffectLocation = transform.position;
        EffectLocation.x += 0.35f;
        EffectLocation.y -= 0.35f;
        if(Direction.x != -0.03f){
            EffectLocation.x -= 0.35f;
            EffectLocation.y -= 0.35f;
            Destroy(Instantiate(ChangeDirectionEffect2,EffectLocation,Quaternion.identity),0.5f);
        }
        Direction.x = -0.03f;
        rotate();
    }

    public void MoveRight(){
        Vector3 EffectLocation = transform.position;
        if(Direction.x != 0.03f){
            EffectLocation.x -= 0.35f;
            EffectLocation.y -= 0.35f;
            Destroy(Instantiate(ChangeDirectionEffect2,EffectLocation,Quaternion.identity),0.5f);
        }
        Direction.x = 0.03f;
        rotate();
    }

    private void rotate(){
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -1 * 45f * 33.33f * Direction.x); 
    }


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle")){
            Destroy(Instantiate(DestroyEffect,transform.position,Quaternion.identity),1f);
            gameObject.SetActive(false);
            fire.SetActive(false);
            AudioManager.instance.Play("Lose");

            Invoke(nameof(Lose),2.0f);
        }
    }
    private void Lose(){
        SceneManager.LoadScene(0);
    }
}
