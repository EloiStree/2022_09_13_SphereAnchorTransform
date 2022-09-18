//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AnchorLoaderControllerMono : MonoBehaviour
//{

//    public AnchorKeyIdToPrefabGroup m_groupOfAnchorType = new AnchorKeyIdToPrefabGroup();

//    public Transform m_whereToCreate;

//    public void CreateAnchor(in string anchorType, out bool created, out GameObject createdInstance, in bool setActiveWhenCreate=true) {

//        created = false;
//        createdInstance = null;
//        for (int i = 0; i < m_groupOfAnchorType.m_anchor.Count; i++)
//        {
//            if (Eloi.E_StringUtility.AreEquals(in anchorType, in m_groupOfAnchorType.m_anchor[i].m_typeName, true, true)) {

//                createdInstance =  GameObject.Instantiate(m_groupOfAnchorType.m_anchor[i].m_linkedPrefab, m_whereToCreate);
//                created = true;
//                createdInstance.transform.localPosition = Vector3.zero;
//                createdInstance.SetActive(setActiveWhenCreate);
//                return;
//            }
//        }
//    }
//    [ContextMenu("Flush all anchors")]
//    public void CreateRandomAnchor()
//    {

//        Eloi.E_UnityRandomUtility.GetRandomOf(out AnchorKeyIdToPrefab id2Prefab, m_groupOfAnchorType.m_anchor);
//        CreateAnchor(in id2Prefab.m_typeName, out bool created, out GameObject intance, true);
//        Set360LocalTransformPositionMono position =intance.GetComponent<Set360LocalTransformPositionMono>();
//        Eloi.E_UnityRandomUtility.GetRandomEuler(out Vector3 eulerRotation);
//        Eloi.E_UnityRandomUtility.GetRandomOf(out float distance);
//        position.m_positionDepth = distance;
//        position.m_localAnglePosition = new Item360Angle(eulerRotation);
//        position.RefreshPosition();
//    }
//    [ContextMenu("Flush all anchors")]
//    public void FlushAllAnchors() {

//        for (int i = 0; i < m_whereToCreate.childCount; i++)
//        {
//            Destroy(m_whereToCreate.GetChild(i).gameObject);
//        }
//    }

//}



//[System.Serializable]
//public class AnchorKeyIdToPrefabGroup
//{
//    public List<AnchorKeyIdToPrefab> m_anchor= new List<AnchorKeyIdToPrefab>();
//}
//[System.Serializable]
//public class AnchorKeyIdToPrefab
//{
//    public string m_typeName;
//    public GameObject m_linkedPrefab;
//}