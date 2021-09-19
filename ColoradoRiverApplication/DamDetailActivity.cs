
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
        private Button _goBackButton;
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
        }

        private void _goBackButton_Click(object sender, EventArgs e)
        {
            _rpiService.Connect();
            _rpiService.TurnOffFan();
            this.Finish();
        }

        private void FindViews()
        {
            _damImageView = FindViewById<ImageView>(Resource.Id.damImageView);
            _damNameTextView = FindViewById<TextView>(Resource.Id.damNameTextView);
            _damDescriptionTextView = FindViewById<TextView>(Resource.Id.damDescriptionTextView);
            _goBackButton = FindViewById<Button>(Resource.Id.goBackButton);
            _goBackButton = FindViewById<Button>(Resource.Id.goBackButton);
        }
        private void BindData()
        {
            _damNameTextView.Text = _selectedDam.Name;
            _damDescriptionTextView.Text = _selectedDam.Description;
            int resImage = (int)typeof(Resource.Drawable).GetField(_selectedDam.ImageName).GetValue(null);
            _damImageView.SetImageResource(resImage);
            _rpiService = new RaspberryPiService();
           
        }
    }
}
