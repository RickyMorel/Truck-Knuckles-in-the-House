using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightFliker : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private Material _materialOn;
    [SerializeField] private Material _materialOff;
    [SerializeField] private int _timerange = 2;

    private MeshRenderer _meshRenderer;
    [SerializeField]private MeshRenderer _meshRendererlod1;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(LightNoandOff());
    }

    IEnumerator LightNoandOff()
    {
        float num = Random.Range(0.1f, _timerange);

        yield return new WaitForSeconds(num);

        _meshRenderer.material = _materialOn;
        _meshRendererlod1.material = _materialOn;

        _light.enabled = true;

        yield return new WaitForSeconds(0.1f);

        _meshRenderer.material = _materialOff;
        _meshRendererlod1.material = _materialOff;

        _light.enabled = false;

        StartCoroutine(LightNoandOff());

        yield return null;
    }
}
