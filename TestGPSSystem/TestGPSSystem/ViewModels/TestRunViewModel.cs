using System;
using System.Collections.ObjectModel;
using System.Threading;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TestGPSSystem.Models;

namespace TestGPSSystem.ViewModels
{
    public class TestRunViewModel : ReactiveObject
    {
        private readonly SynchronizationContext _uiContext = new SynchronizationContext();

        public ObservableCollection<QuestionModel> Questions { get; } = new ObservableCollection<QuestionModel>();
        [Reactive]
        public QuestionModel CurrentQuestion { get; private set; }

        [Reactive] public int Grade { get; private set; }

        public TestRunViewModel()
        {
            Update();
        }

        public void Update()
        {
            _uiContext.Send(state => { Questions.Add(new QuestionModel(new[] {"1", "2", "3", "4"}, 2));}, null);
            CurrentQuestion = Questions[0];
            CurrentQuestion.OnQuestionDone += OnQuestionDone;
        }

        private void OnQuestionDone(object sender, EventArgs e)
        {
            var answer = (bool)sender;
            if (answer)
                Grade += 1;
            Update();
        }
    }
}
