using Unity.VisualScripting;
using UnityEngine;

public class S_Vision : S_Base
{
    #region Public Properties

    public Material VisionConeMaterial;
    public float VisionRange;
    public float VisionAngle;
    public LayerMask VisionObstructingLayer;//layer with objects that obstruct the enemy view, like walls, for example
    public int VisionConeResolution = 120;//the vision cone will be made up of triangles, the higher this value is the pretier the vision cone will be

    #endregion

    #region Private Variables

    private Mesh _visionConeMesh;
    private MeshFilter _meshFilter;
    private float _timePassedSinceLastSawPlayer;
    private float _unseePlayerTime = 0.2f;

    #endregion

    public override void Start()
    {
        base.Start();

        transform.AddComponent<MeshRenderer>().material = VisionConeMaterial;
        _meshFilter = transform.AddComponent<MeshFilter>();
        _visionConeMesh = new Mesh();
        VisionAngle *= Mathf.Deg2Rad;
    }

    void DrawVisionCone()//this method creates the vision cone mesh
    {
        int[] triangles = new int[(VisionConeResolution - 1) * 3];
        Vector3[] Vertices = new Vector3[VisionConeResolution + 1];
        Vertices[0] = Vector3.zero;
        float Currentangle = -VisionAngle / 2;
        float angleIcrement = VisionAngle / (VisionConeResolution - 1);
        float Sine;
        float Cosine;

        for (int i = 0; i < VisionConeResolution; i++)
        {
            Sine = Mathf.Sin(Currentangle);
            Cosine = Mathf.Cos(Currentangle);
            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);
            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);
            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, VisionRange, VisionObstructingLayer))
            {
                Vertices[i + 1] = VertForward * hit.distance;

                CheckHitPlayer(hit);
            }
            else
            {
                Vertices[i + 1] = VertForward * VisionRange;
            }


            Currentangle += angleIcrement;
        }
        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }
        _visionConeMesh.Clear();
        _visionConeMesh.vertices = Vertices;
        _visionConeMesh.triangles = triangles;
        _meshFilter.mesh = _visionConeMesh;
    }

    private void CheckHitPlayer(RaycastHit hit)
    {
        if(!hit.rigidbody) { return; }

        if(hit.rigidbody.tag != "Player") { return; }

        Debug.Log("PLAYERRRRRRRRRRRRRRRRRRRR!");

        _timePassedSinceLastSawPlayer = 0f;

        _aiCues.SetPlayer(hit.rigidbody.GetComponent<PlayerController>());
        Debug.Log("Hit Player!");
    }

    public override void UpdateSense()
    {
        _timePassedSinceLastSawPlayer += Time.deltaTime;

        if (_timePassedSinceLastSawPlayer > _unseePlayerTime) { _aiCues.SetPlayer(null); }

        DrawVisionCone();
    }
}
