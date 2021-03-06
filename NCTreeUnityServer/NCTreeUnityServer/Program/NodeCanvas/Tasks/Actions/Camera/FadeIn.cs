using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !SERVER_UNITY

namespace NodeCanvas.Tasks.Actions{

	[Category("Camera")]
	public class FadeIn : ActionTask{

		public float fadeTime = 1f;

		protected override void OnExecute(){
			CameraFader.current.FadeIn(fadeTime);
		}

		protected override void OnUpdate(){
			if (elapsedTime >= fadeTime)
				EndAction();
		}
	}
}
#endif