using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float LerpTime;
    public float xOffset;
    bool m_canLerp;
    float m_lerpXDist;

    private void Update(){
        if (m_canLerp)
            MoveLerp();
    }

    void MoveLerp(){
        float xPos = transform.position.x;
        xPos = Mathf.Lerp(xPos, m_lerpXDist, LerpTime * Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        // Dừng lerp khi gần đến vị trí mục tiêu
        if (Mathf.Abs(transform.position.x - m_lerpXDist) <= xOffset){
            m_canLerp = false;
        }
    }

    // Phương thức để kích hoạt lerp với khoảng cách mục tiêu
    public void LerpTrigger(float targetXPos){
        m_lerpXDist = targetXPos;
        m_canLerp = true;
    }
}
