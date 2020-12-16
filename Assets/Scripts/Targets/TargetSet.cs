using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    public class TargetSet : MonoBehaviour
    {
        public Target[] targets;
        private bool _resetCheck;

        private void Start()
        {
            targets = GetComponentsInChildren<Target>();
        }

        bool CheckAllTargets()
        {
            foreach(Target target in targets)
            {
                if (target.isOut)
                {
                    return false;
                }
            }

            return true;
        }

        void ResetAllTargets()
        {
            foreach (Target target in targets)
            {
                target.Activate(true);
            }
        }

        IEnumerator ResetTargets()
        {
            if (_resetCheck)
            {
                yield break;
            }

            _resetCheck = true;

            yield return new WaitForSeconds(0.2f);

            if (CheckAllTargets())
            {
                ResetAllTargets();
            }

            _resetCheck = false;
        }

        public void CheckForReset()
        {
            StartCoroutine(ResetTargets());
        }
    }
}
