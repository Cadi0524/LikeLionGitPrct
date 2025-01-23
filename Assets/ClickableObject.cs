using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject particlePrefabRed;
    public GameObject particlePrefabGreen;
    public int particleCount = 30;
    public float particleRadius = 5f;

    public void OnClick(Vector3 clickPosition)
    {
        #region // 예전 코드

        // for (int i = 0; i < particleCount; i++)
        // {
        //     // 랜덤 방향 벡터 생성
        //     Vector3 randomDirection = Random.onUnitSphere;
        //
        //     // 클릭 위치에서 법선 방향으로 밀어냄
        //     Vector3 offset = randomDirection * particleRadius;
        //
        //     // 최종 점 위치
        //     Vector3 finalPosition = clickPosition + offset;
        //
        //     // 표면에만 생성되도록 Raycast 체크
        //     if (Physics.Raycast(finalPosition, -normal, out RaycastHit hit, particleRadius))
        //     {
        //         // 프리팹 생성
        //         GameObject particle = Instantiate(particlePrefab, hit.point, Quaternion.LookRotation(hit.normal));
        //         Destroy(particle, 2f);
        //     }
        // }

        #endregion
        Camera cam = Camera.main;

        for (int i = 0; i < particleCount; i++)
        {
            Vector2 randomCircle = Random.insideUnitCircle * particleRadius;
            Vector3 screenPosition = new Vector3(Input.mousePosition.x + randomCircle.x, Input.mousePosition.y + randomCircle.y,0);
            Ray ray = cam.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Dangerous"))
                {
                    GameObject particle = GameObject.Instantiate(particlePrefabRed, hit.point, Quaternion.identity);
                    Destroy(particle, 2.0f);

                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Safe"))
                {
                    GameObject particle = GameObject.Instantiate(particlePrefabGreen, hit.point, Quaternion.identity);
                    Destroy(particle, 2.0f);
                }
                else
                {
                    GameObject particle = GameObject.Instantiate(particlePrefab, hit.point, Quaternion.identity);
                    Destroy(particle, 2.0f);

                }
                //닿는 오브젝트의 색을 바꾸고 싶음
                // if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Dangerous"))
                // {
                //     particle.GetComponent<Renderer>().material.color = Color.red;
                // }
            }
        }
    }
}