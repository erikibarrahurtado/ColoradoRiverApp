
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ColoradoRiverMobile.Core.Models;
using ColoradoRiverMobile.Core.Repository;

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
    }
}
