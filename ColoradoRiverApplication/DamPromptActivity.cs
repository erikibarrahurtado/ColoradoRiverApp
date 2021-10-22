
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
        private TextView _damNameTextView;
        private TextView _damAnswerDescriptionTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dam_prompt);

            _damRepository = new DamRepository();
            var selectedDamId = Intent.Extras.GetInt("selectedDamId");
            _selectedDam = _damRepository.GetDamById(selectedDamId);

            FindViews();
            BindData();
        }

        private void BindData()
        {
            _damNameTextView.Text = _selectedDam.Name;
            _damAnswerDescriptionTextView.Text = _selectedDam.AnswerDescription;
            int resImage = (int)typeof(Resource.Drawable).GetField(_selectedDam.AnswerImageName).GetValue(null);
            _damAnswerImageView.SetImageResource(resImage);
        }

        private void FindViews()
        {
            _damAnswerImageView = FindViewById<ImageView>(Resource.Id.damAnswerImageView);
            _damNameTextView = FindViewById<TextView>(Resource.Id.damAnswerNameTextView);
            _damAnswerDescriptionTextView = FindViewById<TextView>(Resource.Id.damAnswerDescriptionTextView);

        }
    }
}
