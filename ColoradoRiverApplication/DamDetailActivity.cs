﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using ColoradoRiverMobile.Core.Models;
using ColoradoRiverMobile.Core.Repository;
using ColoradoRiverMobile.Core.Services;
using Xamarin.Essentials;

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
        CancellationTokenSource cts;

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
            CancelSpeech();
            var intent = new Intent();
            intent.SetClass(this, typeof(DamAnswerActivity));
            intent.PutExtra("selectedDamId", _selectedDam.DamId);
            StartActivity(intent);
        }

        private void _goBackButton_Click(object sender, EventArgs e)
        {

            // turn off select DamGPIO async 
            var t = Task.Run(() => _rpiService.ConnectAndTurnOffDamGPIO(_selectedDam.GPIO)); // exception handled.

            CancelSpeech();
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

            var arr = _selectedDam.Description.Split("\n") ;

            int bulletGap = 13;

            SpannableStringBuilder ssb = new SpannableStringBuilder();

            for (int i = 0; i <  arr.Length; i++)
            {
                string line = arr[i];
                SpannableString ss = new SpannableString(line);
                ss.SetSpan(new BulletSpan(bulletGap), 0, line.Length, SpanTypes.ExclusiveExclusive);
                ssb.Append(ss);

                if (i+1< arr.Length)
                    ssb.Append("\n\n");
            }

            _damDescriptionTextView.TextFormatted = ssb;

            int resImage = (int)typeof(Resource.Drawable).GetField(_selectedDam.ImageName).GetValue(null);
            _damImageView.SetImageResource(resImage);
            _rpiService = new RaspberryPiService();

            // set fonts
            var font = Typeface.CreateFromAsset(this.ApplicationContext.Assets, "EBGaramondVariableFont.ttf");
            _damNameTextView.SetTypeface(font, TypefaceStyle.Bold);
            _damDescriptionTextView.SetTypeface(font, TypefaceStyle.Normal);
            _questionButton.SetTypeface(font, TypefaceStyle.Normal);


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
            sb.Append(_damNameTextView.Text + ".");

            StringBuilder sbDescription = new StringBuilder(_selectedDam.Description);
            sbDescription.Replace("\n", ".\n");
            sb.Append(sbDescription.ToString());

            TextToSpeech.SpeakAsync(sb.ToString(), cancelToken: cts.Token).ContinueWith((t) =>
            {
                // Logic that will run after utterance finishes.

            }, TaskScheduler.FromCurrentSynchronizationContext());


        }
    }
}
