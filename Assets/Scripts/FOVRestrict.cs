using Unity.Loading;
using UnityEngine;

public class FOVRestrict : MonoBehaviour
{
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        print("velcotity magnitude " + cc.velocity.magnitude);
        if(cc.velocity.magnitude != 0)
        {
            print("decreasing FOV");
            if(Camera.main.fieldOfView > 50f){
                print("decreasing FOV");
                Camera.main.fieldOfView -= .02f*(Camera.main.fieldOfView - 50f);
            }
        }
        else
        {
            if(Camera.main.fieldOfView < 60f){
                Camera.main.fieldOfView += .02f*(60F - Camera.main.fieldOfView);
            }
        }
        
    }
}
