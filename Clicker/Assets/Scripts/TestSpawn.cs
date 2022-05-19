using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject upgrade;
    public GameObject content;
    public Upgrade thisUpgrade;

    public void spawnUpgrade() {
        GameObject myUpgrade = (GameObject)Instantiate(upgrade, transform.position, Quaternion.identity, content.transform);
        myUpgrade.GetComponent<DisplayUpgrade>().upgrade = this.thisUpgrade;
    }
}
