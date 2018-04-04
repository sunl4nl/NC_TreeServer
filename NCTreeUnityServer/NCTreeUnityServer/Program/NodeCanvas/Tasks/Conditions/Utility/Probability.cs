using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Conditions{

	[Category("✫ Utility")]
	[Description("Return true or false based on the probability settings. Outcome is calculated EACH time this is checked")]
	public class Probability : ConditionTask{

	    public BBParameter<float> probability = 0.5f;
	    public BBParameter<float> maxValue = 1;

	    protected override string info{
	        get {return (probability.value/maxValue.value * 100) + "%";}
	    }

	    protected override bool OnCheck(){
#if SERVER_UNITY
            System.Random r = new System.Random();
            return r.Next(0, (int)maxValue.value) <= probability.value;
#else
            return Random.Range(0f, maxValue.value) <= probability.value;
#endif

        }
    }
}