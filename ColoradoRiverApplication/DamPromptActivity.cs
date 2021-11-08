
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ColoradoRiverMobile.Core.Models;
using ColoradoRiverMobile.Core.Repository;
using Xamarin.Essentials;

namespace ColoradoRiverApplication
{
    [Activity(Label = "DamPromptActivity")]
    public class DamPromptActivity : Activity
    {
        private Dam _selectedDam;
        private DamRepository _damRepository;
        private ImageView _damAnswerImageView;
        private TextView _damAnswerDescriptionTextView;
        private TextView _damAnswerTitleTextView;
        private Button _gobackButton;
        CancellationTokenSource cts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dam_prompt);

            _damRepository = new DamRepository();
            var selectedDamId = Intent.Extras.GetInt("selectedDamId");
            _selectedDam = _damRepository.GetDamById(selectedDamId);

            FindViews();
            BindData();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _gobackButton.Click += _goBackButton_Click;
        }

        private void _goBackButton_Click(object sender, EventArgs e)
        {
            CancelSpeech();
            this.Finish();
        }

        private void BindData()
        {
            // if selected Dam is Parker(id = 4), then 
            if (_selectedDam.DamId == 4)
            {
                _damAnswerDescriptionTextView.TextSize = 35;
            }
            else if (_selectedDam.DamId == 10) {
                _damAnswerDescriptionTextView.TextSize = 38;
            }
            _damAnswerTitleTextView.Text = _selectedDam.Answer;
            _damAnswerDescriptionTextView.Text = _selectedDam.AnswerDescription;
            int resImage = (int)typeof(Resource.Drawable).GetField(_selectedDam.AnswerImageName).GetValue(null);
            _damAnswerImageView.SetImageResource(resImage);
        }

        private void FindViews()
        {
            _damAnswerTitleTextView = FindViewById<TextView>(Resource.Id.damAnswerTitleTextViewId);
            _damAnswerDescriptionTextView = FindViewById<TextView>(Resource.Id.damAnswerDescriptionTextView);
            _damAnswerImageView = FindViewById<ImageView>(Resource.Id.damAnswerImageView);
            _gobackButton = FindViewById<Button>(Resource.Id.goBackButton);
        }

        public void CancelSpeech()
        {
            if (cts?.IsCancellationRequested ?? true)
                return;

            cts.Cancel();
        }
        protected override void OnResume()
        {
            base.OnResume();
            cts = new CancellationTokenSource();
            StringBuilder sb = new StringBuilder("");
            sb.Append(_damAnswerTitleTextView.Text + ".");
            sb.Append("Did you know?\n\n");
            StringBuilder sbDescription = new StringBuilder(_selectedDam.AnswerDescription);
            sbDescription.Replace("\n\n", ".\n\n");
            sb.Append(sbDescription.ToString());

            TextToSpeech.SpeakAsync(sb.ToString(), cancelToken: cts.Token).ContinueWith((t) =>
            {
                // Logic that will run after utterance finishes.

            }, TaskScheduler.FromCurrentSynchronizationContext());


        }
    }
}
