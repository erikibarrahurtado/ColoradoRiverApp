using System;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace ColoradoRiverApplication.ViewHolders
{
    public class DamViewHolder : RecyclerView.ViewHolder
    {
      
        public Button damNameButton { get; set; }

        public DamViewHolder(View itemView, Action<int> listener) : base(itemView) {
            damNameButton = itemView.FindViewById<Button>(Resource.Id.damNameButton);

            damNameButton.Click += (sender, e) => listener(base.LayoutPosition);
            //test
            //itemView.Click += (sender, e) => listener(base.LayoutPosition);

        }

    }
}
