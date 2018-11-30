using System;
using System.Threading;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TestGPSSystem.Models
{
    public class QuestionModel : ReactiveObject
    {
        private readonly Timer _timer;

        public string[] Variants { get; }
        public int CorrectIndex { get; }
        public string ImageSource { get; } = "";

        [Reactive]
        public TimeSpan RemaningTime { get; private set; }

        public event EventHandler OnQuestionDone;

        public QuestionModel(string[] vars, int correctIndex)
        {
            Variants = vars;
            CorrectIndex = correctIndex;
            _timer = new Timer(state => OnTimerTick(), null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            RemaningTime = TimeSpan.FromSeconds(30);
        }

        private void OnTimerTick()
        {
            RemaningTime -= TimeSpan.FromSeconds(1);
            if (RemaningTime == TimeSpan.Zero) OnTimeIsUp();
        }

        private void OnTimeIsUp()
        {
            OnQuestionDone?.Invoke(false, null);
        }
    }
}
