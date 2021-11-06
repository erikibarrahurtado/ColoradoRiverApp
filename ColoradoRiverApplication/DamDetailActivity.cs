
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
using ColoradoRiverMobile.Core.Services;

namespace ColoradoRiverApplication
{
    [Activity(Label = "DamDetailActivity")]
    public class DamDetailActivity : Activity
    {
        private DamRepository _damRepository;
        private Dam _selectedDam;
        private ImageView _damImageView;
        private TextView _damNameTextView;
        private TextView _damDescriptionTextView;
        private ImageButton _goBackButton;
        private Button _questionButton;
        private RaspberryPiService _rpiService; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dam_detail);

            _damRepository = new DamRepository();
            var selectedDamId = Intent.Extras.GetInt("selectedDamId");
            _selectedDam = _damRepository.GetDamById(selectedDamId);

            FindViews();
            BindData();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _goBackButton.Click += _goBackButton_Click;
            _questionButton.Click += _questionButton_Click;
        }

        private void _questionButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(DamPromptActivity));
            intent.PutExtra("selectedDamId", _selectedDam.DamId);
            StartActivity(intent);
        }

        private void _goBackButton_Click(object sender, EventArgs e)
        {
            // UNCOMMENT
            //_rpiService.Connect();
            //_rpiService.TurnOffFan(_selectedDam.GPIO);

            this.Finish();
        }

        private void FindViews()
        {
            _damImageView = FindViewById<ImageView>(Resource.Id.damImageView);
            _damNameTextView = FindViewById<TextView>(Resource.Id.damNameTextView);
            _damDescriptionTextView = FindViewById<TextView>(Resource.Id.damDescriptionTextView);
            _goBackButton = FindViewById<ImageButton>(Resource.Id.goBackButton);
            _questionButton = FindViewById<Button>(Resource.Id.questionButton);
            
        }
        private void BindData()
        {
            _questionButton.Text = _selectedDam.Question;
            _damNameTextView.Text = _selectedDam.Name;
            _damDescriptionTextView.Text = _selectedDam.Description;
            int resImage = (int)typeof(Resource.Drawable).GetField(_selectedDam.ImageName).GetValue(null);
            _damImageView.SetImageResource(resImage);
            _rpiService = new RaspberryPiService();
           
        }
    }
}
