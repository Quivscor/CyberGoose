using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseBuildingBlocks : MonoBehaviour
{
    private DistanceJoint2D joint;
    public List<GameObject> buildingBlocks;
    public List<Transform> startPositions;

    public Camera camera;

    public int releasedBlocks = 0;
    public float raiseDistance;

    private void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            joint.connectedBody = null;
            releasedBlocks++;
            RaiseCameraAndThis();
            SpawnNewBlock();
        }

        if (releasedBlocks == 5)
            GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().OnWin();
    }

    private void SpawnNewBlock()
    {
        GameObject gameObject = Instantiate<GameObject>(buildingBlocks[Random.Range(0, buildingBlocks.Count)],
            startPositions[Random.Range(0, startPositions.Count)].position, Quaternion.identity);
        joint.connectedBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void RaiseCameraAndThis()
    {
        StartCoroutine(RaiseCamera());
    }

    private IEnumerator RaiseCamera()
    {
        float y = this.transform.position.y + raiseDistance;
        float moveSpeed = 2;
        while(this.transform.position.y < y)
        {
            camera.transform.Translate(new Vector3(0, moveSpeed * 2 * Time.fixedDeltaTime, 0));
            this.transform.Translate(new Vector3(0, moveSpeed * 4 * Time.fixedDeltaTime, 0));
            yield return new WaitForFixedUpdate();
        }
    }
}
