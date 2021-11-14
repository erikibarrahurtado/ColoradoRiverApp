using System;
using System.Collections.Generic;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using ColoradoRiverApplication.ViewHolders;
using ColoradoRiverMobile.Core.Models;
using ColoradoRiverMobile.Core.Repository;

namespace ColoradoRiverApplication.Adapters
{
    public class DamAdapter : RecyclerView.Adapter
    {
        private List<Dam> _dams;
        public event EventHandler<int> ItemClick;
        // comment test
        public DamAdapter()
        {
            var damRepository = new DamRepository();
            _dams = damRepository.GetAllDams();
        }

        public override int ItemCount => _dams.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is DamViewHolder damViewHolder)
            {
                damViewHolder.damNameButton.Text = _dams[position].Name;

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Dam_ViewHolder, parent, false);
            DamViewHolder damViewHolder = new DamViewHolder(itemView, OnClick);

            return damViewHolder;
        }

        private void OnClick(int obj)
        {
            var damId = _dams[obj].DamId;
            ItemClick?.Invoke(this, damId);
            //comment DElete, test
        }

        //void OnClick(int position)
        //{
        //    var damId = _dams[position].DamId;
        //    ItemClick?.Invoke(this, damId);
        //}
    }
}
