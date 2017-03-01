using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put all this shit in InteractableGlue
 public class Glue : VRTK.VRTK_InteractableObject
    {
        private GameObject glueParticles;
		
        
        private float glueLife = 5f;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            startGluing();
        }

		//puts the glue animation on the wood
        protected void Start()
        {
            glueParticles = transform.Find("glueParticles").gameObject;
            glueParticles.SetActive(false);
        }

        private void startGluing()
        {
			
            GameObject glueClone = Instantiate(glueParticles, glueParticles.transform.position, glueParticles.transform.rotation) as GameObject;
            glueClone.SetActive(true);
            Rigidbody rb = glueClone.GetComponent<Rigidbody>();
            Destroy(glueClone, glueLife);
        }
}

