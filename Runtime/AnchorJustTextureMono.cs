using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnchorJustTextureMono : MonoBehaviour
{
    public SingleAnchorLoaderControllerMono m_prefabAnchorCreator;
    public void CreateImageAnchor(Texture2D texture, in Item360Angle angle, in float distance, out GameObject createdInstance, in bool setActiveWhenCreate = true)
    {

        m_prefabAnchorCreator.CreateAnchor(angle, distance, out createdInstance, setActiveWhenCreate);
        Texture2DToRendererMono textureScript = createdInstance.GetComponent<Texture2DToRendererMono>();
        if (textureScript)
            textureScript.PushTexture2D(texture);
    }
    public void CreateImageAnchor(Texture2D texture, string[] commands, in Item360Angle angle, in float distance, out GameObject createdInstance, in bool setActiveWhenCreate = true)
    {

        m_prefabAnchorCreator.CreateAnchor(angle, distance, out createdInstance, setActiveWhenCreate);
        Texture2DToRendererMono textureScript = createdInstance.GetComponent<Texture2DToRendererMono>();
        if (textureScript)
            textureScript.PushTexture2D(texture);
    }
}


public  class SingleAnchorLoaderControllerMono : MonoBehaviour
{

    public GameObject m_prefabToCreate;
    public Transform m_whereToCreate;

    public static void SetCommandToAnchor(in GameObject target, params string[] commands) { 
      

    }

    public void CreateAnchor(in Item360Angle angle, in float distance, out GameObject createdInstance, in bool setActiveWhenCreate = true)
    {
        CreateAnchor(out createdInstance, in setActiveWhenCreate);
        Set360LocalTransformPositionMono position = createdInstance.GetComponent<Set360LocalTransformPositionMono>();
        position.m_positionDepth = distance;
        position.m_localAnglePosition.SetWithRotation(angle);
        position.RefreshPosition();
    }

    public void CreateAnchor( out GameObject createdInstance, in bool setActiveWhenCreate = true)
    {
                createdInstance = GameObject.Instantiate(m_prefabToCreate, m_whereToCreate);
                createdInstance.transform.localPosition = Vector3.zero;
                createdInstance.SetActive(setActiveWhenCreate);
                return;
    }

    [ContextMenu("Flush all anchors")]
    public void CreateRandomAnchor()
    {
        Eloi.E_UnityRandomUtility.GetRandomEuler(out Vector3 eulerRotation);
        Eloi.E_UnityRandomUtility.GetRandomOf(out float distance);
        CreateAnchor(new Item360Angle(eulerRotation), in distance,  out GameObject created, true);
    }
    [ContextMenu("Flush all anchors")]
    public void FlushAllAnchors()
    {

        for (int i = 0; i < m_whereToCreate.childCount; i++)
        {
            Destroy(m_whereToCreate.GetChild(i).gameObject);
        }
    }

}


